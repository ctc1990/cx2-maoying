   M S B A M L   `   `   `  ����G  CCLEANXCEL2.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:CLEANXCEL2._2.Pages.Menu.AlarmCLEANXCEL2._2.Pages.Menu.Alarm  5      1    +CLEANXCEL2._2.Pages.Menu.Alarm.HistoryAlarm   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:CLEANXCEL2._2.Pages.Menu.Alarm     5      -   5          N� Title$  HistoryAlarm��5      .��5      � $��30q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � -   5        $��Title��5         LightGreyColor#��[  6   $��0��6I   $��
-30,50,0,0q�6V    � ColumnDefinitions 5      �� 5      $��70 �6#   �� 5      $	��180 �6#   �� 5      $��* �6#   �� 5      $	��300 �6#   �� 5      $	��100 �6#   .+�5      d� -   5        $��ID��5   +   $��0��6   $��ID��65   $��Center=�6B    ! DataGridMainColumnHeaderStyle#��[ 6_    � Cursor$
 Hand��6�   d� 5      -   5        $
��Code��5   +   $��1��6   $��
ALARM CODE��67   $��Center=�6L   #��[ 6i   $
 Hand��6�   d� 5      -   5        $��Description��5   +   $��2��6   $��DESCRIPTION��6>   #��[ 6T   $
��Left=�6�   $
 Hand��6�   d� 5      -   5        $��Datetime��5   +   $��3��6   $��	DATE/TIME��6;   $��Center=�6O   #��[ 6l   $
 Hand��6�   5      �� 5    
   -   5        $��1��5       $��	-30,0,0,0q�6$     StandardScrollViewer#���  67   $
��Auto=�5!      $��Disabled=�6:    �� PanningMode$ VerticalOnly=�5"      .��5#      �� -   5        $��
AlarmStack��5#      $	��Top=�6+   $��Stretch=�6C     TertiaryColor#��[ 6a   6�   5$      5%      5&      