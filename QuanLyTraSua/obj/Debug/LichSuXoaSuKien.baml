   M S B A M L   `   `   `  ����G  CQuanLyTraSua, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuanLyTraSuaQuanLyTraSua  5   	   K*clr-namespace:QuanLyTraSua.UserControlQLTSQuanLyTraSua.UserControlQLTS  5
   	   "    QuanLyTraSua.LichSuXoaSuKien   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QuanLyTraSua     5   	   9uc*clr-namespace:QuanLyTraSua.UserControlQLTS     5
   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��lichSuXoaSKWindow��5   	      LichSuXoaSKVM  � DataContext#  [  5   	    � Title$" Lịch Sử Xoá Sự Kiện��5   	   $	��750��6&   $	��700��63     MaterialDesignBody#���  5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   
���   �$	��0.4q�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *$"LoadedLichSuXoaSuKienWindowCommand+5       .��5#      �  � 	Resources 5$   
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
��auto �6    60   .+�57      �� $��0��6   $'��!Sự Kiện Đã Xoá Gần Đây��6#   $��40(�6A   $��Black"�6O   
���  ��$��Center=�6s   $��Center=�6�   6�   � 58      $��1��6   .+�59      �  5:      �� 5;      $
��auto �6(   68   �� 5<      $
��auto �6(   68   �� 5=      $
��auto �6(   68   �� 5>      $
��auto �6(   68   .+�5@      #  MaterialDesignThemes.Wpf.Card  $��0��6*   $��15q�67   .��5A      �  � Orientation$ 
Horizontal=�6%   $��10q�6>   .+�5B      ��  �� 
IsReadOnly . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên Sự Kiện��6t    % !MaterialDesignFloatingHintTextBox#��[ 6�   $	��200��6�   $��5 5 15 5q�6�   ��68   �� *TENSK+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5C       . $ Điểm Thân Thiết��6z   #��[ 6�   $	��100��6�   $��5 5 15 5q�6�   ��68   �� *DIEMTTEVENT+$ PropertyChanged=�6  �� 5D       . $ % Khuyến Mãi��6{   #��[ 6�   $	��100��6�   $��5 5 15 5q�6�   ��68   �� *GIAMGIAEVENT+$ PropertyChanged=�6  �� 5E       �� 
IsReadOnly . $ Loại Sự Kiện��69   $	��220��6�   $��	10 5 10 5q�6�    & "MaterialDesignFloatingHintComboBox#��[ 6�   ��6g   �� *TenLoaiSuKienList+ �� SelectedItem 6�   �� *SelectedLoaiSuKien+6  �� 5F       . $ Nội dung sự kiện��6v   #��[ 6�   $	��600��6�   $
��auto��6�   $��	5 5 15 10q�6�   ��68   �� *	CONTENT+$ PropertyChanged=�6  5G      5H      �� 5I      $��1��6!    �� Orientation$ 
Horizontal=�6.    5J      ��%�   '��       �� 5K      " ��6$   .�5L   "   ��  � ��$ 20(�6=   6J   �� 5M   "    � ��$
 Bold"�6?   6N   �� 5N   "    � ��$ 60��6;   6H   �� 5O   "    � ��$	 200��6:   6H   �� 5P   "    � ��$ 15q�6;   6H   5Q      5R      .+�5S      ��  � ToolTip$# Restore sự kiện đã xoá��6"   ���#FF8A00��6C   �� *RestoreSKCommand+.��5T      �� $��Restore Sự Kiện��6(   $
��Wrap=�6?    �� TextAlignment$ Center=�6S   6l   5U      �� 5V      $ Get All��6!   ���#89ffaa��63   �� *GetAllEventCommand+.��5W      �� $��Lấy Tất Cả Event��6(   $
��Wrap=�6@   $ Center=�6T   6m   5X      5Y      � 5Z      $��2��6   $��0q�6(   .+�5[      �� -   5        $��suKienSearch��5[   F   $' !Tìm kiếm sự kiện theo tên��6"   $ Tìm Kiếm Sự Kiện��6w   #��[ 6�   $
��auto��6�   $��15q�6�   ��6Z   �� *SearchEvent+.��6�    5\        5]   "   $ KeyUp��61   .	 5^   &     
 6<   �� *OnKeyUpSuKienSearchCommand+   CommandParameter 6k   �� $ suKienSearch��5_   #   .��5`   6   5a      5b        5c      $&  Thông tin sự kiện đã xoá��6*   $��3��6M   $��15q�6Z   $
��auto��6f   $	��350��6t   $��Stretch=�6�   .��5d      �� $��Disabled=�6'   .��5e      �� ��6'   �� *
SuKienList+ 6J   �� *SelectedItemSuKien+ �� Mode$ OneWayToSource=� �� View 5f   "   �� 5g   &    �� AllowsColumnReorder . .P�5h   *   �� $��Tên SK��69    �� DisplayMemberBinding 6I   �� *SUKIEN.TENSK+6y   �� 5i   *   $��	Loại SK��69    6J   �� *TENLSK+6t   �� 5j   *   $��
Điểm TT��69    6J   �� *SUKIEN.DIEMTT+6{   �� 5k   *   $��Giảm Giá��69    6K   �� *SUKIEN.GIAMGIA+6}   �� 5l   *   $��
Nội dung��69    6K   �� *SUKIEN.NDSUKIEN+6~   5m   '   5o      5p      5q      5r      5s      5t      5u      5v      