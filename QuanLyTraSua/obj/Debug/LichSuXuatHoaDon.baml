   M S B A M L   `   `   `  ����G  CQuanLyTraSua, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuanLyTraSuaQuanLyTraSua  5   	   K*clr-namespace:QuanLyTraSua.UserControlQLTSQuanLyTraSua.UserControlQLTS  5
      #    QuanLyTraSua.LichSuXuatHoaDon   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QuanLyTraSua     5   	   9uc*clr-namespace:QuanLyTraSua.UserControlQLTS     5
      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��lichSuXuatHoaDonWindow��5   	      LichSuXuatHoaDonVM  � DataContext#  [  5	   	    � Title$# Lịch Sử Xuất Hoá Đơn��5   	   $	��800��6'   $
��1400��64     MaterialDesignBody#���  5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   
���   �$	��0.4q�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedHoaDonWindowCommand+5      .��5!      �  � 	Resources 5"   
    �� 
TargetType �� Property �� Value��%V   '�       �� 5#      " �6   .�5$      ��  � ��$ 0q�6+   67   5%      5&       � RowDefinitions 5'   
   �� 5(      $
��auto �6   6,   �� 5)      6   .+�5+   
   � $��0��6   .+�5,      /   )QuanLyTraSua.UserControlQLTS.ControlBarUC  $
��auto��6   $
��auto��6,   $��276,0,0.4,-0.2q�6r   
 � Tag 69   �� *Title+ �� ElementName$ lichSuXuatHoaDonWindow��6�   5-      � 5.   
   $��1��6    5/      �� 50      $
��auto �6    60   �� 51      $
��auto �6    60   �� 52      6"   .+�54      �� $��0��6   $#��Lịch Sử Xuất Hoá Đơn��6#   $��40(�6?   $��Black"�6M   
���  ��$��Center=�6q   $��Center=�6�   6�   #  MaterialDesignThemes.Wpf.Card  55      $��1��6"   $��15q�6/   $
��auto��6;   $��Stretch=�6I   .��56      ��  �� Orientation$ 
Horizontal=�6    57      ��%�   '��       �� 58      " ��6    .�59      ��  � ��$ 20(�69   6F   �� 5:       � ��$
 Bold"�6;   6J   �� 5;       � ��$ 15q�67   6D   �� 5<       � ��$ 60��67   6D   5=      5>      .+�5?      (  "System.Windows.Controls.DatePicker   � ToolTip$ Xem từ ngày��6!   $	��120��67   $��40��6C   )	  #MaterialDesignThemes.Wpf.HintAssist 	  Hint$ Ngày Bắt Đầu��6t    ( $MaterialDesignFloatingHintDatePicker#��[ 6�   $��	15 5 15 5q�6�      SelectedDate 6O   �� *
NGAYBATDAU+6�     5@      $ Xem đến ngày��6!   $	��120��68   $��40��6D   $ Ngày kết thúc��6v   #��[ 6�   $��	15 5 15 5q�6�    6P   �� *NGAYKETTHUC+6�   �� 5A      $( "Filter theo khách hàng vãng lai��6   ���#FF8A00$��10q�6�   $	��200��6�   $��Khách Vãng Lai��6�   ��6G   �� *GetKhachVangLaiCommand+6�   �� 5B      $, &Filter theo khách hàng thân thiết��6   ���#FF8A00$��10q�6�   $	��200��6�   ��6I   �� *GetKhachHangThanThietCommand+.��5C      �� $ ��Khách Hàng Thân Thiết��6%    �� TextAlignment$ Center=�6B   $
��Wrap=�6Y   $	��150��6m   6|   5D      �� 5E      $ Get All��6   ���#FF8A00$��Xem Tất Cả��6f   $��10q�6{   $	��200��6�   ��6/   �� *GetAllCommand+6�   5F      5G      � 5H      $��2��6    � ColumnDefinitions 5I      �� 5J      6)   �� 5K      $
��0.7* �6'   66   .+�5M        $ Thông tin hoá đơn��6&   $��0��6B   $��
15 15 7 15q�6R   $��Stretch=�6f   .��5N      �� $��Disabled=�6#   .��5O      �� ��6#   �� *
HoaDonList+ �� SelectedItem 6F   �� *SelectedItem+ �� View 5P      �� 5Q   "   .P�5R   &   �� $��Mã HD��65    �� DisplayMemberBinding 6D   �� *MSHD+6l   �� 5S   &   $��Tổng Tiền��65    6H   �� *
TONGTIEN+6t   �� 5T   &   $��Ngày Xuất��65    6H   �� *
NGAYXUAT+6t   �� 5U   &   $
��MSNV��65    6C   �� *MSNV+6k   �� 5V   &   $��SDT Khách Hàng��65    6M   �� *SDT+6t   �� 5W   &   $��Giảm Giá��65    6G   �� *	GIAMGIA+6r   �� 5X   &   $
��Note��65    6C   �� *NOTE+6k   5Y   #   5[      5\      5]      � 5^      $��1��6    5_      �� 5`      6*   �� 5a      6*   .+�5c        $ Thông tin sự kiện��6*   $��0��6F   $��
7 15 15 15q�6S   $��Stretch=�6g   .��5d      �� $
��Auto=�6'   .��5e      �� ��6'   �� *
SuKienList+ 5f   "   �� 5g   &   .P�5h   *   �� $��Tên SK��69    6I   �� *TENSK+6r   �� 5i   *   $��Nội Dung SK��69    6N   �� *
NDSUKIEN+6z   �� 5j   *   $��Giảm Giá��69    6K   �� *	GIAMGIA+6v   5k   '   5m      5n      5o        5p      $ Thông tin mặt hàng��6*   $��1��6G   $��
7 15 15 15q�6T   $��Stretch=�6h   .��5q      �� $
��Auto=�6'   .��5r      �� ��6'   �� *ChiTietHoaDonList+ 5s   "   �� 5t   &   .P�5u   *   �� $��Tên Mặt Hàng��69    6O   �� *MSMH+6w   �� 5v   *   $��Số Lượng��69    6K   �� *	SOLUONG+6v   �� 5w   *   $��
Đơn Giá��69    6J   �� *DONGIA+6t   5x   '   5z      5{      5|      5}      5      5�      5�      5�      