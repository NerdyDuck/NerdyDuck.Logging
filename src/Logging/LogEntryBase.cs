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

namespace NerdyDuck.Logging;

/// <summary>
/// The base class for all types representing a log entry.
/// </summary>
[Serializable]
public abstract class LogEntryBase
{
	/// <summary>
	/// The serialization namespace for all classes in the NerdyDuck.Logging library.
	/// </summary>
	public const string Namespace = "http://www.nerdyduck.de/Logging/";

	/// <summary>
	/// Gets the date and time when the log entry was created.
	/// </summary>
	/// <value>A <see cref="DateTimeOffset"/> structure.</value>
	public DateTimeOffset Timestamp { get; private set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="LogEntryBase"/> class.
	/// </summary>
	/// <remarks><see cref="Timestamp"/> is set to <see cref="DateTimeOffset.Now"/>.</remarks>
	protected LogEntryBase() => Timestamp = DateTimeOffset.Now;

	/// <summary>
	/// Initializes a new instance of the <see cref="LogEntryBase"/> class with the specified date and time.
	/// </summary>
	/// <param name="timestamp">The date and time when the log entry was created.</param>
	/// <remarks><see cref="Timestamp"/> receives the value of <paramref name="timestamp"/>.</remarks>
	protected LogEntryBase(DateTimeOffset timestamp) => Timestamp = timestamp;
}
