   M S B A M L   `   `   `  ����G  CQuanLyTraSua, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuanLyTraSuaQuanLyTraSua  5   	   K*clr-namespace:QuanLyTraSua.UserControlQLTSQuanLyTraSua.UserControlQLTS  5   	       QuanLyTraSua.NhanVien   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QuanLyTraSua     5   	   9uc*clr-namespace:QuanLyTraSua.UserControlQLTS     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��nhanVienWindow��5   	     � Title$  Nhân Viên��5	   	   $	��800��6   $
��1400��6(      
NhanVienVM � DataContext# [  5   	     MaterialDesignBody#���  5   	   $��Regular"�5   	   $��13(�5   	   
���   �$	��0.4q�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5       6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedNhanVienWindowCommand+   CommandParameter 6T   ��  �� ElementName$ nhanVienWindow��5!      .��5%      �  � RowDefinitions 5&   
   �� 5'      $
��auto �6   6,   �� 5(      6   .+�5*   
   � $��0��6   .+�5+      /   )QuanLyTraSua.UserControlQLTS.ControlBarUC  $
��auto��6   $��	275,0,0,0q�6]   
 � Tag 6,   �� *Title+$ nhanVienWindow��6s   5,      � 5-   
   $��1��6    � ColumnDefinitions 5.      �� 5/      $��* �6#   6/   .+�59      � $��0��6    5:      �� 5;      $
��auto �6$   64   �� 5<      $
��auto �6$   64   �� 5=      $
��auto �6$   64   �� 5>      $
��auto �6$   64   �� 5?      $
��auto �6$   64   .+�5B      � $��0��6    5C      �� 5D      $
��0.4* �6+   6:   �� 5E      6-   .+�5G      �� $��	ExtraBold"�6    $��Center=�67   
���  ��$��Tahoma)�6f   $��QL Nhân Viên��6z   $��45(�6�   $��Center=�6�   6�   �� 5H      $��1��6   
���   �$��0.35 0 0.35 0q�6A   ._�5I      ��  �� Orientation$ 
Horizontal=�6%    � 	Resources 5J       �� 
TargetType �� Property �� Value��%�  '��       '�� '    �� 5K   "   " ��6(   .�5L   &   ��  � ��$ 15(�6A   6N   �� 5M   &    � ��$
 Bold"�6C   6R   �� 5N   &    � ��$ 18 10 10 10q�6?   6U   �� 5O   &    � ��$	 140��6>   6L   �� 5P   &    � ��$ 60��6?   6L   �� 5Q   &    � �� �#fffda86U   5R   #   �� 5S   "   " ��6(   .�5T   &   ��  � ��$	 102��6>   6L   5U   #   5V      .+�5W      ��  � ToolTip$* $Chấm công nhân viên theo tháng��6%   ��6N   �� *ChamCongNhanVienCommnad+.��5X   "   �� $
��Wrap=�6,   $��CHẤM CÔNG NHÂN VIÊN��6A    �� TextAlignment$ Center=�6]   6w   5Y      �� 5Z      $. (Lịch sử xoá nhân viên gần đây��6%   ��6M   �� *LishSuXoaNVCommand+.��5[   "   �� $
��Wrap=�6,   $"��LỊCH SỬ XOÁ NHÂN VIÊN��6A   $ Center=�6`   6y   5\      �� 5]      $) #Quản lý tài khoản nhân viên��6%   ��6K   �� *QLTaiKhoanCommand+.��5^   "   �� $
��Wrap=�6,   $��QUẢN LÝ TÀI KHOẢN��6A   $ Center=�6Z   6s   5_      5c      5d      5e      � 5f      $��1��6    5g      �� 5h      $
��2.5* �6+   6:   �� 5i      $
��auto �6+   6:   .+�5k      #  MaterialDesignThemes.Wpf.Card  $��0��6*   $��15,14.6,14.8,0q�6;   .��5l      �  � Orientation$ 
Horizontal=�6$   $��	0 20 0 20q�6=   .+�5m      �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Họ Tên��6=    % !MaterialDesignFloatingHintTextBox#��[ 6e   $	��200��6�   $��15q�6�   ��6&   �� *TENNV+6�   �� 5n       �� 
IsReadOnly . $ UserName��6R   #��[ 6|   $	��100��6�   $��15q�6�   ��68   �� *
USERNAME+6�   �� 5o      $
 SĐT��6;   #��[ 6`   $	��100��6�   $��15q�6�   ��6&   �� *SDT+6�   �� 5p      $
 CMND��6<   #��[ 6b   $	��100��6�   $��15q�6�   ��6&   �� *CMND+6�   �� 5q      $��15q�6'   $	��100��63   $ Giới Tính��6?    �� 
IsEditable .  & "MaterialDesignFloatingHintComboBox#��[ 6�   ��6j   �� *GioiTinhList+ �� SelectedValue 6�   �� *
GIOITINH+6  (	  "System.Windows.Controls.DatePicker	  5r      $	��100��6)   $ 
Ngày Sinh��6X    ( $MaterialDesignFloatingHintDatePicker#��[ 6�   $��15q�6�    	  SelectedDate 65   �� *
NGAYSINH+6�   �� 5s      $ Địa Chỉ��6>   #��[ 6g   $	��300��6�   $��15q�6�   ��6&   �� *DIACHI+6�   �� 5t      $ Email��6=   #��[ 6d   $	��200��6�   $��15q�6�   ��6&   �� *EMAIL+6�   	  5u      $	��120��6)   $ Ngày vào làm��6Z   #��[ 6�   $��15q�6�    65   �� *
NGAYVAOLAM+6�   �� 5v      $��15q�6'   $	��200��63   $ Chức vụ��6?    . #��[ 6�   ��6h   �� *
ChucVuList+ 6�   �� *CHUCVU+6�   �� 5w      $��15q�6'   $	��200��63   $ Ca Làm Việc��6?    . #��[ 6�   ��6l   �� *CaLamViecList+ 6�   �� *	CALAMVIEC+6  �� 5x      -   5        $��	tienLuong��5x   &   $ Tiền Lương��6R   #��[ 6~   $	��150��6�   $��15q�6�   ��67   �� *	TIENLUONG+.��6�    5y   "     5z   &   $ KeyUp��65   .	 5{   *     
 6@   �� *OnKeyUpLuongNhanVienCommand+ �� UpdateSourceTrigger$ PropertyChanged=� 6�   �� $ 	tienLuong��5|   '   .��5}   :   5~      5�      5�      5�        5�      $��2��6&   $��15,14.6,14.8,0q�63   .��5�      �� $ 
Horizontal=�6!    5�      ��%�   '��       �� 5�      " ��6$   .�5�   "   ��  � ��$ 20(�6=   6J   �� 5�   "    � ��$
 Bold"�6?   6N   �� 5�   "    � ��$ 60��6;   6H   �� 5�   "    � ��$	 110��6:   6H   �� 5�   "    � ��$ 15q�6;   6H   5�      5�      .+�5�      �� ���#55FF84$��Cập nhật��6X   ��6!   �� *UpdateCommand+6n   �� 5�      ���#FF8A00$��Thêm��6U   ��6!   �� *
AddCommand+6h   �� 5�      ���#FF1A1A$
��Xoá��6Y   ��6!   �� *DeleteCommand+6j   �� 5�      ���#89ffaa$��Refresh��6Z   ��6!   �� *RefreshCommand+6o   5�      5�      � 5�      $��3��6   $��10,0,-0.2,2.4q�6$   .+�5�      �� -   5        $��nguyenLieuSearch��5�   D   $' !Tìm kiếm nhân viên theo tên��6   $ Tìm Kiếm Nhân Viên��6\   #��[ 6�   $
��auto��6�   $��15q�6�   .��6�    5�        5�      $ KeyUp��6-   .	 5�   "     
 68   �� *OnKeyUpNameNhanVienCommand+ 6g   �� $ nguyenLieuSearch��5�      .��5�   2   5�      5�        5�      $ Thông tin nhân viên��6&   $��4��6D   $��15,10.6,14.8,15q�6Q   $��Stretch=�6k   $	��300��6�   $	��290��6�   .��5�      �� $��Disabled=�6#   $
��auto��6J   .��5�      �� ��6#   �� *NhanVienList+ �� SelectedItem 6H   �� *SelectedItem+ �� Mode$ OneWayToSource=�  �� View  5�      �� 5�   "   ! �� AllowsColumnReorder! . .P�5�   &   �� $
��MSNV��65   " �� DisplayMemberBinding" 6C   �� *MSNV+6k   �� 5�   &   $��	Họ Tên��65   " 6E   �� *TENNV+6n   �� 5�   &   $��Gender��65   " 6E   �� *
GIOITINH+6q   �� 5�   &   $��Chức vụ��65   " 6F   �� *CHUCVU+6p   �� 5�   &   $��
Ngày sinh��65   " 6H   �� *
NGAYSINH+6t   �� 5�   &   $
��CMND��65   " 6C   �� *CMND+6k   �� 5�   &   $��Địa chỉ��65   " 6F   �� *DIACHI+6p   �� 5�   &   $
��SĐT��65   " 6B   �� *SDT+6i   �� 5�   &   $��Email��65   " 6D   �� *EMAIL+6m   �� 5�   &   $��Ngày vào làm��65   " 6K   �� *
NGAYVAOLAM+6y   5�   #   5�      5�      5�      5�      5�      5�      5�      