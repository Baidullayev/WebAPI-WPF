   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	   !    WpfApp1.AuthorizationWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  AuthorizationWindow��5   	   $	��220��6%   $	��250��62    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��44* �6   �� 5      $
��130* �6   �� 5      $	��55* �6   �� 5      $	��14* �6   �� 5      $��7* �6   .+�5   
   �� -   5        $��UsernameBox��5      $
��Left=�6%   $��16��6@   $��	32,64,0,0q�6L   $�� ��6_    �� TextWrapping$
 Wrap=�6g   $	��Top=�6{   $	��186��6�   $��3��6�   G� 5   
   -   5        $��PasswordBox��5      $
��Left=�6)   $	��Top=�6D   $	��186��6\   $��
34,118,0,0q�6h   $��3��6|   �� 5   
   $��Password��6   $
��Left=�6#   $��	34,95,0,0q�6>   $	��Top=�6Q   $��79��6i    J� RenderTransformOrigin$ 0.823,0.504&�6t   $��2��6�   �� 5   
   $��Login��6   $
��Left=�6    $��	34,41,0,0q�6;   $	��Top=�6N   $��79��6f   $��2��6q   �� 5   
   -   5        $��Sign In��5      $
��Left=�6#   $��
99,149,0,0q�6>   $	��Top=�6R   $ -0.222,0.539&�6j   $��66��6�   $��1��6�   $��2��6�   �� 5   
   -   5        $��Register��5      $
��Left=�6$   $��
30,149,0,0q�6?   $	��Top=�6S   $��64��6k   $ 0.531,1.016&�6�   $��1��6�   �� 5   
   -   5        $��FeedbackLabel��5      $�� ��6%   $
��Left=�60   $��43��6K   $	��Top=�6W   $	��230��6o   $��4��6{   $��	10,10,0,0q�6�   
���  ��6�   5      5      