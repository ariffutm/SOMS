   M S B A M L   `   `   `  ����?  ;SOMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SOMSSOMS  5   	       SOMS.orderListView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:SOMS     5   	     � Title$  List of Order��5   	   $	��450��6   $
��1500��6,   .��5	      �  � RowDefinitions 5
   
   �� 5      $��65 �6   �� 5      $��1* �6   .+�5   
   �� $
��Left=�6   $	��450��60   .+�5      �� $��Search��6   $��3,3,3,3q�6'   $	��600��68   $��60��6D   ���	#FF0C0D0E.��5      � $��35��6    5      �� 5      $��1* �6(    � ColumnDefinitions 5      �� 5      $��70 �6+   �� 5      $��5 �6+   �� 5      $	��230 �6+   �� 5      $	��110 �6+   �� 5      $��90 �6+   �� 5      $	��100 �6+   .+�5      �� $��Detail��6   $��Center=�6-   $��Center=�6J   $��0��6l   $��50��6y   �� 5      -   5         ��Name$ TxtBxDetail��5   ;   $��0��6   $��2��6+   $��30��6P   $	��200��6\   $
��Left=�6h   �� 5!      -   5         ��Name$ ButtonFindID��5!   c   $��3��6   $
��Left=�6-   $��Center=�6H   $��Find By Reference��6y   $��21��6�   ���	#FFDDDDDD6�   �� 5"      -   5        $ ButtonFindDate��5"   -   $��4��6   $��Find By Date��6E   $��21��6\   ���	#FFDDDDDD$
��Left=�6   $��Center=�6�   �� 5#      -   5        $ ButtonAllOrder��5#   -   $��5��6   $��Get All Order��6E   $��21��6]   ���	#FFDDDDDD$
��Left=�6�   $��Center=�6�   5$      5%      5&      � 5'   
   $��1��6   .+�5)      &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridOrder��5)   :   "   VerticalScrollBarVisibility$
 Auto=�6      AutoGenerateColumns$ False��6Q      CanUserAddRows$ False��5*   ,   $��7,7,7,7q�6C   $��Consolas)�6T   ��6
   �� *	orderList+	   Columns	 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn
   Header$
 	Reference��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6Y      
IsReadOnly$
 True��6f   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   ��  �� Path$ Id�6f     5-      $
 Customer��6)   $	 150 6]   $
 True��6j    6;   �� $ Customer�6j     5.      $
 Phone��6)   $	 100 6W   $
 True��6d    68   �� $ Phone�6d     5/      $
 Email��6)   $	 100 6W   $
 True��6d    68   �� $ Email�6d     50      $
 Method��6)   $	 100 6Y   $
 True��6f    69   �� $ Method�6f     51      $
 Courier��6)   $	 100 6[   $
 True��6h    6:   �� $ Courier�6h     52      $
 Status��6)   $	 100 6Y   $
 True��6f    69   �� $ Status�6f     53      $

 Date��6)   $	 100 6Y   $
 True��6f    67   �� $ IssuedOn�6f     54      $
 Address��6)   $	 400 6[   $
 True��6h    6:   �� $ Address�6h   4  .System.Windows.Controls.DataGridTemplateColumn  55      $ 50 6-      CellTemplate 56      �� 57      .R�58   "   �� $ ButtonSelect��6N   -   5        $��Select��58   =   6N   59      5;        5<      $ 50 6-    5=      �� 5>      .R�5?   "   �� $ ButtonDelete��6N   -   5        $��Delete��5?   =   6N   5@      5B        5C      $ 50 6-    5D      �� 5E      .R�5F   "   �� $ ButtonEmail��6`   -   5        $��Email��5F   P   6`   5G      5I      5K      5L      5M      5N      