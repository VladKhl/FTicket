﻿#pragma checksum "..\..\..\Pages\AdmMainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "785FDE7F7339B2AACD073E4AD2053787DBB06AD59500E8B66B463CE6645663F6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FTicket.Pages;
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


namespace FTicket.Pages {
    
    
    /// <summary>
    /// AdmMainPage
    /// </summary>
    public partial class AdmMainPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Pages\AdmMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backbtn;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Pages\AdmMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox stagetxt;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Pages\AdmMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox teamcb;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Pages\AdmMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datematch;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Pages\AdmMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox timamatch;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Pages\AdmMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox tourn;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Pages\AdmMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addmatchbtn;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Pages\AdmMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox abtxt;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\Pages\AdmMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addabbtn;
        
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
            System.Uri resourceLocater = new System.Uri("/FTicket;component/pages/admmainpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\AdmMainPage.xaml"
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
            this.backbtn = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\Pages\AdmMainPage.xaml"
            this.backbtn.Click += new System.Windows.RoutedEventHandler(this.backbtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.stagetxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.teamcb = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.datematch = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.timamatch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tourn = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.addmatchbtn = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\Pages\AdmMainPage.xaml"
            this.addmatchbtn.Click += new System.Windows.RoutedEventHandler(this.addmatchbtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.abtxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.addabbtn = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\..\Pages\AdmMainPage.xaml"
            this.addabbtn.Click += new System.Windows.RoutedEventHandler(this.addabbtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

