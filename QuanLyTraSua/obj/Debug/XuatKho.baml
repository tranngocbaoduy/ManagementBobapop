   M S B A M L   `   `   `  ����G  CQuanLyTraSua, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuanLyTraSuaQuanLyTraSua  5   	   K*clr-namespace:QuanLyTraSua.UserControlQLTSQuanLyTraSua.UserControlQLTS  5   	       QuanLyTraSua.XuatKho   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QuanLyTraSua     5   	   9uc*clr-namespace:QuanLyTraSua.UserControlQLTS     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��xuatKhoWindow��5   	      	XuatKhoVM  � DataContext#  [  5
   	    � Title$ 
Xuất Kho��5   	   $	��800��6   $
��1400��6(     MaterialDesignBody#���  5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   
���   �$	��0.4q�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedXuatKhoWindowCommand+5       .��5#      �  � RowDefinitions 5$   
   �� 5%      $
��auto �6   6,   �� 5&      6   .+�5(   
   � $��0��6   .+�5)      /   )QuanLyTraSua.UserControlQLTS.ControlBarUC  $
��auto��6   $��	275,0,0,0q�6\   
 � Tag 6,   �� *Title+ �� ElementName$ xuatKhoWindow��6r   5*      � 5+   
   $��1��6    � ColumnDefinitions 5,      �� 5-      $��* �6#   6/   .+�57      � $��0��6    58      �� 59      $��60 �6$   62   �� 5:      $
��auto �6$   64   �� 5;      $
��auto �6$   64   �� 5<      $
��auto �6$   64   �� 5=      $	��55* �6$   63   .+�5@      � $��0��6   $��10,0,-0.2,2.4q�6$   .+�5A      �� $��	ExtraBold"�6    
���  ��$��41��6H   $��Tahoma)�6T   $��Phiếu Xuất Kho��6h   $��Center=�6~   $��30(�6�   $��Bottom=�6�   6�   5C      #  MaterialDesignThemes.Wpf.Card  5D      $��1��6&   $��15,14.6,14.8,0q�64   .��5E      �  5F      �� 5G      61   �� 5H      $	��200 �6/   6=   .+�5K      � $��0��6$    � Orientation$ 
Horizontal=�65   $��	0 20 0 20q�6N   .+�5L      �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên Nhân Viên��6'   $	��250��6�   $��	15 5 15 5q�6�    & "MaterialDesignFloatingHintComboBox#��[ 6�   ��6V   �� *NhanVienList+ �� SelectedItem 6{   �� *SelectedNhanVien+6  (	  "System.Windows.Controls.DatePicker	  5M      $	��120��6)    	  SelectedDateFormat$ Short=�65   $ Ngày Xuất��6�    ( $MaterialDesignFloatingHintDatePicker#��[ 6�   $��	15 5 15 5q�6   	  SelectedDate 6P   �� *
NgayXuat+ �� UpdateSourceTrigger$ PropertyChanged=�6  �� 5N      $
 Note��6a    % !MaterialDesignFloatingHintTextBox#��[ 6�   $
��1400��6�   $��	15 5 15 5q�6�   ��6&   �� *Note+$ PropertyChanged=�6�   5P      �� 5Q       � ToolTip$* $Làm mới toàn bộ phiếu xuất��6!   $��20(�6G   $
��Bold"�6U   
���   �$��1��6z   ���#89ffaa$��10q�6�   $	��180��6�   $��80��6�   ��6�   �� *RefreshAllCommand+.��5R      �� $#��Làm Mới Phiếu Xuất Kho��6(    �� TextAlignment$ Center=�6F   $
��Wrap=�6]   $��Center=�6q   $��Center=�6�   6�   5S      5U      5W        5X      $��2��6&   $��15,14.6,14.8,0q�64   .��5Y      � $ 
Horizontal=�6    $��	0 20 0 20q�6:   .+�5Z      �� $ 
Chọn kho��6#   $ Từ Kho��66   $	��100��6^   $��	15 5 15 5q�6�   #��[ 6�   ��6j   �� *	KhoList+ 6�   �� *SelectedKho+6   �� 5[      $  Chọn tên nguyên liệu��6#   $ Tên Nguyên Liệu��6B   $	��200��6�   $��	15 5 15 5q�6�   #��[ 6�   ��6s   �� *NguyenLieuList+ 6�   �� *SelectedNguyenLieu+6#  �� 5\       �� 
IsReadOnly . $ Số Lượng Tồn��6u   #��[ 6�   $��80��6�   $��	15 5 15 5q�6�   ��64   �� *
SoLuongTon+$ PropertyChanged=�6�   �� 5]      $ Số Lượng Xuất��6f   #��[ 6�   $��80��6�   $��	15 5 15 5q�6�   ��6"   �� *InputQuantity+$ PropertyChanged=�6�   5^      5_        5`      $��3��6&   $��15,14.6,14.8,0q�63   .��5a      ��  �� Orientation$ 
Horizontal=�6!    � 	Resources 5b       �� 
TargetType �� Property �� Value��%�   '��       �� 5c      " ��6$   .�5d   "   ��  � ��$ 20(�6=   6J   �� 5e   "    � ��$
 Bold"�6?   6N   �� 5f   "    � ��$	 120��6:   6H   5g      5h      .+�5i      �� $' !Thêm nguyên liệu vào phiếu��6!   ���#FF8A00$��Thêm��6z   $��10q�6�   $��60��6�   ��6F   �� *
AddCommand+6�   �� 5j      $' !Xoá nguyên liệu trong phiếu��6!   ���#FF1A1A$
��Xoá��6~   $��10q�6�   $��60��6�   ��6G   �� *DeleteCommand+6�   �� 5k      $ Làm mới phiếu��6!   ���#89ffaa$��
Làm Mới��6q   $��10q�6�   $��60��6�   ��69   �� *RefreshCommand+6�   �� 5l      $" Hoàn tất và lưu phiếu��6!   ���#89ffaa$��Lưu Phiếu Xuất��6�   $	��180��6�   $��60��6�   ��6B   �� *SavePhieuXuatCommand+6�   5m      5n        5p      $ Thông tin xuất kho��6&   $��4��6C   $��15,10.6,14.8,0q�6P   $	��350��6h   $	��350��6u   $��Stretch=�6�   .��5q      �� $��Disabled=�6#   .��5r      �� ��6#   �� *NguyenLieuXuatList+ 6N   �� *SelectedItem+$ PropertyChanged=� �� View 5s      �� 5t   "   .P�5u   &   �� $��Mã Số SP��65    �� DisplayMemberBinding 6G   �� *MSNL+6o   �� 5v   &   $��Tên SP��65    6E   �� *NGUYENLIEU.TENNL+6y   �� 5w   &   $��Số Lượng Xuất��65    6L   �� *
Quantity+6x   �� 5x   &   $��Đơn Vị Tính��65    6J   �� *NGUYENLIEU.DVT+6|   �� 5y   &   $��Từ Kho��65    6E   �� *
KHO.TENKHO+6s   5z   #   5|      5}      5~      5�      5�      5�      5�      