#region Copyright
/*******************************************************************************
 * NerdyDuck.Logging - Base classes for customized logging for .NET.
 * 
 * The MIT License (MIT)
 *
 * Copyright (c) Daniel Kopp, dak@nerdyduck.de
 *
 * All rights reserved.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 ******************************************************************************/
#endregion

using System.Globalization;
using NerdyDuck.CodedExceptions;
using NerdyDuck.ParameterValidation;

namespace NerdyDuck.Logging;

/// <summary>
/// The base class for filters that decide if a log entry is sent to a <see cref="LogbookListener{T}"/>.
/// </summary>
/// <typeparam name="T">The type of the data object that contains the data to log. Must be derived from <see cref="LogEntryBase" />.</typeparam>
public abstract class LogbookFilter<T> : LogbookComponent, ISynchronizable where T : LogEntryBase
{
	/// <summary>
	/// Gets a value indicating if the properties and methods of the <see cref="LogbookFilter{T}"/> are thread-safe.
	/// </summary>
	/// <value>The default implementation returns <see langword="true"/>.</value>
	public virtual bool IsSynchronized
	{
		get { return true; }
	}

	/// <summary>
	/// Gets an object used to synchronize access to the <see cref="LogbookFilter{T}"/>.
	/// </summary>
	/// <value>Always returns the current instance.</value>
	public object SyncRoot
	{
		get { return this; }
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="LogbookFilter{T}"/> class.
	/// </summary>
	protected LogbookFilter()
		: base()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="LogbookFilter{T}"/> class with the specified name.
	/// </summary>
	/// <param name="name">The name of the <see cref="LogbookFilter{T}"/>.</param>
	protected LogbookFilter(string name)
		: base(name)
	{
	}

	/// <summary>
	/// Destructor.
	/// </summary>
	~LogbookFilter()
	{
		Dispose(false);
	}

	/// <summary>
	/// When overridden in a derived class, determines whether the logbook listener should log the event.
	/// </summary>
	/// <param name="logEntry">The data to log.</param>
	/// <param name="state">A state object.</param>
	/// <returns><see langword="true"/> to log the specified event; otherwise, <see langword="false"/>.</returns>
	public abstract bool ShouldLog(T logEntry, object state);

	/// <summary>
	/// Helper method to synchronize ShouldLog(T,object).
	/// </summary>
	/// <param name="logEntry">The data to log.</param>
	/// <param name="state">A state object.</param>
	/// <returns><see langword="true"/> to log the specified event; otherwise, <see langword="false"/>.</returns>
	/// <exception cref="CodedException">Calling ShouldLog(T) failed.</exception>
	internal bool SyncShouldLog(T logEntry, object state)
	{
		try
		{
			if (IsSynchronized)
			{
				return ShouldLog(logEntry, state);
			}

			bool b;
			lock (SyncRoot)
			{
				b = ShouldLog(logEntry, state);
			}
			return b;
		}
		catch (Exception ex) when (ex.IsCodedException())
		{
			throw new CodedException(HResult.Create(ErrorCodes.LogbookFilter_SyncShouldLog_Failed), string.Format(CultureInfo.CurrentCulture, TextResources.LogbookFilter_SyncShouldLog_Failed, Name, GetType().Name), ex);
		}
	}
}
