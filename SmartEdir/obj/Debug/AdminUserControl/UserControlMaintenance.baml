   M S B A M L   `   `   `  ����D  @SmartEdir, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SmartEdir.AdminUserControlSmartEdir.AdminUserControl  5      7    1SmartEdir.AdminUserControl.UserControlMaintenance   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:SmartEdir.AdminUserControl     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $
��auto��5	      $
��1024��6   .��5
      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5           Name$  TrainsitionigContentSlide��5
   *   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6M   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromRight+   Duration$ 0:0:1.4X�.��5   
   � -   5        $��GirdMaintenance��5       � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $	��250 �6#   .+�5      �  � RowDefinitions 5      �� 5      $��50 �6$   �� 5      $��* �6$   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6*   .+�5      �� $��Maintenance��6    ���	#FF3580BF$��30(�6J   $
��Bold"�6X   $��5q�6j   �� 5      $ 
Horizontal=�6!   $��	170 0 0 0q�6:   .+�5      �� -   5        $��
SearchText��5   "   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search here��64   $	��250��6a   $��5 5 30 5q�6m   ���#707070$��3q�6�   $��15(�6�   6�   '  !MaterialDesignThemes.Wpf.PackIcon  5      -   5        $��ExportToExell��5   2   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ 	FileExcel=�6G   $��40��6X   $��60��6d   $��Center=�6o   ���#7c0426 � Cursor$
 Hand��6�   6�   �� 5      $��	To Excell��6$   $��Bottom=�65   $��	-10 0 0 6q�6P   ���#7c04266c   5      5      � 5      $��1��6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��MaintenanceDataGrid��5      $��5 20 5 5q�6;   	   
IsReadOnly	 . ���	#FF042263
   VerticalGridLinesBrush
 �	#FF888888��6M   Z� ��6c   Z�    Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      -   5        IDColumn��,	  &System.Windows.Controls.DataGridColumn 	  Header$ ID��5"   C    	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ 70
 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Z   �� *Id+   ElementStyle 5#   "   �� 5$   &    �� 
TargetType" ��6,   .�5%   *   ��  �� Property � �� �� Value$
 Left=�6P   �� 5&   *    � ��$ Center=�6N   �� 5'   *    �@��Padding$ 5q�6D   5(   '    	  	CellStyle 5*   "   �� 5+   &   *  $System.Windows.Controls.DataGridCell"  6,   .�5,   *   ��  � �� �#2e61af6G   �� 5-   *    � ��$ 5,0,0,0q�6L   �� 5.   *    � �� �	#FF1342876H   �� 5/   *    � ��
 �����6G    �� Triggers 50   *   P� 51   .    P� Property �@ 
IsSelected P� Value . . �52   2   ��  � �� �	#FF1342876O   �� 53   2    � ��$ 5,0,0,0q�6T   �� 54   2    � ��
 �����6P   �� 55   2    � ��
 �����6O   56   /   58   '   5:        5;      -   5        MaterialIdNameColumn��$ Material ID��5;   O   $	 140
 6d    6p   �� *
MaterialId+  5<      -   5        MaterialNameColumn��$ Material Name��5<   M   $	 140
 6d    6p   �� *MaterialName+  5=      -	   5        TypeNameColumn��$ Material Type��5=   I   $	 140
 6`    6l   �� *MaterialType+  5>      -
   5        CostDateNameColumn��$ Maintenance Cost��5>   M   $	 140
 6g    6s   �� *MaintenanceCost+  5?      -   5        MaintenanceDateColumn��$ Maintenance Date��5?   P   $	 130
 6j    6v   �� *MaintenanceDate+5B      5D      5E      � 5F      $��1��6   ���#7c0426$��2��68   .+�5G      �� $��0 0 0 15q�6   .+�5H      �� $��MAINTENACE REGISTRATION��6    $��0 20 0 0q�6?   
�������$��17(�6d   $��Nirmala UI Semilight)�6r    �� Padding$ 4q�6�   $��Center=�6�   �� 5I       J� Opacity$
 0.59Q�6    $
��10 0q�6/   �� 5J      $��MATERIAL INFORMATION��6    
�������$��	10 10 0 0q�6O   $��11(�6b   �� 5L      $��Material Id��6    
�������$��	10 10 0 5q�6F   $��11(�6Y   �� 5M      -   5        $��
MaterialId��5M      
�������
�������$
��10 0q�6U   $��1q�6c   $��15(�6o   6}   �� 5N      -   5        $��MIDErr��5N       $y�Hidden=�6.   $#��Name Must Be Atleast 5 Letter��6B   
�������$��10 0 0 5q�6z   $��10(�6�   �� 5P      $��Material Name��6    
�������$��10 5 0 3q�6H   $��11(�6Z   �� 5Q      -   5        $��MaterialName��5Q      
�������
�������$
��10 0q�6W   $��1q�6e   $��15(�6q   6   �� 5R      -   5        $��MNErr��5R       $y�Hidden=�6-   $#��Name Must Be Atleast 5 Letter��6A   
�������$��10 0 0 5q�6y   $��10(�6�   �� 5T      $��Material Type��6    
�������$��10 6 0 3q�6H   $��11(�6Z   �� 5U      -   5        $��MaterialType��5U      
�������
�������$��
10 0 10 30q�6X   $��7q�6l   $��15(�6x    �� SelectedIndex$ 0��6�   .@�5V      �� $��Electronics��6'   $��20 0 0 0q�6=   �� 5W      $��	HouseHold��6'   $��20 0 0 0q�6;   �� 5X      $��Field��6'   $��20 0 0 0q�67   �� 5Y      $��Other��6'   $��20 0 0 0q�67   5Z      �� 5\      $
 0.59Q�6    $
��10 0q�6/   �� 5]      $��MAINTENANCE INFORMATION��6    
�������$��
10 10 0 20q�6R   $��11(�6f   �� 5_      $��Maintenance Cost��6    
�������$��10 6 0 3q�6K   $��11(�6]   �� 5`      -   5        $��MaintenanceCost��5`      
�������
�������$
��10 0q�6Z   $��1q�6h   $��15(�6t   6�   �� 5a      -   5        $��MCErr��5a       $y�Hidden=�6-   $#��Name Must Be Atleast 5 Letter��6A   
�������$��10 0 0 5q�6y   $��10(�6�   �� 5c      $��Maintenance Date��6    
�������$��10 6 0 3q�6K   $��11(�6]   (  "System.Windows.Controls.DatePicker  5d      -   5        $��MaintenanceDate��5d   !   $ 
MM/dd/yyyy��69   
�������
�������$��	10 0 10 0q�6�   $��7q�6�   $��15(�6�   6�   �� 5e      -   5        $��MDErr��5e       $y�Hidden=�6-   $#��Name Must Be Atleast 5 Letter��6A   
�������$��10 0 0 5q�6y   $��10(�6�   �� 5f      $ 
Horizontal=�6!   $��	10 15 0 3q�6:   .+�5g      �� -   5        $��UpdateButton��5g   !   
����������#7c0426���#7c0246$��Update��6s   $��0 0 5 0q�6�   6�   �� 5h      -   5        $��DeleteButton��5h   !   ���#ff0000���#7c0426
�������$��Delete��6s   $��0 0 5 0q�6�   6�   �� 5i      -   5        $��
SaveButton��5i   !   ���#0aa405���#7c0426
�������$
��Save��6r   $��0 0 5 0q�6�   6�   5j      5k      5l      5m      5n      5o      