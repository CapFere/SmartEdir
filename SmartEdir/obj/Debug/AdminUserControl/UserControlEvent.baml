   M S B A M L   `   `   `  ����D  @SmartEdir, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SmartEdir.AdminUserControlSmartEdir.AdminUserControl  5      1    +SmartEdir.AdminUserControl.UserControlEvent   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:SmartEdir.AdminUserControl     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $
��auto��5	      $
��1024��6     � 	Resources  5
       �� 
TargetType   WrapText �� Property �� Value��%T   &	        �� 5   
   " ��6   .�5      ��  � ��$
 Wrap=�6-   5      5      .��5      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TrainsitionigContentSlide��5   *   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6M   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromRight+   Duration$ 0:0:1.4X�.��5   
   � -   5        $��	GridEvent��5       � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $	��250 �6#   .+�5      �  � RowDefinitions 5      �� 5      $��50 �6$   �� 5      $��* �6$   .+�5      �� $��0��6   	 �� Orientation$	 
Horizontal=�6*   .+�5      �� $��Notify Events��6    ���	#FF3580BF$��30(�6L   $
��Bold"�6Z   $��5q�6l   �� 5      $	 
Horizontal=�6!   $��	170 0 0 0q�6:   .+�5      �� -   5        $��
SearchText��5   "   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Search here��64   $	��250��6a   $��5 5 30 5q�6m   ���#707070$��3q�6�   $��15(�6�   6�   '  !MaterialDesignThemes.Wpf.PackIcon  5      -   5        $��ExportToExell��5   2   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ 	FileExcel=�6G   $��40��6X   $��60��6d   $��Center=�6o   ���#7c0426 � Cursor$
 Hand��6�   6�   �� 5      $��	To Excell��6$   $��Bottom=�65   $��	-10 0 0 6q�6P   ���#7c04266c   5       5"      � 5#      $��1��6   .+�5$      &   System.Windows.Controls.DataGrid  -   5        $��EventDataGrid��5$      $��5 20 5 5q�65      
IsReadOnly . ���	#FF042263   VerticalGridLinesBrush �	#FF888888��6G   Z� ��6]   Z�    Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      -   5        IDColumn��,	  &System.Windows.Controls.DataGridColumn 	  Header$ ID��5'   C    	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ 70
 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Z   �� *Id+   ElementStyle 5(   "   �� 5)   &   " ��6,   .�5*   *   ��  � ��$
 Left=�6P   �� 5+   *    � ��$ Center=�6N   �� 5,   *    �@��Padding$ 5q�6D   5-   '    	  	CellStyle 5/   "   �� 50   &   *  $System.Windows.Controls.DataGridCell"  6,   .�51   *   ��  � �� �#2e61af6G   �� 52   *    � ��$ 5,0,0,0q�6L   �� 53   *    � �� �	#FF1342876H   �� 54   *    � ��
 �����6G    �� Triggers 55   *   P� 56   .    P� Property �@ 
IsSelected P� Value . . �57   2   ��  � �� �	#FF1342876O   �� 58   2    � ��$ 5,0,0,0q�6T   �� 59   2    � ��
 �����6P   �� 5:   2    � ��
 �����6O   5;   /   5=   '   5?        5@      -   5        EventDateColumn��$ 
Event Date��5@   J   $	 140
 6^    6j   �� *	EventDate+  5A      -   5        EventAddressColumn��$ Event Address��5A   M   $	 140
 6d    6p   �� *EventAddress+  5B      -	   5        EventDetialColumn��$ Event Detail��5B   L   $ *
 6b   # [  6�    6l   �� *EventDetail+6�   5E      5G      5H      � 5I      $��1��6   ���#7c0426$��2��68   .+�5J      �� $��0 0 0 15q�6   .+�5K      �� $��EVENT NOTIFICATION��6    $��0 20 0 0q�6:   
�������$��17(�6_   $��Nirmala UI Semilight)�6m    �� Padding$ 4q�6�   $��Center=�6�   �� 5L       J� Opacity$
 0.59Q�6    $
��10 0q�6/   �� 5M      $ ��UPCOMING EVENT INFORMATION��6    
�������$��	10 10 0 0q�6U   $��11(�6h   �� 5O      $��
Event Date��6    
�������$��	10 25 0 3q�6E   $��11(�6X   (  "System.Windows.Controls.DatePicker  5P      -
   5        $��	EventDate��5P   !   $
 
MM/dd/yyyy��62   
�������
�������$��	10 0 10 0q�6�   $��7q�6�   $��15(�6�   6�   �� 5Q      -   5        $��EDErr��5Q       $y�Hidden=�6-   $#��Name Must Be Atleast 5 Letter��6A   
�������$��10 0 0 5q�6y   $��10(�6�   �� 5S      $��Event Adress��6    
�������$��	10 10 0 5q�6G   $��11(�6Z   �� 5T      -   5        $��EventAdress��5T      
�������
�������$
��10 0q�6V   $��1q�6d   $��15(�6p   6~   �� 5U      -   5        $��EAErr��5U       $y�Hidden=�6-   $#��Name Must Be Atleast 5 Letter��6A   
�������$��10 0 0 5q�6y   $��10(�6�   �� 5W      $��Event Detail��6    
�������$��10 5 0 3q�6G   $��11(�6Y   �� 5X      -   5        $��EventDetail��5X      
�������
�������$	��200��6V    �� TextWrapping$
 Wrap=�6c    �� AcceptsReturn . $ �� HorizontalScrollBarVisibility$ Disabled=�6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   $
��10 0q�6�   $��1q�6�   $��15(�6�   6   �� 5Y      -   5        $��EVDErr��5Y       $y�Hidden=�6.   $#��Name Must Be Atleast 5 Letter��6B   
�������$��10 0 0 5q�6z   $��10(�6�   �� 5[      $	 
Horizontal=�6!   $��	10 15 0 3q�6:   .+�5\      �� -   5        $��UpdateButton��5\   !   
����������#7c0426���#7c0246$��Update��6s   $��0 0 5 0q�6�   6�   �� 5]      -   5        $��DeleteButton��5]   !   ���#ff0000���#7c0426
�������$��Delete��6s   $��0 0 5 0q�6�   6�   �� 5^      -   5        $��
SaveButton��5^   !   ���#0aa405���#7c0426
�������$
��Save��6r   $��0 0 5 0q�6�   6�   5_      5`      5a      5b      5c      5d      