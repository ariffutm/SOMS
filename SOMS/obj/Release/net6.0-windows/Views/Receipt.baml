   M S B A M L   `   `   `  ���� ?  ;SOMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SOMSSOMS      SOMS.Receipt   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     $localclr-namespace:SOMS       � Title$  Receipt��$	��550��$	��620��.��� .+���  �� Orientation$ Vertical=�.+�� $	��100�� � RowDefinitions �� $��1* ��� $��1* ��� $��1* � � ColumnDefinitions �� $	��200 ��� $��70 ��� $	��330 �.+��� $��50��$	��170��$
��Left=�$��2��$��0��$��3,0,0,0q�����  �� DecodePixelWidth$	 300�� �� 	UriSource$ ../Resources/logo.png?��� $��RECEIPT��$��Right=�$��Center=�$��0��$��2��$��2��$��86��$��19(�$
��Bold"�$��0,0,0,0q�$��Segoe UI Semibold)��� $��Bill To��$��1,1,1,1q�$��95��$��Segoe UI Semibold)�.��� $��75�� �� $��1* ��� $��1* ��� $��1* ��� $��1* � �� $��30 ��� $	��350 ��� $��50 ��� $	��200 �.+��� -    ��Name$ Customer��$��3��$
��Name��$��0,1,0,0q�$
��Left=�$��0��$��0��$	��300��$��11(�$��Segoe UI Light)��� -   $	 Ref��$
��REF#��$��Center=�$��0��$��2��$��40���� -   $ RefValue��$��Value��$
��Left=�$��0��$��3��$	��171��$��11(�$��Consolas)��� $��Telp:��$��Center=�$��1��$��30��$��11(�$��Segoe UI SemiBold)��� -   $ Phone��$��1��$��3��$��Phone��$��0,1,0,0q�$
��Left=�$��1��$	��200��$��11(�$��Consolas)��� -   $
 Date��$
��DATE��$��Center=�$��1��$��2��$��40���� -   $ 	DateValue��$��Value��$
��Left=�$��1��$��3��$	��171��$��11(�$��Consolas)��� -   $ Address1��$��3��$��Address��$
��Left=�$��2��$	��370��$��11(�$��Segoe UI Light)�$��0���� -   $ Method��$
��TYPE��$��Center=�$��2��$��2��$��40���� -	   $ 	TypeValue��$��Value��$
��Left=�$��2��$��3��$	��171��$��11(�$��Consolas)��� -
   $ Address2��$��3��$��Address��$
��Left=�$��3��$	��370��$��11(�$��Segoe UI Light)�$��0���� -   $ Track��$��TRACK��$��Center=�$��3��$��2��$��40���� -   $ 
TrackValue��$��Value��$
��Left=�$��3��$��3��$	��171��$��11(�$��Consolas)�&   System.Windows.Controls.DataGrid  -     Name$ DataGridOrderItem��"   VerticalScrollBarVisibility$
 Auto=�	   AutoGenerateColumns$	 False��
   CanUserAddRows$
 False��$��5q�$��Consolas)�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 ITEM��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 300    
IsReadOnly$
 True��   
FontFamily$ Segoe UI Light)�1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ ItemName�  $ QUANTITY��$ 70 $
 True��$ Segoe UI Light)� �� $ Quantity�  $ 
UNIT PRICE��$	 100 $
 True��$ Segoe UI Light)� �� $ Price�  $ AMOUNT��$	 100 $
 True��$ Segoe UI Light)� �� $ Total��� $��30��.+��  �� $��1* � �� $	��380 ��� $��70 ��� $��30 ��� $
��100* �.+��� $��0,0,0,0q�$��TOTAL��$
��Left=�$��Center=�$��0��$��1��$��50��$��30��$��Segoe UI Semibold)��� $��0,0,0,0q�$��RM��$��Right=�$��Center=�$��0��$��2��$��30��$��30��$��Consolas)��� -   $ 
TotalValue��$��3,0,0,0q�$��Value��$
��Left=�$��Center=�$��0��$��3��$��90��$��12(�$��Consolas)�