   M S B A M L   `   `   `  ����D  @SmartEdir, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SmartEdir.ChatUserControlSmartEdir.ChatUserControl  5      /    )SmartEdir.ChatUserControl.UserControlChat   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:SmartEdir.ChatUserControl     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	��480��5	      $	��774��6   .��5
      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5           Name$  TrainsitionigContentSlide��5
   *   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6M   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromRight+   Duration$ 0:0:1.4X�.��5   
   �  � ColumnDefinitions 5      �� 5      $	��250 �6#   �� 5      $��* �6#   .+�5      ��  �� Orientation$ Vertical=�6   
������� J� Opacity$	 0.8Q�6G   .+�5      �� -   5        $��
SearchText��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search here��6,   $	��200��6Y   $��0 5 0 5q�6e   ���#707070$��2q�6�   $��13(�6�   6�   �� 5      -   5        $��ListViewMenu��5      $��Hidden=�61   $
��Auto=�6e   ��.  ��5      �� 5      .R�5      �� $ 
Horizontal=�6)   $
��10 0q�6B   .+�5   "   A� $��ProfileImageButton��6*   -   5        $��50��5   D   $��50��6P   $	��Top=�6[   $��Right=�6s   
���������5   &   �� 5   *   ProfileImage�� j� Stretch$ UniformToFill=�6i    �� ImageSource 6K   �� *Image+6i   5   #   �� 5   "   $ Vertical=�6-   $��20 0 0 0q�6D   .+�5   &   �� 
�������$��15(�6Y   $��0 10 0 0q�6g   $	��Top=�6z   ��6C   �� *Name+6z   %  MaterialDesignThemes.Wpf.Badged  5   &   $��	0 13 10 0q�6R   $��Right=�6e     ControlzEx.BadgedEx	   Badge	 6<   �� *New+6e   5   #   5      5       5"      5#      � 5$      $��1��6   
 � RowDefinitions
 5%      �� 5&      $��* �6$   �� 5'      $��40 �6$   .+�5)      �� $
��Auto=�6   $��Disabled=�6B   .��5*      �� -   5        $��StackPannelMain��5*   E   $ Vertical=�6!   $��0��68   $��Bottom=�6\   $��	0 0 10 15q�6w   .+�5+      �� $��	0 0 0 180q�6%   .+�5,      �� $��Smart Edir Chat Panel��6(   
�������$��23(�6\   $��Center=�6j   $��Center=�6�   $��0 0 0 7q�6�   �� 5-      $��Select Account To Chat��6(   ���#039be5$��13(�6[   $��Center=�6i   $��Center=�6�   5.      5/      50      �� 51      $��1��6   $ 
Horizontal=�6*   ���#039be5.+�52      �� -   5        $��Message��52      
�������$��17(�6@   $��3 0 0 2q�6N   $	��370��6`   ���#039be5$ Enter Message��6�   $��	20 0 25 0q�6�   �� 53      -   5        $
��Send��53       $
��SEND��6,   $��Center=�6a   
�������$��21(�6�   $
��Bold"�6�    � Cursor$
 Hand��6�   54      55      57      59      5:      