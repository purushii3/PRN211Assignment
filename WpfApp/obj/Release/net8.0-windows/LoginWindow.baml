   M S B A M L   `   `   `  ���� A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp      WpfApp.LoginWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:WpfApp       � Title$  LoginWindow��$	��450��$	��800�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�
������  � AllowsTransparency$
 True��.��� .+���  �� CornerRadius$ 10��$��2q�����  �� ImageSource$ /Images/background.png��._��� $��155,60,155,60q�._���  �� Orientation$ Vertical=�.+��� $��Login��$��50(�
�������$��	Helvetica)�$��Center=�$��0,30,0,0q�� $	��480��$��50��$��0,30,0,0q� � ColumnDefinitions �� $��* ��� $
��Auto �.+��� -    ��Name$ txtUser��$��20(�$��Medium"�$��	Helvetica)�$��45��$��Center=�$	��480��
�������$��Center=�.������ 	 �� 
TargetType"	 ��.��� 
 �� Property
 � �� �� Value ��  �� 
TargetType" ��.R��� #��z��#��z��#��z��$ 20��._���  ��Name$ PART_ContentHost��.���� -    ��Name$ txtPlaceholder��$��Enter Username�����	#FF3A3A3A$��20(�$��Medium"�$��	Helvetica)�$��Center=�$��10,0,0,0q� J� IsHitTestVisible$ False���� $��/Images/use.png��$��	408,6,7,6q�� $	��480��$��50��$��0,20,0,0q� �� $��* ��� $
��Auto �.+�G� -    G�Name$ txtPass��$��13(�$��Medium"�$��
Montserrat)�$��45��$��Center=�
�������$	��480�� G� Password$  ������ "	 G�.��� 
 � �� �� " G�.R��� #��z��#��z��#��z��$ 20��._��� $ PART_ContentHost���� -   $ txtPlaceholderP��$��Enter Password�����	#FF3A3A3A$��20(�$��Medium"�$��	Helvetica)�$��Center=�$��10,0,0,0q�$ False��$y�Visible=��� $��/Images/pass.png��$��	408,6,7,6q�� $	��480��$��40��$��0,40,0,0q�.+��� -    ��Name$ btnLogin��$��LOG IN��
�������$��12(�$��
Montserrat)� � Cursor$
 Hand��$��	0,0,276,0q����� "	 ��.��� 
 � �� �#0099FF �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ��� 
 � �� �#28AEED���� " ��.R��� $	��150��$��40��$ 20��#��z��._��� $��Center=�$��Center=��� -   $ btnRegister��$��REGISTER��
�������$��12(�$��
Montserrat)�$
 Hand��$��	276,0,0,0q����� "	 ��.��� 
 � ��
 ��� � P�  �@J�IsMouseOver$
 True��. ��� 
 � ��
 �W�.����� " ��.R��� $	��150��$��40��$ 20��#��z��._��� $��Center=�$��Center=�