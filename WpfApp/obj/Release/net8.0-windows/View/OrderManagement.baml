   M S B A M L   `   `   `  ���� A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfApp.ViewWpfApp.View  !    WpfApp.View.OrderManagement   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     +localclr-namespace:WpfApp.View     -   .��� $��10q�  � RowDefinitions  �� $��* ��� $��50 ��� $��* ��� $��50 ��� $��50 �.+�&   System.Windows.Controls.DataGrid  -     Name$ dgData��$��0��   AutoGenerateColumns$ False��$��0 10 0 0q�   
IsReadOnly$
 True��   CanUserAddRows$ False��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Order Id��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 80    
IsReadOnly$
 True��1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *	OrderId+  $ 
Order Date��$	 100 	 �� *Date+  $ Total Money��$	 100 	 �� *
TotalMoney+  $ 	User Name��$	 100 	 �� *User.UserName+  $ Status��$ * 	 �� *Status+�� $��1��
 �� Orientation$
 
Horizontal=�$��38��$	��Top=�.+��� -    ��Name$ 
txtOrderId��$��80��$��5q�${�False���� -   $ txtDate��$	��100��$��5q��� -   $ txtTotalMoney��$��80��$��5q��� -    ��Name$ cboUser��$��80��$��5q��� $
 Vertical=�$��1q�$��Center=�.+�	� -    	�Name$ rbStatusActive��$��Active�� 	� 	GroupName$ StatusGroup�� d� 	IsChecked �� *
IsActive+ �� Mode$ TwoWay=�	� -   $ rbStatusInactive��$��Inactive��$ StatusGroup�� �� *
IsActive+$ TwoWay=�  -	   $ 	dgDetails��$��2��$ False��   SelectionMode$ Single=�$��0 10 0 0q�$
 True��$ False��   $ Order Id��$ 80 $
 True��	 �� *Order.OrderId+  $ Koi Fish Id��$	 100 	 �� *KoiFish.KoiFishId+  $ Quantity��$	 100 	 �� *
Quantity+  $ Price��$ 60 	 �� *Price+  $ Status��$ * 	 �� *Status+�� $��3��$
 
Horizontal=�$��38��$	��Top=�.+��� -
   $ cboKoi��$��90��$��5q��� -   $ txtQuantity��$��80��$��5q��� -   $ txtPrice��$��80��$��5q��� $
 Vertical=�$��1q�$��Center=�.+�	� -   $ 
rbStatusOn��$��Active��$ StatusGroup�� �� *
IsActive+$ TwoWay=�	� -   $ rbStatusOff��$��Inactive��$ StatusGroup�� �� *
IsActive+$ TwoWay=��� $��4��$
 
Horizontal=�.+��� -   $��Delete Order��$	��155��$��5q�����  �� Color$ 	#FFA2AA3D�� � Triggers :�  :� RoutedEvent$ 
MouseEnter��.[��� .���� .����  �� TargetProperty$1 +(Button.Background).(SolidColorBrush.Color)�	 �� To #28AEED g� Duration$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .���� $1 +(Button.Background).(SolidColorBrush.Color)� #0099FF$ 0:0:0.2D��� -   $��Delete Order Detail��$	��155��$��5q�$��5q����� $ 	#FF1B7140�� :� $ 
MouseEnter��.[��� .���� .���� $1 +(Button.Background).(SolidColorBrush.Color)� #28AEED$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .���� $1 +(Button.Background).(SolidColorBrush.Color)� #0099FF$ 0:0:0.2D�