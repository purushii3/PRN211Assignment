   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.ShopWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ 
ShopWindow��5	   	   $	��700��6   $
��1200��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��Center=�6,   $��32��6I   $	��Top=�6U   $
��1200��6m   $��0��6z   .+�5      �� -   5         ��Name$ Login��5      $
��null��5      $��Center=�5      $��Center=�5      $
��Bold"�5      
�������5      ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,0&�67   .��5      �  � Color$ 	#FF0099FF��6#    � Offset$ 0Q�65   � 5      $ 	#FF800080��6#   $ 1Q�65   5      5      �� 5   
   $
��Left=�6   $
��1000��60   $��1,0,0,0q�6>   $	��Top=�6O   $��98��6g   ���	#FF717578$��1��6�   .+�5       �� -   5        	 ��Name$	 	CartItems��5       $��21��6+   $
��Wrap=�67   $��0��6K   $��50��6T   $��18(�6_   $��42,0,0,0q�6m   �� 5!      -   5        
 ��Name$
 btnShoppingCart��5!      $��43��6.   $��46��6:   
������ 
������ $
��Left=�5#      $��19,0,0,0q�6I   .��5$      �� $ 
Horizontal=�6   $��39��66   $	��146��6B   .+�5%      �� $��/Images/shoppingcart.png��6   $��44��6>   $��40��6I   $��Uniform=�6U   $��Center=�6g   5&      5'      �� 5C      -   5        $
 koiList��5C      $��40��5D      $��5,20,5,0q�5E      $��Koi List��5F      
���   �5H      �� 5J      -   5        $
 logOut��5J      $��40��5K      $��5,20,5,0q�5L      $��Log Out��5M      
��� ���5O      5P      �� 5R   
   -   5         ��Name$ ContentArea��5R      $��1��6.   $��104,10,20,3q�6;   $��Stretch=�6P   $��Stretch=�6l   5S      5T      