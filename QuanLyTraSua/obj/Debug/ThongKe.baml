   M S B A M L   `   `   `  ����|  xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5   	   ` \De.TorstenMandelkow.MetroChart, Version=0.9.5818.20693, Culture=neutral, PublicKeyToken=nullwTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChartDe.TorstenMandelkow.MetroChart 5   	   G CQuanLyTraSua, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuanLyTraSuaQuanLyTraSua 5	   	   K*clr-namespace:QuanLyTraSua.UserControlQLTSQuanLyTraSua.UserControlQLTS 5   	      QuanLyTraSua.ThongKe   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   �DVC{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	   fchartTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChart     5   	   ,localclr-namespace:QuanLyTraSua     5	   	   9uc*clr-namespace:QuanLyTraSua.UserControlQLTS     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   V	 RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 5   	   -   5        $��thongKeWindow��5   	      	ThongKeVM  � DataContext#  [  5   	    � Title$ Thống Kê��5   	   $	��800��6   $
��1400��6(     MaterialDesignBody#���  5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   
���   �$	��0.4q�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5    
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5!      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedThongKeWindowCommand+   CommandParameter 6S   ��  �� ElementName$ test1��5"      .��5$      �  � RowDefinitions 5%   
   �� 5&      $
��auto �6   6,   �� 5'      6   .+�5)   
   � $��0��6   .+�5*      /  )QuanLyTraSua.UserControlQLTS.ControlBarUC  $
��auto��6   $��	275,0,0,0q�6\   
 � Tag 6,   �� *Title+$ thongKeWindow��6r   5+      � 5,   
   $��1��6   $
��auto��6   $
��auto��6)    � ColumnDefinitions 5-      �� 5.      6&   .+�58      � $��0��6    59      �� 5:      $
��0.2* �6'   66   �� 5;      6)   .+�5=      � $��0��6    5>      �� 5?      $
��auto �6(   68   �� 5@      $
��auto �6(   68   .+�5B      �� $��10 30q�6     �� TextAlignment$ Center=�6/   $��	ExtraBold"�6F   $��40(�6]   $��0��6k   
���  ��$
��Wrap=�6�   $	��160��6�   $��Tahoma)�6�   $��THỐNG KÊ��6�   $��Center=�6�   $��Center=�6�   6
  �� 5C      $��1��6   
���   �$��0.35 0 0.35 0q�6>   ._�5D      ��  � 	Resources 5E       �� 
TargetType �� Property �� Value��%(  '��       �� 5F   "   " ��6(   .�5G   &   ��  � ��$ 15(�6A   6N   �� 5H   &    � ��$
 Bold"�6C   6R   �� 5I   &    � ��$ 10q�6?   6L   �� 5J   &    � ��$	 120��6>   6L   �� 5K   &    � ��$ 80��6?   6L   �� 5L   &    � �� �#ffcb726U   5M   #   5N      .+�5O      ��  � ToolTip$( "Xem Thống kê Biểu Đồ Tròn��6%   ��6I   �� *BieuDoTronCommand+.��5P   "   �� $
��Wrap=�6,   $��BIỂU ĐỒ TRÒN��6A   $ Center=�6U   $��94��6l   6y   5Q      �� 5R      $( "Xem Thống kê Biểu Đồ Tròn��6%   ��6I   �� *BieuDoCotCommand+.��5S   "   �� $
��Wrap=�6,   $��BIỂU ĐỒ CỘT��6A   $ Center=�6T   $��89��6k   6x   5T      �� 5U      $, &Xem Thống kê Biểu Đồ Đường��6%   ��6J   �� *BieuDoDuongCommand+.��5V   "   �� $
��Wrap=�6,   $��BIỂU ĐỒ ĐƯỜNG��6A   $ Center=�6V   $��89��6m   6z   5W      5X      5Y      5Z      � 5[      $��1��6    5\      �� 5]      $
��auto �6(   68   �� 5^      $��80 �6(   66   �� 5_      6*   .+�5a      �� $��0��6   
���   �$��0.35 0 0.35 0q�6>   ._�5b      ��  �� Orientation$ 
Horizontal=�6%    5c      ��%�  '��       '�� '    �� 5d   "   " ��6(   .�5e   &   ��  � ��$ 15(�6A   6N   �� 5f   &    � ��$
 Bold"�6C   6R   �� 5g   &    � ��$ 18 10 10 10q�6?   6U   �� 5h   &    � ��$	 140��6>   6L   �� 5i   &    � ��$ 60��6?   6L   �� 5j   &    � �� �#fffda86U   5k   #   �� 5l   "   " ��6(   .�5m   &   ��  � ��$	 102��6>   6L   5n   #   5o      .+�5p      �� $. (Filter những khách hàng tiềm năng��6G   ��6%   �� *ThuChiCommand+.��5q   "   �� $
��Wrap=�6,   $��THU CHI��6A   $ Center=�6Q   6k   5r      �� 5s      $- 'Filter những sự kiện tiềm năng��6G   ��6%   �� *DonBanCommand+.��5t   "   �� $
��Wrap=�6,   $��
ĐƠN BÁN��6A   $��90��6P   $ Center=�6\   6u   5u      �� 5v      $; 5Xem lịch sử xoá những khách hàng gần đây��6K   ��6%   �� *SanPhamBanCommand+.��5w   "   �� $
��Wrap=�6,   $��SẢN PHẨM BÁN��6A   $ Center=�6U   6n   5x      5y      5z      � 5{      $��1��6   .+�5|      �  � Orientation$ 
Horizontal=�6$   .+�5}      �� ) 	 #MaterialDesignThemes.Wpf.HintAssist   Hint$ Xem thống kê theo��6'   $	��220��6�   $��	10 5 10 5q�6�    & "MaterialDesignFloatingHintComboBox#��[ 6�   ��6Z   �� *
FilterBy+ �� SelectedItem 6{   �� *SelectFilter+6�   �� 5~      $ Chọn Năm��6'   $	��220��6�   $��	10 5 10 5q�6�   #��[ 6�   ��6Q   �� *
YearList+y�6r   �� *ComboboxYear+ �� SelectedValue 6�   �� *SelectYearList+6  �� 5      $ Chọn Tháng��6'   $	��220��6�   $��	10 5 10 5q�6�   #��[ 6�   ��6S   �� *	MonthList+y�6u   �� *ComboboxMonth+ 6�   �� *SelectMonthList+6!  5�      5�      � 5�      $��2��6    5�      �� 5�      61   .+�5�      -  'De.TorstenMandelkow.MetroChart.PieChart  -   5          Name$ test1��5�   ]   $��0��6M   .	  (De.TorstenMandelkow.MetroChart.ChartBase 	  ChartSubTitle$&  Quản lý thống kê vừa qua��6n    	  
ChartTitle$ Thống kê��5�      $��Black"�6'   
�������y�5�   )   �� *CollapseTron+ 	  Series 5�   "   0
  *De.TorstenMandelkow.MetroChart.ChartSeries
   
  DisplayMember$
 Name��64   $y�	Collapsed=�6K   $��Black"�5�        
  SeriesTitle$  Tiền Bán Hàng��6.   ! 
  ValueMember$
! Data��5�      ��5�      �� *TienBanHangChart+5�      
  5�   "   $
 Name��64   $��Black"�5�      $  Tiền Mua Hàng��61   $
! Data��5�      ��5�      �� *TienTraHangChart+5�      
  5�   "   $
 Name��64   $��Black"�5�      $  Số Đơn Bán Hàng��61   $
! Data��5�      ��5�      �� *DonBanChart+5�      
  5�   "   $
 Name��64   $"  Số Sản Phẩm Bán Hàng��5�      $
! Data��5�      ��5�      �� *SanPhamChart+5�      5�      >   8System.Windows.Controls.DataVisualization.Charting.Chart  5�      "   Title$&"  Quản lý thống kê vừa qua��6$   $��SemiBold"�6F   ���#A60303$��1��6�   
�������y�6r   �� *CollapseCot+#   Series# 5�   "   B   <System.Windows.Controls.DataVisualization.Charting.BarSeries  -   5        $  Name$$ Barchart��5�   $   ?   9System.Windows.Controls.DataVisualization.Charting.Series%   Title$% Số Đơn Bán Hàng��5�   0   H   BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries&   DependentValuePath$
& Data��5�   6   ���#D9304F   MyYellowColumnDataPointStyle'   DataPointStyle#' [ 5�      (   ItemsSource( 5�      �� *DonBanChart+)   IndependentValueBinding) 5�      �� * �� Path$
* Name�+   DependentValueBinding+ 5�      �� $
* Data�5�   #     5�   "   $"% Số Sản Phẩm Bán Hàng��60   ���#F2BB13  MyGreenColumnDataPointStyle#' [ 5�      ( 5�      �� *SanPhamChart+) 5�      �� $
* Name�+ 5�      �� $
* Data�5�   #     5�   "   $% Tiền trả hàng��60   ���#63BF7A  MyRedColumnDataPointStyle#' [ 5�   !   ( 5�   8   �� *TienTraHangChart+) 5�   !   �� $
* Name�+ 5�   !   �� $
* Data�5�   #     5�   "   $% Tiền bán hàng��60   ���#BFA380  MyBrownColumnDataPointStyle#' [ 5�   !   ( 5�   9   �� *TienBanHangChart+) 5�   !   �� $
* Name�+ 5�   !   �� $
* Data�5�   #   5�        5�      $&"  Quản lý thống kê vừa qua��6$   $��SemiBold"�6E   ���#A60303$��1��6�   
�������y�6p   �� *CollapseDuong+# 5�   "   C   =System.Windows.Controls.DataVisualization.Charting.LineSeries  $% Số Đơn Bán Hàng��61   $
& Data��5�   $   ���#D9304F 	 MyYellowLineDataPointStyle#' [	 5�      ( 5�      �� *DonBanChart+) 5�      �� $
* Name�+ 5�      �� $
* Data�5�   #     5�   "   $"% Số Sản Phẩm Bán Hàng��61   ���#F2BB13 
 MyGreenLineDataPointStyle#' [
 5�      ( 5�      �� *SanPhamChart+) 5�      �� $
* Name�+ 5�      �� $
* Data�5�   #     5�   "   $% Tiền trả hàng��61   ���#63BF7A  MyRedLineDataPointStyle#' [ 5�   !   ( 5�   8   �� *TienTraHangChart+) 5�   !   �� $
* Name�+ 5�   !   �� $
* Data�5�   #     5�   "   $% Tiền bán hàng��5�   &   ���#BFA380  MyBrownLineDataPointStyle#' [ 5�   !   ( 5�   9   �� *TienBanHangChart+) 5�   "   �� $
* Name�+ 5�   !   �� $
* Data�5�   #   5�      5�      5�      5�      5�      5�      5�      