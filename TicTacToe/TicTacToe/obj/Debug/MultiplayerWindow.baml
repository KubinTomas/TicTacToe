   M S B A M L   `   `   `  ����D  @TicTacToe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TicTacToe	TicTacToe  5   	   !    TicTacToe.MultiplayerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TicTacToe     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ MultiplayerWindow��5
   	   $	��500��6#   $	��500��60   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ txtIp��5      $
��Left=�6!   $��29��6<   $��0,39,0,0q�6H   $��1��6Z    �� TextWrapping$
 Wrap=�6g   $��	127.0.0.1��6{   $	��Top=�6�   $	��115��6�   $��1��6�   �� 5   
   -   5         ��Name$ server��5      $��Server��6!   $
��Left=�62   $��2��6M   $	��Top=�6Z   $	��105��6r   $��1��6~   $��43��6�   $��	10,45,0,0q�6�   6�   �� 5   
   -   5        $ client��5      $��Client��6!   $
��Left=�62   $��2��6M   $	��Top=�6Z   $	��105��6r   $��2��6~   $��43��6�   $��	10,45,0,0q�6�   6�   �� 5   
   -   5        $ txtPort��5      $
��Left=�6#   $��29��6>   $��	10,39,0,0q�6J   $��1��6]   $
 Wrap=�6j   $
��4444��6~   $	��Top=�6�   $	��115��6�   $��2��6�   5!      5"      