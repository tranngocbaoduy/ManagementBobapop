using QuanLyTraSua.DBConnection;
using QuanLyTraSua.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyTraSua.ViewModel
{
    public partial class ThongKeViewModel : BaseViewModel
    {
        public ICommand LoadedThongKeWindowCommand { get; set; }
        public ICommand BieuDoCotCommand { get; set; }
        public ICommand BieuDoTronCommand { get; set; }
        public ICommand BieuDoDuongCommand { get; set; }
        public ICommand SanPhamBanCommand { get; set; }
        public ICommand ThuChiCommand { get; set; }
        public ICommand DonBanCommand { get; set; }


        private ObservableCollection<DataChart> _TienBanHangChart { get; set; }
        public ObservableCollection<DataChart> TienBanHangChart { get => _TienBanHangChart; set { _TienBanHangChart = value; OnPropertyChanged(); } }

        private ObservableCollection<DataChart> _TienTraHangChart { get; set; }
        public ObservableCollection<DataChart> TienTraHangChart { get => _TienTraHangChart; set { _TienTraHangChart = value; OnPropertyChanged(); } }

        private ObservableCollection<DataChart> _DonBanChart { get; set; }
        public ObservableCollection<DataChart> DonBanChart { get => _DonBanChart; set { _DonBanChart = value; OnPropertyChanged(); } }

        private ObservableCollection<DataChart> _SanPhamChart { get; set; }
        public ObservableCollection<DataChart> SanPhamChart { get => _SanPhamChart; set { _SanPhamChart = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _FilterBy { get; set; }
        public ObservableCollection<String> FilterBy { get => _FilterBy; set { _FilterBy = value; OnPropertyChanged(); } }

        private String _CollapseTron = "Visible";
        public String CollapseTron { get => _CollapseTron; set { _CollapseTron = value; OnPropertyChanged(); } }

        private String _CollapseCot = "Collapsed";
        public String CollapseCot { get => _CollapseCot; set { _CollapseCot = value; OnPropertyChanged(); } }

        private String _CollapseDuong = "Collapsed";
        public String CollapseDuong { get => _CollapseDuong; set { _CollapseDuong = value; OnPropertyChanged(); } }

        private String _ComboboxMonth = "Collapsed";
        public String ComboboxMonth { get => _ComboboxMonth; set { _ComboboxMonth = value; OnPropertyChanged(); } }

        private String _ComboboxYear = "Collapsed";
        public String ComboboxYear { get => _ComboboxYear; set { _ComboboxYear = value; OnPropertyChanged(); } }

        private String _ThuChiChartVisible = "Visible";
        public String ThuChiChartVisible { get => _ThuChiChartVisible; set { _ThuChiChartVisible = value; OnPropertyChanged(); } }

        private String _DonBanChartVisible = "Collapsed";
        public String DonBanChartVisible { get => _DonBanChartVisible; set { _DonBanChartVisible = value; OnPropertyChanged(); } }

        private String _SanPhamBanChartVisible = "Collapsed";
        public String SanPhamBanChartVisible { get => _SanPhamBanChartVisible; set { _SanPhamBanChartVisible = value; OnPropertyChanged(); } }

        private String _Title2 = "";
        public String Title2 { get => _Title2; set { _Title2 = value; OnPropertyChanged(); } }

        private String _Title1 = "";
        public String Title1 { get => _Title1; set { _Title1 = value; OnPropertyChanged(); } }

        private ObservableCollection<int> _YearList { get; set; }
        public ObservableCollection<int> YearList { get => _YearList; set { _YearList = value; OnPropertyChanged(); } }

        private int _SelectYearList = DateTime.Today.Year;
        public int SelectYearList
        {
            get => _SelectYearList; set
            {
                _SelectYearList = value; OnPropertyChanged();
                if (SelectYearList >= 1990 && SelectYearList <= DateTime.Today.Year)
                {
                    if (CollapseTron == "Visible")
                    {
                        ClearAllChart();
                        LoadMoneyChartByMonthOfYear(DateTime.Today.Year);
                        LoadDonBanChartByMonthOfYear(DateTime.Today.Year);
                        LoadSanPhamChartByMonthOfYear(DateTime.Today.Year);
                    }
                    else
                    {
                        if (ThuChiChartVisible == "Visible")
                        {
                            LoadMoneyChartByMonthOfYear(DateTime.Today.Year);
                        }
                        else if (DonBanChartVisible == "Visible")
                        {
                            LoadDonBanChartByMonthOfYear(DateTime.Today.Year);
                        }
                        else
                        {
                            LoadSanPhamChartByMonthOfYear(DateTime.Today.Year);
                        }
                    }
                }
            }
        }

        private string _SelectFilter = "";
        public string SelectFilter
        {
            get => _SelectFilter; set
            {
                _SelectFilter = value; OnPropertyChanged();
                if (SelectFilter != null)
                {
                    if (SelectFilter.Trim() == "Theo Tháng")
                    {
                        ComboboxYear = "Visible";
                        ComboboxMonth = "Visible";
                    }
                    else if (SelectFilter.Trim() == "Theo Năm")
                    {
                        ComboboxYear = "Visible";
                        ComboboxMonth = "Collapsed";
                    }
                    SelectYearList = DateTime.Today.Year;
                    if (CollapseTron == "Visible")
                    {
                        ClearAllChart();
                        LoadMoneyChartByMonthOfYear(DateTime.Today.Year);
                        LoadDonBanChartByMonthOfYear(DateTime.Today.Year);
                        LoadSanPhamChartByMonthOfYear(DateTime.Today.Year);
                    }
                    else
                    {
                        if (ThuChiChartVisible == "Visible")
                        {
                            LoadMoneyChartByMonthOfYear(DateTime.Today.Year);
                        }
                        else if (DonBanChartVisible == "Visible")
                        {
                            LoadDonBanChartByMonthOfYear(DateTime.Today.Year);
                        }
                        else
                        {
                            LoadSanPhamChartByMonthOfYear(DateTime.Today.Year);
                        }
                    }
                }
            }
        }

        private ObservableCollection<int> _MonthList { get; set; }
        public ObservableCollection<int> MonthList { get => _MonthList; set { _MonthList = value; OnPropertyChanged(); } }

        private int _NumberDayOfMonth = 0;
        public int NumberDayOfMonth { get => _NumberDayOfMonth; set { _NumberDayOfMonth = value; OnPropertyChanged(); } }

        private int _SelectMonthList { get; set; }
        public int SelectMonthList
        {
            get => _SelectMonthList; set
            {
                _SelectMonthList = value; OnPropertyChanged();
                if (SelectMonthList <= 12 && SelectMonthList >= 1 && SelectYearList >= 1990 && SelectYearList <= DateTime.Today.Year)
                {
                    DayList.Clear();
                    if (SelectMonthList == 1 || SelectMonthList == 3 || SelectMonthList == 5 || SelectMonthList == 7 || SelectMonthList == 8 || SelectMonthList == 10 || SelectMonthList == 12)
                    {
                        NumberDayOfMonth = 31;
                    }
                    else if (SelectMonthList == 2)
                    {
                        NumberDayOfMonth = 28;
                    }
                    else
                    {
                        NumberDayOfMonth = 30;
                    }
                    if (CollapseTron == "Visible")
                    {
                        ClearAllChart();
                        LoadMoneyChartByDayOfMonth(SelectMonthList, SelectYearList);
                        LoadDonBanChartByDayOfMonth(SelectMonthList, SelectYearList);
                        LoadSanPhamChartByDayOfMonth(SelectMonthList, SelectYearList);
                    }
                    else
                    {
                        if (ThuChiChartVisible == "Visible")
                        {
                            LoadMoneyChartByDayOfMonth(SelectMonthList, SelectYearList);
                        }
                        else if (DonBanChartVisible == "Visible")
                        {
                            LoadDonBanChartByDayOfMonth(SelectMonthList, SelectYearList);
                        }
                        else if (SanPhamBanChartVisible == "Visible")
                        {
                            LoadSanPhamChartByDayOfMonth(SelectMonthList, SelectYearList);
                        }
                    }
                }
            }
        }

        private ObservableCollection<int> _DayList { get; set; }
        public ObservableCollection<int> DayList { get => _DayList; set { _DayList = value; OnPropertyChanged(); } }

        public ThongKeViewModel()
        {
            TienBanHangChart = new ObservableCollection<DataChart>();
            TienTraHangChart = new ObservableCollection<DataChart>();

            DonBanChart = new ObservableCollection<DataChart>();

            SanPhamChart = new ObservableCollection<DataChart>();

            LoadedThongKeWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    LoadNgayThangNam();
                    LoadFilter();
                    LoadMoneyChartByMonthOfYear(DateTime.Today.Year);
                    LoadDonBanChartByMonthOfYear(DateTime.Today.Year);
                    LoadSanPhamChartByMonthOfYear(DateTime.Today.Year);
                }
            });

            BieuDoTronCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollapseTron = "Visible";
                CollapseCot = "Collapsed";
                CollapseDuong = "Collapsed";

                ClearAllChart();
                LoadMoneyChartByMonthOfYear(DateTime.Today.Year);
                LoadDonBanChartByMonthOfYear(DateTime.Today.Year);
                LoadSanPhamChartByMonthOfYear(DateTime.Today.Year);
            });

            BieuDoCotCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollapseTron = "Collapsed";
                CollapseCot = "Visible";
                CollapseDuong = "Collapsed";

                if (ThuChiChartVisible == "Visible")
                {
                    LoadMoneyChartByMonthOfYear(DateTime.Today.Year);
                }
                else if (DonBanChartVisible == "Visible")
                {
                    LoadDonBanChartByMonthOfYear(DateTime.Today.Year);
                }
                else
                {
                    LoadSanPhamChartByMonthOfYear(DateTime.Today.Year);
                }
            });


            BieuDoDuongCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CollapseTron = "Collapsed";
                CollapseCot = "Collapsed";
                CollapseDuong = "Visible";
                if (ThuChiChartVisible == "Visible")
                {
                    LoadMoneyChartByMonthOfYear(DateTime.Today.Year);
                }
                else if (DonBanChartVisible == "Visible")
                {
                    LoadDonBanChartByMonthOfYear(DateTime.Today.Year);
                }
                else
                {
                    LoadSanPhamChartByMonthOfYear(DateTime.Today.Year);
                }
            });

            DonBanCommand = new RelayCommand<object>((p) =>
            {
                if (CollapseTron == "Visible") { return false; }

                return true;
            }, (p) =>
            {
                if (CollapseTron == "Visible")
                {
                    ClearAllChart();
                    LoadMoneyChartByDayOfMonth(SelectMonthList, SelectYearList);
                    LoadDonBanChartByDayOfMonth(SelectMonthList, SelectYearList);
                    LoadSanPhamChartByDayOfMonth(SelectMonthList, SelectYearList);
                }
                else
                {
                    DonBanChartVisible = "Visible";
                    ThuChiChartVisible = "Collapsed";
                    SanPhamBanChartVisible = "Collapsed";
                    LoadDonBanChartByMonthOfYear(DateTime.Today.Year);
                }
            });

            ThuChiCommand = new RelayCommand<object>((p) => { if (CollapseTron == "Visible") { return false; } return true; }, (p) =>
            {
                if (CollapseTron == "Visible")
                {
                    ClearAllChart();
                    LoadMoneyChartByDayOfMonth(SelectMonthList, SelectYearList);
                    LoadDonBanChartByDayOfMonth(SelectMonthList, SelectYearList);
                    LoadSanPhamChartByDayOfMonth(SelectMonthList, SelectYearList);
                }
                else
                {
                    DonBanChartVisible = "Collapsed";
                    ThuChiChartVisible = "Visible";
                    SanPhamBanChartVisible = "Collapsed";
                    LoadMoneyChartByMonthOfYear(DateTime.Today.Year);
                }
            });

            SanPhamBanCommand = new RelayCommand<object>((p) => { if (CollapseTron == "Visible") { return false; } return true; }, (p) =>
            {
                if (CollapseTron == "Visible")
                {
                    ClearAllChart();
                    LoadMoneyChartByDayOfMonth(SelectMonthList, SelectYearList);
                    LoadDonBanChartByDayOfMonth(SelectMonthList, SelectYearList);
                    LoadSanPhamChartByDayOfMonth(SelectMonthList, SelectYearList);
                }
                else
                {
                    DonBanChartVisible = "Collapsed";
                    ThuChiChartVisible = "Collapsed";
                    SanPhamBanChartVisible = "Visible";
                    LoadSanPhamChartByMonthOfYear(DateTime.Today.Year);
                }
            });
        }

        void LoadFilter()
        {
            FilterBy = new ObservableCollection<string>();

            FilterBy.Add("Theo Tháng");
            FilterBy.Add("Theo Năm");
        }

        void ClearAllChart()
        {
            TienTraHangChart.Clear();
            TienBanHangChart.Clear();
            DonBanChart.Clear();
            SanPhamChart.Clear();
        }

        void LoadMoneyChartByDayOfMonth(int month, int year)
        {
            if (CollapseTron != "Visible")
            {
                ClearAllChart();
            }
            int value = 0;

            var listHoaDon = DataProvider.Ins.DB.HOADONs.Where(p => p.NGAYXUAT.Month == month && p.NGAYXUAT.Year == year).ToList();
            for (int i = 1; i <= NumberDayOfMonth; i++)
            {
                value = 0;
                var listItemInDay = listHoaDon.Where(p => p.NGAYXUAT.Day == i).ToList();
                if (listItemInDay != null && listItemInDay.Count() > 0)
                {
                    foreach (var item in listItemInDay)
                    {
                        value += item.TONGTIEN;
                    }

                }
                TienBanHangChart.Add(new DataChart() { Name = "Ngày " + i, Data = value });
            }

            value = 0;
            var listPhieuNhap = DataProvider.Ins.DB.PHIEUNHAPs.Where(p => p.NGAYNHAP.Month == month && p.NGAYNHAP.Year == year).ToList();
            for (int i = 1; i <= NumberDayOfMonth; i++)
            {
                value = 0;
                var listItemInDay = listPhieuNhap.Where(p => p.NGAYNHAP.Day == i).ToList();
                if (listItemInDay != null && listItemInDay.Count() > 0)
                {
                    foreach (var item in listItemInDay)
                    {
                        value += item.TONGTIEN;
                    }

                }
                TienTraHangChart.Add(new DataChart() { Name = "Ngày " + i, Data = value });
            }

        }

        void LoadDonBanChartByDayOfMonth(int month, int year)
        {
            if (CollapseTron != "Visible")
            {
                ClearAllChart();
            }
            int value = 0;

            var listHoaDon = DataProvider.Ins.DB.HOADONs.Where(p => p.NGAYXUAT.Month == month && p.NGAYXUAT.Year == year).ToList();
            for (int i = 1; i <= NumberDayOfMonth; i++)
            {
                value = 0;
                value = listHoaDon.Where(p => p.NGAYXUAT.Day == i).Count();

                DonBanChart.Add(new DataChart() { Name = "Ngày " + i, Data = value });
            }
        }

        void LoadSanPhamChartByDayOfMonth(int month, int year)
        {
            if (CollapseTron != "Visible")
            {
                ClearAllChart();
            }
            int value = 0;
            for (int i = 1; i <= NumberDayOfMonth; i++)
            {
                value = 0;
                var listHoaDon = DataProvider.Ins.DB.HOADONs.Where(p => p.NGAYXUAT.Day == i && p.NGAYXUAT.Month == month && p.NGAYXUAT.Year == year).ToList();
                if (listHoaDon != null && listHoaDon.Count() > 0)
                {
                    foreach (var item in listHoaDon)
                    {
                        value += DataProvider.Ins.DB.CHITIETHOADONs.Where(p => p.MSHD == item.MSHD).ToList().Sum(k => k.SOLUONG);
                    }
                }
                SanPhamChart.Add(new DataChart() { Name = "Ngây " + i, Data = value });
            }
        }

        void LoadNgayThangNam()
        {
            MonthList = new ObservableCollection<int>();
            YearList = new ObservableCollection<int>();
            DayList = new ObservableCollection<int>();

            for (int i = 1; i <= 12; i++)
            {
                MonthList.Add(i);
            }

            for (int i = 1990; i <= DateTime.Today.Year; i++)
            {
                YearList.Add(i);
            }
        }

        void LoadMoneyChartByMonthOfYear(int year)
        {
            if (CollapseTron != "Visible")
            {
                ClearAllChart();
            }
            int value = 0;

            for (int i = 1; i <= 12; i++)
            {
                value = 0;
                var listHoaDon = DataProvider.Ins.DB.HOADONs.Where(p => p.NGAYXUAT.Month == i && p.NGAYXUAT.Year == year).ToList();
                foreach (var item in listHoaDon)
                {
                    value += item.TONGTIEN;
                }
                TienBanHangChart.Add(new DataChart() { Name = "Tháng " + i, Data = value });
                Title1 = "Tiền Bán Hàng";

                value = 0;
                var listPhieuNhap = DataProvider.Ins.DB.PHIEUNHAPs.Where(p => p.NGAYNHAP.Month == i && p.NGAYNHAP.Year == year).ToList();
                foreach (var item in listPhieuNhap)
                {
                    value += item.TONGTIEN;
                }
                TienTraHangChart.Add(new DataChart() { Name = "Tháng " + i, Data = value });
                Title2 = "Tiền Mua Hàng";
            }

        }

        void LoadDonBanChartByMonthOfYear(int year)
        {
            if (CollapseTron != "Visible")
            {
                ClearAllChart();
            }

            int value = 0;
            for (int i = 1; i <= 12; i++)
            {
                value = 0;
                value = DataProvider.Ins.DB.HOADONs.Where(p => p.NGAYXUAT.Month == i && p.NGAYXUAT.Year == year).Count();
                DonBanChart.Add(new DataChart() { Name = "Tháng " + i, Data = value });
                Title1 = "Đơn Bán Hàng";
                Title2 = "Đơn Bán Hàng";
            }
        }

        void LoadSanPhamChartByMonthOfYear(int year)
        {
            if (CollapseTron != "Visible")
            {
                ClearAllChart();
            }
            int value = 0;
            for (int i = 1; i <= 12; i++)
            {
                value = 0;
                var listHoaDon = DataProvider.Ins.DB.HOADONs.Where(p => p.NGAYXUAT.Month == i && p.NGAYXUAT.Year == year).ToList();
                if (listHoaDon != null && listHoaDon.Count() > 0)
                {
                    foreach (var item in listHoaDon)
                    {
                        value += DataProvider.Ins.DB.CHITIETHOADONs.Where(p => p.MSHD == item.MSHD).ToList().Sum(k => k.SOLUONG);
                    }
                }
                SanPhamChart.Add(new DataChart() { Name = "Tháng " + i, Data = value });
            }
        }

    }
}
