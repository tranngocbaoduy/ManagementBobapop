   M S B A M L   `   `   `  ����G  CQuanLyTraSua, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuanLyTraSuaQuanLyTraSua  5   	   K*clr-namespace:QuanLyTraSua.UserControlQLTSQuanLyTraSua.UserControlQLTS  5   	   !    QuanLyTraSua.ChangePassword   5   
   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:QuanLyTraSua     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   
   3uc*clr-namespace:QuanLyTraSua.UserControlQLTS  5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��changePassWindow��5   	     � Title$  Đổi mật khẩu��5
   	   $	��350��6   $	��350��6+      ChangePassVM � DataContext# [  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
���   �$	��0.4q�5   	     MaterialDesignBody#���  5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   .��5      � $
��auto��6    � 	Resources 5   
    �� 
TargetType	 �� Property
 �� Value��%V   '�       �� 5      " �6   .�5       �� 	 � ��$
 0q�6+   67   5!      5"       � RowDefinitions 5#   
   �� 5$      $
��auto �6   6,   �� 5%      $
��auto �6   6,   .+�5'   
   � $��0��6   .+�5(      /   )QuanLyTraSua.UserControlQLTS.ControlBarUC  $
��auto��6   $
��auto��6,   $��276,0,0.4,-0.2q�6h   
 � Tag 69   �� *Title+ �� ElementName$ loginWindow��6�   5)      #  MaterialDesignThemes.Wpf.Card  5*   
   $��1��6   $	��350��6+   $
��auto��67   $��Center=�6E   $��Center=�6`   .��5+      � $��10 10 10 10q�6    5,      ��%W   '�       �� 5-      " �6   .�5.      �� 	 � ��$
 10q�63   6@   5/      50       51      �� 52      $
��auto �6$   65   �� 53      $
��auto �6$   64   �� 54      $
��auto �6$   64   �� 55      $
��auto �6$   64   �� 56      $
��auto �6%   66   .+�58      � $��0��6   .+�59      �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên đăng nhập��68    % !MaterialDesignFloatingHintTextBox#��[ 6g   ��6   �� *
UserName+6g   5:      � 5;      $��1��6   .+�5<      G� -   5         G�Name$ PasswordBoxOld��5=      $y�Visible=�61   $ Mật khẩu Cũ��5>       ) %MaterialDesignFloatingHintPasswordBox#��[ 6F   .  (System.Windows.Interactivity.Interaction   Triggers 5?      /  )System.Windows.Interactivity.EventTrigger  5@         	EventName$ PasswordChanged��6-   .  (System.Windows.Interactivity.TriggerBase   Actions. 5A   "   6  0System.Windows.Interactivity.InvokeCommandAction     Command 5B   %   �� *PasswordOldChangedCommand+   CommandParameter 5C   %   �� $ PasswordBoxOld��5D      5F      5G      � 5H      $��2��6   .+�5I      G� -   5        $ PasswordBox��5J      $y�Visible=�6.   $ Mật khẩu Mới��5K      #��[ 6G    5L        5M      $ PasswordChanged��6-   . 5N   "      5O   %   �� *PasswordChangedCommand+ 5P   %   �� $ PasswordBox��5Q      5S      5T      � 5U      $��3��6   .+�5V      G� -   5        $ RePasswordBox��5W      $% Nhập Lại Mật khẩu Mới��5X      #��[ 6P    5Y        5Z      $ PasswordChanged��6-   . 5[   "      5\   %   �� *RePasswordChangedCommand+ 5]   %   �� $ RePasswordBox��5^      5`      5a      � 5b      $��4��6    � ColumnDefinitions 5d      �� 5e      6-   �� 5f      6-   .+�5h      ��  �� 	IsDefault . $��Đổi Mật Khẩu��5j      $��0��63     MaterialDesignRaisedButton#��[ 6C   
��� �|�$��Normal$�6�    � ToolTip$ Đổi password��6�   $	��120��6�   ��5h      �� *ClickResetPasswordButton+��5i      �� $ changePassWindow��5l      �� 5m      $��1��5o      #��[ 6)   
��� E��$��Normal$�6t   $ Close��6�   $	��120��6�   ��5m      �� *ClickCloseLoginForm+��5n      �� $ changePassWindow��.��5o   �   Thoát5q      5s      5t      5u      5v      5w      