   M S B A M L   `   `   `  ����G  CQuanLyTraSua, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuanLyTraSuaQuanLyTraSua  5   	   K*clr-namespace:QuanLyTraSua.UserControlQLTSQuanLyTraSua.UserControlQLTS  5
   	       QuanLyTraSua.BanHang   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QuanLyTraSua     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   3uc*clr-namespace:QuanLyTraSua.UserControlQLTS  5
   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��banHangWindow��5   	      	BanHangVM  � DataContext#  [  5   	    � Title$ 
Bán Hàng��5   	   $	��850��6   $
��1440��6'     MaterialDesignBody#���  5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	   
���   �$	��0.4q�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5    
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5!      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedMatHangWindowCommand+   CommandParameter 6S   ��  �� ElementName$ banHangWindow��5"      .��5&      �  � RowDefinitions 5(   
   �� 5)      $
��auto �6   6,   �� 5*      6   .+�5,   
   � $��0��6   .+�5-      /   )QuanLyTraSua.UserControlQLTS.ControlBarUC  $
��auto��6   $��	275,0,0,0q�6\   
 � Tag 6,   �� *Title+$ banHangWindow��6r   5.      � 5/   
   $��1��6    � ColumnDefinitions 50      �� 51      $��* �6#   6/   .+�5;      � $��0��6    5<      �� 5=      6)   �� 5>      $	��100 �6'   65   �� 5?      6)   .+�5A      � $��0��6    5B      �� 5C      $
��auto �6(   68   �� 5D      $
��auto �6(   68   �� 5E      $
��auto �6(   68   �� 5F      $	��55* �6(   67   .+�5I      � $��0��6   $��10,0,-0.2,2.4q�6(   .+�5J      �� -   5        $��nguyenLieuSearch��5J   "   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tìm Kiếm Sản Phẩm��6:    % !MaterialDesignFloatingHintTextBox#��[ 6m   $
��auto��6�   $��15q�6�   .��6�    5K        5L   "   $ KeyUp��61   .	 5M   &     
 6<   �� *OnKeyUpNguyenLieuCommand+ 6i   �� $ nguyenLieuSearch��5N   #   .��5O   6   5P      5Q      #  MaterialDesignThemes.Wpf.Card  5R      $��1��6*   $��15,14.6,14.8,0q�67   .��5S      �� $��0��6%    �� Orientation$ 
Horizontal=�62   $��10q�6K    � 	Resources 5T       �� 
TargetType �� Property �� Value��%&  '��       �� 5U   "   " ��6(   .�5V   &   ��  � ��$ 15(�6A   6N   �� 5W   &    � ��$
 Bold"�6C   6R   �� 5X   &    � �� �#a8c3ff6U   �� 5Y   &    � ��$ 90��6>   6K   �� 5Z   &    � ��$ 60��6?   6L   �� 5[   &    � ��$ 5q�6?   6K   5\   #   5]      .+�5^      �� ��6%   �� *ChooseLMHWindowCommand+��6Q   �� *LoadLMHCommand[0].MSLMH+.��5_   "   �� $
��auto��6V    �� TextAlignment$ Center=�6c   $
��Wrap=�6z   ��6,   �� *LoadLMHCommand[0].TENLMH+6�   5`      �� 5a      ��6%   �� *ChooseLMHWindowCommand+��6P   �� *LoadLMHCommand[1].MSLMH+.��5b   "   �� $
��auto��6V   $ Center=�6c   $
��Wrap=�6z   ��6,   �� *LoadLMHCommand[1].TENLMH+6�   5c      �� 5d      ��6%   �� *ChooseLMHWindowCommand+��6Q   �� *LoadLMHCommand[2].MSLMH+.��5e   "   �� $
��auto��6V   $ Center=�6c   $
��Wrap=�6z   ��6,   �� *LoadLMHCommand[2].TENLMH+6�   5f      �� 5g      ��6%   �� *ChooseLMHWindowCommand+��6P   �� *LoadLMHCommand[3].MSLMH+.��5h   "   �� $ Center=�6V   $��5q�6m   $
��Wrap=�6x   ��6,   �� *LoadLMHCommand[3].TENLMH+6�   5i      �� 5j      ��6%   �� *ChooseLMHWindowCommand+��6P   �� *LoadLMHCommand[4].MSLMH+.��5k   "   �� $
��auto��6V   $ Center=�6c   $
��Wrap=�6z   ��6,   �� *LoadLMHCommand[4].TENLMH+6�   5l      �� 5m      ��6%   �� *ChooseLMHWindowCommand+��6P   �� *LoadLMHCommand[5].MSLMH+.��5n   "   �� $
��auto��6V   $ Center=�6c   $
��Wrap=�6z   ��6,   �� *LoadLMHCommand[5].TENLMH+6�   5o      5p      5q        5t      $��3��6*   $��15,10.6,14.8,15q�67   $��Stretch=�6Q   .��5u      �� $��Disabled=�6'   
���   �$��2q�6b   .��5v      �� ��6'   �� *MatHangList+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6o   �� *SelectedItem+ �� Mode$ OneWayToSource=� �� View 5w   "   �� 5x   &   .P�5y   *   �� $��Mã SP��69    �� DisplayMemberBinding 6H   �� *MSMH+$ PropertyChanged=�6�   �� 5z   *   $��Tên SP��69    6I   �� *TENMH+$ PropertyChanged=�6�   �� 5{   *   $
��Size��69    6G   �� *SIZE+$ PropertyChanged=�6�   �� 5|   *   $��	Giá Bán��69    6J   �� *GIABAN+$ PropertyChanged=�6�   5}   '   5      5�      5�      5�      � 5�      $��1��6    5�      �� 5�      $
��0.9* �6(   68   �� 5�      6*   .+�5�      �� $��0��6   
���   �$��0.35 0 0.35 0q�6>   ._�5�      ��  5�      ��%'  '��       �� 5�   "   " ��6(   .�5�   &   ��  � ��$ 15(�6A   6N   �� 5�   &    � ��$
 Bold"�6C   6R   �� 5�   &    � ��$ 10q�6?   6L   �� 5�   &    � ��$ 80��6>   6K   �� 5�   &    � ��$ 60��6?   6L   �� 5�   &    � �� �#ffd97a6U   5�   #   5�      .+�5�      ��  � ToolTip$' !Xem lịch sử xuất hoá đơn��6%   ��6I   �� *LichSuXuatHoaDonCommand+.��5�   "   �� $
��Wrap=�6,   $��LỊCH SỬ XUẤT HD��6A   $ Center=�6X   $��71��6o   6|   5�      5�      5�      �� 5�      $��1��6   
���   �$��0.35 0 0.35 0q�6>   ._�5�      ��  5�      ��%'  '��       �� 5�   "   " ��6(   .�5�   &   ��  � ��$ 15(�6A   6N   �� 5�   &    � ��$
 Bold"�6C   6R   �� 5�   &    � ��$ 10q�6?   6L   �� 5�   &    � ��$ 80��6>   6K   �� 5�   &    � ��$ 60��6?   6L   �� 5�   &    � �� �#55FF846U   5�   #   5�      .+�5�      �� $ Làm mới hoá đơn��6%   ��6?   �� *RefreshCommand+.��5�   "   �� $
��Wrap=�6,   $��
LÀM MỚI��6A   $ Center=�6P   $��61��6g   6t   5�      �� 5�      $( "Thêm sản phẩm vào hoá đơn��6%   ��6I   �� *
AddCommand+.��5�   "   �� $
��Wrap=�6,   $��THÊM��6A   $ Center=�6M   6f   5�      �� 5�      $( "Xoá sản phẩm trong hoá đơn��6%   ��6J   �� *DeleteCommand+.��5�   "   �� $
��Wrap=�6,   $
��XOÁ��6A   $ Center=�6L   6e   5�      �� 5�      $ In Hoá Đơn��6%   ��6:   �� *PrintOrderCommand+.��5�   "   �� $
��Wrap=�6,   $��IN HOÁ ĐƠN��6A   $ Center=�6S   6l   5�      �� 5�      $ Thanh Toán��6%   ���#FF6969��6:   �� *PaymentCommand+.��5�   "   �� $
��Wrap=�6,   $��THANH TOÁN��6A   $ Center=�6S   6l   5�      5�      5�      5�      � 5�      $��2��6    5�      �� 5�      $��40 �6(   67   �� 5�      $	��140 �6(   67   �� 5�      $	��360 �6(   67   �� 5�      $
��auto �6(   68   .+�5�      �� $��0��6    $��20(�6-   
���  ��$
��Bold"�6L   $��Center=�6^   $��Center=�6y   $��Hoá Đơn Bán Hàng��6�   $��235,8,233.6,8q�6�   6�     5�      $��1��6*   $��15,15,14.6,0q�68   .��5�      �  � Orientation$ 
Horizontal=�6%   $��10q�6>   .+�5�      �� $ Tên Nhân Viên��6'   $	��220��6�   $��	10 5 10 5q�6�    & "MaterialDesignFloatingHintComboBox#��[ 6�   ��6V   �� *NhanVienList+ 6{   �� *SelectedNhanVien+6  �� 5�      $ Loại Khách Hàng��6'   $	��160��6�   $��	10 5 10 5q�6�   #��[ 6�   ��6X   �� *StyleCustomerList+ 6�   �� *SelectedStyleCustomer+6  (	  "System.Windows.Controls.DatePicker	  5�      $	��120��6K   $ Ngày Nhập��6X    ( $MaterialDesignFloatingHintDatePicker#��[ 6�   $��	10 5 10 5q�6�    	  SelectedDate 6)   �� *
NgayNhap+6�   �� 5�      -   5        $��bindingText��5�   &   $ Phone��6P   #��[ 6w   $	��100��6�   $��	10 5 10 5q�6�   ��69   �� *SDTKH+.��6�    5�   "     5�   &   $ KeyUp��65   .	 5�   *     
 6@   �� *OnKeyUpKhachHangCommand+$ PropertyChanged=� 6�   �� $ bindingText��5�   '   .��5�   :   5�      �� 5�      $ Tên Khách Hàng��6=   #��[ 6m   $	��150��6�   $��	10 5 10 5q�6�   ��6&   �� *TENKH+6�   �� 5�       �� 
IsReadOnly . $ 
Điểm TT��6P   #��[ 6y   $��50��6�   $��	10 5 10 5q�6�   ��6&   �� *DIEMTT+6�   �� 5�      $��Center=�6'   $ Event��6B   $	��220��6�   #��[ 6�   ��6i   �� *TenSuKienList+ 6�   �� *SelectedItemSuKienKH+6	  5�      5�        5�      $��2��6*   $��15,11,14.6,0q�67   $	��350��6M   $	��350��6]   $��2��6j   .��5�      �� $��Disabled=�6'   
���   �$��2q�6b   .��5�      �� ��6'   �� *MatHangInCart+  �� SelectedIndex  6M   �� *IndexSelected+ 5�   "   �� 5�   &   .P�5�   *   �� $��Tên SP��69    6I   �� *MatHang.TENMH+$ PropertyChanged=�6�   �� 5�   *   $
��Size��69    6G   �� *MatHang.SIZE+$ PropertyChanged=�6�   �� 5�   *   $��	Giá Bán��69    6J   �� *MatHang.GIABAN+$ PropertyChanged=�6�   �� 5�   *   $��Số Lượng��69    6K   �� *
Quantity+$ PropertyChanged=�6�   �� 5�   *   $��
Đơn Giá��69    6J   �� *Price+$ PropertyChanged=�6�   5�   '   5�      5�      5�      � 5�      $��3��6   $��	15 0 15 0q�6(    5�      �� 5�      $
��auto �6,   6<   �� 5�      $
��auto �6,   6<   �� 5�      $
��auto �6,   6<   �� 5�      $
��auto �6,   6<   �� 5�      $
��auto �6,   6<   �� 5�      $��50 �6,   6:   .+�5�      �� $��0��6%   $ 
Horizontal=�62   $
��auto��6K   $��	20 10 0 0q�6X   .+�5�      �� $
 Left=�6(   $
��Bold"�6=   $��20(�6O   $��Thành Tiền��6]   $	��320��6o   6}   �� 5�      
�������$ Right=�6?   ! �� Padding$! 2 2 10 0q�6U   $
��Bold"�6h   $��20(�6z   $	��280��6�   ��6�   �� *	ThanhTien+6�   5�      �� 5�      $��1��6%   $ 
Horizontal=�62   $
��auto��6K   $��	20 10 0 0q�6X   .+�5�      �� $
 Left=�6(   $
��Bold"�6=   $��20(�6O   $��
Thuế VAT��6]   $	��320��6m   6{   �� 5�      
�������$ Right=�6?   $! 2 2 10 0q�6U   $
��Bold"�6i   $��20(�6{   $	��280��6�   ��6�   �� *	ThueVat+6�   5�      �� 5�      $��2��6%   $ 
Horizontal=�62   $
��auto��6K   $��	20 10 0 0q�6X   .+�5�      �� $
 Left=�6(   $
��Bold"�6=   $��20(�6O   $��Giảm Giá��6]   $	��320��6m   6{   �� 5�      
�������$ Right=�6?   $! 2 2 10 0q�6U   $
��Bold"�6h   $��20(�6z   $	��280��6�   ��6�   �� *	GiamGia+6�   5      �� 5     $��3��6%   $ 
Horizontal=�62   $
��auto��6K   $��	20 10 0 0q�6X   .+�5     �� $
 Left=�6(   $
��Bold"�6=   $��20(�6O   $��Sự Kiện��6]   $	��320��6l   6z   �� 5     
�������$ Right=�6?   $! 2 2 10 0q�6U   $
��Bold"�6h   $��20(�6z   $	��280��6�   ��6�   �� *GiamGiaEvent+6�   5     �� 5     $��4��6%   $ Tổng tiền hoá đơn��62   $ 
Horizontal=�6N   $
��auto��6g   $��	20 10 0 0q�6t   .+�5     �� $
 Left=�6(   $
��Bold"�6=   
���  ��$��32(�6`   $��TỔNG CỘNG��6n   $	��320��6   6�   �� 5     
����ح�$ Right=�6?   $! 2 2 10 0q�6U   
���  ��$
��Bold"�6z   $��32(�6�   $	��280��6�   ��6�   �� *
TongTien+6�   5     5	     5
     5     5     5     5     