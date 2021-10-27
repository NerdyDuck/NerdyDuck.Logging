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
