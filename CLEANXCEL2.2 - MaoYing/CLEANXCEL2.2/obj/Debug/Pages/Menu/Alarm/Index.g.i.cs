﻿#pragma checksum "..\..\..\..\..\Pages\Menu\Alarm\Index.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F5E5746D05DFAF4393DA8D2CF9F936616B644098475FBA244727B93906643529"
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
    /// Index
    /// </summary>
    public partial class Index : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 135 "..\..\..\..\..\Pages\Menu\Alarm\Index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel SubMenuPanel;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\..\..\..\Pages\Menu\Alarm\Index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RBCurrent;
        
        #line default
        #line hidden
        
        
        #line 162 "..\..\..\..\..\Pages\Menu\Alarm\Index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RBHistory;
        
        #line default
        #line hidden
        
        
        #line 192 "..\..\..\..\..\Pages\Menu\Alarm\Index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel SubPageHeader;
        
        #line default
        #line hidden
        
        
        #line 193 "..\..\..\..\..\Pages\Menu\Alarm\Index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PageTitle;
        
        #line default
        #line hidden
        
        
        #line 195 "..\..\..\..\..\Pages\Menu\Alarm\Index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PageDescription;
        
        #line default
        #line hidden
        
        
        #line 203 "..\..\..\..\..\Pages\Menu\Alarm\Index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame FrameLocalContainer;
        
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
            System.Uri resourceLocater = new System.Uri("/CLEANXCEL2.2;component/pages/menu/alarm/index.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\Menu\Alarm\Index.xaml"
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
            
            #line 8 "..\..\..\..\..\Pages\Menu\Alarm\Index.xaml"
            ((CLEANXCEL2._2.Pages.Menu.Alarm.Index)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 43 "..\..\..\..\..\Pages\Menu\Alarm\Index.xaml"
            ((System.Windows.Media.Animation.DoubleAnimation)(target)).Completed += new System.EventHandler(this.LoadPage);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SubMenuPanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 4:
            this.RBCurrent = ((System.Windows.Controls.RadioButton)(target));
            
            #line 159 "..\..\..\..\..\Pages\Menu\Alarm\Index.xaml"
            this.RBCurrent.Checked += new System.Windows.RoutedEventHandler(this.RBCurrent_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.RBHistory = ((System.Windows.Controls.RadioButton)(target));
            
            #line 168 "..\..\..\..\..\Pages\Menu\Alarm\Index.xaml"
            this.RBHistory.Checked += new System.Windows.RoutedEventHandler(this.RBHistory_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SubPageHeader = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.PageTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.PageDescription = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.FrameLocalContainer = ((System.Windows.Controls.Frame)(target));
            
            #line 205 "..\..\..\..\..\Pages\Menu\Alarm\Index.xaml"
            this.FrameLocalContainer.Loaded += new System.Windows.RoutedEventHandler(this.FrameLocalContainer_Loaded);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

