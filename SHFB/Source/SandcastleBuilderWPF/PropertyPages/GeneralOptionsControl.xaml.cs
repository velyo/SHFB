﻿//===============================================================================================================
// System  : Sandcastle Help File Builder WPF Controls
// File    : GeneralOptionsControl.xaml.cs
// Author  : Eric Woodruff
// Updated : 10/13/2017
// Note    : Copyright 2011-2017, Eric Woodruff, All rights reserved
// Compiler: Microsoft Visual C#
//
// This user control is used to modify the general help file builder package preferences that are unrelated to
// individual projects.
//
// This code is published under the Microsoft Public License (Ms-PL).  A copy of the license should be
// distributed with the code and can be found at the project website: https://GitHub.com/EWSoftware/SHFB.  This
// notice, the author's name, and all copyright notices must remain intact in all applications, documentation,
// and source files.
//
//    Date     Who  Comments
// ==============================================================================================================
// 03/27/2011  EFW  Created the code
// 03/04/2013  EFW  Added link to display the About box
// 05/03/2015  EFW  Removed support for the MS Help 2 file format
// 09/28/2017  EFW  Converted the control to WPF for better high DPI scaling support on 4K displays
//===============================================================================================================

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using Microsoft.Win32;

using Sandcastle.Core;

namespace SandcastleBuilder.WPF.PropertyPages
{
    /// <summary>
    /// This user control is used to modify the general help file builder package preferences that are unrelated
    /// to individual projects.
    /// </summary>
    [ToolboxItem(false)]
    public partial class GeneralOptionsControl : UserControl
    {
        #region Properties
        //=====================================================================

        /// <summary>
        /// This read-only property is used to see if the values are valid
        /// </summary>
        public bool IsValid
        {
            get
            {
                bool isValid = true;
                string filePath = txtMSHelpViewerPath.Text.Trim();

                if(filePath.Length != 0)
                {
                    try
                    {
                        txtMSHelpViewerPath.Text = filePath = Path.GetFullPath(filePath);

                        if(!File.Exists(filePath))
                            isValid = false;
                    }
                    catch(Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex);
                        isValid = false;
                    }
                }

                if(!isValid)
                {
                    txtMSHelpViewerPath.BorderBrush = Brushes.Red;
                    txtMSHelpViewerPath.BorderThickness = new Thickness(2);
                    txtMSHelpViewerPath.ToolTip = "The viewer application does not exist";
                }
                else
                {
                    txtMSHelpViewerPath.BorderBrush = Brushes.Black;
                    txtMSHelpViewerPath.BorderThickness = new Thickness(1);
                    txtMSHelpViewerPath.ToolTip = null;
                }

                return isValid;
            }
        }

        /// <summary>
        /// This is used to get or set the path to the MS Help Viewer tool
        /// </summary>
        public string MSHelpViewerPath
        {
            get { return txtMSHelpViewerPath.Text; }
            set { txtMSHelpViewerPath.Text = value; }
        }

        /// <summary>
        /// This is used to get or set the port to use when launching the ASP.NET development web server
        /// </summary>
        public int AspNetDevelopmentServerPort
        {
            get { return udcASPNetDevServerPort.Value.Value; }
            set { udcASPNetDevServerPort.Value = value; }
        }

        /// <summary>
        /// This is used to get or set whether or not verbose logging is enabled when building a help file
        /// </summary>
        public bool VerboseLogging
        {
            get { return chkVerboseLogging.IsChecked.Value; }
            set { chkVerboseLogging.IsChecked = value; }
        }

        /// <summary>
        /// This is used to get or set whether or not to use the external browser when viewing website output
        /// </summary>
        public bool UseExternalWebBrowser
        {
            get { return chkUseExternalBrowser.IsChecked.Value; }
            set { chkUseExternalBrowser.IsChecked = value; }
        }

        /// <summary>
        /// This is used to get or set whether or not to open the help file after a successful build
        /// </summary>
        public bool OpenHelpAfterBuild
        {
            get { return chkOpenHelpAfterBuild.IsChecked.Value; }
            set { chkOpenHelpAfterBuild.IsChecked = value; }
        }

        /// <summary>
        /// This is used to get or set whether or not to open the build log viewer tool window after a failed
        /// build.
        /// </summary>
        public bool OpenLogViewerOnFailedBuild
        {
            get { return chkOpenLogViewerOnFailure.IsChecked.Value; }
            set { chkOpenLogViewerOnFailure.IsChecked = value; }
        }

        /// <summary>
        /// This is used to get or set whether or not the extended XML comments completion source options are
        /// enabled.
        /// </summary>
        public bool EnableExtendedXmlCommentsCompletion
        {
            get { return chkEnableExtendedXmlComments.IsChecked.Value; }
            set { chkEnableExtendedXmlComments.IsChecked = value; }
        }

        /// <summary>
        /// This is used to get or set whether or not the MAML and XML comments element Go To Definition and tool
        /// tip option is enabled.
        /// </summary>
        public bool EnableGoToDefinition
        {
            get { return chkEnableGoToDefinition.IsChecked.Value; }
            set { chkEnableGoToDefinition.IsChecked = value; }
        }

        /// <summary>
        /// Related to the above, if enabled, Ctrl+clicking on a target will invoke the Go To Definition option
        /// </summary>
        public bool EnableCtrlClickGoToDefinition
        {
            get { return chkEnableCtrlClickGoToDefinition.IsChecked.Value; }
            set { chkEnableCtrlClickGoToDefinition.IsChecked = value; }
        }

        /// <summary>
        /// Related to the above, if enabled, any XML comments <c>cref</c> attribute value will allow Go To
        /// Definition and tool tip info.
        /// </summary>
        public bool EnableGoToDefinitionInCRef
        {
            get { return chkEnableGoToDefinitionInCRef.IsChecked.Value; }
            set { chkEnableGoToDefinitionInCRef.IsChecked = value; }
        }
        #endregion

        #region Constructor
        //=====================================================================

        /// <summary>
        /// Constructor
        /// </summary>
        public GeneralOptionsControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Event handlers
        //=====================================================================

        /// <summary>
        /// Select a help viewer application
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void btnSelectMSHCViewer_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();

            dlg.Title = "Select the MS Help Viewer (.mshc) application";
            dlg.Filter = "Executable files (*.exe)|*.exe|All Files (*.*)|*.*";
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            dlg.DefaultExt = "exe";

            if(dlg.ShowDialog() ?? false)
                txtMSHelpViewerPath.Text = dlg.FileName;
        }

        /// <summary>
        /// Enable or disable the Ctrl+click and <c>cref</c> options based on the overall Go To Definition
        /// setting.
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void chkEnableGoToDefinition_Click(object sender, RoutedEventArgs e)
        {
            chkEnableCtrlClickGoToDefinition.IsEnabled = chkEnableGoToDefinitionInCRef.IsEnabled =
                chkEnableGoToDefinition.IsChecked.Value;
        }

        /// <summary>
        /// View the Project website
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void lnkSHFBInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(lnkSHFBInfo.NavigateUri.AbsoluteUri);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unable to navigate to website.  Reason: " + ex.Message,
                    Constants.AppName, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        #endregion
    }
}
