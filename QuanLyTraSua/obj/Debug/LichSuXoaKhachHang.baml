   M S B A M L   `   `   `  ����G  CQuanLyTraSua, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuanLyTraSuaQuanLyTraSua  5   	   K*clr-namespace:QuanLyTraSua.UserControlQLTSQuanLyTraSua.UserControlQLTS  5
   	   %    QuanLyTraSua.LichSuXoaKhachHang   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QuanLyTraSua     5   	   9uc*clr-namespace:QuanLyTraSua.UserControlQLTS     5
   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��lichSuXoaKHWindow��5   	      LichSuXoaKHVM  � DataContext#  [  5   	    � Title$# Lịch Sử Xoá Khách Hàng��5   	   $	��800��6)   $	��700��66     MaterialDesignBody#���  5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   
���   �$	��0.4q�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *'%LoadedLichSuXoaKhachHangWindowCommand+5       .��5#      �  � 	Resources 5$   
    �� 
TargetType �� Property �� Value��%V   '�       �� 5%      " �6   .�5&      ��  � ��$ 0q�6+   67   5'      5(       � RowDefinitions 5)   
   �� 5*      $
��auto �6   6,   �� 5+      6   .+�5-   
   � $��0��6   .+�5.      /   )QuanLyTraSua.UserControlQLTS.ControlBarUC  $
��auto��6   $
��auto��6,   $��276,0,0.4,-0.2q�6m   
 � Tag 69   �� *Title+ �� ElementName$ lichSuXoaKHWindow��6�   5/      � 50   
   $��1��6    51      �� 52      $
��auto �6    60   �� 53      $
��auto �6    60   �� 54      $
��auto �6    60   �� 55      $
��auto �6    60   �� 56      $
��auto �6    60   .+�58      �� $��0��6   $(��"Khách Hàng Đã Xoá Gần Đây��6#   $��40(�6D   $��Black"�6R   
���  ��$��Center=�6v   $��Center=�6�   6�   #  MaterialDesignThemes.Wpf.Card  59      $��1��6"   $��15q�6/   .��5:      �  � Orientation$ 
Horizontal=�6   $��10q�66   .+�5;      �� -   5        $��bindingText��5;   0    �� 
IsReadOnly . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Số điện thoại��6[    % !MaterialDesignFloatingHintTextBox#��[ 6�   $	��150��6�   $��5 5 15 5q�6�   ��6C   �� *SDTKH+.��6�    5<        5=      $ KeyUp��6-   .	 5>   "     
 68   �� *OnKeyUpSDTKhachHangCommand+ �� UpdateSourceTrigger$ PropertyChanged=�   CommandParameter 6�   �� $ bindingText��5?      .��5@   2   5A      �� 5B       . $ Họ Tên Khách Hàng��6l   #��[ 6�   $	��200��6�   $��5 5 15 5q�6�   ��60   �� *TENKH+$ PropertyChanged=�6�   �� 5C       . $ Điểm Thân Thiết��6m   #��[ 6�   $	��100��6�   $��5 5 15 5q�6�   ��60   �� *DIEMTT+$ PropertyChanged=�6�   �� 5D       . $ % Khuyến Mãi��6n   #��[ 6�   $	��100��6�   $��5 5 15 5q�6�   ��60   �� *	GIAMGIA+$ PropertyChanged=�6�   �� 5E       . $ Địa Chỉ��6m   #��[ 6�   $	��300��6�   $��5 5 15 5q�6�   ��60   �� *DIACHI+$ PropertyChanged=�6�   �� 5F       . $ Email��6l   #��[ 6�   $	��300��6�   $��5 5 15 5q�6�   ��60   �� *EMAIL+$ PropertyChanged=�6�   5G      5H      �� 5I      $��2��6    �� Orientation$ 
Horizontal=�6&    5J      ��%�   '��       �� 5K      " ��6   .�5L      ��  � ��$ 20(�65   6B   �� 5M       � ��$
 Bold"�67   6F   �� 5N       � ��$ 60��63   6@   �� 5O       � ��$	 200��62   6@   �� 5P       � ��$ 15q�63   6@   5Q      5R      .+�5S      ��  � ToolTip$* $Restore lại khách hàng đã xoá��6   ���#FF8A00��6A   �� *RestoreKHCommand+.��5T      �� $��Restore Khách Hàng��6    $
��Wrap=�6:   $	��140��6N    �� TextAlignment$ Center=�6Z   6s   5U      �� 5V      $ Get All��6   ���#89ffaa��6+   �� *GetAllCommand+.��5W      �� $#��Lấy Tất Cả Khách Hàng��6    $
��Wrap=�6=   $	��140��6Q   $ Center=�6]   6v   5X      5Y      � 5Z      $��3��6   $��0q�6    .+�5[      �� -   5        $��khachHangSearch��5[   L   $8 2Tìm kiếm khách hàng theo số điện thoại��6   $ Tìm Kiếm Khách Hàng��6�   #��[ 6�   $
��auto��6�   $��15q�6�   ��6c   �� *SearchEvent+.��6   5\        5]      $ KeyUp��6)   .	 5^        
 64   �� *OnKeyUpKhachHangSearchCommand+ 6f   �� $ khachHangSearch��5_      .��5`   .   5a      5b        5c      $ Thông tin khách hàng��6"   $��4��6A   $��15q�6N   $
��auto��6Z   $	��360��6h   $��Stretch=�6x   .��5d      �� $��Disabled=�6   $
��auto��6F   .��5e      �� ��6   �� *KhachHangList+ �� SelectedItem 6E   �� *SelectedItemKhachHang+ �� Mode$ OneWayToSource=� �� View 5f      �� 5g       �� AllowsColumnReorder . .P�5h   "   �� $��SĐT Khách Hàng��61    �� DisplayMemberBinding 6I   �� *SDT+6p   �� 5i   "   $��Tên Khách Hàng��61    6I   �� *TENKH+6r   �� 5j   "   $��Điểm Thân Thiết��61    6J   �� *DIEMTT+6t   �� 5k   "   $��Địa Chỉ��61    6B   �� *DIACHI+6l   �� 5l   "   $��Email��61    6@   �� *EMAIL+6i   5m      5o      5p      5q      5r      5s      5t      