   M S B A M L   `   `   `  ����D  @SmartEdir, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:SmartEdir.MemberUserControlSmartEdir.MemberUserControl  5      5    /SmartEdir.MemberUserControl.UserControlFacility   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:SmartEdir.MemberUserControl     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	��550��5	      $	��774��6   .��5
      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5           Name$  TrainsitionigContentSlide��5
   *   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6M   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromRight+   Duration$ 0:0:1.4X�.��5   
   � -   5        $��GridFacility��5       � ColumnDefinitions 5      �� 5      $
��121* �6#   �� 5      $��8* �6#    � RowDefinitions 5      �� 5      $��50 �6    �� 5      $��* �6    .+�5      �� $��0��6   $��2��6&   .+�5      �� $��Facility Request��6   ���	#FF3580BF$��28(�6K   $
��Bold"�6Y   $��5q�6k   5      � 5      $��1��6    5      �� 5      $	��400 �6'   �� 5      $��3 �6'   �� 5      $��* �6'   .+�5      �� $��0��6   $��40 -70  0 0q�6-   $��Center=�6B   .+�5      ��  �� Orientation$ Vertical=�6!   $��0 0 0 30q�68   .+�5      �� $��Phone Number��6$   $��Center=�68   $��16(�6S   
�������$��
55 0 70 10q�6s   �� 5       -   5        $��PhoneNumber��5    "   $	��250��65   $��4q�6A   $��15(�6M   ���#EEEEEE
�������
�������6�   �� 5!      -   5        $��PNErr��5!   $   $y�Hidden=�61   $#��Name Must Be Atleast 5 Letter��6E   
�������$��55 0 0 5q�6|   $��10(�6�   5"      �� 5#      $ Vertical=�6!   $��0 0 0 30q�68   .+�5$      �� $
��Date��6$   $��Center=�60   $��16(�6K   
�������$��
55 0 70 10q�6k   (  "System.Windows.Controls.DatePicker  5%      -   5        $
��Date��5%   %   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
MM/dd/yyyy��61   $��Center=�6]   $	��250��6x   $��40��6�   $��4q�6�   $��15(�6�   ���#EEEEEE
�������
�������6�   �� 5&      -   5        $
��DErr��5&   $   $y�Hidden=�60   $#��Name Must Be Atleast 5 Letter��6D   
�������$��55 0 0 5q�6{   $��10(�6�   5'      5)      �� 5*      $��	0 -70 0 0q�6   $��1��60   
���  ��$	��300��6Q   �� 5+      $��2��6   $��	40 0  0 0q�6-   $��Center=�6@   .+�5,      �� $ Vertical=�6!   $��0 0 0 20q�68   .+�5-      �� $��Subject��6$   $��Center=�63   $��16(�6N   
�������$��
20 0 70 10q�6n   �� 5.      -   5        $��Subject��5.   "   $	��250��61   $��4q�6=   $��15(�6I   ���#EEEEEE
�������
�������6�   �� 5/      -   5        $��SUErr��5/   $   $y�Hidden=�61   $#��Name Must Be Atleast 5 Letter��6E   
�������$��55 0 0 5q�6|   $��10(�6�   50      �� 52      $ Vertical=�6!   $��0 0 0 20q�68   .+�53      �� $
��Body��6$   $��Center=�60   $��16(�6K   
�������$��
20 0 70 10q�6k   �� 54      -	   5        $
��Body��54   "   $	��200��6.   $	��250��6;   $��4q�6G   $��15(�6S   ���#EEEEEE
�������
������� �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn . $	 �� HorizontalScrollBarVisibility$	 Disabled=�6�   "
 �� VerticalScrollBarVisibility$

 Auto=�6�   6  �� 55      -
   5        $
��BErr��55   $   $y�Hidden=�60   $#��Name Must Be Atleast 5 Letter��6D   
�������$��55 0 0 5q�6{   $��10(�6�   56      �� 57      $��Right=�6!   $ 
Horizontal=�6=   $��	10 0 0 35q�6V   .+�58      �� -   5        $��SubmitButton��58   !   $	��100��65   ���#0aa405
��� � �
�������$��Submit��6~   $��0 0 5 0q�6�   6�   59      5:      5;      5=      5>      5?      