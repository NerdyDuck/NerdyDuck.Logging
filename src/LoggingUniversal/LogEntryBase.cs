#region Copyright
/*******************************************************************************
 * <copyright file="LogEntryBase.cs" owner="Daniel Kopp">
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
 * <file name="LogEntryBase.cs" date="2016-04-06">
 * The base class for all types representing a log entry.
 * </file>
 ******************************************************************************/
#endregion

using System;

namespace NerdyDuck.Logging
{
	/// <summary>
	/// The base class for all types representing a log entry.
	/// </summary>
#if WINDOWS_DESKTOP
	[Serializable]
#endif
	public abstract class LogEntryBase
	{
		#region Constants
		/// <summary>
		/// The serialization namespace for all classes in the NerdyDuck.Logging library.
		/// </summary>
		public const string Namespace = "http://www.nerdyduck.de/Logging/";
		#endregion

		#region Private fields
		private DateTimeOffset mTimestamp;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the date and time when the log entry was created.
		/// </summary>
		/// <value>A <see cref="DateTimeOffset"/> structure.</value>
		public DateTimeOffset Timestamp
		{
			get { return mTimestamp; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="LogEntryBase"/> class.
		/// </summary>
		/// <remarks><see cref="Timestamp"/> is set to <see cref="DateTimeOffset.Now"/>.</remarks>
		protected LogEntryBase()
		{
			mTimestamp = DateTimeOffset.Now;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LogEntryBase"/> class with the specified date and time.
		/// </summary>
		/// <param name="timestamp">The date and time when the log entry was created.</param>
		/// <remarks><see cref="Timestamp"/> receives the value of <paramref name="timestamp"/>.</remarks>
		protected LogEntryBase(DateTimeOffset timestamp)
		{
			mTimestamp = timestamp;
		}
		#endregion
	}
}
