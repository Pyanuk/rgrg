   M S B A M L   `   `   `  ����@  <COFFE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:COFFECOFFE  5          COFFE.UserPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:COFFE     5        N� Title$  UserPage��5      $	��454��6   .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ UserDatagrid��5         AutoGenerateColumns .  $��
0,0,20,256q�6E      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	ID_User+  5      $/ )Название пользователя��6%    6D   �� *
Username+  5      $+ %Пароль пользователя��6%    6B   �� *Password_Users+  5      $ Роль ID��6%    66   �� *Roles.RoleName+5      �� 5   
   -   5         ��Name$ insert��5      $#��Добавить данные��6!   $��0,307,20,123q�6;   6Q   �� 5   
   -   5        $ delete��5      $#��Удаление данных��6!   $��0,283,20,143q�6;   6Q   �� 5   
   -   5        $ update��5      $'��!Обновление данных��6!   $��0,263,20,167q�6=   6S   �� 5   
   -   5         ��Name$ RoleComboBox��5      $��0,203,20,231q�6)   �� 5   
   -   5         ��Name$ NasvanieTextBox��5      $��0,243,20,187q�6+   ��6A   �� *SelectedItem.Username+	 �� UpdateSourceTrigger$	 PropertyChanged=�.��6�   
 � 	Resources
 5       �� 
TargetType �� Property �� Value �� 
TargetType � ColumnDefinitions ��Name ��Name J� IsHitTestVisible ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  '��       �� 5      " ��6   .�5      ��  � �� 5      �� 5      " ��6.   .R�5    "   �  5!   &   �� 5"   *   $
��128* �6;   �� 5#   *   $	��25* �6;   �� 5$   *   $	��65* �6;   .+�5&   &   �� $ border��6-   #��z��5'      #��z��5(      #��z��5)      $��3��6I   �� 5*   &   $ 	watermark��60   $B��<Введите название пользователю ...��5+      $��2,2,2,2q�5,      
�������$y�	Collapsed=�5.       .  $��3��5/   1   �� 50   &   $ PART_ContentHost��63   $��3��6M   51   #    52   "   P� 53   &    � ��$  ��6>   . �54   *   �� $ 	watermark��61    � y�$ Visible=�6^   55   '   57      59      5:      5;      .��6!   5<      G� 5>   
   -   5         G�Name$ PasswordTextBox��5>      $��0,223,20,207q�6/   5?      5B      5C      