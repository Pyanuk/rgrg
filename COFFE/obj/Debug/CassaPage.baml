   M S B A M L   `   `   `  ����@  <COFFE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:COFFECOFFE  5          COFFE.CassaPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:COFFE     5        N� Title$  	CassaPage��5	      .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ CoffeDatagrid��5         AutoGenerateColumns .  $��0,0,532,195q�6F      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Коффе��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Type_Coffee_Name+  5      $ Цена��6%    63   �� *PRICE_Type_Coffee+5        5   
   -   5        $ ProductsDatagrid��5       .  $��519,2,10,193q�6I    5        5      $ Еда��6%    62   �� *ProductName+  5      $ Цена��6%    63   �� *Price+5      �� 5   
   -   5         ��Name$ CartListBox��5      $
��Left=�6'   $��268,2,0,195q�6B   $	��254��6W   �� 5   
   -   5        $(��"Удалить из корзины��5      $
��Left=�6.   $	��Top=�6I   $��318,187,0,0q�6a   $	��154��6�   �� 5   
   -   5         ��Name$ Check��5      $��Покупка��6    $��317,161,405,0q�62   $	��Top=�6I   $��26��6u   �� 5   
   -   5        $ Cheki��5      $��Чеки��6    $��395,161,328,263q�6/   �� 5   
   -   5         ��Name$ PaidAmountTextBox��5      $��317,207,329,0q�6-   $	��Top=�6D   �� 5   
   -   5        $ TotalAmountTextBox��5      $
��Left=�6.   $��318,225,0,0q�6I   $	��Top=�6^   $	��154��6v   	 �� 
IsReadOnly	 . 6�   5       5!      