   M S B A M L   `   `   `  ����G  CCLEANXCEL2.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:CLEANXCEL2._2.UserControlsCLEANXCEL2._2.UserControls  5      ,    &CLEANXCEL2._2.UserControls.RangeSlider   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:CLEANXCEL2._2.UserControls     5      -   5        $��UserControlRangeSlider��5      $	��140��5      $	��0,5q�5
      .��5      � $��Center=�6     � RowDefinitions  5   
   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��9* �6   .+�5   
   � $��2��6   $
��Left=�6#   $��10q�6>   $	��600��6J    5      �� 5      $��3* �6#   �� 5      $��* �6#   �� 5      �� 5      �� 5      $��10 �6#   �� 5      $
��1.3* �6#   �� 5       �� 5!      .+�5#      �� -   5        $��EquipmentLabel��5#   (   $��0��6   $
��Left=�6>   $��nothing��6Y      H4#��[  6h   $
��10,0q�6�   $	��Top=�6�   �� 5$      -   5        $��TBStartTitle��5$   b   $��1��6    	 Label#��[ 6(   $��Start��6G   $
��Auto��6T   $��Center=�6w   $��Center=�6�   �� 5%      -   5        $��TBStart��5%   e   $��2��6     TextBox#��[ 6&   $
��21px(�6G   $
��Auto��6W    �� TextAlignment$ Center=�6�   ��6t   �� *Start+ �� Mode$ TwoWay=�6�   �� 5&      $��3��6     H5#��[ 6(   $��s��6D   $��Center=�6M   �� 5'      -   5        $��TBDurationTitle��5'   e   $��5��6   #��[ 6(   $��Duration��6G   $
��Auto��6W   $��Center=�6|   $��Center=�6�   �� 5(      -   5        $��
TBDuration��5(   e   $��6��6   #��[ 6&   $
��21px(�6G   $
��Auto��6W   $ Center=�6�   ��6w   �� *
Duration+$ TwoWay=�6�   �� 5)      $��7��6   #��[ 6(   $��s��6D   $��Center=�6M   5*      � 5,   
   $��1��6   $��0��6   $��2��6,   $��20q�6@   .+�5-      �� -   5        $"��borderRepeatButtonBackground��5.       �� CornerRadius$ 4,4,4,4��5/      $��0��50      $��0��51        TertiaryColor#��[ 52      $
��Left=�53      $��Center=�54      $��0,0,0,0q�55      $��8��56      �� 58      -   5        $��borderRepeatButtonFill��59      $��0��5:      $ 4,4,4,4��5;        GreenBlueColor#��[ 5<      $��0��5=      $
��Left=�5>      $��Center=�5?      $��8��5@      $��0,0,0,0q�5G      �� 5I      -	   5         ��Name$ LowerSlider��5I      $��0��5J      $��12��5K       � Minimum$ 0Q�5L       � Maximum$	 100Q�5M       �� TickFrequency$ 1Q�5N      	 �� IsSnapToTickEnabled	 .   mySliderStyle1#��[ 5Q      
 �� AutoToolTipPlacement$
 TopLeft=�5S       ^� 	Placement$ Mouse=�5T      $��0,0,0,0q�5V       � Value 5P      �� *Start+$ TwoWay=�5V      �� 5X      -
   5        $ UpperSlider��5X      $��0��5Y      $��12��5Z      $ 0Q�5[      $	 100Q�5\      $ 1Q�5]      	 . #��[ 5`      $
 TopLeft=�5b      $ Mouse=�5c      $��0,0,0,0q�5e       5_      �� *End+5e   *   5f      5g      5h      