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
using System.Runtime.Serialization;
using NerdyDuck.CodedExceptions;

namespace NerdyDuck.Logging;

/// <summary>
/// Describes the purpose of a <see cref="LogbookComponent"/> along with a description of the parameters used to initialize the component.
/// </summary>
[DataContract(Namespace = LogEntryBase.Namespace)]
public class LogbookComponentDescription
{
	/// <summary>
	/// Gets or sets the name of the type that the <see cref="LogbookComponentDescription"/> describes.
	/// </summary>
	/// <value>The assembly-qualified name of the type that implements <see cref="LogbookComponent"/>.</value>
	[DataMember]
	public string TypeName { get; set; }

	/// <summary>
	/// Gets or sets the display name of the <see cref="LogbookComponent"/>.
	/// </summary>
	/// <value>A localized, human-readable name for the component.</value>
	[DataMember]
	public string DisplayName { get;set; }

	/// <summary>
	/// Gets or sets a description text for the <see cref="LogbookComponent"/>.
	/// </summary>
	/// <value>A localized, human-readable description of the functionality of the component.</value>
	[DataMember]
	public string Description { get; set; }

	/// <summary>
	/// Gets or sets a list of descriptions of the parameters used to initialize the <see cref="LogbookComponent"/>.
	/// </summary>
	/// <value>A collection of <see cref="LogbookComponentParameterDescription"/>s. May be <see langword="null"/>.</value>
	[DataMember]
	public ICollection<LogbookComponentParameterDescription> Parameters { get; set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="LogbookComponentDescription"/> class.
	/// </summary>
	/// <remarks><see cref="TypeName"/>, <see cref="DisplayName"/> and <see cref="Description"/> are set to <see cref="string.Empty"/>, <see cref="Parameters"/> contains an empty collection.</remarks>
	public LogbookComponentDescription()
	{
		TypeName = string.Empty;
		DisplayName = string.Empty;
		Description = string.Empty;
		Parameters = new List<LogbookComponentParameterDescription>();
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="LogbookComponentDescription"/> class with the specified type name, display name and description.
	/// </summary>
	/// <param name="typeName">The name of the type that the <see cref="LogbookComponentDescription"/> describes.</param>
	/// <param name="displayName">The display name of the <see cref="LogbookComponent"/>.</param>
	/// <param name="description">A description text for the <see cref="LogbookComponent"/>.</param>
	/// <remarks><see cref="TypeName"/>, <see cref="DisplayName"/> and <see cref="Description"/> are set to the corresponding arguments, <see cref="Parameters"/> contains an empty collection.</remarks>
	/// <exception cref="CodedArgumentNullOrWhiteSpaceException"><paramref name="typeName"/>, <paramref name="displayName"/> or <paramref name="description"/> is <see langword="null"/> or empty or only white-space.</exception>
	public LogbookComponentDescription(string typeName, string displayName, string description)
		: this(typeName, displayName, description, null)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="LogbookComponentDescription"/> class with the specified type name, display name, description and a list of parameter descriptions.
	/// </summary>
	/// <param name="typeName">The name of the type that the <see cref="LogbookComponentDescription"/> describes.</param>
	/// <param name="displayName">The display name of the <see cref="LogbookComponent"/>.</param>
	/// <param name="description">A description text for the <see cref="LogbookComponent"/>.</param>
	/// <param name="parameters">A list of descriptions of the parameters used to initialize the <see cref="LogbookComponent"/>.</param>
	/// <exception cref="CodedArgumentNullOrWhiteSpaceException"><paramref name="typeName"/>, <paramref name="displayName"/> or <paramref name="description"/> is <see langword="null"/> or empty or only white-space.</exception>
	public LogbookComponentDescription(string typeName, string displayName, string description, IEnumerable<LogbookComponentParameterDescription>? parameters)
	{
		if (string.IsNullOrWhiteSpace(typeName))
			throw new CodedArgumentNullOrWhiteSpaceException(HResult.Create(ErrorCodes.LogbookComponentDescription_ctor_TypeNullEmpty), nameof(typeName));
		if (string.IsNullOrWhiteSpace(displayName))
			throw new CodedArgumentNullOrWhiteSpaceException(HResult.Create(ErrorCodes.LogbookComponentDescription_ctor_DisplayNameNullEmpty), nameof(displayName));
		if (string.IsNullOrWhiteSpace(description))
			throw new CodedArgumentNullOrWhiteSpaceException(HResult.Create(ErrorCodes.LogbookComponentDescription_ctor_DescriptionNullEmpty), nameof(description));

		TypeName = typeName;
		DisplayName = displayName;
		Description = description;

		if (parameters == null)
		{
			Parameters = new List<LogbookComponentParameterDescription>();
		}
		else
		{
			Parameters = new List<LogbookComponentParameterDescription>(parameters);
		}
	}
}
