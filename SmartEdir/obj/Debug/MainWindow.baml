   M S B A M L   `   `   `  ����D  @SmartEdir, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SmartEdir	SmartEdir  5   	       SmartEdir.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:SmartEdir     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   
   -   5          � Icon$  Assets/logo-3.png��5	   	   $	��500��5
   S   $	��800��6`    � WindowStyle$
 None=�6l    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�6�   .��5      � -   5        $��	GridLogin��5      .+�5   
   ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TrainsitionigContentSlide��5   .   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6Q   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:1.2X�.��5      �  � ColumnDefinitions 5      �� 5      $	��400 �6'   �� 5      $��* �6'   .+�5      � $��0��6   .+�5      �� $��
20,10,0,10q�6!   .+�5      �� $��Login��6    $��Segoe UI Black)�60   $��24(�6L   $
��0,10q�6Z   $	��Top=�6h   $
��Left=�6�   �� 5       �� Orientation$ 
Horizontal=�6%   .+�5      �� $
��Left=�6(   $	��Top=�6C   $
��Wrap=�6[   ���#707070�� 6�   $"�Don't you have account yet? ��6�   6�   �� 5      $
��Left=�6(   $	��Top=�6C   $
��Wrap=�6[   ���	#FF2468AC�� 6�   $�Contact the admins,��6�   6�   5      �� 5      $
��Left=�6$   $	��Top=�6?   $
��Wrap=�6W   ���#707070�� 6�   $%�fireayehuzekarias1989@gmail.com��6�   6�   �� 5      $��	0 30 0 15q�6%   $ 
Horizontal=�68   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]	   Kind$	 Email=�66   $��Center=�6C   ���#7070706^   �� 5      $��5q�6)   .+�5   "   �� -   5        $��	EmailText��5   *   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Email��6;    %  !MaterialDesignFloatingHintTextBox#��[  6b   $	��250��6�   ���#707070$��4q�6�   $��17(�6�   �� 5   "   -   5        $��EmailErr��5   ,   $y�Hidden=�6<   $#��Name Must Be Atleast 5 Letter��6P   
���  ��$��10 0 0 5q�6�   $��10(�6�   5      5!      �� 5"      $ 
Horizontal=�6%   $��0 0 0 15q�6>   .+�5#        $		 Key=�66   $��Center=�6A   ���#7070706\   �� 5$      $��5q�6)   .+�5%   "   G� -   5        $��PasswordText��5%   .   $
 Password��6B    ) %MaterialDesignFloatingHintPasswordBox#��[ 6l   $	��250��6�   ���#707070$��4q�6�   $��17(�6�   �� 5&   "   -   5        $��PasswordErr��5&   ,   $y�Hidden=�6?   $#��Name Must Be Atleast 5 Letter��6S   
���  ��$��10 0 0 5q�6�   $��10(�6�   5'      5)      �� 5*      $
��0 20q�6%   .+�5+      �� -   5        $��LoginButton��5+   %   $��Center=�68   $��LOGIN��6U   $��Impact)�6e   $��18(�6y   $	��100��6�   ���#7c0426���#FFF  MaterialDesignRaisedButton#��[ 6�   5,      5:      5;      � 5<      $��1��6    � RowDefinitions 5=      �� 5>      $��50 �6(   �� 5?      $��* �6(   .+�5A      � .+�5B      �� $ 
Horizontal=�6%   $	��Top=�6>   $��40��6V   $��Right=�6b   $��10q�6~   .+�5C      �� -	   5         ��Name$ ButtonMinimize��5C   %    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6=   $��30��6�   $��30��6�   $��0q�6�   ��6�   Z� ��6�   Z� .��5D   "     $	 Minus=�6:   ���#7070706G   5E      �� 5F      -
   5        $ ButtonClose��5F   %   #��[ 6:   $��30��6�   $��30��6�   $��0q�6�   ��6�   Z� ��6�   Z� .��5G   "     $	 Close=�6:   ���#7070706G   5H      5I      5J      � 5K      $��1��6   .+�5L      ��  �� RadiusY$ 8��6$    �� RadiusX$ 8��60   
�������6<   �� 5M      $��Assets/logo-2.png��6    $
��Fill=�6<   �� 5N      ��5O      �� 5P   "    �� EndPoint$ 0.5,1&�66    �� 
StartPoint$ 0.5,0&�6G   .��5Q   &   �  � Color$ 	#CC935E12��63    � Offset$ 1Q�6E   � 5R   &   $ 	#CCEA4646��63   � 5S   &   $ 	#CCB89128��63   $ 0.566Q�6E   5T   #   5V      5[      5]      5^      5_      5`      5a      