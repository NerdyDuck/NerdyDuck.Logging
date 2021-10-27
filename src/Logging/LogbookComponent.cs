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
using System.Globalization;
using NerdyDuck.CodedExceptions;
using NerdyDuck.ParameterValidation;

namespace NerdyDuck.Logging;

/// <summary>
/// Specifies the properties and methods of all classes representing a component of a logbook.
/// </summary>
public abstract class LogbookComponent : IDisposable
{
	private string mName;
	private bool mIsOpen;
	private bool mIsDisposed;

	/// <summary>
	/// Gets a value indicating if the <see cref="LogbookComponent"/> is disposed.
	/// </summary>
	/// <value><see langword="true"/>, if the object was disposed using <see cref="Dispose()"/> method; otherwise, <see langword="false"/>.</value>
	protected bool IsDisposed
	{
		get { return mIsDisposed; }
	}

	/// <summary>
	/// Gets a value indicating if the <see cref="LogbookComponent"/> is ready to handle log data.
	/// </summary>
	/// <value><see langword="true"/>, if the <see cref="LogbookComponent"/> was opened using <see cref="Open"/>; otherwise, <see langword="false"/>.</value>
	public bool IsOpen
	{
		get { return mIsOpen; }
	}

	/// <summary>
	/// Gets or sets the name of the <see cref="LogbookComponent"/>.
	/// </summary>
	/// <value>The name of the <see cref="LogbookComponent"/>; if <see langword="null"/> is assigned to the property, the property value is set to the class name of the current instance.</value>
	public string Name
	{
		get { return mName; }
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				mName = this.GetType().Name;
			}
			else
			{
				mName = value;
			}
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="LogbookComponent"/> class.
	/// </summary>
	/// <remarks><see cref="Name"/> is set to the class name; <see cref="IsOpen"/> and <see cref="IsDisposed"/> is set to <see langword="false"/>.</remarks>
	protected LogbookComponent()
		: this(null)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="LogbookComponent"/> class with the specified name.
	/// </summary>
	/// <param name="name">The name of the <see cref="LogbookComponent"/>.</param>
	/// <remarks><see cref="Name"/> is set to the value of <paramref name="name"/>, unless it is <see langword="null"/> or empty. Then <see cref="Name"/> is set to the class name; <see cref="IsOpen"/> and <see cref="IsDisposed"/> is set to <see langword="false"/>.</remarks>
	protected LogbookComponent(string name)
	{
		Name = name;
		mIsOpen = false;
		mIsDisposed = false;
	}

	/// <summary>
	/// Destructor.
	/// </summary>
	~LogbookComponent()
	{
		Dispose(false);
	}

	/// <summary>
	/// Closes the <see cref="LogbookComponent"/> for input.
	/// </summary>
	/// <remarks>The default implementation only sets <see cref="IsOpen"/> to <see langword="false"/>.</remarks>
	public virtual void Close()
	{
		mIsOpen = false;
	}

	/// <summary>
	/// Gets a description of the <see cref="LogbookComponent"/>, including the parameters it requires to work, in the specified language.
	/// </summary>
	/// <param name="culture">The language to return descriptive texts and names for. May be <see langword="null"/>.</param>
	/// <returns>A <see cref="LogbookComponentDescription"/>.</returns>
	/// <remarks><para>If <paramref name="culture"/> is <see langword="null"/>, the current thread culture is used to determine the culture for descriptive texts.</para>
	/// <note type="note"><para>Note to implementers:</para><para>Override this method to modify the output of the method. Change the <see cref="LogbookComponentDescription.DisplayName"/> and <see cref="LogbookComponentDescription.Description"/>, and add descriptions of all parameters used in your implementation.</para></note></remarks>
	public virtual LogbookComponentDescription GetDescription(CultureInfo culture) => new LogbookComponentDescription(
			GetType().ToStringAssemblyNameOnly(),
			TextResources.ResourceManager.GetString(nameof(TextResources.LogbookComponent_DisplayName), culture),
			TextResources.ResourceManager.GetString(nameof(TextResources.LogbookComponent_Description), culture));

	/// <summary>
	/// Gets a dictionary of the current parameter values of the <see cref="LogbookComponent"/>, in serialized form, keyed by the parameter name.
	/// </summary>
	/// <returns>A dictionary of parameter values, keyed by the parameter name.</returns>
	/// <remarks>The values must be serialized so they can be deserialized using <see cref="ParameterConvert"/>.</remarks>
	public virtual IDictionary<string, string> GetParameters() => new CaseInsensitiveStringDictionary();

	/// <summary>
	/// Opens the <see cref="LogbookComponent"/> so it processes log data.
	/// </summary>
	/// <remarks><see cref="IsOpen"/> returns <see langword="true"/> after the method was called.</remarks>
	public virtual void Open() => mIsOpen = true;

	/// <summary>
	/// Configures the current <see cref="LogbookComponent"/> with the specified parameters.
	/// </summary>
	/// <param name="parameters">A dictionary of serialized parameter values, keyed by the parameter name.</param>
	/// <remarks><note type="note"><para>Note to implementers:</para><para>The method must be designed so it can be called multiple times during the lifetime of the component.</para></note></remarks>
	public virtual void SetParameters(IDictionary<string, string> parameters)
	{
		if (parameters == null)
			throw new CodedArgumentNullException(HResult.Create(ErrorCodes.LogbookComponent_SetParameters_ArgNull), nameof(parameters));
	}

	/// <summary>
	/// Returns a string that represents the current object.
	/// </summary>
	/// <returns>A string containing the type of the component and its <see cref="Name"/>.</returns>
	public override string ToString() => string.Format("{0} ('{1}\')", this.GetType().Name, mName);

	/// <summary>
	/// Releases allocated resources.
	/// </summary>
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	/// <summary>
	/// Releases allocated resources.
	/// </summary>
	/// <param name="disposing">A value indicating if the method was called by user code. If <see langword="false"/>, the method was called by the runtime in the finalizer.</param>
	/// <remarks>If <paramref name="disposing"/> is <see langword="false"/>, no other objects should be referenced.</remarks>
	protected virtual void Dispose(bool disposing)
	{
		if (mIsDisposed)
			return;
		mIsDisposed = true;

		if (disposing)
		{
			if (mIsOpen)
			{
				try
				{
					Close();
				}
				catch { }
			}
		}
	}

	/// <summary>
	/// Asserts that the filter is not disposed.
	/// </summary>
	/// <exception cref="ObjectDisposedException">The filter was already disposed.</exception>
	protected void AssertDisposed()
	{
		if (mIsDisposed)
		{
			throw new ObjectDisposedException(ToString());
		}
	}

	/// <summary>
	/// Checks if all required parameters are present, and calls <see cref="SetParameters(IDictionary{string, string})"/>.
	/// </summary>
	/// <param name="parameters">The parameters used to initialize the component.</param>
	internal void SetParametersInternal(CaseInsensitiveStringDictionary parameters)
	{
		LogbookComponentDescription description = GetDescription(null);
		HelperMethods.CheckParameters(description, parameters);
		SetParameters(parameters);
	}
}
