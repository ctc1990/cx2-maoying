   M S B A M L   `   `   `  ����G  CCLEANXCEL2.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:CLEANXCEL2._2.DictionariesCLEANXCEL2._2.Dictionaries  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   GeneralDuration  DesiredFrameRate  DesiredDecelerationRatio  SlideInLeft  �� TargetProperty t� From	 t� To g� DesiredFrameRate g� Duration t� EasingFunction4   .System.Windows.Media.Animation.ExponentialEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode  SlideOutRight 
 FadeIn W� From	 W� To	 W� EasingFunction  FadeOut  
FadeInHalf  FadeOutHalf 	 Blur
 �� 
TargetName 

 Unblur�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      2local(clr-namespace:CLEANXCEL2._2.Dictionaries  5      .sys&clr-namespace:System;assembly=mscorlib  5      %�  &	        &	       &	 :     &	 U     7  7   &	 �     7  7   &	 �    7  7   &	 1    7  7   &	 �    7  7   &	 a    7  7   &		 �    7  7   &	
 �    7  7   E�5      0:0:0.25D�61   ��5      30��6-   X�5      0.9Q�67   t� 5
      $  (FrameworkElement.Margin)�5   	   $ 	-20,0,0,0X�5   	   $ 0,0,0,0X�6   8   8   5   
      5      $ EaseIn=�6   5      t� 5      $  (FrameworkElement.Margin)�5   	   $ 0,0,0,0X�5   	   $ 20,0,0,0X�6   8   8   5   
      5      $ EaseOut=�6   5      W� 5      $   (FrameworkElement.Opacity)�5   	   $ 0X�5    	   $ 1X�6   8   8  	 5#   
      5$      $ EaseIn=�6   5&      W� 5(      $   (FrameworkElement.Opacity)�5)   	   $ 1X�5*   	   $ 0X�6   8   8  	 5-   
      5.      $ EaseOut=�6   50      W� 52      $   (FrameworkElement.Opacity)�53   	   $ 0X�54   	   $
 0.92X�6   8   8  	 57   
      58      $ EaseIn=�6   5:      W� 5<      $   (FrameworkElement.Opacity)�5=   	   $
 0.92X�5>   	   $ 0X�6   8   8  	 5A   
      5B      $ EaseOut=�6   5D      W� 5F      $
 
blurEffect��5G   	   $  Radius�5H   	   $ 0X�5I   	   $ 20X�6   8   8  	 5L   
      5M      $ EaseIn=�6   5O      W� 5Q      $
 
blurEffect��5R   	   $  Radius�5S   	   $ 20X�5T   	   $ 0X�6   8   8  	 5W   
      5X      $ EaseIn=�6   5Z      5[      