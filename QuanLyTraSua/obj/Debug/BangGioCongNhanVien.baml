   M S B A M L   `   `   `  ����G  CQuanLyTraSua, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuanLyTraSuaQuanLyTraSua  5   	   K*clr-namespace:QuanLyTraSua.UserControlQLTSQuanLyTraSua.UserControlQLTS  5   	   &     QuanLyTraSua.BangGioCongNhanVien   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QuanLyTraSua     5   	   9uc*clr-namespace:QuanLyTraSua.UserControlQLTS     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��bangGioCongNhanVien��5   	     � Title$$  Bảng Giờ Công Nhân Viên��5	   	   $	��600��6)   $	��800��66      BangGiaCongNVVM � DataContext# [  5   	     MaterialDesignBody#���  5   	   $��Regular"�5   	   $��13(�5   	   
���   �$	��0.4q�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5       6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *(&LoadedBangGioCongNhanVienWindowCommand+   CommandParameter 6_   ��  �� ElementName$ bangGioCongNhanVien��5!      .��5%      �  � RowDefinitions 5&   
   �� 5'      $
��auto �6   6,   �� 5(      6   .+�5*   
   � $��0��6   .+�5+      /   )QuanLyTraSua.UserControlQLTS.ControlBarUC  $
��auto��6   $��	275,0,0,0q�6b   
 � Tag 6,   �� *Title+$ bangGioCongNhanVien��6x   5,      � 5-   
   $��1��6    � ColumnDefinitions 5.      �� 5/      $��* �6#   6/   .+�57      �� $
��Auto=�6   $
��auto��6>   .��59      � $��0��6    5:      �� 5;      $
��auto �6(   68   �� 5<      $
��auto �6(   68   .+�5>      �  � Orientation$ Vertical=�6    $��Center=�67   $��Center=�6R   .+�5?      �� $��	ExtraBold"�6$   
���  ��$��Tahoma)�6M   $,��&Check-in giờ làm việc Nhân viên��6a   $��45(�6�   $��Center=�6�   $��10q�6�   6�   �� 5@      -   5        $��dataText��5@   ;    �� TextAlignment$ Center=�6$   $��	ExtraBold"�6K   
�����f�$��Tahoma)�6�   $��45(�6�   $��Center=�6�   $��10q�6�   6�   #  MaterialDesignThemes.Wpf.Card  5B      $
��auto��6.   $��1��6;   $��Stretch=�6H   $��10q�6k   .��5C      �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Ca Làm Việc��6K   $
��auto��6�   $��	10 5 10 5q�6�    & "MaterialDesignFloatingHintComboBox#��[ 6�    �� SelectedItem 6'   �� *
SelectedCa+��6x   �� *CaLamViecList+6�   5D      5E      � 5G      
�������$��1��62   $
��auto��6@   .+�5I      �  5J      �� 5K   "   65   �� 5L   "   65   .+�5N      � $��0��6#   $��15q�63    5O   "   �� 5P   &   66   �� 5Q   &   66   .+�5S   "   �� $��0��6,   $��20(�69   $��15q�6G   $��Black"�6S   $��Check Giờ Vào Ca��6f   6�     5T   "   $��1��66   $��Stretch=�6C   .��5U   &   �� $��1��6`    � IsSharedSizeScope . $
��auto��6�   $
��auto��6�   ��64   �� *NhanVienLamByCaList+��5V   *   �� 5W   .   .R�5X   2   ��  ��Name$ Border��6:    �� Padding$ 8q�6J   $��0 0 0 1q�6V     MaterialDesignDivider#���  6p   ._�5Y   6   �  5Z   :   �� 5[   >    z� SharedSizeGroup$ Checkerz��6O   �� 5\   >   .+�5^   :   d�  � ToolTip$* $Nhập mật khẩu check-in vào ca��6G   $��Center=�6�    ) %MaterialDesignActionLightToggleButton#��[ 6�   {�6o   �� *ISCHECKINYET_+ d� 	IsChecked 6�   �� *	ISCHECKIN+��6  �� *Code+�� 5_   :   $��10 0 0 0q�6E   $��1��6W   .+�5`   >   �� $
��Bold"�6H   ��6Z   �� *TENNV+�� 5a   >   ��6H   �� *SDT+�� 5b   >    �� 
IsReadOnly 6F   �� *ISCHECKINYET+��6j   �� *PASSIN+5c   ;   5d   7   5e   3    �� Triggers 5f   2   �� 5g   6    �� Value$
 True��6k    �� Binding 6B   �� *SelectedItemNhanVien+.a�5h   :   ��  �� 
TargetName$ Border��6A     MaterialDesignSelection �� Value# �  6l     �� Property  � ��5i   7   5k   /   5m   '   5n   #   5o      � 5s      $��1��6#   $��15q�63    5t   "   �� 5u   &   66   �� 5v   &   66   .+�5x   "   �� $��0��6,   $��20(�69   $��15q�6G   $��Black"�6S   $��Check Giờ Ra Ca��6f   6     5y   "   $��1��66   $��Stretch=�6C   .��5{   &   �� $��1��6_    . $
��auto��6�   $
��auto��6�   ��63   �� *NhanVienLamByCaList+��5|   *   �� 5}   .   .R�5~   2   �� $ Border��6:   $ 8q�6J   $��0 0 0 1q�6V   #���  6p   ._�5   6   �  5�   :   �� 5�   >   $ Checkerz��6O   �� 5�   >   .+�5�   :   d� $( "Nhập mật khẩu check-in ra ca��6G   $��Center=�6�   #��[ 6�   {�6n   �� *ISCHECKOUTYET_+ 6�   �� *
ISCHECKOUT+��6  �� *Code+�� 5�   :   $��10 0 0 0q�6E   $��1��6W   .+�5�   >   �� $
��Bold"�6H   ��6Z   �� *TENNV+�� 5�   >   ��6H   �� *SDT+�� 5�   >    6F   �� *ISCHECKOUTYET+��6k   �� *	PASSOUT+5�   ;   5�   7   5�   3    5�   2   �� 5�   6   $
 True��6k    6B   �� *SelectedItemNhanVien+.a�5�   :   �� $ Border��6A   # �  6l     � ��5�   7   5�   /   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      