   M S B A M L   `   `   `  ���� ?  ;SOMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SOMSSOMS      SOMS.salesPageView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     $localclr-namespace:SOMS       � Title$  
Sales Page��$	��450��$	��900��.���  � RowDefinitions �� $��65 ��� $��1* �.+��� $	��450��.+��� $��Search��$��4,4,4,4q�$	��870��$��55�����	#FF0C0D0E.��� $��35�� �� $��1* � � ColumnDefinitions �� $��70 ��� $��10 ��� $	��90* ��� $��40 ��� $��10 ��� $	��120 ��� $��40 ��� $��10 ��� $	��120 ��� $	��70* ��� $	��70* ��� $	��70* �.+��� $��Sum (RM)��$��Center=�$��Center=�$��0��$��70���� -    ��Name$ TxtBxSum��
������� �� 
IsReadOnly$
 True��$��0��$��1��$��0,5,0,3q�$	��135��$
��LEft=�$��2���� $
��From��$��Center=�$��Center=�$��0��$��3��$��40��(  "System.Windows.Controls.DatePicker  -     Name$ TxtBxDateFrom��$��0��$��5��$��0,5,0,3q�$	��110��$
��Left=�����  �� EndPoint$ 0.5,0&� �� 
StartPoint$ 0.5,1&�.���  � Color$ 	#FFA3AEB9��� $ 	#FF8399A9��	 � Offset$	 0.375Q�� $ 	#FF718597��$	 0.375Q�� $ 	#FFABADB3��$	 1Q��� $��To��$��Center=�$��Center=�$��0��$��6��$��30��  -   $ TxtBxDateTo��$��0��$��8��$��0,5,0,3q�$	��110��$
��Left=����� $ 0.5,0&�$ 0.5,1&�.��� $ 	#FFA3AEB9��� $ 	#FF8399A9��$	 0.375Q�� $ 	#FF718597��$	 0.375Q�� $ 	#FFABADB3��$	 1Q��� -   
 ��Name$
 
ButtonFind��$��9��$��80��$��Find By Date��$��21��$��0,6,0,0q����	#FFDDDDDD$	��Top=��� -   $
 ButtonSales��$��10��$��80��$��Get All Sales��$��21��$��0,6,0,0q����	#FFDDDDDD$	��Top=��� -   $
 ButtonReport��$��11��$	��100��$��Generate Report��$��21��$��0,6,0,0q����	#FFDDDDDD$	��Top=�� $��1��.+�&   System.Windows.Controls.DataGrid  -     Name$ DataGridSales��"   VerticalScrollBarVisibility$
 Auto=�   AutoGenerateColumns$ False��   CanUserAddRows$ False��$��10,10,10,10q�$��Consolas)����� *	salesList+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Order Reference��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 150    
IsReadOnly$
 True��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ orderId�  $ 	Item Name��$	 150 $
 True�� �� $ itemName�  $ Quantity��$	 100 $
 True�� �� $ Quantity�  $
 Date��$	 100 $
 True�� �� $ 
dateIssued�  $ Amount (RM)��$	 100 $
 True�� �� $ Amount�