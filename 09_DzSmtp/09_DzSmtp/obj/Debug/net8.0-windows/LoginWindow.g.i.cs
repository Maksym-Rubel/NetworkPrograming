﻿#pragma checksum "..\..\..\LoginWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DF8964AECFCEBD32D937EBE0B1F8A61D2BFB01A3"
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
    /// LoginWindow
    /// </summary>
    public partial class LoginWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 125 "..\..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmailTxt;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PassTxr;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image myImage;
        
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
            System.Uri resourceLocater = new System.Uri("/09_DzSmtp;component/loginwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\LoginWindow.xaml"
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
            this.EmailTxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 125 "..\..\..\LoginWindow.xaml"
            this.EmailTxt.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 126 "..\..\..\LoginWindow.xaml"
            this.EmailTxt.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PassTxr = ((System.Windows.Controls.TextBox)(target));
            
            #line 127 "..\..\..\LoginWindow.xaml"
            this.PassTxr.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus_1);
            
            #line default
            #line hidden
            
            #line 128 "..\..\..\LoginWindow.xaml"
            this.PassTxr.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus_1);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 129 "..\..\..\LoginWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LoginBtn);
            
            #line default
            #line hidden
            return;
            case 4:
            this.myImage = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

