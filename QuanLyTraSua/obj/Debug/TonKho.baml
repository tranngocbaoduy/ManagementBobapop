   M S B A M L   `   `   `  ����G  CQuanLyTraSua, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuanLyTraSuaQuanLyTraSua  5   	   K*clr-namespace:QuanLyTraSua.UserControlQLTSQuanLyTraSua.UserControlQLTS  5   	       QuanLyTraSua.TonKho   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QuanLyTraSua     5   	   9uc*clr-namespace:QuanLyTraSua.UserControlQLTS     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��sanPhamWindow��5   	      TonKhoVM  � DataContext#  [  5	   	    � Title$ Sản Phẩm��5   	   $	��800��6   $
��1400��6(     MaterialDesignBody#���  5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   
���   �$	��0.4q�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedTonKhoWindowCommand+5      .��5!      �  � RowDefinitions 5"   
   �� 5#      $
��auto �6   6,   �� 5$      6   .+�5&   
   � $��0��6   .+�5'      /   )QuanLyTraSua.UserControlQLTS.ControlBarUC  $
��auto��6   $��	275,0,0,0q�6\   
 � Tag 6,   �� *Title+ �� ElementName$ sanPhamWindow��6r   5(      � 5)   
   $��1��6   $
��auto��6   $
��auto��6)    � ColumnDefinitions 5*      �� 5+      6&   .+�55      � $��0��6    56      �� 57      $��0.18* �6'   67   �� 58      6)   .+�5:      � $��0��6    5;      �� 5<      $��0.35* �6(   69   �� 5=      $��* �6(   65   .+�5?      ��  �� TextAlignment$ Center=�6    $��	ExtraBold"�67   $��40(�6N   $��0��6\   
���  ��$
��Wrap=�6{   $	��160��6�   $��Tahoma)�6�   $��Quản lý tồn kho��6�   $��Center=�6�   $��Center=�6�   $��30,0,29.6,549.4q�6   $��2��6  6,  �� 5@      $��1��6   
���   �$��0.35 0 0.35 0q�6>   ._�5A      ��  � 	Resources 5B       �� 
TargetType �� Property �� Value��%(  '��       �� 5C   "   " ��6(   .�5D   &   ��  � ��$ 15(�6A   6N   �� 5E   &    � ��$
 Bold"�6C   6R   �� 5F   &    � ��$ 10q�6?   6L   �� 5G   &    � ��$	 120��6>   6L   �� 5H   &    � ��$ 80��6?   6L   �� 5I   &    � �� �#ffcb726U   5J   #   5K      .+�5M      ��  � ToolTip$  Xem lịch sử nhập kho��6%   ��6D   �� *LichSuNhapKhoWindowCommand+.��5N   "   �� $
��Wrap=�6,   $��LỊCH SỬ NHẬP KHO��6A   $ Center=�6Y   $��89��6p   6}   5O      �� 5P      $  Xem lịch sử xuất kho��6%   ��6D   �� *LichSuXuatKhoWindowCommand+.��5Q   "   �� $
��Wrap=�6,   $��LỊCH SỬ XUÂT KHO��6A   $ Center=�6Y   $��94��6p   6}   5R      �� 5S      $ Phiếu nhập kho��6%   ��6>   �� *NhapKhoWindowCommand+.��5T   "   �� $
��Wrap=�6,   $��
NHẬP KHO��6A   $ Center=�6Q   6j   5U      �� 5V      $ Phiếu xuất kho��6%   ��6>   �� *XuatKhoWindowCommand+.��5W   "   �� $
��Wrap=�6,   $��
XUẤT KHO��6A   $ Center=�6Q   6j   5X      �� 5Y      $) #Quản lý nguyên liệu trong kho��6%   ��6M   �� *QuanLyKhoWindowCommand+.��5Z   "   �� $
��Wrap=�6,   $��QUẢN LÝ KHO��6A   $ Center=�6T   6m   5[      5\      5]      5^      � 5_      $��1��6    5`      �� 5a      $	��100 �6(   67   �� 5b      $
��auto �6(   68   �� 5c      $
��auto �6(   68   �� 5d      $	��55* �6(   67   .+�5g      � $��0��6   $��10,0,-0.2,2.4q�6(    5h      �� 5i      $��3* �6/   6<   �� 5j      61   .+�5l      #  MaterialDesignThemes.Wpf.Card  $��1��6.   $��5 20 0 0q�6;   .��5m      �� -   5        $��bindingText��5m   N   $* $Tìm kiếm nguyên liệu theo tên��6&   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$  Tìm kiếm nguyên liệu��6a    % !MaterialDesignFloatingHintTextBox#��[ 6�   $
��auto��6�   $��15q�6�   .��6�    5n   "     5o   &   $ KeyUp��65   .	 5p   *     
 6@   �� *OnKeyUpCommand+   CommandParameter 6c   �� $ bindingText��5q   '   .��5r   :   5s      5t      �� 5u      $��1��6!   $2 ,Danh sách các nhà cung cấp hiện tại��61   ���#55FF84$��5q�6�   $	��130��6�   $��60��6�   ��6_   �� *NhaCungCapWindowCommand+��6�   �� $ sanPhamWindow��.��5v      �� $��DS Nhà Cung Cấp��6(   $ Center=�6?   $
��Wrap=�6V   $��20(�6j   
���   �$
��Bold"�6�   $��Center=�6�   $��Center=�6�   6�   5w      5y        5z      $��1��6*   $��15q�68   .��5{      �  � Orientation$ 
Horizontal=�6$   $
��auto��6=   .+�5|      �� $ Tên nguyên liệu��6>   #��[ 6o   $	��300��6�   $��15q�6�   ��6&   �� *TENNL+6�   �� 5}      $ Đơn Vị Tính��6<   #��[ 6i   $	��100��6�   $��15q�6�   ��6&   �� *DVT+6�   �� 5~      $ Số Lượng Tồn��6A    �� 
IsReadOnly . #��[ 6�   $	��100��6�   $��15q�6�   ��6&   �� *
QUANTITY+6�   �� 5�      $ Nhà Cung Cấp��6'    �� 
IsEditable .  & "MaterialDesignFloatingHintComboBox#��[ 6�   ��6U   �� *NhaCungCapList+ �� SelectedItem 6|   �� *SelectedNhaCungCap+ �� SelectedValue 6�   �� *TENNCC+5�      �� 5�       . $ Giá Nhập Trung Bình��6Q   #��[ 6�   $	��100��6�   $��15q�6�   ��6&   �� *GIABAN+6�   5�      5�        5�      $��2��6*   $��15,14.6,14.8,0q�67   .��5�      ��  �� Orientation$ 
Horizontal=�6%    5�      ��%�   '��       �� 5�   "   " ��6(   .�5�   &   ��  � ��$ 20(�6A   6N   �� 5�   &    � ��$
 Bold"�6C   6R   5�   #   5�      .+�5�      �� ���#55FF84$��Cập nhật SP��6\   $��10q�6r   $	��130��6~   $��60��6�   ��6%   �� *UpdateCommand+6�   �� 5�      ���#FF8A00$��Thêm SP��6Y   $��10q�6l   $	��130��6x   $��60��6�   ��6%   �� *
AddCommand+6�   �� 5�      ���#FF1A1A$��Xoá SP��6\   $��10q�6m   $	��130��6y   $��60��6�   ��6%   �� *DeleteCommand+6�   �� 5�      ���#55FF84$��
Làm Mới��6]   $��10q�6o   $	��130��6{   $��60��6�   ��6%   �� *RefreshCommand+6�   5�      5�        5�      $ Thông tin nguyên liệu��6*   $��3��6J   $��15q�6W   $��Stretch=�6c   $	��420��6�   .��5�      �� 
���   �$	��Top=�6;   $��Disabled=�6[   $��2q�6�   .��5�      �� ��6'   �� *
TonKhoList+ 6J   �� *SelectedItem+ �� Mode$ OneWayToSource=� �� View 5�   "   �� 5�   &   .P�5�   *   �� $��Mã Số SP��69    �� DisplayMemberBinding 6K   �� *MSNL+6s   �� 5�   *   $��Tên SP��69    6I   �� *NGUYENLIEU.TENNL+6}   �� 5�   *   $��Số Lượng Tồn��69    6O   �� *
Quantity+6{   �� 5�   *   $��Đơn Vị Tính��69    6N   �� *NGUYENLIEU.DVT+6�   �� 5�   *   $��Giá Nhập Lần Cuối��69    6T   �� *GIACUOICUNG+6�   �� 5�   *   $��Giá Trung Bình��69    6Q   �� *GIATRUNGBINH+6�   �� 5�   *   $��Giá Cao Nhất��69    6O   �� *
GIACAONHAT+6}   �� 5�   *   $��Giá Thấp Nhất��69    6P   �� *GIATHAPNHAT+6   �� 5�   *   $��Tên Nhà Cung Cấp��69    6S   �� *NHACUNGCAP.TENNCC+6�   5�   '   5�      5�      5�      5�      5�      5�      5�      5�      