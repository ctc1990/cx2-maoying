   M S B A M L   `   `   `  ����G  CCLEANXCEL2.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CLEANXCEL2._2.Pages.UserCLEANXCEL2._2.Pages.User  5      $    CLEANXCEL2._2.Pages.User.Index   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:CLEANXCEL2._2.Pages.User     5      [ WSharpVectors.Runtime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=d16e717f0a981fb93svg)http://sharpvectors.codeplex.com/runtime/  5      ^ ZSharpVectors.Converters, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b532964b8548be771svgc&http://sharpvectors.codeplex.com/svgc/  5      -   5          N� Title$  Index��5       � 	Resources 5         	ShowFrame �� 
TargetName �� TargetProperty t� From	 t� To  GeneralDuration g� Duration g� DecelerationRatio W� From		 W� To  	HideFrame
 g� 	BeginTime��%�  &	        7  7  &	 I    7  7  �� 5   
   .��5      t� $ FrameLocalContainer��5      $ (FrameworkElement.Margin)�5      $ 	-20,0,0,0X�5      $ 0,0,0,0X�6"   8   $	 0.9Q�5      W� 5      $ FrameLocalContainer��5      $  (FrameworkElement.Opacity)�5      $ 0X�5      $	 1X�6   8  $	 0.9Q�5      5      �� 5   
   -   5        .��5       t� $ FrameLocalContainer��5!      $ (FrameworkElement.Margin)�5"      $
 00:00:00X�5#      $ 0,0,0,0X�6&   $ 20,0,0,0X�65   8   $	 0.9Q�5%      W� 5'      $ FrameLocalContainer��5(      $  (FrameworkElement.Opacity)�5)      $
 00:00:00X�5*      $ 1X�6&   $	 0X�6/   8  $	 0.9Q�5,      5-      5/       � Triggers 51      :� 52   
    :� RoutedEvent$ Window.Loaded��6   .[�54      �� .��55      �� .��57      t� $
 Logo��58      $ (FrameworkElement.Margin)�59      $
 00:00:00X�5:      $ 	-20,0,0,0X�5;      $ 0,0,0,0X�6*   # [ 5<       t� EasingFunction 5=      4  .System.Windows.Media.Animation.ExponentialEase  5>      7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode$ EaseOut=�6.   5@      W� 5B      $
 Logo��5C      $  (FrameworkElement.Opacity)�5D      $
 00:00:00X�5E      $ 0X�5F      $	 1X�6"   # [ 5G       W� EasingFunction 5H        5I      $ EaseOut=�6.   5K      t� 5N      $ RBSignIn��5O      $ (FrameworkElement.Margin)�5P      $
 00:00:00X�5Q      $ 	150,0,0,0X�5R      $ 0,0,0,0X�6*   # [ 5S       5T        5U      $ EaseOut=�6.   5W      W� 5Y      $ RBSignIn��5Z      $  (FrameworkElement.Opacity)�5[      $
 00:00:00X�5\      $ 0X�5]      $	 1X�6"   # [ 5^       5_        5`      $ EaseOut=�6.   5b      t� 5d      $ RBRegistration��5e      $ (FrameworkElement.Margin)�5f      $
 
00:00:00.5X�5g      $ 	150,0,0,0X�5h      $ 0,0,0,0X�6*   # [ 5i       5j        5k      $ EaseOut=�6.   5m      W� 5o      $ RBRegistration��5p      $  (FrameworkElement.Opacity)�5q      $
 
00:00:00.5X�5r      $ 0X�5s      $	 1X�6"   # [ 5t       5u        5v      $ EaseOut=�6.   5x      t� 5z      $ 
RBPassword��5{      $ (FrameworkElement.Margin)�5|      $
 00:00:01X�5}      $ 	150,0,0,0X�5~      $ 0,0,0,0X�6*   # [ 5       5�        5�      $ EaseOut=�6.   5�      W� 5�      $ 
RBPassword��5�      $  (FrameworkElement.Opacity)�5�      $
 00:00:01X�5�      $ 0X�5�      $	 1X�6"   # [ 5�       5�        5�      $ EaseOut=�6.   5�      5�      5�      5�      .��5�      �  � ColumnDefinitions 5�   
   �� 5�      $��* �6   �� 5�        DimGridSubMenu#��[ 6    � RowDefinitions 5�   
   �� 5�      $��* �6   .+�5�   
   ��  �� Padding$ 30q�6   ._�5�      ]� -   5         ]�Name$
 Logo��5�       J� Opacity$ 0Q�5�       K� ZIndex$	 100��5�      $	��500��5�      $	��Top=�5�      $
��Left=�5�      $��0��5�      $��0��6!   .+�5�      (  "SharpVectors.Converters.SvgViewbox     Source$$ ../../Images/Logos/logo_CX.svg?�6"   5�      5�      ]� 5�   
   -   5        $ 	FormPanel��5�      $ 10��5�      $��Center=�5�      $��Center=�5�      $��0��5�      $��0��6    J� RenderTransformOrigin$ 0,0.5&�5�      .+�5�      �� ._�5�       � -   5          �Name$ FrameLocalContainer��5�        � NavigationUIVisibility$ Hidden=�5�      $ 0Q�5�      5�      5�      �� 5�   
   -   5         ��Name$ CbxMainLanguage��5�      $��1��5�      $��40��5�      $	��Top=�5�      $��	0,40,40,0q�5�        ComboBoxFlatStyle#��[ 5�       �� SelectedIndex$ 0��5�      .@�5�      �� .��6   	English6$   �� 5�      .��6   中文 (简体)6$   �� 5�      {�.  .��6-   	Français67   �� 5�      {�.  .��6-   
Deutsche67   �� 5�      {�.  .��6-   	日本語62   5�      ]� 5�   
   -   5        $ SubMenuPanel��5�      $��Center=�5�      $��Center=�5�      $��1��5�      $��0��6   $ 1,0.5&�5�      .+�5�      �  5�      �� 5�      #��[ 6'    5�      �� 5�      $��* �6$   �� 5�      $��80 �6$   �� 5�      $��80 �6$   �� 5�      $��80 �6$   �� 5�      $��* �6$   .+�5�      	� -   5         	�Name$ RBSignIn��5�      $��1��5�      $��0��6"   $��Sign In��5�        	RBSubMenu#��[ 5�      $ 0Q�5�       	� 	GroupName$
 Menu��5�       d� 	IsChecked$ FalseY�5�      5�      	� 5�      -	   5        $ RBRegistration��5�      $��2��5�      $��0��6"   $��Registration��5�      #��[ 5�      $ 0Q�5�      $
 Menu��5�      5�      	� 5�      -
   5        $ 
RBPassword��5�      $��3��5�      $��0��6"   $��Password Recovery��5�      #��[ 5�      $ 0Q�5�      $
 Menu��5�      5�      5�      5�      5�      5�      