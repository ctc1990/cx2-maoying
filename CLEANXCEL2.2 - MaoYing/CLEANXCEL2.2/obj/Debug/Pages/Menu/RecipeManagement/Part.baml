   M S B A M L   `   `   `  ����G  CCLEANXCEL2.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:CLEANXCEL2._2.Pages.Menu.RecipeManagement)CLEANXCEL2._2.Pages.Menu.RecipeManagement  5      4    .CLEANXCEL2._2.Pages.Menu.RecipeManagement.Part   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ilocal7clr-namespace:CLEANXCEL2._2.Pages.Menu.RecipeManagement     5      -   5          N� Title$
  Part��5
      .��5      � $��
0,30,30,30q�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   � $��0��6   $��0q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      .+�5      �� -   5        $��TBRegisteredPart��5   %   $��0��6      H1#��[  6=   $��Registered Part��6Y   $
��Left=�6p   �� 5      $��1��6   $��0,50,0,0q�6(   $	��420��6:     StandardScrollViewer#��[ 5       �� PanningMode$ VerticalOnly=�6H   $
��Auto=�5      $��Disabled=�6:   .��5      �� -   5        $��PartList��5      5      5      � 5!   
   $��1��6   $��	70,10,0,0q�6    5"      �� 5#      $
��Auto �6    �� 5$      $
��Auto �6    �� 5%      $��* �6     5'      �� 5(      $��4* �6#   �� 5)      $��6* �6#   .+�5+      �� -   5        $��TBPartNameTitle��5+      $��0��6/   $��0��6<   $��	Part Name��6L   $	��350��6]     H3#��[ 6i   $
��Left=�6�   �� 5,      -   5        $��
TBPartName��5,   4   $��1��6   $��0��6#     TextBox#��[ 6F   $	��350��6g   $
��Left=�6s   �� 5-      $��2��6   $��0��6&   $��2��66   .+�5.      �� -   5        $��TBDescriptionTitle��5.      $��Description��66   #��[ 6I   $��0,20,0,0q�6e   �� 5/      -   5        $��TBDescription��5/      #��[ 6/   $��0,10,0,0q�6P   �� 50      -   5        $��TBRecipeIDTitle��50      $��	Recipe ID��63   #��[ 6D   $��0,20,0,0q�6`   �� 51      -	   5        $��
CBRecipeID��51        ComboBoxFlatStyle#��[ 6-   $��0,10,0,0q�6X   �� 52      -
   5        $��TBBatchNoTitle��52      $��Batch No��62   #��[ 6B   $��0,20,0,0q�6^   �� 53      -   5        $��	TBBatchNo��53      #��[ 6+   $��0,10,0,0q�6L   �� 55      $��0��6   $��2��6*   $��2��6:    �� Orientation$ 
Horizontal=�6K   $��Right=�6d   .+�57      �� -   5        $
��Save��57      $��0��6)   $��2��66   $��2��6F     StandardButton#��[ 6W   $
��Save��6   $	��Top=�6�   $��Right=�6�   $��20q�6�   6�   �� 59      -   5        $��Delete��59      $��0��6+   $��2��68   $��2��6H   #��[ 6Y   $��Delete��6�   $	��Top=�6�   $��Right=�6�   $��20q�6�   6�   5;      5<      5=      5>      5?      