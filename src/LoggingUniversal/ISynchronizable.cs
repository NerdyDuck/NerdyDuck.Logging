#region Copyright
/*******************************************************************************
 * <copyright file="ILogbookComponent.cs" owner="Daniel Kopp">
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
 * <file name="ILogbookComponent.cs" date="2016-04-08">
 * Specifies the properties of a class that can be synchronized or is
 * synchronized in itself.
 * </file>
 ******************************************************************************/
#endregion

namespace NerdyDuck.Logging
{
	/// <summary>
	/// Specifies the properties of a class that can be synchronized or is synchronized in itself.
	/// </summary>
	public interface ISynchronizable
	{
		/// <summary>
		/// When implemented, gets a value indicating if the methods of the class are already synchronized.
		/// </summary>
		/// <value><see langword="true"/>, if the methods are thread-safe; otherwise, <see langword="false"/>.</value>
		/// <remarks>The methods may be thread-safe because an internal synchronization method is used, or simply because the methods don't use common resources that need to be synchronized.</remarks>
		bool IsSynchronized { get; }

		/// <summary>
		/// When implemented, gets an object used to synchronize access to the object.
		/// </summary>
		/// <value>Returns an object, usually the current instance. Never returns <see langword="null"/>.</value>
		object SyncRoot { get; }
	}
}
