﻿#pragma checksum "..\..\..\UserControls\RecipeTable.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4640579629767D800A4433CD97332C04CCB105C719B4498BB01EF6FBEAABBCEE"
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
    /// RecipeTable
    /// </summary>
    public partial class RecipeTable : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 2 "..\..\..\UserControls\RecipeTable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CLEANXCEL2._2.UserControls.RecipeTable userControl;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\UserControls\RecipeTable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock title;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\UserControls\RecipeTable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TBProcessTimeTitle;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\UserControls\RecipeTable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TBProcessTime;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\UserControls\RecipeTable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Protect_DeleteButton;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\UserControls\RecipeTable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TBPowerTitle;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\UserControls\RecipeTable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBPower;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\UserControls\RecipeTable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TBFrequencyTitle;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\UserControls\RecipeTable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TBFrequency;
        
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
            System.Uri resourceLocater = new System.Uri("/CLEANXCEL2.2;component/usercontrols/recipetable.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\RecipeTable.xaml"
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
            this.userControl = ((CLEANXCEL2._2.UserControls.RecipeTable)(target));
            return;
            case 2:
            this.title = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.TBProcessTimeTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.TBProcessTime = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.Protect_DeleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\UserControls\RecipeTable.xaml"
            this.Protect_DeleteButton.PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Protect_DeleteButton_PreviewMouseUp);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TBPowerTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.TBPower = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.TBFrequencyTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.TBFrequency = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

