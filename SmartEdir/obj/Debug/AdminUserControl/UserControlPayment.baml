   M S B A M L   `   `   `  ����D  @SmartEdir, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SmartEdir.AdminUserControlSmartEdir.AdminUserControl  5      3    -SmartEdir.AdminUserControl.UserControlPayment   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:SmartEdir.AdminUserControl     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $
��auto��5	      $
��1024��6   .��5
      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5           Name$  TrainsitionigContentSlide��5
   *   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6M   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromRight+   Duration$ 0:0:1.4X�.��5   
   � -   5        $��GridPayment��5       � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $	��250 �6#   .+�5      �  � RowDefinitions 5      �� 5      $��50 �6$   �� 5      $��* �6$   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6*   .+�5      �� $��Payment��6    ���	#FF3580BF$��30(�6F   $
��Bold"�6T   $��5q�6f   �� 5      $ 
Horizontal=�6!   $��	220 0 0 0q�6:   .+�5      �� -   5        $��
SearchText��5   "   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search here��64   $	��250��6a   $��5 5 30 5q�6m   ���#707070$��3q�6�   $��15(�6�   6�   �� 5      $��Center=�6%   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  -   5        $��Refresh��5   6   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ Reload=�6E   
�������$��25��6e   $��25��6p    � Cursor$
 Hand��6�   5        5      -   5        $��ExportToExell��5   2   $ 	FileExcel=�6G   $��40��6X   $��60��6d   $��Center=�6o   ���#7c0426$
 Hand��6�   6�   �� 5      $��	To Excell��6$   $��Bottom=�65   $��	-10 0 0 6q�6P   ���#7c04266c   5      5       � 5!      $��1��6   .+�5"      &   System.Windows.Controls.DataGrid  -   5        $��PaymentDataGrid��5"      $��5 20 5 5q�67   	   
IsReadOnly	 . ���	#FF042263
   VerticalGridLinesBrush
 �	#FF888888��6I   Z� ��6_   Z�    Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      -   5        PaymentColumn��,	  &System.Windows.Controls.DataGridColumn 	  Header$ 	Member Id��5%   H    	  Width5
  /System.Windows.Controls.DataGridLengthConverter$	 120
 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6g   �� *
MemberId+   ElementStyle 5&   "   �� 5'   &    �� 
TargetType" ��6,   .�5(   *   ��  �� Property � �� �� Value$
 Left=�6P   �� 5)   *    � ��$ Center=�6N   �� 5*   *    �@��Padding$ 5q�6D   5+   '    	  	CellStyle 5-   "   �� 5.   &   *  $System.Windows.Controls.DataGridCell"  6,   .�5/   *   ��  � �� �#2e61af6G   �� 50   *    � ��$ 5,0,0,0q�6L   �� 51   *    � �� �	#FF1342876H   �� 52   *    � ��
 �����6G    �� Triggers 53   *   P� 54   .    P� Property �@ 
IsSelected P� Value . . �55   2   ��  � �� �	#FF1342876O   �� 56   2    � ��$ 5,0,0,0q�6T   �� 57   2    � ��
 �����6P   �� 58   2    � ��
 �����6O   59   /   5;   '   5=        5>      -   5        MaterialNameColumn��$ Receipt Number��5>   M   $	 140
 6e    6q   �� *ReceiptNumber+  5?      -	   5        BrandNameColumn��$	 Day��5?   J   $ 90
 6W    6b   �� *Day+  5@      -
   5        TypeNameColumn��$ Month��5@   I   $	 100
 6X    6d   �� *Month+  5A      -   5        BrandNameColumnn��$
 Year��5A   K   $ 90
 6Y    6d   �� *Year+  5B      -   5        TypeNameColumnn��$ Status��5B   J   $	 120
 6Z    6f   �� *Status+5E      5G      5H      � 5I      $��1��6   ���#7c0426$��2��68   .+�5J      �� $��0 0 0 15q�6   .+�5K      �� $��PAYMENT ADMINSTRATION��6    $��0 20 0 0q�6=   
�������$��17(�6b   $��Nirmala UI Semilight)�6p    �� Padding$ 4q�6�   $��Center=�6�   �� 5L       J� Opacity$
 0.59Q�6    $
��10 0q�6/   �� 5M      $��ADD NEW YEAR PAYMENT��6    
�������$��	10 10 0 0q�6O   $��11(�6b   �� 5O      $
��Year��6    
�������$��	10 10 0 5q�6?   $��13(�6R   �� 5P      -   5        $
��Year��5P      
�������
�������$
��10 0q�6O   $��1q�6]   $��15(�6i   6w   �� 5Q      -   5        $
��YErr��5Q       $y�Hidden=�6,   $#��Name Must Be Atleast 5 Letter��6@   
�������$��10 0 0 5q�6x   $��10(�6�   �� 5S      $��Amount��6    
�������$��10 5 0 3q�6A   $��13(�6S   �� 5T      -   5        $��Amount��5T      
�������
�������$
��10 0q�6Q   $��1q�6_   $��15(�6k   6y   �� 5U      -   5        $
��AErr��5U       $y�Hidden=�6,   $#��Name Must Be Atleast 5 Letter��6@   
�������$��10 0 0 5q�6x   $��10(�6�   �� 5V      $��Right=�6!   $ 
Horizontal=�6=   $��	10 0 0 35q�6V   .+�5W      �� -   5        $��
SaveButton��5W   !   ���#0aa405���#7c0426
�������$
��Save��6r   $��0 0 5 0q�6�   6�   5X      �� 5[      $
 0.59Q�6    $
��10 0q�6/   �� 5\      $ ��MONTHLY AND YEARLY INCOMES��6    
�������$��10 5 0 5q�6U   $��11(�6g   �� 5^      $��Yearly Income��6    
�������$��10 6 0 3q�6H   $��12(�6Z   �� 5_      -   5        $��	YearTotal��5_       �� 
IsEditable .  �� 
IsReadOnly . 
�������
�������$��
10 0 10 10q�6y   $��7q�6�   $��15(�6�    �� SelectedIndex$ 0��6�   5a      �� 5b      -   5        $��YI��5b       $y�Hidden=�6*   $"��The Total Income is 2000 ETB��6>   
����İ�$��	30 0 0 30q�6~   $��14(�6�   �� 5d      $��Monthly Income��6    
�������$��10 6 0 3q�6I   $��12(�6[   �� 5e      -   5        $��
MonthTotal��5e       .  . 
�������
�������$��
10 0 10 10q�6z   $��7q�6�   $��15(�6�   $ 0��6�   5g      �� 5h      -   5        $��MI��5h       $y�Hidden=�6*   $"��The Total Income is 2000 ETB��6>   
����İ�$��30 0 0 5q�6~   $��14(�6�   5i      5j      5k      5l      5m      