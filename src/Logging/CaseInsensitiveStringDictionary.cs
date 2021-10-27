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

namespace NerdyDuck.Logging;

/// <summary>
/// A dictionary of string values keyed by case-insensitive strings.
/// </summary>
internal class CaseInsensitiveStringDictionary : Dictionary<string, string>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="CaseInsensitiveStringDictionary"/> class.
	/// </summary>
	public CaseInsensitiveStringDictionary()
		: base(StringComparer.OrdinalIgnoreCase)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="CaseInsensitiveStringDictionary"/> class that contains elements copied from the specified <see cref="IDictionary{TKey, TValue}"/> and uses the <see cref="StringComparer.OrdinalIgnoreCase"/> comparer for the key type.
	/// </summary>
	/// <param name="dictionary">The <see cref="IDictionary{TKey, TValue}"/> whose elements are copied to the new <see cref="CaseInsensitiveStringDictionary"/>.</param>
	public CaseInsensitiveStringDictionary(IDictionary<string, string> dictionary)
		: base(dictionary, StringComparer.OrdinalIgnoreCase)
	{
	}
}
