﻿#pragma checksum "..\..\..\..\..\Pages\Menu\Alarm\CurrentAlarm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EC90CD4AEB5145922140D80632DED381C78F65F588C2A94044428C2FE276CB8C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CLEANXCEL2._2.Pages.Menu.Alarm;
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


namespace CLEANXCEL2._2.Pages.Menu.Alarm {
    
    
    /// <summary>
    /// CurrentAlarm
    /// </summary>
    public partial class CurrentAlarm : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\..\Pages\Menu\Alarm\CurrentAlarm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Title;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\Pages\Menu\Alarm\CurrentAlarm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton ID;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\Pages\Menu\Alarm\CurrentAlarm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton Code;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\Pages\Menu\Alarm\CurrentAlarm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton Description;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\Pages\Menu\Alarm\CurrentAlarm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton Datetime;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\Pages\Menu\Alarm\CurrentAlarm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel AlarmStack;
        
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
            System.Uri resourceLocater = new System.Uri("/CLEANXCEL2.2;component/pages/menu/alarm/currentalarm.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\Menu\Alarm\CurrentAlarm.xaml"
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
            
            #line 9 "..\..\..\..\..\Pages\Menu\Alarm\CurrentAlarm.xaml"
            ((CLEANXCEL2._2.Pages.Menu.Alarm.CurrentAlarm)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            
            #line 10 "..\..\..\..\..\Pages\Menu\Alarm\CurrentAlarm.xaml"
            ((CLEANXCEL2._2.Pages.Menu.Alarm.CurrentAlarm)(target)).Unloaded += new System.Windows.RoutedEventHandler(this.Page_Unloaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Title = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.ID = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 28 "..\..\..\..\..\Pages\Menu\Alarm\CurrentAlarm.xaml"
            this.ID.Click += new System.Windows.RoutedEventHandler(this.ID_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Code = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 29 "..\..\..\..\..\Pages\Menu\Alarm\CurrentAlarm.xaml"
            this.Code.Click += new System.Windows.RoutedEventHandler(this.Code_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Description = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 30 "..\..\..\..\..\Pages\Menu\Alarm\CurrentAlarm.xaml"
            this.Description.Click += new System.Windows.RoutedEventHandler(this.Description_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Datetime = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 31 "..\..\..\..\..\Pages\Menu\Alarm\CurrentAlarm.xaml"
            this.Datetime.Click += new System.Windows.RoutedEventHandler(this.Datetime_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AlarmStack = ((System.Windows.Controls.StackPanel)(target));
            
            #line 35 "..\..\..\..\..\Pages\Menu\Alarm\CurrentAlarm.xaml"
            this.AlarmStack.Loaded += new System.Windows.RoutedEventHandler(this.AlarmStack_Loaded);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
