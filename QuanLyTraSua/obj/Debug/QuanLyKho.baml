   M S B A M L   `   `   `  ����G  CQuanLyTraSua, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuanLyTraSuaQuanLyTraSua  5   	   K*clr-namespace:QuanLyTraSua.UserControlQLTSQuanLyTraSua.UserControlQLTS  5	   	       QuanLyTraSua.QuanLyKho   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QuanLyTraSua     5   	   9uc*clr-namespace:QuanLyTraSua.UserControlQLTS     5	   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��quanLyKhoWindow��5   	      QuanLyKhoVM  � DataContext#  [  5
   	    � Title$ Quản Lý Kho��5   	   $
��auto��6   $
��auto��6,     MaterialDesignBody#���  5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   
���   �$	��0.4q�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedQuanLyKhoWindowCommand+5      .��5!      �  � 	Resources 5"   
    �� 
TargetType �� Property �� Value��%V   '�       �� 5#      " �6   .�5$      ��  � ��$ 0q�6+   67   5%      5&       � RowDefinitions 5'   
   �� 5(      $
��auto �6   6,   �� 5)      6   .+�5+   
   � $��0��6   .+�5,      /   )QuanLyTraSua.UserControlQLTS.ControlBarUC  $
��auto��6   $
��auto��6,   $��276,0,0.4,-0.2q�6g   
 � Tag 69   �� *Title+ �� ElementName$ loginWindow��6�   5-      � 5.   
   $��1��6    5/      �� 50      $��0.25* �6    61   �� 51      $��0.25* �6    61   �� 52      6"   .+�54      �� $��0��6   $��Nguyên liệu trong kho��6#   $��40(�6@   $��Black"�6N   
���  ��$��Center=�6r   $��Center=�6�   6�   #  MaterialDesignThemes.Wpf.Card  55      $��1��6"   $��10q�6/   .��56      ��  �� Orientation$ 
Horizontal=�6   $��	15 5 5 15q�66   .+�57      ��  � ToolTip$ Chọn kho để filter��6   $	��150��6<   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên Kho��6H    & "MaterialDesignFloatingHintComboBox#��[ 6�   ��6q   �� *	KhoList+ �� SelectedItem 6�   �� *SelectedKho+ �� UpdateSourceTrigger$ PropertyChanged=�6  �� 58      -   5        $��bindingText��58      $* $Tìm kiếm nguyên liệu theo tên��61    % !MaterialDesignFloatingHintTextBox#��[ 6p   $
��auto��6�   $��25 0 0 0q�6�   $	��400��6�   .��6�    59        5:      $ KeyUp��6-   .	 5;   "     
 68   �� *OnKeyUpCommand+   CommandParameter 6[   �� $ bindingText��5<      .��5=   2   5>      5?      5@        5B      $) #Thông tin nguyên liệu tồn kho��6"   $��2��6J   $��
7 15 15 15q�6W   $��Stretch=�6k   .��5C      �� $��Disabled=�6   .��5D      �� ��6   �� *
TonKhoList+ �� View 5E      �� 5F      .P�5G   "   �� $��Mã Số SP��61    �� DisplayMemberBinding 6C   �� *MSNL+6k   �� 5H   "   $��Tên SP��61    6A   �� *NGUYENLIEU.TENNL+6u   �� 5I   "   $��Số Lượng Tồn��61    6G   �� *
Quantity+6s   �� 5J   "   $��	Giá Bán��61    6B   �� *NGUYENLIEU.GIABAN+6w   �� 5K   "   $��Đơn Vị Tính��61    6F   �� *NGUYENLIEU.DVT+6x   �� 5L   "   $��Tên Nhà Cung Cấp��61    6K   �� *NHACUNGCAP.TENNCC+6�   5M      5O      5P      5Q      5R      5S      5T      