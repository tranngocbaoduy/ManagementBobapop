   M S B A M L   `   `   `  ����G  CQuanLyTraSua, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuanLyTraSuaQuanLyTraSua  5   	   K*clr-namespace:QuanLyTraSua.UserControlQLTSQuanLyTraSua.UserControlQLTS  5
   	   $    QuanLyTraSua.LichSuXoaNhanVien   5   
   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QuanLyTraSua     5   	   9uc*clr-namespace:QuanLyTraSua.UserControlQLTS     5
   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��lichSuXoaNVWindow��5   	      LichSuXoaNVVM  � DataContext#  [  5   	    � Title$" Lịch Sử Xoá Nhân Viên��5   	   $	��800��6(   $
��1400��65     MaterialDesignBody#���  5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   
���   �$	��0.4q�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *&$LoadedLichSuXoaNhanVienWindowCommand+5       .��5#      �  � 	Resources 5$   
    �� 
TargetType �� Property �� Value��%V   '�       �� 5%      " �6   .�5&      ��  � ��$ 0q�6+   67   5'      5(       � RowDefinitions 5)   
   �� 5*      $
��auto �6   6,   �� 5+      6   .+�5-   
   � $��0��6   .+�5.      /   )QuanLyTraSua.UserControlQLTS.ControlBarUC  $
��auto��6   $
��auto��6,   $��276,0,0.4,-0.2q�6m   
 � Tag 69   �� *Title+ �� ElementName$ lichSuXoaNVWindow��6�   5/      � 50   
   $��1��6    51      �� 52      $
��auto �6    60   �� 53      $
��auto �6    60   �� 54      $
��auto �6    60   �� 55      $
��auto �6    60   �� 56      $
��auto �6    60   .+�58      �� $��0��6   $'��!Nhân Viên Đã Xoá Gần Đây��6#   $��40(�6C   $��Black"�6Q   
���  ��$��Center=�6u   $��Center=�6�   6�   #  MaterialDesignThemes.Wpf.Card  59      $��1��6"   $��15q�60   .��5:      �  � Orientation$ 
Horizontal=�6   $��	0 20 0 20q�65   .+�5;      �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Họ Tên��65    % !MaterialDesignFloatingHintTextBox#��[ 6]   $	��200��6�   $��15q�6�   ��6   �� *TENNV+6�   �� 5<       �� 
IsReadOnly . $ UserName��6J   #��[ 6t   $	��100��6�   $��15q�6�   ��60   �� *
USERNAME+6�   �� 5=      $
 SĐT��63   #��[ 6X   $	��100��6�   $��15q�6�   ��6   �� *SDT+6�   �� 5>      $
 CMND��64   #��[ 6Z   $	��100��6�   $��15q�6�   ��6   �� *CMND+6�   �� 5?      $��15q�6   $	��100��6+   $ Giới Tính��67    �� 
IsEditable .  & "MaterialDesignFloatingHintComboBox#��[ 6�   ��6b   �� *GioiTinhList+ �� SelectedValue 6�   �� *
GIOITINH+6�   (	  "System.Windows.Controls.DatePicker	  5@      $	��100��6!   $ 
Ngày Sinh��6P    ( $MaterialDesignFloatingHintDatePicker#��[ 6{   $��15q�6�    	  SelectedDate 6-   �� *
NGAYSINH+6�   �� 5A      $ Địa Chỉ��66   #��[ 6_   $	��300��6�   $��15q�6�   ��6   �� *DIACHI+6�   �� 5B      $ Email��65   #��[ 6\   $	��200��6�   $��15q�6�   ��6   �� *EMAIL+6�   	  5C      $	��120��6!   $ Ngày vào làm��6R   #��[ 6�   $��15q�6�    6-   �� *
NGAYVAOLAM+6�   �� 5D      $��15q�6   $	��200��6+   $ Chức vụ��67    . #��[ 6�   ��6`   �� *
ChucVuList+ 6�   �� *CHUCVU+6�   �� 5E      $��15q�6   $	��200��6+   $ Ca Làm Việc��67    . #��[ 6�   ��6d   �� *CaLamViecList+ 6�   �� *	CALAMVIEC+6�   �� 5F       . $ Tiền Lương��6K   #��[ 6w   $	��150��6�   $��15q�6�   ��60   �� *	TIENLUONG+6�   5G      5H      �� 5I      $��2��6    �� Orientation$ 
Horizontal=�6&    5J      ��%�   '��       �� 5K      " ��6   .�5L      ��  � ��$ 20(�65   6B   �� 5M       � ��$
 Bold"�67   6F   �� 5N       � ��$ 60��63   6@   �� 5O       � ��$	 200��62   6@   �� 5P       � ��$ 15q�63   6@   5Q      5R      .+�5S      ��  � ToolTip$# Restore nhân viên đã xoá��6   ���#FF8A00��6=   �� *RestoreNVCommand+.��5T      �� $��Restore Nhân Viên��6    $
��Wrap=�69   $	��110��6M    �� TextAlignment$ Center=�6Y   6r   5U      �� 5V      $ Get All��6   ���#89ffaa��6+   �� *GetAllCommand+.��5W      �� $,��&Lấy Tất Cả Nhân Viên Đã Xoá��6    $
��Wrap=�6C   $	��180��6W   $ Center=�6c   6|   5X      �� 5Y      $* $Làm mới ô thông tin nhân viên��6   ���#89ffaa��6A   �� *RefreshCommand+.��5Z      �� $��Refresh��6    $
��Wrap=�6/   $	��180��6C   $ Center=�6O   6h   5[      5\      � 5]      $��3��6   $��0q�6    .+�5^      �� -   5        $��nhanVienSearch��5^   O   $< 6Tìm nhân viên theo số điện thoại nhân viên��6   $ Tìm Kiếm Nhân Viên��6�   #��[ 6�   $
��auto��6�   $��15q�6�   ��6e   �� *SearchEvent+.��6   5_        5`      $ KeyUp��6)   .	 5a        
 64   �� *OnKeyUpNhanVienSearchCommand+   CommandParameter 6e   �� $ nhanVienSearch��5b      .��5c   .   5d      5e        5f      $ Thông tin nhân viên��6"   $��4��6@   $��15,10.6,14.8,15q�6M   $��Stretch=�6g   $	��300��6�   $	��290��6�   .��5g      �� $��Disabled=�6   $
��auto��6F   .��5h      �� ��6   �� *NhanVienList+ �� SelectedItem 6D   �� *SelectedItem+ �� Mode$ OneWayToSource=� �� View 5i      �� 5j       �� AllowsColumnReorder . .P�5k   "   �� $
��MSNV��61     �� DisplayMemberBinding  6?   �� *MSNV+6g   �� 5l   "   $��	Họ Tên��61     6A   �� *TENNV+6j   �� 5m   "   $��Gender��61     6A   �� *
GIOITINH+6m   �� 5n   "   $��Chức vụ��61     6B   �� *CHUCVU+6l   �� 5o   "   $��
Ngày sinh��61     6D   �� *
NGAYSINH+6p   �� 5p   "   $
��CMND��61     6?   �� *CMND+6g   �� 5q   "   $��Địa chỉ��61     6B   �� *DIACHI+6l   �� 5r   "   $
��SĐT��61     6>   �� *SDT+6e   �� 5s   "   $��Email��61     6@   �� *EMAIL+6i   �� 5t   "   $��Ngày vào làm��61     6G   �� *
NGAYVAOLAM+6u   5u      5w      5x      5y      5z      5{      5|      