   M S B A M L   `   `   `  ����H  DSocialNetwork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SocialNetwork.PagesSocialNetwork.Pages  5      &     SocialNetwork.Pages.CommentsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:SocialNetwork.Pages     5        N� Title$  CommentsPage��5	         BackgroundBrush N� 
Background# [  6   .��5      �  � RowDefinitions 5   
   �� 5      $��5* �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��DataGridComments��5   4   $��0��6   $��2��6       AutoGenerateColumns .     
IsReadOnly .   DataGridStyle#��[ 5        DataGridColumnHeaderStyle   ColumnHeaderStyle# [ 5         HeadersVisibility$ Column=�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *
comment_id+  5      $	 PostId��6%   
 65   �� *	post_id+  5      $	 UserId��6%   
 65   �� *	user_id+  5      $	 Content��6%   
 66   �� *	content+  5      $	 	CreatedAt��6%   
 68   �� *
created_at+5!      �� 5#   
   -   5        $��
BackButton��5#      $��1��5$      $��0��6   $	��100��5%      $��50��6   $��
Назад��5&      6!   �� 5(   
   -   5        $��
NextButton��5(      $��1��5)      $��1��6   $	��150��5*      $��50��6   $)��#Следующая страница��5+      6.   5,      5-      