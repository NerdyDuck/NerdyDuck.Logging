#region Copyright
/*******************************************************************************
 * <copyright file="ErrorCodes.cs" owner="Daniel Kopp">
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
 * <file name="ErrorCodes.cs" date="2016-04-14">
 * Error codes for the NerdyDuck.Logging assembly.
 * </file>
 ******************************************************************************/
#endregion

namespace NerdyDuck.Logging
{
	/// <summary>
	/// Error codes for the NerdyDuck.Logging assembly.
	/// </summary>
	internal enum ErrorCodes
	{
		/// <summary>
		/// 0x0001; LogbookComponentDescription.ctor; typeName is null or whitespace.
		/// </summary>
		LogbookComponentDescription_ctor_TypeNullEmpty,

		/// <summary>
		/// 0x0002; LogbookComponentDescription.ctor; displayName is null or whitespace.
		/// </summary>
		LogbookComponentDescription_ctor_DisplayNameNullEmpty,

		/// <summary>
		/// 0x0003; LogbookComponentDescription.ctor; description is null or whitespace.
		/// </summary>
		LogbookComponentDescription_ctor_DescriptionNullEmpty,

		/// <summary>
		/// 0x0004; LogbookComponentParameterDescription.ctor; name is null or whitespace.
		/// </summary>
		LogbookComponentParameterDescription_ctor_NameNullEmpty,

		/// <summary>
		/// 0x0005; LogbookComponentParameterDescription.ctor; displayName is null or whitespace.
		/// </summary>
		LogbookComponentParameterDescription_ctor_DisplayNameNullEmpty,

		/// <summary>
		/// 0x0006; LogbookComponentParameterDescription.ctor; description is null or whitespace.
		/// </summary>
		LogbookComponentParameterDescription_ctor_DescriptionNullEmpty,

		/// <summary>
		/// 0x0007; LogbookComponentParameterDescription.ctor; dataType is None.
		/// </summary>
		LogbookComponentParameterDescription_ctor_DataTypeNone,

		/// <summary>
		/// 0x0008; LogbookComponent.SetParameters; parameters is null.
		/// </summary>
		LogbookComponent_SetParameters_ArgNull,

		/// <summary>
		/// 0x0009; LogbookFilter.SyncShouldLog; Filter caused exception.
		/// </summary>
		LogbookFilter_SyncShouldLog_Failed,

		/// <summary>
		/// 0x000a; LogbookListener.SyncWrite; Write failed.
		/// </summary>
		LogbookListener_SyncWrite_Failed,
	}
}
