   M S B A M L   `   `   `  ����D  @SmartEdir, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SmartEdir.AdminUserControlSmartEdir.AdminUserControl  5      2    ,SmartEdir.AdminUserControl.UserControlMember   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:SmartEdir.AdminUserControl     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $
��auto��5	      $
��1024��6     � 	Resources  5
      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value ��Name �� 
IsReadOnly �� Path �� StringFormat �� RelativeSource	 �� AncestorType(  "System.Windows.Controls.DatePicker��%�   '        �� 5   
   "  6   .�5      ��  � �� 5      �� 5      .R�5      �� $ PART_TextBox��64    . ��6J   �� $ SelectedDate�$ 
dd.MM.yyyy�� �� "	  5      5      5      5      .��5      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5        
  Name$
 TrainsitionigContentSlide��5   *   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6M   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromRight+   Duration$ 0:0:1.4X�.��5      � -   5        $��
GridMember��5       � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��250 �6   .+�5      �  � RowDefinitions 5      �� 5      $��50 �6$   �� 5      $��* �6$   .+�5       �� $��0��6    �� Orientation$ 
Horizontal=�6*   .+�5!      �� $��Members��6    ���	#FF3580BF$��30(�6F   $
��Bold"�6T   $��5q�6f   �� 5"      $ 
Horizontal=�6!   $��	240 0 0 0q�6:   .+�5#      �� -   5        $��
SearchText��5#   "   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search here��64   $	��250��6a   $��5 5 30 5q�6m   ���#707070$��3q�6�   $��15(�6�   6�   '  !MaterialDesignThemes.Wpf.PackIcon  5$      -   5        $��ExportToExell��5$   2   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ 	FileExcel=�6G   $��40��6X   $��60��6d   $��Center=�6o   ���#7c0426 � Cursor$
 Hand��6�   6�   �� 5%      $��	To Excell��6$   $��Bottom=�65   $��	-10 0 0 6q�6P   ���#7c04266c   5&      5(      � 5)      $��1��6   .+�5*      &	   System.Windows.Controls.DataGrid	  -   5        $��MemberDataGrid��5*      $��5 20 5 5q�66    	  
IsReadOnly . ���	#FF042263 	  VerticalGridLinesBrush �	#FF888888��6H   Z� ��6^   Z�  	  Columns 5,      0
  *System.Windows.Controls.DataGridTextColumn
  5-      -   5        IDColumn��,  &System.Windows.Controls.DataGridColumn   Header$ ID��5-   C      Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Z   �� *Id+   ElementStyle 5.   "   �� 5/   &   " ��6,   .�50   *   ��  � ��$
 Left=�6P   �� 51   *    � ��$ Center=�6N   �� 52   *    �@��Padding$ 5q�6D   53   '      	CellStyle 55   "   �� 56   &   *  $System.Windows.Controls.DataGridCell"  6,   .�57   *   ��  � �� �#2e61af6G   �� 58   *    � ��$ 5,0,0,0q�6L   �� 59   *    � �� �	#FF1342876H   �� 5:   *    � ��
 �����6G    �� Triggers 5;   *   P� 5<   .    P� Property �@ 
IsSelected P� Value . . �5=   2   ��  � �� �	#FF1342876O   �� 5>   2    � ��$ 5,0,0,0q�6T   �� 5?   2    � ��
 �����6P   �� 5@   2    � ��
 �����6O   5A   /   5C   '   5E      
  5F      -   5        FirstNameColumn��$ 
First Name��5F   J   $	 120 6^    6j   �� *	FirstName+
  5G      -   5        MiddleNameColumn��$ Middle Name��5G   K   $	 120 6`    6l   �� *
MiddleName+
  5H      -	   5        LastNameColumn��$ 	Last Name��5H   I   $	 120 6\    6h   �� *
LastName+
  5I      -
   5        BirthDateNameColumn��$ 
Birth Date��5I   N   $	 120 6b    6n   �� *	BirthDate+
  5J      -   5        GenderNameColumn��$ Gender��5J   K   $	 110 6[    6g   �� *Gender+
  5K      -   5        OccupationNameColumn��$ 
Occupation��5K   O   $	 100 6c    6o   �� *
Occupation+5N      5P      5Q      � 5R   
   $��1��6   ���#7c0426$��2��64   .+�5S      �� $��0 0 0 15q�6   .+�5T      �� $��MEMBER REGISTRATION��6   $��0 20 0 0q�67   
�������$��17(�6\   $��Nirmala UI Semilight)�6j    �� Padding$ 4q�6�   $��Center=�6�   �� 5U       J� Opacity$
 0.59Q�6   $
��10 0q�6+   �� 5V      $��MEMBER BASIC INFORMATION��6   
�������$��	10 10 0 0q�6O   $��11(�6b   �� 5X      $��
First Name��6   
�������$��	10 10 0 5q�6A   $��11(�6T   �� 5Y      -   5        $��	FirstName��5Y      
�������
�������$
��10 0q�6P   $��1q�6^   $��15(�6j   6x   �� 5Z      -   5        $��FNErr��5Z      $y�Hidden=�6)   $#��Name Must Be Atleast 5 Letter��6=   
�������$��10 0 0 5q�6u   $��10(�6�   �� 5\      $��Middle Name��6   
�������$��10 5 0 3q�6B   $��11(�6T   �� 5]      -   5        $��
MiddleName��5]      
�������
�������$
��10 0q�6Q   $��1q�6_   $��15(�6k   6y   �� 5^      -   5        $��MNErr��5^      $y�Hidden=�6)   $#��Name Must Be Atleast 5 Letter��6=   
�������$��10 0 0 5q�6u   $��10(�6�   �� 5`      $��	Last Name��6   
�������$��10 6 0 3q�6@   $��11(�6R   �� 5a      -   5        $��LastName��5a      
�������
�������$
��10 0q�6O   $��1q�6]   $��15(�6i   6w   �� 5b      -   5        $��LNErr��5b      $y�Hidden=�6)   $#��Name Must Be Atleast 5 Letter��6=   
�������$��10 0 0 5q�6u   $��10(�6�   �� 5d      $��
Birth Date��6   
�������$��10 6 0 3q�6A   $��11(�6S     5e      -   5        $��	BirthDate��5e      $ 
MM/dd/yyyy��6.   
�������
�������$��	10 0 10 0q�6   $��7q�6�   $��15(�6�   6�   �� 5f      -   5        $��BDErr��5f      $y�Hidden=�6)   $#��Name Must Be Atleast 5 Letter��6=   
�������$��10 0 0 5q�6u   $��10(�6�   �� 5h      $��Gender��6   
�������$��10 6 0 3q�6=   $��11(�6O   �� 5i      -   5        $��Gender��5i      
�������
�������$��
10 0 10 15q�6N   $��7q�6b   $��15(�6n     �� SelectedIndex$  0��6|   .@�5j      �� $
��Male��6#   $��20 0 0 0q�62   �� 5k      $��Female��6#   $��20 0 0 0q�64   5l      �� 5n      $��
Occupation��6   
�������$��10 6 0 3q�6A   $��11(�6S   �� 5o      -   5        $��
Occupation��5o      
�������
�������$
��10 0q�6Q   $��1q�6_   $��15(�6k   6y   �� 5p      -   5        $
��OErr��5p      $y�Hidden=�6(   $#��Name Must Be Atleast 5 Letter��6<   
�������$��10 0 0 5q�6t   $��10(�6�   �� 5q      $ 
Horizontal=�6   $��	10 15 0 3q�66   .+�5r      �� -   5        $��UpdateButton��5r      
����������#7c0426���#7c0246$��Update��6o   $��0 0 5 0q�6�   6�   �� 5s      -   5        $��DeleteButton��5s      ���#ff0000���#7c0426
�������$��Delete��6o   $��0 0 5 0q�6�   6�   �� 5t      -   5        $��
SaveButton��5t      ���#0aa405���#7c0426
�������$
��Save��6n   $��0 0 5 0q�6}   6�   5u      5w      5x      5y      5z      5{      