   M S B A M L   `   `   `  ���� ?  ;SOMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SOMSSOMS      SOMS.userPageView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     $localclr-namespace:SOMS       � Title$  Manage User��$	��550��$	��800��.����  �� Orientation$ Vertical=�.+��� $��	User Form��$��10q�.��� $	��150�� � RowDefinitions �� $��1* ��� $��1* ��� $��1* ��� $��1* � � ColumnDefinitions �� $	��100 ��� $��* �.+��� $��Id��$
��Left=�$��Center=�$��0��$��0���� -    ��Name$ TextBlockId��$��0��$��1��$��27��$��5q�$	��300��$
��Left=��� $��Username��$
��Left=�$��Center=�$��1��$��0���� -    ��Name$ TextBoxUsername��$��1��$��1��$��27��$��5,5,0,5q�$	��300��$
��Left=��� $��Password��$
��Left=�$��Center=�$��2��$��0���� -   $ TextBoxPassword��$��2��$��1��$��27��$��5q�$	��300��$
��Left=��� $��Status��$
��Left=�$��Center=�$��3��$��0���� -    ��Name$ TextBoxStatus��$��3��$��1��$��27��$��5q�$	��300��$
��Left=�.@��� $��Admin���� $
��User���� $��40��$ 
Horizontal=�$��Right=�.+��� -    ��Name$ 	ButtonAdd��$	��Add��$��30��$��80��$��5,0,5,0q��� -   $ ButtonUpdate��$��Update��$��30��$��80���� -   $ ButtonCancel��$��Cancel��$��30��$��80��$��5,0,10,0q��� $	��210��.+�&   System.Windows.Controls.DataGrid  -     Name$ DataGridUser��"	   VerticalScrollBarVisibility$
	 Auto=�
   AutoGenerateColumns$
 False��   CanUserAddRows$ False��$	��200��$��10q����� *
userList+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100    
IsReadOnly$
 True��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ Id�  $ Username��$	 100 $
 True�� �� $ Username�  $ Password��$	 100 $
 True�� �� $ Password�  $ Status��$	 100 $
 True�� �� $ Status�4  .System.Windows.Controls.DataGridTemplateColumn  $ 50    CellTemplate �� .R��� $ 
ButtonEdit��-	   $��Select��  $ 50  �� .R��� $ ButtonDelete��-
   $��Delete��