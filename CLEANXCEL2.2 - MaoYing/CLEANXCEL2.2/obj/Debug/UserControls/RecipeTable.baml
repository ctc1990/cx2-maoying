   M S B A M L   `   `   `  ����G  CCLEANXCEL2.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:CLEANXCEL2._2.UserControlsCLEANXCEL2._2.UserControls  5      ,    &CLEANXCEL2._2.UserControls.RecipeTable   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:CLEANXCEL2._2.UserControls     5      -   5          >�Name$  userControl��5      $
��Left=�5      $	��0,5q�5
      $	��220��5      $
��1080��5         PrimaryColor#��[  5      $��1q�5      .��5      � #��[  6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� -   5        $��title��5      $��
20,20,20,0q�6!     H3#��[ 65    
 CWhite#��[ 6�   ��6Q   �� *Title+ �� ElementName$ userControl��6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��	0,10,60,0q�6.   $��Right=�6A   $	��Top=�6]   .+�5      �� -   5        $��TBProcessTimeTitle��5   5   $��0��6   $��0��6%    	 Label#��[ 6O   $��Process Time��6n   $��0,0,10,0q�6�   �� 5      -   5        $��TBProcessTime��5   5   $��0��6   $��1��6%   #��[ 6J   $��0,0,10,0q�6�   $��50��6�    �� TextAlignment$ Center=�6�   ��6i   �� *ProcessTime+$ userControl�� �� Mode$ TwoWay=�6�   �� 5      $��0��6   $��2��6%   #��[ 65   $��s��6T   $��Center=�6]   5      �� 5   
   -   5        $��Protect_DeleteButton��5      $��0��5      $��50��5      $��Right=�5         CustomDeleteButton#��[ 5!      5#      � 5$   
   $��1��6   $��
20,0,20,40q�6    5%      �� 5&      $��* �6     � ColumnDefinitions 5*      �� 5+      $
��1.2* �6#   �� 5,      $
��1.0* �6#   �� 5-      $
��1.0* �6#   �� 5.      $
��1.2* �6#   �� 5/      $
��1.0* �6#   �� 50      $
��1.0* �6#   .+�56      �� -   5        $��TBPowerTitle��56   5   $��0��6   $��0��6%   #��[ 6I   $��Ultrasonic Power��6h   �� 57      -   5        $��TBPower��57   3   $��0��6   $��1��6#     H7#��[ 6B   ��6^   �� *Power+$ userControl��$ TwoWay=��� 58      $��0��6   $��2��6%     H5#��[ 65   $��%��6Q   $��Center=�6Z   �� 59      -   5        $��TBFrequencyTitle��59   5   $��0��6   $��3��6%   #��[ 6M   $��Ultrasonic Frequency��6l   �� 5;      -	   5        $��TBFrequency��5;   4   $��0��6   $��4��6$     ComboBoxFlatStyle#��[ 6G   $
��42px(�6r   $��80��6�   #��[  5<      #��[ 6B   $��Center=�6g   $	��120��5=   X    �� Text 6   �� *	Frequency+$ userControl��$ TwoWay=�.@�5>      �� .��6   406#   �� 5@      .��6   1326$   5A      �� 5B      $��0��6   $��5��6%   #��[ 65   $	��kHz��6Q   $��Center=�6\   5H      5K      5L      