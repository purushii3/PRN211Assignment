   M S B A M L   `   `   `  ���� A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfApp.ShopWpfApp.Shop      WpfApp.Shop.CheckOut   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     +localclr-namespace:WpfApp.Shop     -   .��� $��10q�  � RowDefinitions  �� $��* ��� $��50 ��� $��50 �.+�&   System.Windows.Controls.DataGrid  -     Name$ dgData��$��0��   AutoGenerateColumns$ False��$��0 10 0 0q�   
IsReadOnly$ False��   CanUserAddRows$ False��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Koi Fish Name��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 450 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *KoiFish.KoiFishName+  $ Quantity��$	 200  �� *
Quantity+  $ Price��$ *  �� *Price+�� $��1��	 �� Orientation$	 
Horizontal=�$��38��$	��Top=�.+��� -   
 ��Name$
 
txtKoiName��$	��200��$��5q��� -   $
 txtQuantity��$	��124��$��29��$��5q��� -   $
 txtPrice��$��80��$��5q��� -   $
 txtTotalPrice��$	��100��$��	230,5,5,5q��� $��2��$	 
Horizontal=�.+��� -   $��Checkout��$	��155��$��5q�$��5q�����  �� Color$ #0099FF�� � Triggers :�  :� RoutedEvent$ 
MouseEnter��.[��� .���� .����  �� TargetProperty$1 +(Button.Background).(SolidColorBrush.Color)�	 �� To #28AEED g� Duration$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .���� $1 +(Button.Background).(SolidColorBrush.Color)� #0099FF$ 0:0:0.2D��� -   $��Delete Order��$	��155��$��5q����� $ 	#FFA2AA3D�� :� $ 
MouseEnter��.[��� .���� .���� $1 +(Button.Background).(SolidColorBrush.Color)� #28AEED$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .���� $1 +(Button.Background).(SolidColorBrush.Color)� #0099FF$ 0:0:0.2D�