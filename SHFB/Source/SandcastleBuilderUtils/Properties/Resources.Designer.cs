﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SandcastleBuilder.Utils.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SandcastleBuilder.Utils.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to &lt;Project DefaultTargets=&quot;Build&quot; xmlns=&quot;http://schemas.microsoft.com/developer/msbuild/2003&quot; ToolsVersion=&quot;4.0&quot;&gt;
        ///	&lt;PropertyGroup&gt;
        ///		&lt;!-- The configuration and platform will be used to determine which assemblies to include from solution and
        ///				 project documentation sources --&gt;
        ///		&lt;Configuration Condition=&quot; &apos;$(Configuration)&apos; == &apos;&apos; &quot;&gt;Debug&lt;/Configuration&gt;
        ///		&lt;Platform Condition=&quot; &apos;$(Platform)&apos; == &apos;&apos; &quot;&gt;AnyCPU&lt;/Platform&gt;
        ///
        ///		&lt;SchemaVersion&gt;2.0&lt;/SchemaVersion&gt;
        ///		&lt;ProjectGuid&gt;$guid1$&lt;/ProjectGuid&gt;
        ///		&lt;SHFBS [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ProjectTemplate {
            get {
                return ResourceManager.GetString("ProjectTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap SandcastleLogo {
            get {
                object obj = ResourceManager.GetObject("SandcastleLogo", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Spinner {
            get {
                object obj = ResourceManager.GetObject("Spinner", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
