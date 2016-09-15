﻿#region Copyright
/*******************************************************************************
 * <copyright file="Resources.cs" owner="Daniel Kopp">
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
 * <file name="Resources.cs" date="2016-04-18">
 * Helper class to access localized string resources.
 * </file>
 ******************************************************************************/
#endregion

using System;
using System.Globalization;

namespace NerdyDuck.Logging.Properties
{
	/// <summary>
	/// Helper class to access localized string resources.
	/// </summary>
	[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Resources.tt", "1.0.0.0")]
	[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
	internal static class Resources
	{
		#region String resource properties
		/// <summary>
		/// Gets a localized string similar to "Data type may not be 'None'.".
		/// </summary>
		internal static string LogbookComponentParameterDescription_ctor_DataTypeNone
		{
			get { return GetResource("LogbookComponentParameterDescription_ctor_DataTypeNone"); }
		}

		/// <summary>
		/// Gets a localized string similar to "Generic logbook component".
		/// </summary>
		internal static string LogbookComponent_Description
		{
			get { return GetResource("LogbookComponent_Description"); }
		}

		/// <summary>
		/// Gets a localized string similar to "Generic component".
		/// </summary>
		internal static string LogbookComponent_DisplayName
		{
			get { return GetResource("LogbookComponent_DisplayName"); }
		}

		/// <summary>
		/// Gets a localized string similar to "Cannot query logbook filter '{0}' of type '{1}'.".
		/// </summary>
		internal static string LogbookFilter_SyncShouldLog_Failed
		{
			get { return GetResource("LogbookFilter_SyncShouldLog_Failed"); }
		}

		/// <summary>
		/// Gets a localized string similar to "Indicates if the listener is enabled and receives log data.".
		/// </summary>
		internal static string LogbookListener_IsEnabled_Description
		{
			get { return GetResource("LogbookListener_IsEnabled_Description"); }
		}

		/// <summary>
		/// Gets a localized string similar to "Listener is enabled.".
		/// </summary>
		internal static string LogbookListener_IsEnabled_DisplayName
		{
			get { return GetResource("LogbookListener_IsEnabled_DisplayName"); }
		}

		/// <summary>
		/// Gets a localized string similar to "Cannot write to logbook listener '{0}' of type '{1}'.".
		/// </summary>
		internal static string LogbookListener_SyncWrite_Failed
		{
			get { return GetResource("LogbookListener_SyncWrite_Failed"); }
		}
		#endregion

#if WINDOWS_UWP
		#region Private fields
		private static Windows.ApplicationModel.Resources.Core.ResourceMap mResourceMap;
		private static Windows.ApplicationModel.Resources.Core.ResourceContext mContext;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the main resource map of the assembly.
		/// </summary>
		internal static Windows.ApplicationModel.Resources.Core.ResourceMap ResourceMap
		{
			get
			{
				if (object.ReferenceEquals(mResourceMap, null))
				{
					mResourceMap = Windows.ApplicationModel.Resources.Core.ResourceManager.Current.MainResourceMap;
				}

				return mResourceMap;
			}
		}

		/// <summary>
		/// Gets or sets the resource context to use when retrieving resources.
		/// </summary>
		internal static Windows.ApplicationModel.Resources.Core.ResourceContext Context
		{
			get { return mContext; }
			set { mContext = value; }
		}
		#endregion

		#region Methods
		/// <summary>
		/// Retrieves a string resource using the resource map.
		/// </summary>
		/// <param name="name">The name of the string resource.</param>
		/// <returns>A localized string.</returns>
		internal static string GetResource(string name)
		{
			Windows.ApplicationModel.Resources.Core.ResourceContext context = Context;
			if (context == null)
			{
				context = Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse();
			}

			Windows.ApplicationModel.Resources.Core.ResourceCandidate resourceCandidate = ResourceMap.GetValue("NerdyDuck.Logging/Resources/" + name, context);

			if (resourceCandidate == null)
			{
				throw new ArgumentOutOfRangeException(nameof(name));
			}

			return resourceCandidate.ValueAsString;
		}

		/// <summary>
		/// Retrieves a string resource for the specified culture using the resource map.
		/// </summary>
		/// <param name="name">The name of the string resource.</param>
		/// <param name="culture">The culture to retrieve a matching string for. May be <see langword="null"/>.</param>
		/// <returns>A localized string.</returns>
		internal static string GetResource(string name, CultureInfo culture)
		{
			Windows.ApplicationModel.Resources.Core.ResourceContext context;
			if (culture == null || culture.IsNeutralCulture)
			{
				context = Context;
				if (context == null)
				{
					context = Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse();
				}
			}
			else
			{
				context = new Windows.ApplicationModel.Resources.Core.ResourceContext();
				context.Languages = new string[] { culture.TwoLetterISOLanguageName };
			}

			Windows.ApplicationModel.Resources.Core.ResourceCandidate resourceCandidate = ResourceMap.GetValue("NerdyDuck.Logging/Resources/" + name, context);

			if (resourceCandidate == null)
			{
				throw new ArgumentOutOfRangeException(nameof(name));
			}

			return resourceCandidate.ValueAsString;
		}
		#endregion
#endif

#if WINDOWS_DESKTOP
		#region Private fields
		private static System.Resources.ResourceManager mResourceManager;
		private static System.Globalization.CultureInfo mResourceCulture;
		#endregion

		#region Properties
		/// <summary>
		/// Returns the cached ResourceManager instance used by this class.
		/// </summary>
		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
		internal static System.Resources.ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(mResourceManager, null))
				{
					System.Resources.ResourceManager temp = new System.Resources.ResourceManager("NerdyDuck.Logging.Properties.Resources", typeof(Resources).Assembly);
					mResourceManager = temp;
				}
				return mResourceManager;
			}
		}

		/// <summary>
		/// Overrides the current thread's CurrentUICulture property for all resource lookups using this strongly typed resource class.
		/// </summary>
		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
		internal static System.Globalization.CultureInfo Culture
		{
			get { return mResourceCulture; }
			set { mResourceCulture = value; }
		}
		#endregion

		#region Methods
		/// <summary>
		/// Retrieves a string resource using the resource manager.
		/// </summary>
		/// <param name="name">The name of the string resource.</param>
		/// <returns>A localized string.</returns>
		internal static string GetResource(string name)
		{
			return ResourceManager.GetString(name, mResourceCulture);
		}

		/// <summary>
		/// Retrieves a string resource for the specified culture using the resource manager.
		/// </summary>
		/// <param name="name">The name of the string resource.</param>
		/// <param name="culture">The culture to retrieve a matching string for. May be <see langword="null"/>.</param>
		/// <returns>A localized string.</returns>
		internal static string GetResource(string name, CultureInfo culture)
		{
			return ResourceManager.GetString(name, culture);
		}
		#endregion
#endif
	}
}
