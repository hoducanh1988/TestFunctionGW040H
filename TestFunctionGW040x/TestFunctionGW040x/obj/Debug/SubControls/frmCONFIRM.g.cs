﻿#pragma checksum "..\..\..\SubControls\frmCONFIRM.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8904CBF31565698D26AED79D77DB4C88F26BADDE"
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
using TestFunctionGW040x;


namespace TestFunctionGW040x {
    
    
    /// <summary>
    /// frmCONFIRM
    /// </summary>
    public partial class frmCONFIRM : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\SubControls\frmCONFIRM.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordbox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\SubControls\frmCONFIRM.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbMessage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TestFunctionGW040x;component/subcontrols/frmconfirm.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SubControls\frmCONFIRM.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\SubControls\frmCONFIRM.xaml"
            ((System.Windows.Controls.Border)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Border_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 19 "..\..\..\SubControls\frmCONFIRM.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Label_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.passwordbox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 25 "..\..\..\SubControls\frmCONFIRM.xaml"
            this.passwordbox.KeyDown += new System.Windows.Input.KeyEventHandler(this.passwordbox_KeyDown);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\SubControls\frmCONFIRM.xaml"
            this.passwordbox.PasswordChanged += new System.Windows.RoutedEventHandler(this.passwordbox_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 27 "..\..\..\SubControls\frmCONFIRM.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 28 "..\..\..\SubControls\frmCONFIRM.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tbMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
