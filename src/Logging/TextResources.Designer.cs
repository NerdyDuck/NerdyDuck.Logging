﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NerdyDuck.Logging {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class TextResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TextResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NerdyDuck.Logging.TextResources", typeof(TextResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Generic logbook component.
        /// </summary>
        internal static string LogbookComponent_Description {
            get {
                return ResourceManager.GetString("LogbookComponent_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Generic component.
        /// </summary>
        internal static string LogbookComponent_DisplayName {
            get {
                return ResourceManager.GetString("LogbookComponent_DisplayName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Data type may not be &apos;None&apos;..
        /// </summary>
        internal static string LogbookComponentParameterDescription_ctor_DataTypeNone {
            get {
                return ResourceManager.GetString("LogbookComponentParameterDescription_ctor_DataTypeNone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot query logbook filter &apos;{0}&apos; of type &apos;{1}&apos;..
        /// </summary>
        internal static string LogbookFilter_SyncShouldLog_Failed {
            get {
                return ResourceManager.GetString("LogbookFilter_SyncShouldLog_Failed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Indicates if the listener is enabled and receives log data..
        /// </summary>
        internal static string LogbookListener_IsEnabled_Description {
            get {
                return ResourceManager.GetString("LogbookListener_IsEnabled_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Listener is enabled..
        /// </summary>
        internal static string LogbookListener_IsEnabled_DisplayName {
            get {
                return ResourceManager.GetString("LogbookListener_IsEnabled_DisplayName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot write to logbook listener &apos;{0}&apos; of type &apos;{1}&apos;..
        /// </summary>
        internal static string LogbookListener_SyncWrite_Failed {
            get {
                return ResourceManager.GetString("LogbookListener_SyncWrite_Failed", resourceCulture);
            }
        }
    }
}
