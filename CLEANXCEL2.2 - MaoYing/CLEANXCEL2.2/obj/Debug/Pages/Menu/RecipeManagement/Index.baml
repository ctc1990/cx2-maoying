   M S B A M L   `   `   `  ����G  CCLEANXCEL2.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:CLEANXCEL2._2.Pages.Menu.RecipeManagement)CLEANXCEL2._2.Pages.Menu.RecipeManagement  5      5    /CLEANXCEL2._2.Pages.Menu.RecipeManagement.Index   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ilocal7clr-namespace:CLEANXCEL2._2.Pages.Menu.RecipeManagement     5      -   5          N� Title$  Index��5
       � 	Resources 5         	ShowFrame �� 
TargetName �� TargetProperty t� From	 t� To  GeneralDuration g� Duration g� DecelerationRatio W� From		 W� To  	HideFrame
 g� 	BeginTime��%�  &	        7  7  &	 I    7  7  �� 5   
   .��5      t� $ FrameLocalContainer��5      $ (FrameworkElement.Margin)�5      $ 	-20,0,0,0X�5      $ 0,0,0,0X�6"   8   $	 0.9Q�5      W� 5      $ FrameLocalContainer��5      $  (FrameworkElement.Opacity)�5      $ 0X�5      $	 1X�6   8  $	 0.9Q�5      5      �� 5   
   .��5      t� $ FrameLocalContainer��5      $ (FrameworkElement.Margin)�5       $
 00:00:00X�5!      $ 0,0,0,0X�6&   $ 20,0,0,0X�65   8   $	 0.9Q�5#      W� 5%      -   5        $ FrameLocalContainer��5&      $  (FrameworkElement.Opacity)�5'      $
 00:00:00X�5(      $ 1X�6&   $	 0X�6/   8  $	 0.9Q�5*      6)   5+      5-       � Triggers 5/      :� 50   
    :� RoutedEvent$ Window.Loaded��6   .[�52      �� .��53      �� .��55      t� $ SubPageHeader��56      $ (FrameworkElement.Margin)�57      $
 00:00:00X�58      $ 	-20,0,0,0X�59      $ 0,0,0,0X�6*   # [ 5:       t� EasingFunction 5;      4  .System.Windows.Media.Animation.ExponentialEase  5<      7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode$ EaseOut=�6.   5>      W� 5@      $ SubPageHeader��5A      $  (FrameworkElement.Opacity)�5B      $
 00:00:00X�5C      $ 0X�5D      $	 1X�6"   # [ 5E       W� EasingFunction 5F        5G      $ EaseOut=�6.   5I      t� 5L      $ RBPart��5M      $ (FrameworkElement.Margin)�5N      $
 00:00:00X�5O      $ 	150,0,0,0X�5P      $ 0,0,0,0X�6*   # [ 5Q       5R        5S      $ EaseOut=�6.   5U      W� 5W      $ RBPart��5X      $  (FrameworkElement.Opacity)�5Y      $
 00:00:00X�5Z      $ 0X�5[      $	 1X�6"   # [ 5\       5]        5^      $ EaseOut=�6.   5`      t� 5b      $ RBRecipe��5c      $ (FrameworkElement.Margin)�5d      $
 
00:00:00.5X�5e      $ 	150,0,0,0X�5f      $ 0,0,0,0X�6*   # [ 5g       5h        5i      $ EaseOut=�6.   5k      W� 5m      $ RBRecipe��5n      $  (FrameworkElement.Opacity)�5o      $
 
00:00:00.5X�5p      $ 0X�5q      $	 1X�6"   # [ 5r       5s        5t      $ EaseOut=�6.   5v      t� 5x      $ 	RBProcess��5y      $ (FrameworkElement.Margin)�5z      $
 
00:00:01.0X�5{      $ 	150,0,0,0X�5|      $ 0,0,0,0X�6*   # [ 5}       5~        5      $ EaseOut=�6.   5�      W� 5�      $ 	RBProcess��5�      $  (FrameworkElement.Opacity)�5�      $
 
00:00:01.0X�5�      $ 0X�5�      $	 1X�6"   # [ 5�       5�        5�      $ EaseOut=�6.   5�      t� 5�      $ RBSubProcess��5�      $ (FrameworkElement.Margin)�5�      $
 
00:00:01.5X�5�      $ 	150,0,0,0X�5�      $ 0,0,0,0X�6*   # [ 5�       5�        5�      $ EaseOut=�6.   5�      W� 5�      $ RBSubProcess��5�      $  (FrameworkElement.Opacity)�5�      $
 
00:00:01.5X�5�      $ 0X�5�      $	 1X�6"   # [ 5�       5�        5�      $ EaseOut=�6.   5�      t� 5�      $ RBUploadDownload��5�      $ (FrameworkElement.Margin)�5�      $
 
00:00:02.0X�5�      $ 	150,0,0,0X�5�      $ 0,0,0,0X�6*   # [ 5�       5�        5�      $ EaseOut=�6.   5�      W� 5�      $ RBUploadDownload��5�      $  (FrameworkElement.Opacity)�5�      $
 
00:00:02.0X�5�      $ 0X�5�      $	 1X�6"   # [ 5�       5�        5�      $ EaseOut=�6.   5�      5�      5�      5�      .��5�      �  � ColumnDefinitions 5�   
   �� 5�      $��* �6   �� 5�        DimGridSubMenu#��[ 6    � RowDefinitions 5�   
   �� 5�      $��* �6   .+�5�   
   ]� -   5         ]�Name$ SubMenuPanel��5�      $��Center=�5�      $��Center=�5�      $��1��5�      $��0��6    J� RenderTransformOrigin$ 1,0.5&�5�      .+�5�      �  5�      �� 5�      #��[ 6'    5�      �� 5�      $��* �6$   �� 5�      $��80 �6$   �� 5�      $��80 �6$   �� 5�      $��80 �6$   �� 5�      $��80 �6$   �� 5�      $��80 �6$   �� 5�      $��* �6$   .+�5�      	� -   5         	�Name$ RBPart��5�      $��1��5�      $��0��6"   $
��Part��5�        	RBSubMenu#��[ 5�       J� Opacity$ 0Q�5�       	� 	GroupName$ RecipeManagementMenu��5�      5�      	� 5�      -   5        $ RBRecipe��5�      $��2��5�      $��0��6"   $��Recipe��5�      #��[ 5�      $ 0Q�5�      $ RecipeManagementMenu��5�      5�      	� 5�      -   5        $ 	RBProcess��5�      $��3��5�      $��0��6"   $��Process��5�      #��[ 5�      $ 0Q�5�      $ RecipeManagementMenu��5�      5�      	� 5�      -   5        $ RBSubProcess��5�      $��4��5�      $��0��6"   $��Sub Process��5�      #��[ 5�      $ 0Q�5�      $ RecipeManagementMenu��5�      5�      	� 5�      -   5        $ RBUploadDownload��5�      $��5��5�      $��0��6"   $��Upload/Download��5�      #��[ 5      $ 0Q�5     $ RecipeManagementMenu��5     5     5     5     � 5	  
   $��0��6   $��0��6    5
     �� 5     $��* �6#    5     �� 5     $��80��6    �� 5     .+�5     �� -	   5         ��Name$ SubPageHeader��5     $��0��5     $��0��6   .+�5     �� -
   5        $��	PageTitle��5       
PageHeader#��[ 5     $��Recipe Management��5     �� 5     -   5        $��PageDescription��5       PageDesc#��[ 5     $3��-Create and modify processes and part recipes.��5     5     �� 5     $��1��6   $��0��6"   ._�5      � -   5          �Name$ FrameLocalContainer��5       � NavigationUIVisibility$ Hidden=�5     $ 0Q�5     6!   5      5!     5#     5$     