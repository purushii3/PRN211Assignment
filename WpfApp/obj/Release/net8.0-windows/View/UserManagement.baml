   M S B A M L   `   `   `  ���� A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfApp.ViewWpfApp.View       WpfApp.View.UserManagement   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:WpfApp.View     -   $	��600��$
��1241��.��� $��10q�  � RowDefinitions  �� $	��300 ��� $��50 ��� $��60 �.+�&   System.Windows.Controls.DataGrid  -     Name$ dgData��$��0��   AutoGenerateColumns$ False��   
IsReadOnly$ False��   CanUserAddRows$ False��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ userID��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 60    
IsReadOnly$
 True��1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *UserId+  $ username��$ 70 	 �� *
UserName+  $ fullName��$	 150 	 �� *
FullName+  $ password��$	 120 	 �� *
Password+  $ roleId��$ 50 	 �� *RoleId+  $ 	birthDate��$	 100 	 �� *
Birthday+  $ address��$	 100 	 �� *	Address+  $ phone��$	 120 	 �� *Phone+  $ status��$	 100 	 �� *Status+�� $��1��
 �� Orientation$
 
Horizontal=�$��38��$	��Top=�.+��� -    ��Name$ 	txtUserId��$��40��$��5q�${�False���� -   $ txtUserName��$��70��$��5q��� -   $ txtFullName��$	��140��$��5q��� -   $ txtPassword��$	��100��$��5q��� -   $ 	txtRoleId��$��40��$��5q��� -   $ txtBirthDate��$��70��$��5q��� -	   $ 
txtAddress��$	��100��$��5q��� -
   $ txtPhone��$	��100��$��5q��� $
 
Horizontal=�$��5q�$��Center=�.+�	� -    	�Name$ rbStatusActive��$��Active�� 	� 	GroupName$ StatusGroup��$��5q� d� 	IsChecked �� *
IsActive+ �� Mode$ TwoWay=�	� -   $ rbStatusInactive��$��Inactive��$ StatusGroup��$��5q� �� *
IsActive+$ TwoWay=��� $��2��$
 
Horizontal=�$��	0,0,10,10q�.+��� -   $��Create User��$	��160��$��5q�����  �� Color$ #0099FF�� � Triggers :�  :� RoutedEvent$ 
MouseEnter��.[��� .���� .����  �� TargetProperty$1 +(Button.Background).(SolidColorBrush.Color)�	 �� To #28AEED g� Duration$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .���� $1 +(Button.Background).(SolidColorBrush.Color)� #0099FF$ 0:0:0.2D��� -   $��Update User��$	��160��$��5q����� $ 	#FF1B7140�� :� $ 
MouseEnter��.[��� .���� .���� $1 +(Button.Background).(SolidColorBrush.Color)� #28AEED$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .���� $1 +(Button.Background).(SolidColorBrush.Color)� #0099FF$ 0:0:0.2D��� -   $��Delete User��$	��160��$��5q����� $ 	#FFA2AA3D�� :� $ 
MouseEnter��.[��� .���� .���� $1 +(Button.Background).(SolidColorBrush.Color)� #28AEED$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .���� $1 +(Button.Background).(SolidColorBrush.Color)� #0099FF$ 0:0:0.2D��� $��44��$	��238��$��20,0,0,0q�$
 
Horizontal=�.+��� -    ��Name$ 	btnSearch��$��46��$��46��
������ 
������ $
��Left=�.���� $
 
Horizontal=�$��39��$	��151�� J� RenderTransformOrigin$ 
0.13,0.472&�.+��� $��/Images/search.png��$��44��$��40��$��Uniform=�$��Center=�� $	��196��$��46�� � ColumnDefinitions �� $��* ��� $
��Auto �.+��� -   $ 	txtSearch��$��20(�$��Medium"�$��	Helvetica)�$��40��$��Center=�$	��180��
������ 
���   �$��Center=�$��0,3,0,3q�.������  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R��� #��z��#��z��#��z�� �� CornerRadius$ 20��._���  ��Name$ PART_ContentHost��.���� -    ��Name$ txtPlaceholder��$��
Enter name��
�������$��15(�$��Medium"�$��	Helvetica)�$��Center=�$��10,0,8,0q�  J� IsHitTestVisible$  False��