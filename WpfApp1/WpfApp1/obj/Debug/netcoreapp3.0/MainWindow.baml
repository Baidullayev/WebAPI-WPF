   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   B >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1 5   	      WpfApp1.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   C	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  MyNote��5
   	   $	��530��6   $
��1000��6%    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��26* �6   �� 5      $
��181* �6   �� 5      $
��562* �6   �� 5      $
��231* �6   .+�5   
   o� -   5         o�Name$ MainMenu��5      $��25��6"   $	��Top=�6.   $��11(�6F   $��Arial)�6T   $��4��6g   $��	0,0,208,0q�6{   .@�5      m� $
��File��6   .@�5      m� -   5        $��NewNoteMenuItem��5      $��New Note��62   ${�False��6D   6h   m� 5      -   5         m�Name$ SignOutMenuItem��5   4   $��Sign in��6M   5      �� 5      m� 5      -   5        $
��Exit��5      68   5      m� 5      $��Options��6   6+   m� 5       $
��Help��6   6(   5"      �� 5#   
   $
��Left=�6   $	��612��62   $��
179,25,0,0q�6?   $	��Top=�6S   $��2��6k   $��1��6u   �� 5$   
   -   5        $��
NewNoteBox��5$   $   $��New Note��6   ${�False��66   $
��Left=�6H   $��20��6c   $��	10,30,0,0q�6o   $	��Top=�6�   $	��190��6�   $
��Bold"�6�   $��2��6�   �� 5%   
   -   5        $��AllNotesItemButton��5%   $   $��My Notes��6   ${�False��6>   $
��Left=�6P   $��20��6k   $��	10,61,0,0q�6w   $	��Top=�6�   $	��190��6�   $��Normal"�6�   $��2��6�   �� 5'   
   -   5        $��SharedNotesButton��5'   *   $��Shared with me��6   ${�False��6C   $
��Left=�6U   $��20��6p   $��	10,91,0,0q�6|   $	��Top=�6�   $	��190��6�   $��Normal"�6�   $��2��6�   6�   �� 5(   
   $
��Left=�6   $	��607��62   $��
324,30,0,0q�6?   $	��Top=�6S   $��1��6k   $��2��6u   �� 5)   
   -	   5        $��TrashButton��5)   !   $��Trash��6   $
��Left=�64   ${�False��6O   $��20��6a   $��
10,121,0,0q�6m   $	��Top=�6�   $	��190��6�   $��Normal"�6�   $��2��6�   �� 5*   
   -
   5        $��NoteBox��5*   $   ${�False��6   $��2��63   $
��Left=�6C   $	��412��6^   $��
330,91,0,0q�6k   $�� ��6    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��453��6�   $��2��6�   �� 5+   
   -   5        $��SaveChangesButton��5+      ${�False��6*   $��Save changes��6<   $��3��6S   $
��Left=�6c   $��25��6~   $��
123,30,0,0q�6�   $	��Top=�6�   $��98��6�   6�   (  "System.Windows.Controls.DatePicker  5,   
   -   5        $��RemindTimePicker��5,      ${�False��6-   $��3��6?   $
��Left=�6O   $��	18,30,0,0q�6j   $	��Top=�6}   �� 5-   
   $��Remind time��6   $��2��6&   $
��Left=�66   $��
504,32,0,0q�6Q   $	��Top=�6e   $��2��6}   �� 5.   
   -   5        $��NotesListLabel��5.      $��
Notes List��6'   $��2��6<   $
��Left=�6L   $��5,33,0,0q�6g   $	��Top=�6y   $	��138��6�   �� 5/   
   -   5        $��SignInLable��5/      $��Sign in��6$   $��3��6^   $
��Left=�6n   $��25��6�   $��28,0,0,0q�6�   $	��Top=�6�   $	��193��6�   $��Right=�6�    � Cursor$
 Hand��6�   �� 50   
   -   5        $��	NotesList��50      $��2��6R   $
��Left=�6b   $	��442��6}   $��5,61,0,0q�6�   $	��Top=�6�   $	��314��6�    � ContextMenu 52      �� 53      -   5        $��ZoneIformationList��53       �� 	StaysOpen$
 true��68   
�������	 J� BitmapEffect	 54      �� 55      .@�57      m� -   5        $��ShareContextMenu��57   .   $��Share��6   6G   m� 58      -   5        $��TrashContextMenu��58   6   $��Move to Trash��6   6N   m� 59      -   5        $��PdfContextMenu��59   6   $��Export to pdf��6   6L   5:      
 �� View
 5<      �� 5=      .P�5>      �� -  'WpfApp1.GridViewColumnVisibilityManager   	IsVisible$ false��6%    �� DisplayMemberBinding 6]   ��  �� Path$ Id�.��6�   Id6�   �� 5?       �� Width$	 350��6R    6%   �� $ Header�.��6^   header6f   5@      5B      �� 5C   
   $��Header��6   $��2��6!   $
��Left=�61   $��
331,36,0,0q�6L   $	��Top=�6`   �� 5D   
   -   5        $��	HeaderBox��5D      ${�False��6#   $��2��65   $
��Left=�6E   $��24��6`   $��
331,59,0,0q�6l   $�� ��6�   $
 Wrap=�6�   $	��Top=�6�   $	��453��6�   $��2��6�   5E      5F      