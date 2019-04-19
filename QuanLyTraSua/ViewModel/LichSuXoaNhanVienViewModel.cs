
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
    public partial class LichSuXoaNhanVienViewModel : BaseViewModel
    {
        public ICommand RestoreNVCommand { get; set; }
        public ICommand GetAllCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand LoadedLichSuXoaNhanVienWindowCommand { get; set; }
        public ICommand OnKeyUpNhanVienSearchCommand { get; set; }

        private ObservableCollection<Model.NHANVIEN> _NhanVienList;
        public ObservableCollection<Model.NHANVIEN> NhanVienList { get => _NhanVienList; set { _NhanVienList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.NHANVIEN> _TempNhanVienList;
        public ObservableCollection<Model.NHANVIEN> TempNhanVienList { get => _TempNhanVienList; set { _TempNhanVienList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.NHANVIEN> _FullNhanVienList;
        public ObservableCollection<Model.NHANVIEN> FullNhanVienList { get => _FullNhanVienList; set { _FullNhanVienList = value; OnPropertyChanged(); } }


        private Model.NHANVIEN _SelectedItem;
        public Model.NHANVIEN SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MSNV = SelectedItem.MSNV.ToString();
                    TENNV = SelectedItem.TENNV;
                    USERNAME = SelectedItem.USERNAME;
                    GIOITINH = SelectedItem.GIOITINH;
                    EMAIL = SelectedItem.EMAIL;
                    CMND = SelectedItem.CMND;
                    DIACHI = SelectedItem.DIACHI;
                    SDT = SelectedItem.SDT;
                    NGAYVAOLAM = SelectedItem.NGAYVAOLAM;
                    NGAYSINH = SelectedItem.NGAYSINH;
                    CHUCVU = SelectedItem.CHUCVU;
                    MSCALV = SelectedItem.MSCLV;
                    TIENLUONG = SelectedItem.TIENLUONG.ToString();
                    GIOITINH = SelectedItem.GIOITINH;

                    if (SelectedItem.MSCLV == "C1")
                    {
                        CALAMVIEC = "Ca 1";
                    }
                    else if (SelectedItem.MSCLV == "C2")
                    {
                        CALAMVIEC = "Ca 2";
                    }
                    else if (SelectedItem.MSCLV == "C3")
                    {
                        CALAMVIEC = "Ca 3";
                    }
                    else
                    {
                        CALAMVIEC = "FULLTIME";
                    }
                }
            }
        }

        private String _MSNV;
        public String MSNV { get => _MSNV; set { _MSNV = value; OnPropertyChanged(); } }

        private String _TENNV;
        public String TENNV { get => _TENNV; set { _TENNV = value; OnPropertyChanged(); } }

        private String _USERNAME;
        public String USERNAME { get => _USERNAME; set { _USERNAME = value; OnPropertyChanged(); } }

        private String _GIOITINH;
        public String GIOITINH { get => _GIOITINH; set { _GIOITINH = value; OnPropertyChanged(); } }

        private DateTime _NGAYSINH;
        public DateTime NGAYSINH { get => _NGAYSINH; set { _NGAYSINH = value; OnPropertyChanged(); } }

        private String _CMND;
        public String CMND { get => _CMND; set { _CMND = value; OnPropertyChanged(); } }

        private String _DIACHI;
        public String DIACHI { get => _DIACHI; set { _DIACHI = value; OnPropertyChanged(); } }

        private String _SDT;
        public String SDT { get => _SDT; set { _SDT = value; OnPropertyChanged(); } }

        private String _CALAMVIEC;
        public String CALAMVIEC { get => _CALAMVIEC; set { _CALAMVIEC = value; OnPropertyChanged(); } }

        private String _EMAIL;
        public String EMAIL { get => _EMAIL; set { _EMAIL = value; OnPropertyChanged(); } }

        private DateTime _NGAYVAOLAM;
        public DateTime NGAYVAOLAM { get => _NGAYVAOLAM; set { _NGAYVAOLAM = value; OnPropertyChanged(); } }

        private String _CHUCVU;
        public String CHUCVU { get => _CHUCVU; set { _CHUCVU = value; OnPropertyChanged(); } }

        private String _MSCALV;
        public String MSCALV { get => _MSCALV; set { _MSCALV = value; OnPropertyChanged(); } }

        private String _TIENLUONG;
        public String TIENLUONG { get => _TIENLUONG; set { _TIENLUONG = value; OnPropertyChanged(); } }


        public LichSuXoaNhanVienViewModel()
        {
            LoadedLichSuXoaNhanVienWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoadLichSuNhanVien(); });

            GetAllCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoadLichSuNhanVien(); });

            RefreshCommand = new RelayCommand<object>((p) => { return true; }, (p) => { RefreshNhanVien(); });

            RestoreNVCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null) { return false; }
                return true;
            }, (p) => { RestoreNhanVien(); });

            OnKeyUpNhanVienSearchCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
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
                        var listTemp = DataProvider.Ins.DB.NHANVIENs;
                        TempNhanVienList.Clear();
                        foreach (var item in listTemp)
                        {
                            if (item.SDT.StartsWith(p.Text, comparison))
                            {
                                foreach (var prop in FullNhanVienList)
                                {
                                    if (item.SDT == prop.SDT)
                                    {
                                        TempNhanVienList.Add(prop);
                                    }
                                }
                            }
                        }
                        if (TempNhanVienList != null)
                        {
                            NhanVienList = TempNhanVienList;
                        }
                    }
                    else
                    {
                        LoadLichSuNhanVien();
                    }
                }
                catch  
                {
                    // bỏ qua lỗi null tham số
                }
            });

        }

        void RestoreNhanVien()
        {
            if (MessageBox.Show("Restore Nhân Viên Này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                var itemNV = DataProvider.Ins.DB.NHANVIENs.Where(i => i.SDT == SDT).SingleOrDefault();
                if (itemNV != null)
                { 
                    var itemTK = DataProvider.Ins.DB.TAIKHOANs.Where(i => i.USERNAME == itemNV.USERNAME).SingleOrDefault();
                    if(itemTK != null)
                    {
                        itemTK.ACTIVE = true;
                        itemNV.ACTIVE = true;
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Restore Nhân Viên Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Restore Không Nhân Viên Thành Công");
                    }
                }
                RefreshNhanVien();
                LoadLichSuNhanVien();
            }
        }

        void RefreshNhanVien()
        {
            MSNV = "";
            TENNV = "";
            GIOITINH = "";
            NGAYSINH = DateTime.Today;
            CMND = "";
            NGAYVAOLAM = DateTime.Today;
            DIACHI = "";
            SDT = "";
            EMAIL = "";
            CHUCVU = "";
            TIENLUONG = "";
            MSCALV = "";
            USERNAME = "";
            CALAMVIEC = "";
        }

        void LoadLichSuNhanVien()
        {
            NhanVienList = new ObservableCollection<Model.NHANVIEN>();
            TempNhanVienList = new ObservableCollection<Model.NHANVIEN>();
            FullNhanVienList = new ObservableCollection<Model.NHANVIEN>();

            var listNhanVien = DataProvider.Ins.DB.NHANVIENs.Where(i => i.ACTIVE == false);

            foreach (var item in listNhanVien)
            {
                NhanVienList.Add(item);
                TempNhanVienList.Add(item);
                FullNhanVienList.Add(item);
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
