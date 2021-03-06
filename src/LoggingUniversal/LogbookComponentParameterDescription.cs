﻿#region Copyright
/*******************************************************************************
 * <copyright file="LogbookComponentParameterDescription.cs" owner="Daniel Kopp">
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
 * <file name="LogbookComponentParameterDescription.cs" date="2016-04-06">
 * Describes a parameter used to initialize a ILogbookComponent.
 * </file>
 ******************************************************************************/
#endregion

using NerdyDuck.CodedExceptions;
using NerdyDuck.ParameterValidation;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NerdyDuck.Logging
{
	/// <summary>
	/// Describes a parameter used to initialize a <see cref="LogbookComponent"/>.
	/// </summary>
	[DataContract(Namespace = LogEntryBase.Namespace)]
	public class LogbookComponentParameterDescription
	{
		#region Private fields
		private string mName;
		private string mDisplayName;
		private string mDescription;
		private ParameterDataType mDataType;
		private bool mIsRequired;
		private IReadOnlyList<Constraint> mConstraints;
		private string mConstraintString;
		private object mDefaultValue;
		private string mSerializedDefaultValue;
		private PropertySyncState DefaultValueState;
		private PropertySyncState ConstraintsState;
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the name of the parameter that the <see cref="LogbookComponentParameterDescription"/> describes.
		/// </summary>
		/// <value>The name of the parameter.</value>
		[DataMember]
		public string Name
		{
			get { return mName; }
			set { mName = value; }
		}

		/// <summary>
		/// Gets or sets the display name of the parameter.
		/// </summary>
		/// <value>A localized, human-readable name for the parameter.</value>
		[DataMember]
		public string DisplayName
		{
			get { return mDisplayName; }
			set { mDisplayName = value; }
		}

		/// <summary>
		/// Gets or sets a description text for the parameter.
		/// </summary>
		/// <value>A localized, human-readable description of the effect of the parameter.</value>
		[DataMember]
		public string Description
		{
			get { return mDescription; }
			set { mDescription = value; }
		}

		/// <summary>
		/// Gets or sets the data type of the parameter.
		/// </summary>
		/// <value>One of the <see cref="ParameterDataType"/> values.</value>
		[DataMember]
		public ParameterDataType DataType
		{
			get { return mDataType; }
			set { mDataType = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating if the parameter is mandatory and must be provided to initialize the <see cref="LogbookComponent"/>.
		/// </summary>
		/// <value><see langword="true"/>, if the parameter is mandatory; otherwise, <see langword="false"/>.</value>
		[DataMember]
		public bool IsRequired
		{
			get { return mIsRequired; }
			set { mIsRequired = value; }
		}

		/// <summary>
		/// Gets or sets a read-only list of <see cref="Constraint"/>s that describe the limits of the parameter value.
		/// </summary>
		/// <value>A read-only collection of <see cref="Constraint"/>s, or <see langword="null"/>.</value>
		public IReadOnlyList<Constraint> Constraints
		{
			get
			{
				if (ConstraintsState == PropertySyncState.SerializedChanged)
				{
					mConstraints = ConstraintParser.Parser.Parse(mConstraintString, mDataType);
					ConstraintsState = PropertySyncState.InSync;
				}
				return mConstraints;
			}
			set
			{
				mConstraints = value;
				ConstraintsState = PropertySyncState.ObjectChanged;
			}
		}

		/// <summary>
		/// Gets or sets the string representation of the <see cref="Constraints"/> property.
		/// </summary>
		/// <value>A string containing one or more string representations of a <see cref="Constraint"/>. May be <see langword="null"/>.</value>
		[DataMember]
		public string ConstraintString
		{
			get
			{
				if (ConstraintsState == PropertySyncState.ObjectChanged)
				{
					mConstraintString = ConstraintParser.ConcatConstraints(mConstraints);
					ConstraintsState = PropertySyncState.InSync;
				}
				return mConstraintString;
			}
			set
			{
				mConstraintString = value;
				ConstraintsState = PropertySyncState.SerializedChanged;
			}
		}

		/// <summary>
		/// Gets or sets the default value of the parameter.
		/// </summary>
		/// <value>A value matching the data type in <see cref="DataType"/>. May be <see langword="null"/>.</value>
		public object DefaultValue
		{
			get
			{
				if (DefaultValueState == PropertySyncState.SerializedChanged)
				{
					mDefaultValue = ParameterConvert.ToDataType(mSerializedDefaultValue, mDataType, Constraints);
					DefaultValueState = PropertySyncState.InSync;
				}
				return mDefaultValue;
			}
			set
			{
				mDefaultValue = value;
				DefaultValueState = PropertySyncState.ObjectChanged;
			}
		}

		/// <summary>
		/// Gets or sets the serialized value of <see cref="DefaultValue"/>.
		/// </summary>
		/// <value>A string containing the string representation of <see cref="DefaultValue"/>, serialized using <see cref="ParameterConvert"/>. May be <see langword="null"/>.</value>
		[DataMember]
		public string SerializedDefaultValue
		{
			get
			{
				if (DefaultValueState == PropertySyncState.ObjectChanged)
				{
					mSerializedDefaultValue = ParameterConvert.ToString(mDefaultValue, mDataType, Constraints);
					DefaultValueState = PropertySyncState.InSync;
				}
				return mSerializedDefaultValue;
			}
			set
			{
				mSerializedDefaultValue = value;
				DefaultValueState = PropertySyncState.SerializedChanged;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="LogbookComponentParameterDescription"/> class.
		/// </summary>
		/// <remarks><see cref="Name"/>, <see cref="DisplayName"/> and <see cref="Description"/> are set to <see cref="string.Empty"/>; <see cref="DataType"/> is set to <see cref="ParameterDataType.None"/>; All other properties are set to <see langword="null"/>.</remarks>
		public LogbookComponentParameterDescription()
		{
			mName = string.Empty;
			mDisplayName = string.Empty;
			mDescription = string.Empty;
			mDataType = ParameterDataType.None;
			mIsRequired = false;
			mConstraints = null;
			mConstraintString = null;
			ConstraintsState = PropertySyncState.InSync;
			mDefaultValue = null;
			mSerializedDefaultValue = null;
			DefaultValueState = PropertySyncState.InSync;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LogbookComponentParameterDescription"/> class with the specified parameters.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="displayName"></param>
		/// <param name="description"></param>
		/// <param name="dataType"></param>
		/// <param name="isRequired">A value indicating if the parameter is mandatory and must be provided to initialize the <see cref="LogbookComponent"/>.</param>
		/// <param name="constraints"></param>
		/// <param name="defaultValue"></param>
		/// <remarks><see cref="ConstraintString"/> and <see cref="SerializedDefaultValue"/> are set with serialized versions of <paramref name="constraints"/> and <paramref name="defaultValue"/>.</remarks>
		/// <exception cref="CodedArgumentNullOrWhiteSpaceException"><paramref name="name"/>, <paramref name="displayName"/> or <paramref name="description"/> are <see langword="null"/>, empty or white-space.</exception>
		/// <exception cref="CodedArgumentOutOfRangeException"><paramref name="dataType"/> is <see cref="ParameterDataType.None"/>.</exception>
		/// <exception cref="ParameterConversionException"><paramref name="defaultValue"/> is not <see langword="null"/>, and could not be serialized using <see cref="ParameterConvert.ToString(object, ParameterDataType, IReadOnlyList{Constraint})"/>.</exception>
		public LogbookComponentParameterDescription(string name, string displayName, string description, ParameterDataType dataType, bool isRequired, IEnumerable<Constraint> constraints, object defaultValue)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new CodedArgumentNullOrWhiteSpaceException(Errors.CreateHResult(ErrorCodes.LogbookComponentParameterDescription_ctor_NameNullEmpty), nameof(name));
			if (string.IsNullOrWhiteSpace(displayName))
				throw new CodedArgumentNullOrWhiteSpaceException(Errors.CreateHResult(ErrorCodes.LogbookComponentParameterDescription_ctor_DisplayNameNullEmpty), nameof(displayName));
			if (string.IsNullOrWhiteSpace(description))
				throw new CodedArgumentNullOrWhiteSpaceException(Errors.CreateHResult(ErrorCodes.LogbookComponentParameterDescription_ctor_DescriptionNullEmpty), nameof(description));
			if (dataType == ParameterDataType.None)
				throw new CodedArgumentOutOfRangeException(Errors.CreateHResult(ErrorCodes.LogbookComponentParameterDescription_ctor_DataTypeNone), nameof(dataType), Properties.Resources.LogbookComponentParameterDescription_ctor_DataTypeNone);

			mName = name;
			mDisplayName = displayName;
			mDescription = description;
			mDataType = dataType;
			mIsRequired = isRequired;

			if (constraints == null)
			{
				mConstraints = null;
				mConstraintString = null;
			}
			else
			{
				mConstraints = new List<Constraint>(constraints);
				mConstraintString = ConstraintParser.ConcatConstraints(mConstraints);
			}
			ConstraintsState = PropertySyncState.InSync;
			if (defaultValue == null)
			{
				mDefaultValue = null;
				mSerializedDefaultValue = null;
			}
			else
			{
				mDefaultValue = defaultValue;
				mSerializedDefaultValue = ParameterConvert.ToString(mDefaultValue, mDataType, mConstraints);
			}
			DefaultValueState = PropertySyncState.InSync;
		}
		#endregion

		#region Enumerations
		/// <summary>
		/// Specifies the state of the <see cref="Constraints"/> and <see cref="DefaultValue"/> and its serialized versions <see cref="ConstraintString"/> and <see cref="SerializedDefaultValue"/>.
		/// </summary>
		private enum PropertySyncState
		{
			/// <summary>
			/// Object and serialized property are equal.
			/// </summary>
			InSync,

			/// <summary>
			/// Serialized property was changed, object property needs to update.
			/// </summary>
			SerializedChanged,

			/// <summary>
			/// Object property was changed, serialized property needs to update.
			/// </summary>
			ObjectChanged
		}
		#endregion
	}
}
