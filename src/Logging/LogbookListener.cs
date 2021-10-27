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

using System.Collections.Generic;
using System.Globalization;
using NerdyDuck.CodedExceptions;
using NerdyDuck.ParameterValidation;

namespace NerdyDuck.Logging;

/// <summary>
/// The base class for logbook listeners that take log data input and send it to a storage or display medium (e.g. files, databases, or a list view in a user interface).
/// </summary>
/// <typeparam name="T">The type of the data object that contains the data to log. Must be derived from <see cref="LogEntryBase" />.</typeparam>
public abstract class LogbookListener<T> : LogbookComponent, ISynchronizable where T : LogEntryBase
{
	private LogbookFilter<T> mFilter;
	private bool mIsEnabled;

	/// <summary>
	/// Gets or sets the <see cref="LogbookFilter{T}"/> that determines if the <see cref="Write(T, object)"/> method should be called for a log entry.
	/// </summary>
	/// <value>A <see cref="LogbookFilter{T}"/>. May be <see langword="null"/>.</value>
	/// <remarks>The value of the property is not used within the <see cref="LogbookListener{T}"/>, but should be evaluated by any code calling the <see cref="Write(T, object)"/> method.</remarks>
	public LogbookFilter<T> Filter
	{
		get { return mFilter; }
		set { mFilter = value; }
	}

	/// <summary>
	/// Gets or sets a value indicating if the <see cref="LogbookListener{T}"/> should receive log data.
	/// </summary>
	/// <value><see langword="true"/>, if the <see cref="Write(T, object)"/> method of the <see cref="LogbookListener{T}"/> should be called; otherwise, <see langword="false"/>.</value>
	/// <remarks>The value of the property is not used within the <see cref="LogbookListener{T}"/>, but should be evaluated by any code calling the <see cref="Write(T, object)"/> method.</remarks>
	public bool IsEnabled
	{
		get { return mIsEnabled; }
		set { mIsEnabled = value; }
	}

	/// <summary>
	/// Gets a value indicating if the properties and methods of the <see cref="LogbookListener{T}"/> are thread-safe.
	/// </summary>
	/// <value>The default implementation returns <see langword="false"/>.</value>
	public virtual bool IsSynchronized
	{
		get { return false; }
	}

	/// <summary>
	/// Gets an object used to synchronize access to the <see cref="LogbookListener{T}"/>.
	/// </summary>
	/// <value>Always returns the current instance.</value>
	public object SyncRoot
	{
		get { return this; }
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="LogbookListener{T}"/> class.
	/// </summary>
	public LogbookListener()
		: this(null)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="LogbookListener{T}"/> class with the specified name.
	/// </summary>
	/// <param name="name">The name of the <see cref="LogbookListener{T}"/>.</param>
	public LogbookListener(string name)
		: base(name)
	{
		mFilter = null;
		mIsEnabled = true;
	}

	/// <summary>
	/// Destructor.
	/// </summary>
	~LogbookListener()
	{
		Dispose(false);
	}

	/// <summary>
	/// Causes the <see cref="LogbookListener{T}"/> to flush all buffers and send all unwritten data to the underlying data stores.
	/// </summary>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void Flush()
	{
	}

	/// <summary>
	/// Gets a description of the <see cref="LogbookListener{T}"/>, including the parameters it requires to work, in the specified language.
	/// </summary>
	/// <param name="culture">The language to return descriptive texts and names for. May be <see langword="null"/>.</param>
	/// <returns>A <see cref="LogbookComponentDescription"/>.</returns>
	/// <remarks><para>If <paramref name="culture"/> is <see langword="null"/>, the current thread culture is used to determine the culture for descriptive texts.</para>
	/// <note type="note"><para>Note to implementers:</para><para>Override this method to modify the output of the method. Change the <see cref="LogbookComponentDescription.DisplayName"/> and <see cref="LogbookComponentDescription.Description"/>, and add descriptions of all parameters used in your implementation.</para></note></remarks>
	public override LogbookComponentDescription GetDescription(CultureInfo culture)
	{
		LogbookComponentDescription ReturnValue = base.GetDescription(culture);
		ReturnValue.Parameters.Add(new LogbookComponentParameterDescription(
			nameof(IsEnabled),
			TextResources.ResourceManager.GetString(nameof(TextResources.LogbookListener_IsEnabled_DisplayName), culture),
			TextResources.ResourceManager.GetString(nameof(TextResources.LogbookListener_IsEnabled_Description), culture),
			ParameterDataType.Bool,
			false,
			null,
			true));
		return ReturnValue;
	}

	/// <summary>
	/// Gets a dictionary of the current parameter values of the <see cref="LogbookListener{T}"/>, in serialized form, keyed by the parameter name.
	/// </summary>
	/// <returns>A dictionary of parameter values, keyed by the parameter name.</returns>
	/// <remarks>The values must be serialized so they can be deserialized using <see cref="ParameterConvert"/>.</remarks>
	public override IDictionary<string, string> GetParameters()
	{
		IDictionary<string, string> ReturnValue = base.GetParameters();
		ReturnValue.Add(nameof(IsEnabled), ParameterConvert.ToString(IsEnabled));
		return ReturnValue;
	}

	/// <summary>
	/// Configures the current <see cref="LogbookListener{T}"/> with the specified parameters.
	/// </summary>
	/// <param name="parameters">A dictionary of serialized parameter values, keyed by the parameter name.</param>
	/// <remarks><note type="note"><para>Note to implementers:</para><para>The method must be designed so it can be called multiple times during the lifetime of the component.</para></note></remarks>
	public override void SetParameters(IDictionary<string, string> parameters)
	{
		base.SetParameters(parameters);
		if (parameters.TryGetValue(nameof(IsEnabled), out string Temp))
		{
			try
			{
				mIsEnabled = ParameterConvert.ToBoolean(Temp);
			}
			catch (ParameterConversionException ex)
			{
				// TODO
			}
		}
	}

	/// <summary>
	/// When implemented by a deriving class, writes the specified log data to its data store.
	/// </summary>
	/// <param name="logEntry">The data to log.</param>
	/// <param name="state">A state object.</param>
	public abstract void Write(T logEntry, object state);

	/// <summary>
	/// Releases allocated resources.
	/// </summary>
	/// <param name="disposing">A value indicating if the method was called by user code. If <see langword="false"/>, the method was called by the runtime in the finalizer.</param>
	/// <remarks>If <paramref name="disposing"/> is <see langword="false"/>, no other objects should be referenced.</remarks>
	protected override void Dispose(bool disposing)
	{
		if (IsDisposed)
			return;

		base.Dispose(disposing);

		if (disposing)
		{
			IDisposable Temp = mFilter;
			if (Temp != null)
			{
				Temp.Dispose();
			}
		}
		mFilter = null;

	}

	/// <summary>
	/// Helper method to synchronize Write(T,object).
	/// </summary>
	/// <param name="logEntry">The data to log.</param>
	/// <param name="state">A state object.</param>
	/// <exception cref="CodedException">Calling Write(T,object) failed.</exception>
	internal void SyncWrite(T logEntry, object state)
	{
		try
		{
			if (IsSynchronized)
			{
				Write(logEntry, state);
			}
			else
			{
				lock (SyncRoot)
				{
					Write(logEntry, state);
				}
			}
		}
		catch (Exception ex) when (ex.IsCodedException())
		{
			throw new CodedException(HResult.Create(ErrorCodes.LogbookListener_SyncWrite_Failed), string.Format(CultureInfo.CurrentCulture, TextResources.LogbookListener_SyncWrite_Failed, Name, GetType().Name), ex);
		}
	}
}
