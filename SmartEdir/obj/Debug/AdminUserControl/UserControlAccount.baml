   M S B A M L   `   `   `  ����D  @SmartEdir, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SmartEdir.AdminUserControlSmartEdir.AdminUserControl  5      3    -SmartEdir.AdminUserControl.UserControlAccount   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:SmartEdir.AdminUserControl     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $
��auto��5	      $
��1024��6   .��5
      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5           Name$  TrainsitionigContentSlide��5
   *   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6M   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromRight+   Duration$ 0:0:1.4X�.��5   
   � -   5        $��GridAccount��5       � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $	��250 �6#   .+�5      �  � RowDefinitions 5      �� 5      $��50 �6$   �� 5      $��* �6$   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6*   .+�5      �� $��Account��6    ���	#FF3580BF$��30(�6F   $
��Bold"�6T   $��5q�6f   �� 5      $ 
Horizontal=�6!   $��	330 0 0 0q�6:   .+�5      �� -   5        $��
SearchText��5   "   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search here��64   $	��250��6a   $��5 5 30 5q�6m   ���#707070$��3q�6�   $��15(�6�   6�   5      5      � 5      $��1��6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��AccountDataGrid��5      $��5 20 5 5q�67      
IsReadOnly . ���	#FF042263   VerticalGridLinesBrush �	#FF888888��6I   Z� ��6_   Z� 	   Columns	 5       0  *System.Windows.Controls.DataGridTextColumn  5!      -   5        EmailColumn��,  &System.Windows.Controls.DataGridColumn
   Header$
 Email Address��5!   F      Width5  /System.Windows.Controls.DataGridLengthConverter$	 160 6]   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6i   �� *Email+ 	  ElementStyle 5"   "   �� 5#   &    �� 
TargetType" ��6,   .�5$   *   ��  �� Property � �� �� Value$
 Left=�6P   �� 5%   *    � ��$ Center=�6N   �� 5&   *    �@��Padding$ 5q�6D   5'   '      	CellStyle 5)   "   �� 5*   &   *
  $System.Windows.Controls.DataGridCell" 
 6,   .�5+   *   ��  � �� �#2e61af6G   �� 5,   *    � ��$ 5,0,0,0q�6L   �� 5-   *    � �� �	#FF1342876H   �� 5.   *    � ��
 �����6G    �� Triggers 5/   *   P� 50   .    P� Property �@
 
IsSelected P� Value . . �51   2   ��  � �� �	#FF1342876O   �� 52   2    � ��$ 5,0,0,0q�6T   �� 53   2    � ��
 �����6P   �� 54   2    � ��
 �����6O   55   /   57   '   59        5:      -   5        MaterialNameColumn��$
 Password��5:   M   $	 140 6_    6k   �� *
Password+  5;      -   5        BrandNameColumn��$
 	User Role��5;   J   $	 140 6]    6i   �� *Role+  5<      -   5        TypeNameColumn��$
 	Member Id��5<   I   $	 140 6\    6h   �� *
MemberID+5?      5A      5B      � 5C      $��1��6   ���#7c0426$��2��68   .+�5D      �� $��0 0 0 15q�6   .+�5E      �� $��ACCOUNT REGISTRATION��6    $��0 20 0 0q�6<   
�������$��17(�6a   $��Nirmala UI Semilight)�6o    �� Padding$ 4q�6�   $��Center=�6�   �� 5F       J� Opacity$
 0.59Q�6    $
��10 0q�6/   �� 5G      $��ACCOUNT BASIC INFORMATION��6    
�������$��	10 10 0 0q�6T   $��11(�6g   �� 5I      $��Email Address��6    
�������$��	10 10 0 5q�6H   $��11(�6[   �� 5J      -	   5        $��EmailAddress��5J      
�������
�������$
��10 0q�6W   $��1q�6e   $��15(�6q   6   �� 5K      -
   5        $��EAErr��5K       $y�Hidden=�6-   $#��Name Must Be Atleast 5 Letter��6A   
�������$��10 0 0 5q�6y   $��10(�6�   �� 5M      $��Password��6    
�������$��10 5 0 3q�6C   $��11(�6U   G� 5N      -   5        $��Password��5N   "   
�������
�������$
��10 0q�6W   $��1q�6e   $��15(�6q   6   �� 5O      -   5        $
��PErr��5O       $y�Hidden=�6,   $#��Name Must Be Atleast 5 Letter��6@   
�������$��10 0 0 5q�6x   $��10(�6�   �� 5Q      $��	User Role��6    
�������$��10 6 0 3q�6D   $��11(�6V   �� 5R      -   5        $��UserRole��5R      
�������
�������$��
10 0 10 30q�6T   $��7q�6h   $��15(�6t    �� SelectedIndex$ 0��6�   .@�5S      �� $��Admin��6'   $��20 0 0 0q�67   �� 5T      $��Member��6'   $��20 0 0 0q�68   5U      �� 5W      $
 0.59Q�6    $
��10 0q�6/   �� 5X      $!��ACCOUNT PROFILE INFORMATION��6    
�������$��10 5 0 5q�6V   $��11(�6h   �� 5Z      $��	Member Id��6    
�������$��10 6 0 3q�6D   $��11(�6V   �� 5[      -   5        $��MemberId��5[      
�������
�������$
��10 0q�6S   $��1q�6a   $��15(�6m   6{   �� 5\      -   5        $��MIErr��5\       $y�Hidden=�6-   $#��Name Must Be Atleast 5 Letter��6A   
�������$��10 0 0 5q�6y   $��10(�6�   �� 5^      $��Center=�6!   .+�5_      A� -   5        $��ProfileImageButton��5_   "   $	��100��6<   $	��100��6I   $	��Top=�6U   $��Right=�6m   
���������5`      �� 5a   "   -   5        ProfileImage�� �� ImageSource$ /Assets/images.jpg��5a   C    j� Stretch$ UniformToFill=�6d   5c      5d      �� 5e      -   5        $��PPErr��5e       $y�Hidden=�6-   $#��Name Must Be Atleast 5 Letter��6A   
�������$��10 0 0 5q�6y   $��10(�6�   �� 5f      $ 
Horizontal=�6!   $��	10 15 0 3q�6:   .+�5g      �� -   5        $��UpdateButton��5g   !   
����������#7c0426���#7c0246$��Update��6s   $��0 0 5 0q�6�   6�   �� 5h      -   5        $��DeleteButton��5h   !   ���#ff0000���#7c0426
�������$��Delete��6s   $��0 0 5 0q�6�   6�   �� 5i      -   5        $��
SaveButton��5i   !   ���#0aa405���#7c0426
�������$
��Save��6r   $��0 0 5 0q�6�   6�   5j      5k      5l      5m      5n      5o      