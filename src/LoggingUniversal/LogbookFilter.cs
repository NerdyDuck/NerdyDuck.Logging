#region Copyright
/*******************************************************************************
 * <copyright file="LogbookFilter.cs" owner="Daniel Kopp">
 * Copyright 2015-2016 Daniel Kopp
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * </copyright>
 * <author name="Daniel Kopp" email="dak@nerdyduck.de" />
 * <assembly name="NerdyDuck.Logging">
 * Base classes for customized logging for .NET.
 * </assembly>
 * <file name="LogbookFilter.cs" date="2016-04-08">
 * The base class for filters that decide if a log entry is sent to a
 * LogbookListener(Of T).
 * </file>
 ******************************************************************************/
#endregion

using NerdyDuck.CodedExceptions;
using NerdyDuck.ParameterValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdyDuck.Logging
{
	/// <summary>
	/// The base class for filters that decide if a log entry is sent to a <see cref="LogbookListener{T}"/>.
	/// </summary>
	/// <typeparam name="T">The type of the data object that contains the data to log. Must be derived from <see cref="LogEntryBase" />.</typeparam>
	public abstract class LogbookFilter<T> : LogbookComponent, ISynchronizable where T : LogEntryBase
	{
		#region Properties
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
		#endregion

		#region Constructors
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
		#endregion

		#region Destructor
		/// <summary>
		/// Destructor.
		/// </summary>
		~LogbookFilter()
		{
			Dispose(false);
		}
		#endregion

		#region Public methods
		#region ShouldLog
		/// <summary>
		/// When overridden in a derived class, determines whether the logbook listener should log the event.
		/// </summary>
		/// <param name="logEntry">The data to log.</param>
		/// <param name="state">A state object.</param>
		/// <returns><see langword="true"/> to log the specified event; otherwise, <see langword="false"/>.</returns>
		public abstract bool ShouldLog(T logEntry, object state);
		#endregion
		#endregion

		#region Private methods
		#region SyncShouldLog
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
				throw new CodedException(Errors.CreateHResult(ErrorCodes.LogbookFilter_SyncShouldLog_Failed), string.Format(Properties.Resources.LogbookFilter_SyncShouldLog_Failed, Name, GetType().Name), ex);
			}
		}
		#endregion
		#endregion
	}
}
