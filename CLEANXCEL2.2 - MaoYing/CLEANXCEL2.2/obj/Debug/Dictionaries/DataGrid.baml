   M S B A M L   `   `   `  ����G  CCLEANXCEL2.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:CLEANXCEL2._2.DictionariesCLEANXCEL2._2.Dictionaries  5      a ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes 6L   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   DataGridCheckBoxStyle1  �� 
TargetType �� Property 
 CWhite �� Value  AlarmPinkH3 �� 
TargetType �� Orientation (� Stretch F�Name �� Stretch �� Triggers	 P� Property
 P� Value �� 
TargetName  DataGridColumnHeaderStyle1=   7System.Windows.Controls.Primitives.DataGridColumnHeader  AlarmPinkH1 
 Roboto  DataGridRowStyle1)  #System.Windows.Controls.DataGridRow:  4System.Windows.Controls.Primitives.DataGridRowHeader  AlarmPinkH2 ��Name �� CornerRadius J� SnapsToDevicePixels?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid � ColumnDefinitions � RowDefinitions?  9System.Windows.Controls.Primitives.DataGridCellsPresenter   
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter   DetailsVisibility$   SelectiveScrollingOrientation;  5System.Windows.Controls.SelectiveScrollingOrientation   Vertical �� ConverterParameter&   System.Windows.Controls.DataGrid#   RowDetailsScrollingConverter �� 	Converter �� RelativeSource �� AncestorType7  1System.Windows.Controls.DataGridHeadersVisibility
   Row!   HeadersVisibilityConverter �� Triggers  DataGridCellStyle1*	  $System.Windows.Controls.DataGridCell ��Name 	 DataGridStyle1 �� Padding ��NameG
  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter  
 Name!   Column" ��Name# �� CanContentScroll$ ��Name% �� ScrollableHeight& � Maximum' �� Orientation*( �� #ComputedVerticalScrollBarVisibility) �� ViewportHeight* �� ViewportSize+ � Value, �� Mode- ]� 
Conditions. �� Property/ �� Value 
 ButtonFocusVisual30 �� StrokeDashArray ! DataGridMainColumnHeaderStyle  Transparent  PrimaryColor1 ��Name�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      2local(clr-namespace:CLEANXCEL2._2.Dictionaries  5      UThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero  6L   %�  &	        7  7  &	 i    7  7  7  &	 B    7  &	 �    7  &		 
    7  7  7  7  &	
 l    &	     7 
 7  7  7  7  �� 5      "  ��6+   .�5   
   ��  � ��8   6'   �� 5   
    � ��8  6'   �� 5   
    � �� 5	      �� 5
      " ��6"   .R�5      �� .��5      �� $ 
Horizontal=�6%   .+�5      (� $
��Left=�6&   $��Center=�5   !   $
 Fill=�5   !   $��30��5   !   $��30��5   !   $��10,0,0,0q�6,   .��5   "   � $	��200��6'   $	��200��64   .+�5   &   �� $	��100��5   )   $	��100��5   )   #��z��5   )   F� 5   &   $
 tick��5   )   #��z��5   )   
������ $
 None=�5   )   $y�Hidden=�5   )   $��20��5   )   "���Ѐ�� ��� �� ;X� h�	 ��	$��0,0,2,2q�5   K   5   #   5       �� 5!      #��z��6(   $��10,0,0,0q�6I   5"      5#       5$      P� 5%      	 �@d�	IsChecked$

 TrueY�67   . �5&      �� $
 tick��6;    � y�$ Visible=�6M   5'      5*      5,      5-      �� 5/      "    6/   .�50   
   ��  � ��8   6'   �� 51   
    � ��8  6'   �� 52   
    � ��8  6'   �� 53   
    � ��$ Stretch=�60   �� 54   
    � ��$ 
10,15,0,15q�6$   55      �� 57      "   6&   .�58   
   ��  �@ HeaderStyle 59      �� 5:      "   6   .�5;      ��  � y�$ 	Collapsed=�63   �� 5<       � ��$ 0��6.   5=      5?      �� 5@   
    � ��8   6'   �� 5A   
    �@J�SnapsToDevicePixels . 60   �� 5B   
    �@=�ErrorTemplate 65   Z� �� 5C   
    � �� 5D      �� 5E      "  6"   .R�5F      �� $ 
DGR_Border��6   $��1q�61   $ 5��6E   #��z��6V    . ._�5G         5H      �� 5I   "   $
��Auto �63   �� 5J   "   $��* �63   .+�5L      � $��1��6#    5M   "   �� 5N   &   $��* �64   �� 5O   &   $
��Auto �64   .+�5Q   "     #��z 69   # z 6c     5R   "   $��4q�6;   $��1��6F   #y�z 6j   6S   �� *AreRowDetailsFrozen+# Z # Z  �� "  6j  �� 5T   "   #��z��6)   #��z��6U   $��2��6�   5U        5V      $ Vertical=�60   y�6p   �� *HeadersVisibility+# Z # Z  �� "  5W      5X      5Y      5[       5\   
   P� 5]      	 �@ DetailsVisibility$
 Visible=�63   . �5^      ��  � ��$ 4,1,4,4q�64   �� 5_       � �� �	#FF3886B960   5`      5b      �� 5e      "  	 6'   .�5f   
   ��  � ��8   6'   �� 5g   
    � ��
 ���� 6'   �� 5h   
    � ��$ 10,5,0,5q�6#   �� 5i   
    � �� 5j      �� 5k      " 	 6"   .R�5l      �� $ border��6    �� 61   .F�5m      �� 5n      6/   5o      5q      5r      �� 5t      "   6#   .�5u   
   ��  �@ ColumnHeaderStyle8   6.   �� 5v   
    �@ RowStyle8  6%   �� 5w   
    �@ 	CellStyle8  6&   �� 5x   
    �@ CanUserAddRows .  6+   �� 5y   
    �@ AutoGenerateColumns .  60   �� 5z   
    �@ GridLinesVisibility$
 None=�60   �� 5{   
    � ��8  6'   �� 5|   
    � ��# � ��6'   �� 5}   
    � ��$ 0q�6,   �� 5~   
    � ��$
 Left=�60   �� 5   
    � ��$ Stretch=�6.   �� 5�   
     �@ RowDetailsVisibilityMode$ VisibleWhenSelected=�65   �� 5�   
    � �� . 6:   �� 5�   
    �@��PanningMode$
 Both=�65   �� 5�   
    �@��IsFlicksEnabled .  63   �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      �� #��z��6   #��z��6I   #��z��6}   # z��6�    . ._�5�      �� $ DG_ScrollViewer��6'   |�.  ��5�      �� 5�   "   " ��62   .R�5�   &   �  5�   *   �� 5�   .   $
��Auto �6?   �� 5�   .   $
��Auto �6?   �� 5�   .   $
��Auto �6?    5�   *   �� 5�   .   $
��Auto �6<   �� 5�   .   $��* �6<   �� 5�   .   $
��Auto �6<   .+�5�   *   
  $!  PART_ColumnHeadersPresenter��6I   $��0��6n   y�6~   �� *HeadersVisibility+# Z! # Z  �� "  �� 5�   *   $!" PART_ScrollContentPresenter��6A   ## z��6f   $��2��6�   $��1��6�   �� 5�   *   $$ PART_VerticalScrollBar��64   $��2��6T   #& z% 6d   $' Vertical=�6�   $��1��6�   #y�z( 6�   #* z) 6W  + 6�   �� *VerticalOffset+$, OneWay=� �� *TemplatedParent+6W  5�   '   5�   #   .��5�      �� # z 6-   5�      5�      5�      5�       5�   
   ]� 5�      - 5�      �� 5�      . �@��
IsGrouping/ . 66   �� 5�      ". �@%�IsVirtualizingWhenGrouping/ .  6X   ./�5�      ��  � �� .  6B   5�      5�      �� 5�      .�5�   
   ��  � �� 5�      �� 5�      .R�5�      �� $	0 1 2R�6    $��1��66   #��� ��6J    . $��2q�6�   5�      5�      5�      �� 5�      "  d�62   .�5�   
   ��  �@�FocusVisualStyle8   6-   �� 5�   
    � ��8  6'   �� 5�   
    � ��8  6(   �� 5�   
    � ��$ 1q�6,   �� 5�   
    � ��8  6'   �� 5�   
    � ��$
 21px(�6%   �� 5�   
    � ��8  6'   �� 5�   
    � ��$ Center=�67   �� 5�   
    � ��$ Center=�65   �� 5�   
    � ��$ 1q�6$   �� 5�   
    � �� 5�      �� 5�      " d�6"   .R�5�      �  5�      �� 5�      $
��Auto �6/   �� 5�      .+�5�      �� $ border��6!   $��0��61   $��10q�6A   #��z��6M   #��z��5�   !   #��z��6d    . ._�5�      �� $1 contentPresenter��6/   |�.  #��z��6[   ��. # z 6�   #��z��5�   /   #��z��6r   5�      F� 5�      $��1��6   $��1��6/   
���   �+���Ѐ�� ��� �        Ѐ�� ��� � -1    	$��Center=�6t   5�       5�      P� 5�      	 �@J�IsKeyboardFocused
 . 5�      P� 5�      	 �@d�	IsChecked$

 trueY�67   5�      P� 5�      	 � {�
 .  . �5�      ��  � �� �#ADADAD6;   5�      5�      5�      5�      5     