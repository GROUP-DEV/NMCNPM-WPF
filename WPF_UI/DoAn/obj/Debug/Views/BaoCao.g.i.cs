﻿#pragma checksum "..\..\..\Views\BaoCao.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F75599F747DAD77F0057C7948DEF342DCB0565FF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DoAn.Controller;
using DoAn.Views;
using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
using Microsoft.Windows.Controls;
using Microsoft.Windows.Controls.PropertyGrid;
using System;
using System.ComponentModel;
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


namespace DoAn.Views {
    
    
    /// <summary>
    /// BaoCao
    /// </summary>
    public partial class BaoCao : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 523 "..\..\..\Views\BaoCao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbthang;
        
        #line default
        #line hidden
        
        
        #line 538 "..\..\..\Views\BaoCao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DoAn.Views.NumericBox txtnam;
        
        #line default
        #line hidden
        
        
        #line 540 "..\..\..\Views\BaoCao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DoAn.Views.NumericBox txtBCnam;
        
        #line default
        #line hidden
        
        
        #line 542 "..\..\..\Views\BaoCao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbtiltle;
        
        #line default
        #line hidden
        
        
        #line 543 "..\..\..\Views\BaoCao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button back;
        
        #line default
        #line hidden
        
        
        #line 555 "..\..\..\Views\BaoCao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridBC;
        
        #line default
        #line hidden
        
        
        #line 599 "..\..\..\Views\BaoCao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridtheonam;
        
        #line default
        #line hidden
        
        
        #line 637 "..\..\..\Views\BaoCao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnlapBC;
        
        #line default
        #line hidden
        
        
        #line 648 "..\..\..\Views\BaoCao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnlapBCnam;
        
        #line default
        #line hidden
        
        
        #line 661 "..\..\..\Views\BaoCao.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnxuatBC;
        
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
            System.Uri resourceLocater = new System.Uri("/DoAn;component/views/baocao.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\BaoCao.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 12 "..\..\..\Views\BaoCao.xaml"
            ((DoAn.Views.BaoCao)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbbthang = ((System.Windows.Controls.ComboBox)(target));
            
            #line 522 "..\..\..\Views\BaoCao.xaml"
            this.cbbthang.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbbthang_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtnam = ((DoAn.Views.NumericBox)(target));
            return;
            case 4:
            this.txtBCnam = ((DoAn.Views.NumericBox)(target));
            return;
            case 5:
            this.tbtiltle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.back = ((System.Windows.Controls.Button)(target));
            
            #line 543 "..\..\..\Views\BaoCao.xaml"
            this.back.Click += new System.Windows.RoutedEventHandler(this.back_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.gridBC = ((System.Windows.Controls.DataGrid)(target));
            
            #line 555 "..\..\..\Views\BaoCao.xaml"
            this.gridBC.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.gridBC_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.gridtheonam = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            this.btnlapBC = ((System.Windows.Controls.Button)(target));
            
            #line 637 "..\..\..\Views\BaoCao.xaml"
            this.btnlapBC.Click += new System.Windows.RoutedEventHandler(this.btnlapBC_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnlapBCnam = ((System.Windows.Controls.Button)(target));
            
            #line 648 "..\..\..\Views\BaoCao.xaml"
            this.btnlapBCnam.Click += new System.Windows.RoutedEventHandler(this.btnlapBCnam_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnxuatBC = ((System.Windows.Controls.Button)(target));
            
            #line 661 "..\..\..\Views\BaoCao.xaml"
            this.btnxuatBC.Click += new System.Windows.RoutedEventHandler(this.btnxuatBC_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

