   M S B A M L   `   `   `  ����D  @TicTacToe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TicTacToe	TicTacToe  5   	       TicTacToe.endGame   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TicTacToe     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ endGame��5	   	   $	��350��6   $	��350��6&   .��5
      �  � RowDefinitions 5   
   �� 5      $	��40* �6   �� 5      $
��150* �6   �� 5      $
��115* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��winner��5   \   $��1��6   $��2��6!   $	��250��65   $	��100��6A   $��25(�6N    �� TextAlignment$ Center=�6j   �� 5   
   -   5        $��2��5      $��0��6   $	��100��6.   $��50��6:   $��
Play again��6F   $��20(�6[   6i   �� 5   
   -   5        $��2��5      $��1��6   $	��100��6.   $��50��6:   $��End game��6F   $��20(�6Y   6g   5      5      