   M S B A M L   `   `   `  ����l  hSystem.Windows.Controls.DataVisualization.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5      G CCLEANXCEL2.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:CLEANXCEL2._2.Pages.Menu.Analytics"CLEANXCEL2._2.Pages.Menu.Analytics 5      6   0CLEANXCEL2._2.Pages.Menu.Analytics.StatusDiagram   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      �chartingToolkit{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5      Blocal0clr-namespace:CLEANXCEL2._2.Pages.Menu.Analytics     5      -   5          N� Title$  StatusDiagram��5      .��5      � $��-10,30,30,30q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� $��0��6   $�� ��6(      H1#��[  60   $
��Left=�6L   �� 5      -   5        $��RecipeSelection��5   '   $��3��6     ComboBoxFlatStyle#��[ 6>   $	��300��5      $��20,0,0,0q�6G   $
��Left=�6Y    �� DisplayMemberPath 6   ��  �� Path$
 Text�6Y   �� 5      -   5        $��bAnalyse��5   %   $��4��6     StandardButton#��[ 65   $��Analyse��6]   $	��200��6�   $��20,0,0,0q�6�   5       � 5!   
   $��1��6    5"      �� 5#      $
��Auto �6    �� 5$      $��* �6    �� 5%      $
��Auto �6    .+�5'      �� -   5        $��
YAxisLabel��5'   e   $��0��6   $
��Left=�6%   $	��Top=�6@   $��LABEL��6X    	 Label#��[ 5(      $��20q�63   �� 5)      $��1��6     StandardScrollViewer#��[ 6(   $
��Auto=�6Y   $
��10,0q�6|   .��5*      >   8System.Windows.Controls.DataVisualization.Charting.Chart  -   5        $��TimelineChart��5+       $��1��5*   (   $��0��65      Title$  ��6E     
GraphChart#���  5+   5      Axes 5-      C   =System.Windows.Controls.DataVisualization.Charting.LinearAxis  D   >System.Windows.Controls.DataVisualization.Charting.NumericAxis   Minimum�   �System.Windows.Controls.DataVisualization.Charting.NullableConverter`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]$ 0 65   =   7System.Windows.Controls.DataVisualization.Charting.Axis   Orientation$ X=�6A   	   Interval$		 100 6Q   D   >System.Windows.Controls.DataVisualization.Charting.DisplayAxis
   ShowGridLines
 .   AxisLabelStyle   AxisLabelStyle# [ 6u   6�   5/      50      �� 51      -   5        $��
XAxisLabel��51   l   $��2��6   $��Right=�6%   $��Bottom=�6A   $��TIME (s)��6\   #��[ 52      $��20q�63   53      �� 54   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�55      A�  
 CWhite#��[ 6     GreenBlueColor#��[ 65   $��20��56      $��20��6$   $��1��6/   �� 57      -   5        $��TBActualTitle��57      $��Actual��6-    	 Desc#��[	 6;   $��10,0,0,0q�6Y   A� 58      #��[ 6    
 RedPinkColor#��[
 65   $��20��59      $��20��6$   $��1��6/   $��	200,0,0,0q�6C   �� 5:      -   5        $��
TBSetTitle��5:      $	��Set��6*   #��[	 65   $��10,0,0,0q�6S   5;      5<      5=      