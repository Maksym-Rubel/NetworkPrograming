﻿#pragma checksum "..\..\..\MainPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CFC631884EFE505198D4B34F1FF6433C317A9224"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using _09_DzSmtp;


namespace _09_DzSmtp {
    
    
    /// <summary>
    /// MainPage
    /// </summary>
    public partial class MainPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 238 "..\..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox themeBox;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox toBox;
        
        #line default
        #line hidden
        
        
        #line 241 "..\..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listFiles;
        
        #line default
        #line hidden
        
        
        #line 262 "..\..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox priorityCheckBox;
        
        #line default
        #line hidden
        
        
        #line 265 "..\..\..\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox messageBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/09_DzSmtp;component/mainpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 231 "..\..\..\MainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 234 "..\..\..\MainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteOne);
            
            #line default
            #line hidden
            return;
            case 3:
            this.themeBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.toBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.listFiles = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            
            #line 260 "..\..\..\MainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SelectFile);
            
            #line default
            #line hidden
            return;
            case 7:
            this.priorityCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 262 "..\..\..\MainPage.xaml"
            this.priorityCheckBox.Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 262 "..\..\..\MainPage.xaml"
            this.priorityCheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.priorityCheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 264 "..\..\..\MainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SendMessage);
            
            #line default
            #line hidden
            return;
            case 9:
            this.messageBox = ((System.Windows.Controls.RichTextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

