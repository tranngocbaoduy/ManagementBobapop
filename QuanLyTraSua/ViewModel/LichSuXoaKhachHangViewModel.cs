using QuanLyTraSua.DBConnection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyTraSua.ViewModel
{
    public partial class LichSuXoaKhachHangViewModel : BaseViewModel
    {
        public ICommand RestoreKHCommand { get; set; }
        public ICommand GetAllCommand { get; set; }
        public ICommand LoadedLichSuXoaKhachHangWindowCommand { get; set; }
        public ICommand OnKeyUpKhachHangSearchCommand { get; set; }

        private ObservableCollection<Model.KHACHHANG> _KhachHangList;
        public ObservableCollection<Model.KHACHHANG> KhachHangList { get => _KhachHangList; set { _KhachHangList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.KHACHHANG> _TempKhachHangList;
        public ObservableCollection<Model.KHACHHANG> TempKhachHangList { get => _TempKhachHangList; set { _TempKhachHangList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.KHACHHANG> _FullKhachHangList;
        public ObservableCollection<Model.KHACHHANG> FullKhachHangList { get => _FullKhachHangList; set { _FullKhachHangList = value; OnPropertyChanged(); } }


        private Model.KHACHHANG _SelectedItemKhachHang;
        public Model.KHACHHANG SelectedItemKhachHang
        {
            get => _SelectedItemKhachHang; set
            {
                _SelectedItemKhachHang = value; OnPropertyChanged();
                if (SelectedItemKhachHang != null)
                {
                    SDTKH = SelectedItemKhachHang.SDT;
                    TENKH = SelectedItemKhachHang.TENKH;
                    DIACHI = SelectedItemKhachHang.DIACHI;
                    EMAIL = SelectedItemKhachHang.EMAIL;
                    DIEMTT = SelectedItemKhachHang.DIEMTT.ToString();
                    if (SelectedItemKhachHang.DIEMTT > 100)
                    {
                        GIAMGIA = "5 %";
                    }
                    else if (SelectedItemKhachHang.DIEMTT > 1000)
                    {
                        GIAMGIA = "10 %";
                    }
                    else if (SelectedItemKhachHang.DIEMTT > 5000)
                    {
                        GIAMGIA = "12 %";
                    }
                    else if (SelectedItemKhachHang.DIEMTT > 10000)
                    {
                        GIAMGIA = "15 %";
                    }
                    else
                    {
                        GIAMGIA = "0 %";
                    }
                }
            }
        }

        private String _SDTKH { get; set; }
        public String SDTKH { get => _SDTKH; set { _SDTKH = value; OnPropertyChanged(); } }

        private String _SearchKH = "";
        public String SearchKH { get => _SearchKH; set { _SearchKH = value; OnPropertyChanged(); } }

        private String _TENKH { get; set; }
        public String TENKH { get => _TENKH; set { _TENKH = value; OnPropertyChanged(); } }

        private String _DIEMTT { get; set; }
        public String DIEMTT { get => _DIEMTT; set { _DIEMTT = value; OnPropertyChanged(); } }

        private String _GIAMGIA { get; set; }
        public String GIAMGIA { get => _GIAMGIA; set { _GIAMGIA = value; OnPropertyChanged(); } }

        private String _DIACHI { get; set; }
        public String DIACHI { get => _DIACHI; set { _DIACHI = value; OnPropertyChanged(); } }

        private String _EMAIL { get; set; }
        public String EMAIL { get => _EMAIL; set { _EMAIL = value; OnPropertyChanged(); } }

        public LichSuXoaKhachHangViewModel()
        {
            LoadedLichSuXoaKhachHangWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoadLichSuKhachHang(); });

            GetAllCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoadLichSuKhachHang(); });

            RestoreKHCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItemKhachHang == null) { return false; }
                return true;
            }, (p) => { RestoreKhachHang(); });

            OnKeyUpKhachHangSearchCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                try
                {
                    StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;
                    if (p != null && p.Text != "")
                    {
                        if (!IsNumeric(p.Text))
                        {
                            MessageBox.Show("Bạn phải nhập số "); p.Text = "";
                            return;
                        }
                        var listTemp = DataProvider.Ins.DB.KHACHHANGs;
                        TempKhachHangList.Clear();
                        foreach (var item in listTemp)
                        {
                            if (item.SDT.StartsWith(p.Text, comparison))
                            {
                                foreach (var prop in FullKhachHangList)
                                {
                                    if (item.SDT == prop.SDT)
                                    {
                                        TempKhachHangList.Add(prop);
                                    }
                                }
                            }
                        }
                        if (TempKhachHangList != null)
                        {
                            KhachHangList = TempKhachHangList;
                        }
                    }
                    else
                    {
                        LoadLichSuKhachHang();
                    }
                }
                catch  
                {
                    // bỏ qua lỗi null tham số
                }
            });

        }

        void RestoreKhachHang()
        {
            if (MessageBox.Show("Thêm Sự Kiện Này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                var itemKH = DataProvider.Ins.DB.KHACHHANGs.Where(i => i.SDT == SDTKH).SingleOrDefault();
                if (itemKH != null)
                {
                    itemKH.ACTIVE = true;
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Restore Khách Hàng Thành Công");
                }
                LoadLichSuKhachHang();
            }
        }

        void LoadLichSuKhachHang()
        {
            KhachHangList = new ObservableCollection<Model.KHACHHANG>();
            TempKhachHangList = new ObservableCollection<Model.KHACHHANG>();
            FullKhachHangList = new ObservableCollection<Model.KHACHHANG>();

            var listKhachHang = DataProvider.Ins.DB.KHACHHANGs;

            foreach (var item in listKhachHang)
            {
                if (item.ACTIVE == false)
                {
                    KhachHangList.Add(item);
                    TempKhachHangList.Add(item);
                    FullKhachHangList.Add(item);
                }
            }
        }

        public static System.Boolean IsNumeric(System.Object Expression)
        {
            if (Expression == null || Expression is DateTime)
                return false;

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;

            try
            {
                if (Expression is string)
                    Double.Parse(Expression as string);
                else
                    Double.Parse(Expression.ToString());
                return true;
            }
            catch { } // just dismiss errors but return false
            return false;
        }
    }
}
