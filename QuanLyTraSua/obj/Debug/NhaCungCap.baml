   M S B A M L   `   `   `  ����G  CQuanLyTraSua, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuanLyTraSuaQuanLyTraSua  5   	   K*clr-namespace:QuanLyTraSua.UserControlQLTSQuanLyTraSua.UserControlQLTS  5          QuanLyTraSua.NhaCungCap   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QuanLyTraSua     5   	   9uc*clr-namespace:QuanLyTraSua.UserControlQLTS     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��nhaCungCapWindow��5   	      NhaCungCapVM  � DataContext#  [  5
   	    � Title$ Nhà Cung Cấp��5   	   $
��auto��6   $
��auto��6-     MaterialDesignBody#���  5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   
���   �$	��0.4q�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedNhaCungCapWindowCommand+5       .��5"      �  � RowDefinitions 5#   
   �� 5$      $
��auto �6   6,   �� 5%      6   .+�5'   
   � $��0��6   .+�5(      /   )QuanLyTraSua.UserControlQLTS.ControlBarUC  $
��auto��6   $��	275,0,0,0q�6_   
 � Tag 6,   �� *Title+ �� ElementName$ nhaCungCapWindow��6u   5)      � 5*   
   $��1��6   $
��auto��6   $
��auto��6)    � ColumnDefinitions 5+      �� 5,      6&   .+�56      � $��0��6    57      �� 58      $��50 �6$   62   �� 59      $
��auto �6$   64   �� 5:      $
��auto �6$   64   �� 5;      $
��auto �6$   64   �� 5<      $	��55* �6$   63   .+�5?      � $��0��6   .+�5@      �� $��5q�6    $��Center=�6+   $��	ExtraBold"�6H   
���  ��$��Tahoma)�6p   $ ��Danh sách nhà cung cấp��6�   $��40(�6�   $��Center=�6�   6�   5A      #  MaterialDesignThemes.Wpf.Card  5B      $��1��6&   $��15,14.6,14.8,0q�63   .��5C      �� -   5        $��bindingText��5C      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$! Tìm kiếm nhà cung cấp��61    % !MaterialDesignFloatingHintTextBox#��[ 6h   $
��auto��6�   $��10q�6�   .��6�    5D        5E      $ KeyUp��6-   .	 5F   "     
 68   �� *OnKeyUpCommand+   CommandParameter 6[   �� $ bindingText��5G      .��5H   2   5I      5J        5K      $��2��6&   $��15,14.6,14.8,0q�64   .��5L      �  � Orientation$ 
Horizontal=�6    $
��auto��69   .+�5M      �� $ Tên Nhà Cung Cấp��6f   #��[ 6�   $	��200��6�   $��	15 5 15 5q�6�   ��6"   �� *TENNHACUNGCAP+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5N      $ Địa Chỉ��6:   #��[ 6c   $	��200��6�   $��	15 5 15 5q�6�   ��6"   �� *DIACHI+6�   �� 5O      $
 SĐT��67   #��[ 6\   $	��100��6�   $��	15 5 15 5q�6�   ��6"   �� *SDT+6�   �� 5P      $ Email��69   #��[ 6`   $	��100��6�   $��	15 5 15 5q�6�   ��6"   �� *EMAIL+6�   5Q      5R        5T      $��3��6&   $��15,14.6,14.8,0q�63   .��5U      ��  �� Orientation$ 
Horizontal=�6!    � 	Resources 5V       �� 
TargetType �� Property �� Value��%�   '��       �� 5W      " ��6$   .�5X   "   ��  � ��$ 20(�6=   6J   �� 5Y   "    � ��$
 Bold"�6?   6N   5Z      5[      .+�5\      ��  � ToolTip$" Cập nhật nhà cung cấp��6!   ���#55FF84$��CẬP NHẬT��6x   $��10q�6�   $	��120��6�   $��60��6�   ��6A   �� *UpdateCommand+6�   �� 5]      $ Thêm nhà cung cấp��6!   ���#FF8A00$��THÊM ��6q   $��10q�6�   $	��120��6�   $��60��6�   ��6=   �� *
AddCommand+6�   �� 5^      $ Xoá nhà cung cấp��6!   ���#FF1A1A$
��XOÁ��6s   $��10q�6�   $	��120��6�   $��60��6�   ��6<   �� *DeleteCommand+6�   �� 5_      $. (Làm mới ô thông tin nhà cung cấp��6!   ���#55FF84$��
LÀM MỚI��6�   $��10q�6�   $	��120��6�   $��60��6�   ��6L   �� *RefreshCommand+6�   5`      5a        5c      $  Thông tin nhà cung cấp��6&   $��4��6G   $��15,10.6,14.8,0q�6T   $��Stretch=�6l   .��5d      �� $
��Auto=�6#   .��5e      �� ��6#   �� *NhaCungCapList+ �� SelectedItem 6J   �� *SelectedItem+ �� Mode$ OneWayToSource=� �� View 5f      �� 5g   "   .P�5h   &   ��  �� Width$	 150��65   $��Mã Nhà Cung Cấp��6A    �� DisplayMemberBinding 6Z   �� *MSNCC+6�   �� 5i   &   $	 200��65   $��Tên Nhà Cung Cấp��6A    6[   �� *TENNCC+6�   �� 5j   &   $	 150��65   $��Địa Chỉ��6A    6R   �� *DIACHI+6|   �� 5k   &   $	 150��65   $
��SĐT��6A    6N   �� *SDT+6u   �� 5l   &   $	 150��65   $��Email��6A    6P   �� *EMAIL+6y   5m   #   5o      5p      5q      5r      5s      5t      5u      