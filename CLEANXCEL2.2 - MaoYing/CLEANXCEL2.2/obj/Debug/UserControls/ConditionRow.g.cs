﻿#pragma checksum "..\..\..\UserControls\ConditionRow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "49FE54A610EBA6929CEB87423E52F3947F3F1316C632D2F9C04A15D520460FCE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CLEANXCEL2._2.UserControls;
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


namespace CLEANXCEL2._2.UserControls {
    
    
    /// <summary>
    /// ConditionRow
    /// </summary>
    public partial class ConditionRow : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\UserControls\ConditionRow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CLEANXCEL2._2.UserControls.ConditionRow UC_ConditionRow;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\UserControls\ConditionRow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Protect_DeleteButton;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\UserControls\ConditionRow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Condition;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\UserControls\ConditionRow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Equipment;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\UserControls\ConditionRow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Value;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\UserControls\ConditionRow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border BitBorder;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\UserControls\ConditionRow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Bit;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\UserControls\ConditionRow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Unit;
        
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
            System.Uri resourceLocater = new System.Uri("/CLEANXCEL2.2;component/usercontrols/conditionrow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\ConditionRow.xaml"
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
            this.UC_ConditionRow = ((CLEANXCEL2._2.UserControls.ConditionRow)(target));
            return;
            case 2:
            this.Protect_DeleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\UserControls\ConditionRow.xaml"
            this.Protect_DeleteButton.PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Protect_DeleteButton_MouseUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Condition = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.Equipment = ((System.Windows.Controls.ComboBox)(target));
            
            #line 54 "..\..\..\UserControls\ConditionRow.xaml"
            this.Equipment.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Equipment_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Value = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.BitBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 7:
            this.Bit = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            this.Unit = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

