   M S B A M L   `   `   `  ����D  @SmartEdir, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SmartEdir	SmartEdir  5   	       SmartEdir.WindowAdmin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:SmartEdir     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5        $	��650��5	   R   $
��1024��6_     � WindowStyle$
  None=�6l    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ NoResize=�6�   '  !System.Windows.Shell.WindowChrome   WindowChrome 5
        5   
      CaptionHeight$ 0Q�6    � 	Resources 5         OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime	 O� Value  	CloseMenu��%�  &	        &	 �    �� 5   
   .��5      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ GridMain��6�   .\�5        $ 0��6'   $	 0Q�63     5      $ 0:0:0.5��6'   $		 250Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ GridMain��6�   .\�5        $ 0��6'   $	 0Q�63     5      $ 0:0:0.5��6'   $	 50Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ StackPanelMenu��6�   .\�5        $ 0��6'   $	 0Q�63     5      $ 0:0:0.5��6'   $		 250Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ listViewItemMember��6�   .\�5        $ 0��6'   $
	 -250Q�63     5      $ 0:0:0.5��6'   $
	 -250Q�69     5      $ 0:0:0.7��6'   $	 0Q�69   5      U� 5       $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ listViewItemMaterial��6�   .\�5!        $ 0��6'   $
	 -250Q�63     5"      $ 0:0:0.5��6'   $
	 -250Q�69     5#      $ 0:0:0.9��6'   $	 0Q�69   5$      U� 5%      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ listViewItemMaintenance��6�   .\�5&        $ 0��6'   $
	 -250Q�63     5'      $ 0:0:0.5��6'   $
	 -250Q�69     5(      $ 0:0:1.1��6'   $	 0Q�69   5)      U� 5*      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ listViewItemEvent��6�   .\�5+        $ 0��6'   $
	 -250Q�63     5,      $ 0:0:0.5��6'   $
	 -250Q�69     5-      $ 0:0:1.3��6'   $	 0Q�69   5.      U� 5/      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ listViewItemPayment��6�   .\�50        $ 0��6'   $
	 -250Q�63     51      $ 0:0:0.5��6'   $
	 -250Q�69     52      $ 0:0:1.5��6'   $	 0Q�69   53      U� 54      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ listViewItemFacility��6�   .\�55        $ 0��6'   $
	 -250Q�63     56      $ 0:0:0.5��6'   $
	 -250Q�69     57      $ 0:0:1.7��6'   $	 0Q�69   58      U� 59      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ listViewItemChat��6�   .\�5:        $ 0��6'   $
	 -250Q�63     5;      $ 0:0:0.5��6'   $
	 -250Q�69     5<      $ 0:0:1.9��6'   $	 0Q�69   5=      U� 5>      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $ button��6�   .\�5?        $ 0��6'   $	 0Q�63     5@      $ 0:0:0.5��6'   $	 0Q�69     5A      $ 0:0:1.5��6'   $	 1Q�69   5B      U� 5C      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $ button��6�   .\�5D        $ 0��6'   $	 0Q�63     5E      $ 0:0:0.5��6'   $	 0Q�69     5F      $ 0:0:1.5��6'   $	 1Q�69   5G      5H      �� 5I   
   .��5J      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ GridMain��6�   .\�5K        $ 0��6'   $		 250Q�63     5L      $ 0:0:0.5��6'   $	 0Q�69   5M      U� 5N      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ GridMain��6�   .\�5O        $ 0��6'   $	 50Q�63     5P      $ 0:0:0.5��6'   $	 0Q�69   5Q      U� 5R      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ StackPanelMenu��6�   .\�5S        $ 0��6'   $		 250Q�63     5T      $ 0:0:0.5��6'   $	 0Q�69   5U      5V      5W      
 � Triggers
 5X      :� 5Y   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ ButtonOpenMenu��66   .[�5Z      �� #��[  6   5[      :� 5\   
   $ ButtonBase.Click��6   $ ButtonCloseMenu��66   .[�5]      �� -   5         ��Name$ CloseMenu_BeginStoryboard��5]      #��[ 6A   5^      .��5`      � .+�5a   
   ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TrainsitionigContentSlide��5a   .   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6Q   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:1.4X�.��5b      � ���#7c0426.+�5c      �� -   5         ��Name$ StackPanelMenu��5c      $	��250��65   $
��Left=�6A   $��
-250 0 0 0q�6\    J� RenderTransformOrigin$ 0.5,0.5&�6p   z�5d      V� 5e      .~�5f      �� �� 5g      �� 5h      T� 5i      5j      .+�5l      ��  �� Orientation$ 
Horizontal=�6!   $	��Top=�6:   $	��100��6R   $��Center=�6_   .+�5m      ��  0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6!   $��0q�6�   $��50��6�   $��50��6�   $��10q�6�   ��6g   Z� ��6}   Z� .��5n      '  !MaterialDesignThemes.Wpf.PopupBox     PlacementMode$ BottomAndAlignRightEdges=�66      	StaysOpen .  $��40��6q   $��40��6|      PopupContent. 5o   "   �� $	��150��6-   .+�5p   &   �� -   5        $��AddAccountButton��5p   -   $��Add Account��6E   6[   �� 5q   &   -   5        $��ProfileButton��5q   -   $��Profile��6B   6T   �� 5r   &   -   5        $��LogoutButton��5r   -   $��Logout��6A   6R   5s   #   5t      5u      �� 5v      -   5         ��Name$ button��5v   !   #��[ 61   $��0q�6�   $��80��6�   $��80��6�   $��10q�6�   $ 0.5,0.5&�6�   ��6w   Z� z�5w      V� 5x   "   .~�5y   &   �� �� 5z   &   �� 5{   &   T� 5|   &   5}   #   ��5      �� 5�   "   -	   5        ProfileImage�� �� ImageSource$% Assets/pexels-photo-247885.jpeg��5�   C    j� Stretch$ UniformToFill=�6q   5�      �� 5�      -
   5        $��Notification��5�   5   $y�Hidden=�6!   #��[ 6I   $��0q�6�   $��50��6�   $��50��6�   $��10q�6�   ��6�   Z� ��6�   Z� .��5�      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ Notifications=�66   $��20��6K   $��20��6V   5�      5�      �� 5�      -   5        $��ListViewMenu��5�      $��Hidden=�6d   .@�5�      �� -   5         ��Name$ listViewItemMember��5�   '   $��60��6C   $ 0.5,0.5&�6O   z�5�      V� 5�   "   .~�5�   &   �� �� 5�   &   �� 5�   &   T� 5�   &   5�   #   .��5�      �� $ 
Horizontal=�6)   $
��10 0q�6B   .+�5�   "     -   5        $% TransitioningContentSlideMember��5�   F    6o     *SlideInFromLeft+$ 0:0:0.4X�.��5�   &   � -   5         �Name$ GridCursourMember��5�   @   $y�Visible=�6+   $��0 0 10 0q�6[   
�������$��10��6�   $
��Left=�6�   $	��Top=�6�   $��60��6�   5�   #     5�   "   $ WalletMembership=�6:   $��30��6R   $��30��6]   $��Center=�6i   $��5q�6�   
�������6�   �� 5�   "   $��Member Registration��6,   $��10q�6G   $��Center=�6S   
�������6n   5�      5�      �� 5�      -   5        $ listViewItemMaterial��5�   '   $��60��6E   $ 0.5,0.5&�6Q   z�5�      V� 5�   "   .~�5�   &   �� �� 5�   &   �� 5�   &   T� 5�   &   5�   #   .��5�      �� $ 
Horizontal=�6)   $
��10 0q�6B   .+�5�   "     -   5        $' !TransitioningContentSlideMaterial��5�   F    6q     *SlideInFromLeft+$ 0:0:0.4X�.��5�   &   � -   5        $ GridCursourMaterial��5�   B   $y�	Collapsed=�6+   $��0 0 10 0q�6_   
�������$��10��6�   $
��Left=�6�   $	��Top=�6�   $��60��6�   5�   #     5�   "   $ 
MaterialUi=�6:   
�������$��30��6_   $��30��6j   $��Center=�6v   $��5q�6�   �� 5�   "   $��Material Registration��6,   $��10q�6I   
�������$��Center=�6h   5�      5�      �� 5�      -   5        $ listViewItemMaintenance��5�   '   $��60��6H   $ 0.5,0.5&�6T   $��Hidden=�6t   z�5�      V� 5�   "   .~�5�   &   �� �� 5�   &   �� 5�   &   T� 5�   &   5�   #   .��5�      �� $ 
Horizontal=�6)   $
��10 0q�6B   .+�5�   "     -   5        $* $TransitioningContentSlideMaintenance��5�   F    6t     *SlideInFromLeft+$ 0:0:0.4X�.��5�   &   � -   5        $ GridCursourMaintenance��5�   B   $y�	Collapsed=�6+   $��0 0 10 0q�6b   
�������$��10��6�   $
��Left=�6�   $	��Top=�6�   $��60��6�   5�   #     5�   "   $ Receipt=�6:   
�������$��30��6\   $��30��6g   $��Center=�6s   $��5q�6�   �� 5�   "   
�������$��Maintenance Registration��6?   $��10q�6_   $��Center=�6k   5�      5�      �� 5�      -   5        $ listViewItemEvent��5�   '   $��60��6B   $ 0.5,0.5&�6N   z�5�      V� 5�   "   .~�5�   &   �� �� 5�   &   �� 5�   &   T� 5�   &   5�   #   .��5�      �� $ 
Horizontal=�6)   $
��10 0q�6B   .+�5�   "     -   5        $$ TransitioningContentSlideEvent��5�   F    6n     *SlideInFromLeft+$ 0:0:0.4X�.��5�   &   � -   5        $ GridCursourEvent��5�   B   $y�	Collapsed=�6+   $��0 0 10 0q�6\   
�������$��10��6�   $
��Left=�6�   $	��Top=�6�   $��60��6�   5�   #     5�   "   
�������$ NotificationClearAll=�6M   $��30��6i   $��30��6t   $��Center=�6�   $��5q�6�   �� 5�   "   
�������$��Notify Event��6?   $��10q�6S   $��Center=�6_   5�      5�      �� 5�      -   5        $ listViewItemPayment��5�   '   $��60��6D   $ 0.5,0.5&�6P   z�5�      V� 5�   "   .~�5�   &   �� �� 5�   &   �� 5�   &   T� 5�   &   5�   #   .��5�      �� $ 
Horizontal=�6)   $
��10 0q�6B   .+�5�   "     -   5        $&  TransitioningContentSlidePayment��5�   F    6p     *SlideInFromLeft+$ 0:0:0.4X�.��5�   &   � -   5        $ GridCursourPayment��5�   B   $y�	Collapsed=�6+   $��0 0 10 0q�6^   
�������$��10��6�   $
��Left=�6�   $	��Top=�6�   $��60��6�   5�   #     5�   "   
�������$ CreditCardMultiple=�6M   $��30��6g   $��30��6r   $��Center=�6~   $��5q�6�   �� 5�   "   
�������$��View Payment��6?   $��10q�6S   $��Center=�6_   5�      5�      �� 5�      -   5        $ listViewItemFacility��5�   '   $��60��6E   $ 0.5,0.5&�6Q   z�5�      V� 5�   "   .~�5�   &   �� �� 5�   &   �� 5�   &   T� 5�   &   5�   #   .��5�      �� $ 
Horizontal=�6)   $
��10 0q�6B   .+�5�   "     -   5        $' !TransitioningContentSlidefacility��5�   F    6q     *SlideInFromLeft+$ 0:0:0.4X�.��5�   &   � -   5        $ GridCursourFacility��5�   B   $y�	Collapsed=�6+   $��0 0 10 0q�6_   
�������$��10��6�   $
��Left=�6�   $	��Top=�6�   $��60��6�   5�   #     5�   "   
�������$ Server=�6M   $��30��6[   $��30��6f   $��Center=�6r   $��5q�6�   �� 5�   "   
�������$��View Requests��6?   $��10q�6T   $��Center=�6`   5�      5�      �� 5�      -   5        $ listViewItemChat��5�   '   $��60��6A   $ 0.5,0.5&�6M   z�5�      V� 5�   "   .~�5�   &   �� �� 5�   &   �� 5�   &   T� 5�   &   5�   #   .��5�      �� $ 
Horizontal=�6)   $
��10 0q�6B   .+�5�   "     -   5        $# TransitioningContentSlidechat��5�   F    6m     *SlideInFromLeft+$ 0:0:0.4X�.��5�   &   � -    5        $ GridCursourChat��5�   B   $y�	Collapsed=�6+   $��0 0 10 0q�6[   
�������$��10��6�   $
��Left=�6�   $	��Top=�6�   $��60��6�   5�   #     5�   "   
�������$
 Chat=�6M   $��30��6Y   $��30��6d   $��Center=�6p   $��5q�6�   �� 5�   "   
�������$
��Chat��6?   $��10q�6K   $��Center=�6W   5�      5�      5�      5      � 5     -!   5        $ GridMain��5     ���	#FFFBFBFB$
��1024��6@   $ 0.5,0.5&�6M   z�5     V� 5     .~�5     �� �� 5     �� 5     T� 5     5     .+�5
     �  � RowDefinitions 5     �� 5     $��50 �6,   �� 5     $��* �6,   .+�5     �  � ColumnDefinitions 5     �� 5  "   $��* �63   �� 5  "   $	��250 �63   .+�5     �� -"   5        $ ButtonCloseMenu��5  %   #��[ 6>   $��30��6�   $��30��6�   $��0q�6�   $	��Top=�6�   $
��Left=�6�   $��5q�6  $y�	Collapsed=�60  ��6�   Z� ��6�   Z� .��5  "     $
 Menu=�6:   ���#7c04266F   5     �� 5     -#   5        $ ButtonOpenMenu��5  %   #��[ 6=   $��30��6�   $��30��6�   $��0q�6�   $	��Top=�6�   $
��Left=�6�   $��5q�6  ��6�   Z� ��6�   Z� .��5  "     $
 Menu=�6:   ���#7c04266F   5     5     � 5     -$   5        $��
GridMember��5     $��1��61   5     5     5      �� 5!     $ 
Horizontal=�6   $	��Top=�66   $��40��6N   $��Right=�6Z   $��10q�6v   .+�5"     �� -%   5        $ ButtonMinimize��5"     #��[ 65   $��30��6{   $��30��6�   $��0q�6�   ��6�   Z� ��6�   Z� .��5#       -&   5        $��MI��5#  Q   $ Minus=�62   
�������6Q   5$     �� 5%     -'   5        $ ButtonClose��5%     #��[ 62   $��30��6x   $��30��6�   $��0q�6�   ��6�   Z� ��6�   Z� .��5&       -(   5        $��CI��5&  Q   $ Close=�62   
�������6Q   5'     5(     5)     5*     5+     5,     