#region Copyright
/*******************************************************************************
 * <copyright file="LogbookComponentDescription.cs" owner="Daniel Kopp">
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
 * <file name="LogbookComponentDescription.cs" date="2016-04-06">
 * Describes the purpose of a ILogbookComponent along with a description of the
 * parameters used to initialize the component.
 * </file>
 ******************************************************************************/
#endregion

using NerdyDuck.CodedExceptions;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NerdyDuck.Logging
{
	/// <summary>
	/// Describes the purpose of a <see cref="LogbookComponent"/> along with a description of the parameters used to initialize the component.
	/// </summary>
	[DataContract(Namespace = LogEntryBase.Namespace)]
	public class LogbookComponentDescription
	{
		#region Private fields
		private string mTypeName;
		private string mDisplayName;
		private string mDescription;
		private ICollection<LogbookComponentParameterDescription> mParameters;
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the name of the type that the <see cref="LogbookComponentDescription"/> describes.
		/// </summary>
		/// <value>The assembly-qualified name of the type that implements <see cref="LogbookComponent"/>.</value>
		[DataMember]
		public string TypeName
		{
			get { return mTypeName; }
			set { mTypeName = value; }
		}

		/// <summary>
		/// Gets or sets the display name of the <see cref="LogbookComponent"/>.
		/// </summary>
		/// <value>A localized, human-readable name for the component.</value>
		[DataMember]
		public string DisplayName
		{
			get { return mDisplayName; }
			set { mDisplayName = value; }
		}

		/// <summary>
		/// Gets or sets a description text for the <see cref="LogbookComponent"/>.
		/// </summary>
		/// <value>A localized, human-readable description of the functionality of the component.</value>
		[DataMember]
		public string Description
		{
			get { return mDescription; }
			set { mDescription = value; }
		}

		/// <summary>
		/// Gets or sets a list of descriptions of the parameters used to initialize the <see cref="LogbookComponent"/>.
		/// </summary>
		/// <value>A collection of <see cref="LogbookComponentParameterDescription"/>s. May be <see langword="null"/>.</value>
		[DataMember]
		public ICollection<LogbookComponentParameterDescription> Parameters
		{
			get { return mParameters; }
			set { mParameters = value; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="LogbookComponentDescription"/> class.
		/// </summary>
		/// <remarks><see cref="TypeName"/>, <see cref="DisplayName"/> and <see cref="Description"/> are set to <see cref="string.Empty"/>, <see cref="Parameters"/> contains an empty collection.</remarks>
		public LogbookComponentDescription()
		{
			mTypeName = string.Empty;
			mDisplayName = string.Empty;
			mDescription = string.Empty;
			mParameters = new List<LogbookComponentParameterDescription>();
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
		public LogbookComponentDescription(string typeName, string displayName, string description, IEnumerable<LogbookComponentParameterDescription> parameters)
		{
			if (string.IsNullOrWhiteSpace(typeName))
				throw new CodedArgumentNullOrWhiteSpaceException(Errors.CreateHResult(ErrorCodes.LogbookComponentDescription_ctor_TypeNullEmpty), nameof(typeName));
			if (string.IsNullOrWhiteSpace(displayName))
				throw new CodedArgumentNullOrWhiteSpaceException(Errors.CreateHResult(ErrorCodes.LogbookComponentDescription_ctor_DisplayNameNullEmpty), nameof(displayName));
			if (string.IsNullOrWhiteSpace(description))
				throw new CodedArgumentNullOrWhiteSpaceException(Errors.CreateHResult(ErrorCodes.LogbookComponentDescription_ctor_DescriptionNullEmpty), nameof(description));

			mTypeName = typeName;
			mDisplayName = displayName;
			mDescription = description;

			if (parameters == null)
			{
				mParameters = new List<LogbookComponentParameterDescription>();
			}
			else
			{
				mParameters = new List<LogbookComponentParameterDescription>(parameters);
			}
		}
		#endregion
	}
}
