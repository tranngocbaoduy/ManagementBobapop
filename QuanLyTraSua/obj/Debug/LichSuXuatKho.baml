   M S B A M L   `   `   `  ����G  CQuanLyTraSua, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuanLyTraSuaQuanLyTraSua  5   	   K*clr-namespace:QuanLyTraSua.UserControlQLTSQuanLyTraSua.UserControlQLTS  5
   	        QuanLyTraSua.LichSuXuatKho   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QuanLyTraSua     5   	   9uc*clr-namespace:QuanLyTraSua.UserControlQLTS     5
   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��lichSuXuatKhoWindow��5   	      LichSuXuatKhoVM  � DataContext#  [  5   	    � Title$ Lịch Sử Xuất kho��5   	   $	��800��6#   $
��1400��60     MaterialDesignBody#���  5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   
���   �$	��0.4q�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedPhieuXuatWindowCommand+5       .��5#      �  � 	Resources 5$   
    �� 
TargetType �� Property �� Value��%V   '�       �� 5%      " �6   .�5&      ��  � ��$ 0q�6+   67   5'      5(       � RowDefinitions 5)   
   �� 5*      $
��auto �6   6,   �� 5+      6   .+�5-   
   � $��0��6   .+�5.      /   )QuanLyTraSua.UserControlQLTS.ControlBarUC  $
��auto��6   $
��auto��6,   $��276,0,0.4,-0.2q�6g   
 � Tag 69   �� *Title+ �� ElementName$ loginWindow��6�   5/      � 50   
   $��1��6    51      �� 52      $��0.25* �6    61   �� 53      $
��0.2* �6    60   �� 54      6"   .+�56      �� $��0��6   $��Lịch Sử Xuất Kho��6#   $��40(�6;   $��Black"�6I   
���  ��$��Center=�6m   $��Center=�6�   6�   #  MaterialDesignThemes.Wpf.Card  57      $��1��6"   $��15,10.6,14.8,0q�6/   $��Stretch=�6G   .��58      �� $��2��6    �� Orientation$ 
Horizontal=�6*    59      ��%�   '��       �� 5:      " ��6    .�5;      ��  � ��$ 20(�69   6F   �� 5<       � ��$
 Bold"�6;   6J   �� 5=       � ��$ 60��67   6D   �� 5>       � ��$ 15q�67   6D   5?      5@      .+�5A      (  "System.Windows.Controls.DatePicker   � ToolTip$ Xem từ ngày��6!   $	��120��67   $��40��6C   )	  #MaterialDesignThemes.Wpf.HintAssist 	  Hint$ Ngày Bắt Đầu��6t    ( $MaterialDesignFloatingHintDatePicker#��[ 6�   $��	15 5 15 5q�6�      SelectedDate 6O   �� *
NGAYBATDAU+6�     5B      $ Xem đến ngày��6!   $	��120��68   $��40��6D   $ Ngày kết thúc��6v   #��[ 6�   $��	15 5 15 5q�6�    6P   �� *NGAYKETTHUC+6�   �� 5C      $ Get All��6   ���#FF8A00$��Xem Tất Cả��6f   $	��200��6}   ��6/   �� *GetAllCommand+6�   5D      5E      � 5F      $��2��6    � ColumnDefinitions 5G      �� 5H      6)   �� 5I      $
��0.7* �6'   66   .+�5K        $ Thông tin xuất kho��6&   $��0��6C   $��
15 15 7 15q�6S   $��Stretch=�6g   .��5L      �� $��Disabled=�6#   .��5M      �� -   5        ��5M   #   �� *PhieuXuatKhoList+ �� SelectedItem 6L   �� *SelectedItem+ �� Mode$ OneWayToSource=� �� View 5N      �� 5O   "   .P�5P   &   �� $��Mã PX��65    �� DisplayMemberBinding 6D   �� *MSPX+6l   �� 5Q   &   $��Mã NV Xuất��65    6I   �� *MSNV+6q   �� 5R   &   $��Ngày Xuất��65    6H   �� *
NGAYXUAT+6t   �� 5S   &   $��Trạng Thái��65    6I   �� *NOTE+6q   5T   #   5V      5W      5X        5Z      $��1��6&   $��
7 15 15 15q�66   $��Stretch=�6J   .��5[      �� $
��Auto=�6#   .��5\      �� ��6#   �� *ChiTietPhieuXuatKhoList+ 5^      �� 5_   "   .P�5`   &   �� $��Mã Nguyên Liệu��65    6M   �� *CHITIETPHIEUXUAT.MSNL+6�   �� 5a   &   $��Tên Nguyên Liệu��65    6N   �� *TENNL+6w   �� 5b   &   $��Số Lượng��65    6G   �� *CHITIETPHIEUXUAT.SOLUONG+6�   �� 5c   &   $��Mã Kho��65    6E   �� *CHITIETPHIEUXUAT.MSKHO+6   5d   #   5f      5g      5h      5i      5k      5l      5m      