#region Copyright
/*******************************************************************************
 * <copyright file="CaseInsensitiveStringDictionary.cs" owner="Daniel Kopp">
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
 * <file name="CaseInsensitiveStringDictionary.cs" date="2016-04-06">
 * Specifies the properties and methods of all classes representing a component
 * of a logbook.
 * </file>
 ******************************************************************************/
#endregion

using System;
using System.Collections.Generic;

namespace NerdyDuck.Logging
{
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
}
