   M S B A M L   `   `   `  ����G  CQuanLyTraSua, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuanLyTraSuaQuanLyTraSua  5   	   K*clr-namespace:QuanLyTraSua.UserControlQLTSQuanLyTraSua.UserControlQLTS  5   	        QuanLyTraSua.QuanLySanPham   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QuanLyTraSua     5   	   9uc*clr-namespace:QuanLyTraSua.UserControlQLTS     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��quanLySanPhamWindow��5   	      QuanLySanPhamVM  � DataContext#  [  5	   	    � Title$) #Quản Lý Mặt Hàng Sản Phẩm��5   	   $	��800��6,   $
��1400��69     MaterialDesignBody#���  5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   
���   �$	��0.4q�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *" LoadedQuanLySanPhamWindowCommand+5      .��5!      �  � RowDefinitions 5"   
   �� 5#      $
��auto �6   6,   �� 5$      6   .+�5&   
   � $��0��6   .+�5'      /   )QuanLyTraSua.UserControlQLTS.ControlBarUC  $
��auto��6   $��	275,0,0,0q�6b   
 � Tag 6,   �� *Title+ �� ElementName$ quanLySanPhamWindow��6x   5(      � 5)   
   $��1��6   $
��auto��6   $
��auto��6)   .+�5+      � $��1��6    5,      �� 5-      $
��auto �6$   64   �� 5.      $
��auto �6$   64   .+�53      � $��1��6    54      �� 55      $
��auto �6(   68   �� 56      $
��auto �6(   68   �� 57      $
��auto �6(   68   �� 58      $
��auto �6(   68   �� 59      $
��auto �6(   68   .+�5;      � $��0��6    � ColumnDefinitions 5<      �� 5=      $	��550 �6/   6=   �� 5>      $	��550 �6/   6=   .+�5@      �� $��20 10q�6$    �� TextAlignment$ Center=�64   $��	ExtraBold"�6K   $��40(�6b   $��0��6p   
���  ��$
��Wrap=�6�   $��Tahoma)�6�   $��Quản lý Sản Phẩm��6�   $��Center=�6�   6�   �� 5A      $��1��6!   
���   �$��
0.35 0 0 0q�6E   ._�5B      ��  �� Orientation$ 
Horizontal=�6)    � 	Resources 5C   "    �� 
TargetType �� Property �� Value��%�  '��       '�� '    �� 5D   &   " ��6,   .�5E   *   ��  � ��$ 15(�6E   6R   �� 5F   *    � ��$
 Bold"�6G   6V   �� 5G   *    � ��$ 18 10 10 10q�6C   6Y   �� 5H   *    � ��$	 140��6B   6P   �� 5I   *    � ��$ 60��6C   6P   �� 5J   *    � �� �#fffda86Y   5K   '   �� 5L   &   " ��6,   .�5M   *   ��  � ��$	 102��6B   6P   5N   '   5O   #   .+�5P   "   ��  � ToolTip$. (Filter những khách hàng tiềm năng��6U   ��6)   �� *LichSuXoaSanPhamCommand+.��5Q   &   �� $
��Wrap=�60   $#��LỊCH SỬ XOÁ SẢN PHẨM��6D   $ Center=�6`   6z   5R   #   �� 5S   "   $- 'Filter những sự kiện tiềm năng��6K   ��6)   �� *GetAllCommand+.��5T   &   �� $
��Wrap=�60   $��LẤY ALL SẢN PHẨM��6E   $��90��6]   $ Center=�6i   6�   5U   #   5W      5X      5Y      #  MaterialDesignThemes.Wpf.Card  5[      $��2��6*   $��10q�67   .��5\      �� $ 
Horizontal=�6%    5]      ��%�   '��       �� 5^   "   " ��6(   .�5_   &   ��  � ��$ 20(�6A   6N   �� 5`   &    � ��$
 Bold"�6C   6R   �� 5a   &    � ��$	 120��6>   6L   5b   #   5c      .+�5d      �� ���#55FF84$��10q�6\   $��60��6i   ��6%   �� *AddLMHCommand+.��5e   "   �� $��Thêm Loại MH��6,   $ Center=�6@   $
��Wrap=�6W   6m   5f      �� 5g      ���#55FF84$��10q�6_   $��60��6l   ��6%   �� *DeleteLMHCommand+.��5h   "   �� $��Xoá Loại MH��6,   $ Center=�6?   $
��Wrap=�6V   6l   5i      �� 5j      ���#55FF84$��Cập nhật��6�   $��10q�6�   $��60��6�   y�6%   �� *CollapsedButton+��6L   �� *UpdateCommand+6�   �� 5k      ���#FF8A00$��Thêm��6�   $��10q�6�   $��60��6�   y�6%   �� *CollapsedButton+��6L   �� *
AddCommand+6�   �� 5l      ���#FF1A1A$
��Xoá��6�   $��10q�6�   $��60��6�   y�6%   �� *CollapsedButton+��6L   �� *DeleteCommand+6�   �� 5m      ���#FF8A00$��
Restore MH��6�   $��10q�6�   $��60��6�   y�6%   �� *CollapsedRestore+��6M   �� *RestoreCommand+6�   �� 5n      ���#55FF84$��
Làm Mới��6]   $��10q�6o   $��60��6{   ��6%   �� *RefreshCommand+6�   5p      5q      � 5r      $��3��6    5s      �� 5t      $
��0.5* �6/   6>   �� 5u      62   .+�5w        $��1��6.   $��10q�6>   .��5x      �� -   5        $��bindingText��5x   &   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tìm kiếm sản phẩm��69    % !MaterialDesignFloatingHintTextBox#��[ 6l   $
��auto��6�   $��15q�6�   .��6�    5y   "     5z   &   $ KeyUp��65   .	 5{   *     
 6@   �� *OnKeyUpCommand+   CommandParameter 6c   �� $ bindingText��5|   '   .��5}   :   5~      5        5�      $��0��6.   $��10q�6>   .��5�      �� -   5        $��	loaiMHMoi��5�   &   $$ Thêm Loại Mặt Hàng Mới��6X   #��[ 6�   $
��auto��6�   $��15q�6�   ��67   �� *ThemLoaiMatHang+.��6�    5�   "     5�   &   $ KeyUp��65   .	 5�   *     
 6@   �� *OnKeyUpThemLoaiMatHangCommand+ 6r   �� $ 	loaiMHMoi��5�   '   .��5�   :   5�      5�      5�        5�      $��1��6*   $��10q�68   .��5�      �  � Orientation$ 
Horizontal=�6$   $
��auto��6=   $
��auto��6K   .+�5�      �� $ Tên SP��6>   #��[ 6f   $	��200��6�   $��15q�6�   ��6&   �� *TENMH+6�   �� 5�      $
 Size��6'   $��70��6�   $��	10 5 10 5q�6�    & "MaterialDesignFloatingHintComboBox#��[ 6�   ��6M   �� *
SizeList+ �� SelectedItem 6n   �� *SelectedSize+ �� SelectedValue 6�   �� *SIZE+6  �� 5�      $ 	Giá Bán��6?   #��[ 6h   $	��100��6�   $��15q�6�   ��6&   �� *GIABAN+6�   �� 5�      $ Loại sản phẩm��6'   $	��220��6�   $��	10 5 10 5q�6�   #��[ 6�   ��6V   �� *TenLoaiSanPhamList+ 6�   �� *SelectedTenLoaiSanPham+ 6�   �� *TENLMH+6/  5�      5�      � 5�      $��4��6    5�      �� 5�      $
��0.5* �6/   6>   �� 5�      61   .+�5�      � $��0��6   .+�5�        $( "Thông tin các loại mặt hàng��62   $
��auto��6X   $��10q�6f   $��Stretch=�6r   $	��370��6�   .��5�   "   �� 
���   �$	��Top=�6C   $	��370��6b   $��Disabled=�6p   $��2q�6�   .��5�   &   �� ��6/   �� *LoaiSanPhamList+ 6W   �� *SelectedLoaiSanPham+ �� View 5�   *   �� 5�   .   .P�5�   2   �� $��Tên Loại Sản Phẩm��6A    �� DisplayMemberBinding 6\   �� *TENLMH+6�   5�   /   5�   '   5�   #   5�      5�      � 5�      $��1��6   .+�5�        $$ Thông tin những mặt hàng��62   $��10q�6U   $��Stretch=�6a   $
��auto��6~   $	��370��6�   .��5�   "   �� 
���   �$��Disabled=�6C   $	��370��6j   $��2q�6w   .��5�   &   �� ��6/   �� *SanPhamList+ 6S   �� *SelectedSanPham+ 5�   *   �� 5�   .   .P�5�   2   �� $��Tên Sản Phẩm��6A    6W   �� *TENMH+6�   �� 5�   2   $
��Size��6A    6O   �� *SIZE+6w   �� 5�   2   $��	Giá Bán��6A    6R   �� *GIABAN+6|   5�   /   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      