   M S B A M L   `   `   `  ����G  CQuanLyTraSua, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuanLyTraSuaQuanLyTraSua  5   	   K*clr-namespace:QuanLyTraSua.UserControlQLTSQuanLyTraSua.UserControlQLTS  5
   	   !    QuanLyTraSua.QuanLyTaiKhoan   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QuanLyTraSua     5   	   9uc*clr-namespace:QuanLyTraSua.UserControlQLTS     5
   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��quanLyTKWindow��5   	      
QuanLyTKVM  � DataContext#  [  5   	    � Title$ Quản Lý Tài Khoản��5   	   $	��800��6$   $	��550��61     MaterialDesignBody#���  5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   
���   �$	��0.4q�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *#!LoadedQuanLyTaiKhoanWindowCommand+5       .��5#      �  � 	Resources 5$   
    �� 
TargetType �� Property �� Value��%V   '�       �� 5%      " �6   .�5&      ��  � ��$ 0q�6+   67   5'      5(       � RowDefinitions 5)   
   �� 5*      $
��auto �6   6,   �� 5+      6   .+�5-   
   � $��0��6   .+�5.      /   )QuanLyTraSua.UserControlQLTS.ControlBarUC  $
��auto��6   $
��auto��6,   $��276,0,0.4,-0.2q�6j   
 � Tag 69   �� *Title+ �� ElementName$ quanLyTKWindow��6�   5/      � 50   
   $��1��6    51      �� 52      $
��auto �6    60   �� 53      $
��auto �6    60   �� 54      $
��auto �6    60   �� 55      $
��auto �6    60   �� 56      $
��auto �6    60   .+�58      �� $��0��6   $��Quản Lý Tài Khoản��6#   $��40(�6<   $��Black"�6J   
���  ��$��Center=�6n   $��Center=�6�   6�   #  MaterialDesignThemes.Wpf.Card  59      $��1��6"   $��15q�60   .��5:      �  � Orientation$ 
Horizontal=�6   $��	0 20 0 20q�65   .+�5;      ��  �� 
IsReadOnly . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ UserName��6J    % !MaterialDesignFloatingHintTextBox#��[ 6t   $	��200��6�   $��15q�6�   ��60   �� *
USERNAME+6�   �� 5<       . $ Active��6H   #��[ 6p   $	��100��6�   $��15q�6�   ��60   �� *ACTIVE+6�   5=      5>      �� 5?      $��2��6    �� Orientation$ 
Horizontal=�6&    5@      ��%�   '��       �� 5A      " ��6   .�5B      ��  � ��$ 20(�65   6B   �� 5C       � ��$
 Bold"�67   6F   �� 5D       � ��$ 60��63   6@   �� 5E       � ��$	 100��62   6@   �� 5F       � ��$ 15q�63   6@   5G      5H      .+�5I      ��  � ToolTip$ Get All��6   ���#89ffaa��6+   �� *GetAllCommand+.��5J      �� $��Lấy Tất Cả��6    $
��Wrap=�62    �� TextAlignment$ Center=�6F   6_   5K      �� 5L      $+ %Làm mới ô thông tin tài khoản��6   ���#89ffaa��6B   �� *RefreshCommand+.��5M      �� $��Refresh��6    $
��Wrap=�6/   $ Center=�6D   6]   5N      �� 5O      $ Kích hoạt tài khoản��6   ���#FF8A00��67   �� *ActiveCommand+.��5P      �� $��Active��6    $
��Wrap=�6.   $ Center=�6C   6\   5Q      �� 5R      $% Tắt kích hoạt tài khoản��6   ���#FF6969��6;   �� *InActiveCommand+.��5S      �� $��	In Active��6    $
��Wrap=�61   $ Center=�6F   6_   5T      5U      � 5V      $��3��6   $��0q�6    .+�5W      �� -   5        $��taiKhoanSearch��5W   E   $, &Tìm kiếm tài khoản theo username��6   $ Tìm Kiếm Theo UserName��6[   #��[ 6�   $
��auto��6�   $��15q�6�   .��6�    5X        5Y      $ KeyUp��6)   .	 5Z        
 64   �� *OnKeyUpTaiKhoanSearchCommand+   CommandParameter 6e   �� $ taiKhoanSearch��5[      .��5\   .   5]      5^        5_      $ Thông tin tài khoản��6"   $��4��6@   $��15,10.6,14.8,15q�6M   $��Stretch=�6g   $	��350��6�   $	��350��6�   .��5`      �� $��Disabled=�6   $
��auto��6F   .��5a      �� ��6   �� *TaiKhoanList+ �� SelectedItem 6D   �� *SelectedItem+ �� Mode$ OneWayToSource=� �� View 5b      �� 5c       �� AllowsColumnReorder . .P�5d   "   �� $��USERNAME��61    �� DisplayMemberBinding 6C   �� *
USERNAME+6o   �� 5e   "   $��ACTIVE��61    6A   �� *ACTIVE+6k   5f      5h      5i      5j      5k      5l      5m      