   M S B A M L   `   `   `  ����G  CCLEANXCEL2.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:CLEANXCEL2._2.UserControlsCLEANXCEL2._2.UserControls  5      )    #CLEANXCEL2._2.UserControls.AlarmRow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:CLEANXCEL2._2.UserControls     5      -   5        $��
UserWindow��5      $��0,0,0,1q�5       
  CBlack#��[  5	       
 Roboto#��[ 5
      $��60��5      $��15(�5        � 	Resources  5        ShowDetails �� 
TargetName �� TargetProperty g� 	BeginTime W� From  GeneralDuration g� Duration g� DecelerationRatio	 W� To �� ElementName	 �� Path
 �� Mode  HideDetails��%  &	       7  &	 �     7  �� 5   
   .��5      W� $ 
UserWindow��5      $" (FrameworkElement.MaxHeight)�5      $ 0:0:0X�5      $ 60X�5      8   $	 0.9Q�5       5      �� $ 
UserWindow��$	 ActualHeight�$
 OneWay=�5      5      �� 5   
   .��5      W� $ 
UserWindow��5      $" (FrameworkElement.MaxHeight)�5      $ 0:0:0X�5      $ 60X�5    Y   8   $	 0.9Q�5"       5       �� $ 
UserWindow��$	 ActualHeight�$
 OneWay=�5"      5#      5$      .��5&      ]� .+�5'      � $
��Left=�6    � RowDefinitions 5(   
   �� 5)      $
��Auto �6   �� 5*      $��* �6   .+�5,   
   � $��0��6   $��60��6    � ColumnDefinitions 5-      �� 5.      $��70 �6#   �� 5/      $	��180 �6#   �� 50      $��* �6#   �� 51      $	��300 �6#   �� 52      $	��100 �6#   .+�54      �� -   5        $��id��54      $��0��6&   $��1��66   $
��Wrap=�6?   $��Center=�6S   $��Center=�6n     SubMenu2Active#��[ 6�   ��6�   �� $ 
UserWindow��$	 
Foreground��� 55      -   5        $
��code��55      $��1��6(   $��WrapWithOverflow=�68   $��Center=�6X   $��Center=�6s   #��[ 6�   ��6�   �� $ 
UserWindow��$	 
Foreground��� 56      -   5        $��description��56      $��2��6/   $
��10,0q�6?   $��Failed to load data��6M   $
��Wrap=�6h   $��Center=�6|   $
��Left=�6�   #��[ 6�   ��6�   �� $ 
UserWindow��$	 
Foreground��� 57      -   5        $
��date��57      $��3��6(   $
��Wrap=�68   $��Center=�6L   $��Center=�6g   #��[ 6�   ��6�   �� $ 
UserWindow��$	 
Foreground��� 58      -   5        $��4��58      $��Center=�6)   $��50��6_   ��6k   �� $ 
UserWindow��$	 
Foreground���59      �� 5:       �� 
TargetType" ��6    .�5;      ��  �� Property � �� �� Value$ Stretch=�6D   �� 5<       � ��$ Center=�6B   �� 5=       � �� 5>   "   �� 5?   &   .R�5@   *   � $
��Left=�6/   $��Stretch=�6J   .+�5A   .   �� #��z��65   #��z��6q   #��z��6�     Transparent#��[ 6�   A� 5B   .   $��4��66   $��8��6F   $��8��6Q   $��	0,0,-30,0q�6[   #��z��6n   #��z��6�   $��Center=�6�   A� 5C   .   $��4��66   $��8��6F   $��8��6Q   $��0,0,0,0q�6[   #��z��6l   #��z��6�   $��Center=�6�   A� 5D   .   $��4��66   $��8��6F   $��8��6Q   $��0,0,30,0q�6[   #��z��6m   #��z��6�   $��Center=�6�   5E   +   5F   '   5H      5I      5K      5L      � 5M      -   5        $��Details��5M      $��2��6"   $��3��6/   $��Stretch=�6C    5N      �� 5O      $��90 �6'   �� 5P      $
��Auto �6'   �� 5Q      $��* �6'   .+�5S      � $��1��6   $
��Left=�6'   $	��Top=�6B   $	��300��6Z   $
��0,10q�6f    5T      �� 5U      $
��Auto �6+   �� 5V      $
��Auto �6+   .+�5X      � $��0��6    5Y      �� 5Z      $
��Auto �6,   �� 5[      $
��Auto �6,   .+�5]      �� -   5        $��station��5]   1   $��0��6$   $��0��6@     DialDisplay#��[ 6I   $��Center=�6�   ��6n   �� $ 
UserWindow��$	 
Foreground�6�   �� 5^      $��1��6$   $��STATION��61     Desc#��[ 6@   ��6^   �� $ 
UserWindow��$	 
Foreground�5_      � 5`      $��1��6   $��
30,15,10,0q�6+    5a      �� 5b      $��5* �6,   �� 5c      $��5* �6,   �� 5d      $��5* �6,   �� 5e      $��5* �6,   .+�5i      �� -	   5        $��io��5i   1   $��0��6$   $��IO��6;    	 DDActualValue#��[	 6E   ��6l   �� $ 
UserWindow��$	 
Foreground��� 5j      -
   5        $��equipment_description��5j   1   $��1��6$   $�� ��6N   $	��200��6V    
 SubMenu#��[
 6b   $��WrapWithOverflow=�6�   ��6�   �� $ 
UserWindow��$	 
Foreground�6�   5k      5l      � 5m      $��2��6   $��
20,10,0,20q�6'   $
��Left=�6;   .+�5n      &   System.Windows.Controls.DataGrid  -   5        $��Actions��5n   =   $��Stretch=�6     DataGridStyle1#���  6L   ��6v   �� $ 
UserWindow��$	 
Foreground�   Columns 5o      0  *System.Windows.Controls.DataGridTextColumn  5p      ,  &System.Windows.Controls.DataGridColumn   Header$ POSSIBILITIES��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 5q   1   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5p   H   �� *POSSIBILITIES+$
 TwoWay=�   ElementStyle 5r   "   �� 5s   &   .�5t   *   ��  � ��$
 Wrap=�6S   5u   '   5w        5x      $ ACTIONS��61   $	 800 6k    6B   �� *	ACTIONS+$
 TwoWay=� 5y   "   �� 5z   &   .�5{   *   ��  � ��$
 Wrap=�6S   5|   '   5~      4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ STATUS��65   $	 100 6m     DataGridCheckBoxStyle1# [ 5�   1    5   E   �� *STATUS+$
 TwoWay=�5�   1   5�      5�      5�      5�      5�      5�      