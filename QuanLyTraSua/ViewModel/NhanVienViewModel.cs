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
    public partial class NhanVienViewModel : BaseViewModel
    {
        public ICommand LoadedNhanVienWindowCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand OnKeyUpNameNhanVienCommand { get; set; }
        public ICommand OnKeyUpLuongNhanVienCommand { get; set; }
        public ICommand ChamCongNhanVienCommnad { get; set; }
        public ICommand QLTaiKhoanCommand { get; set; }
        public ICommand LishSuXoaNVCommand { get; set; }

        private ObservableCollection<Model.NHANVIEN> _NhanVienList;
        public ObservableCollection<Model.NHANVIEN> NhanVienList { get => _NhanVienList; set { _NhanVienList = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _ChucVuList;
        public ObservableCollection<String> ChucVuList { get => _ChucVuList; set { _ChucVuList = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _GioiTinhList;
        public ObservableCollection<String> GioiTinhList { get => _GioiTinhList; set { _GioiTinhList = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _CaLamViecList;
        public ObservableCollection<String> CaLamViecList { get => _CaLamViecList; set { _CaLamViecList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.NHANVIEN> _TempNhanVienList;
        public ObservableCollection<Model.NHANVIEN> TempNhanVienList { get => _TempNhanVienList; set { _TempNhanVienList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.NHANVIEN> _FullNhanVienList;
        public ObservableCollection<Model.NHANVIEN> FullNhanVienList { get => _FullNhanVienList; set { _FullNhanVienList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.ROLE> _RoleList;
        public ObservableCollection<Model.ROLE> RoleList { get => _RoleList; set { _RoleList = value; OnPropertyChanged(); } }

        private Model.NHANVIEN _SelectedNhanVien;
        public Model.NHANVIEN SelectedNhanVien { get => _SelectedNhanVien; set { _SelectedNhanVien = value; OnPropertyChanged(); } }


        // gan selected Item cho select NhanVien hien thi Nhan Vien
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
                    SDT = SelectedItem.SDT.Trim();
                    NGAYVAOLAM = SelectedItem.NGAYVAOLAM;
                    NGAYSINH = SelectedItem.NGAYSINH;
                    CHUCVU = SelectedItem.CHUCVU;
                    MSCALV = SelectedItem.MSCLV;
                    TIENLUONG = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", SelectedItem.TIENLUONG);
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


        public NhanVienViewModel()
        {
            LoadedNhanVienWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { if (p != null) { LoadNhanVien(); LoadChucVuVaCa(); } });

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TENNV)) { return false; }
                if (string.IsNullOrEmpty(GIOITINH)) { return false; }
                if (string.IsNullOrEmpty(SDT)) { return false; }
                if (string.IsNullOrEmpty(EMAIL)) { return false; }
                if (string.IsNullOrEmpty(CHUCVU)) { return false; }
                if (string.IsNullOrEmpty(CMND)) { return false; }
                if (string.IsNullOrEmpty(TENNV)) { return false; }
                if (string.IsNullOrEmpty(TIENLUONG)) { return false; }
                if (string.IsNullOrEmpty(CALAMVIEC)) { return false; }
                if (CMND.Length > 12) { return false; }
                if (SDT.Length > 12) { return false; }
                if (TIENLUONG.Length < 5) { return false; }

                return true;
            }, (p) => { AddNhanVien(); });

            UpdateCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TENNV)) { return false; }
                if (string.IsNullOrEmpty(GIOITINH)) { return false; }
                if (string.IsNullOrEmpty(SDT)) { return false; }
                if (string.IsNullOrEmpty(EMAIL)) { return false; }
                if (string.IsNullOrEmpty(CHUCVU)) { return false; }
                if (string.IsNullOrEmpty(CMND)) { return false; }
                if (string.IsNullOrEmpty(TIENLUONG)) { return false; }
                if (string.IsNullOrEmpty(CALAMVIEC)) { return false; }
                if (SelectedItem == null) { return false; }
                if (TIENLUONG.Length < 5) { return false; }

                var itemNV = DataProvider.Ins.DB.NHANVIENs.Where(i => i.CMND == CMND).SingleOrDefault();
                if (itemNV == null) { return false; }

                return true;
            }, (p) => { UpdateNhanVien(); });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TENNV)) { return false; }
                if (string.IsNullOrEmpty(GIOITINH)) { return false; }
                if (string.IsNullOrEmpty(SDT)) { return false; }
                if (string.IsNullOrEmpty(EMAIL)) { return false; }
                if (string.IsNullOrEmpty(CHUCVU)) { return false; }
                if (string.IsNullOrEmpty(TIENLUONG)) { return false; }
                if (string.IsNullOrEmpty(CMND)) { return false; }
                if (string.IsNullOrEmpty(TENNV)) { return false; }
                if (string.IsNullOrEmpty(CALAMVIEC)) { return false; }
                if (SelectedItem == null) { return false; }

                var itemNV = DataProvider.Ins.DB.NHANVIENs.Where(i => i.CMND == CMND).SingleOrDefault();
                if (itemNV == null) { return false; }


                return true;
            }, (p) => { DeleteNhanVien(); });

            RefreshCommand = new RelayCommand<object>((p) => { return true; }, (p) => { RefreshNhanVien(); });

            LishSuXoaNVCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LichSuXoaNhanVien LichSuXoaNVForm = new LichSuXoaNhanVien();
                LichSuXoaNVForm.ShowDialog();
                LoadNhanVien();
            });

            ChamCongNhanVienCommnad = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                QuanLyChamCongNhanVien ChamCongForm = new QuanLyChamCongNhanVien();
                ChamCongForm.ShowDialog();
                LoadNhanVien();
            });

            QLTaiKhoanCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                QuanLyTaiKhoan QuanLyTKForm = new QuanLyTaiKhoan();
                QuanLyTKForm.ShowDialog();
                LoadNhanVien();
            });

            OnKeyUpNameNhanVienCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                try
                {
                    StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;
                    if (p != null && p.Text != "")
                    {
                        var listTemp = DataProvider.Ins.DB.NHANVIENs;
                        TempNhanVienList.Clear();
                        foreach (var item in listTemp)
                        {
                            if (item.TENNV.StartsWith(p.Text, comparison))
                            {
                                foreach (var prop in FullNhanVienList)
                                {
                                    if (item.TENNV == prop.TENNV)
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
                        LoadNhanVien();
                    }
                }
                catch  
                {
                    // bỏ qua lỗi null tham số
                }
            });

            OnKeyUpLuongNhanVienCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if (!IsNumeric(p.Text))
                {
                    MessageBox.Show("Bạn phải nhập số "); p.Text = "";
                    return;
                }
            });

        }

        void UpdateNhanVien()
        {
            if (MessageBox.Show("Cập Nhật Nhân Viên?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                var itemNV = DataProvider.Ins.DB.NHANVIENs.Where(i => i.CMND == CMND).SingleOrDefault();
                if (itemNV != null)
                {
                    if (CALAMVIEC == "Ca 1")
                    {
                        MSCALV = "C1";
                    }
                    else if (CALAMVIEC == "Ca 2")
                    {
                        MSCALV = "C2";
                    }
                    else if (CALAMVIEC == "Ca 3")
                    {
                        MSCALV = "C3";
                    }
                    else
                    {
                        MSCALV = "FULLTIME";
                    }
                    itemNV.TENNV = TENNV;
                    itemNV.EMAIL = EMAIL;
                    itemNV.GIOITINH = GIOITINH;
                    itemNV.NGAYSINH = NGAYSINH.Date;
                    itemNV.MSCLV = MSCALV;
                    itemNV.DIACHI = DIACHI;
                    itemNV.NGAYVAOLAM = NGAYVAOLAM.Date;
                    itemNV.CHUCVU = CHUCVU;
                    itemNV.SDT = SDT.Trim();

                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Cập Nhật Thành Công");
                    RefreshNhanVien();
                    LoadNhanVien();
                }
            }
        }


        void DeleteNhanVien()
        {
            if (MessageBox.Show("Xoá Nhân Viên?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                var itemNV = DataProvider.Ins.DB.NHANVIENs.Where(i => i.CMND == CMND).SingleOrDefault();
                if (itemNV != null)
                {
                    var itemTK = DataProvider.Ins.DB.TAIKHOANs.Where(i => i.USERNAME == itemNV.USERNAME).SingleOrDefault();
                    if (itemTK != null)
                    {
                        itemTK.ACTIVE = false;
                        itemNV.ACTIVE = false;
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Xoá Nhân Viên Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Xoá Nhân Viên Thất Bại");
                    }
                    RefreshNhanVien();
                    LoadNhanVien();
                }
            }
        }

        void AddNhanVien()
        {
            if (MessageBox.Show("Tạo Nhân Viên?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                if (!ValidateNhanVien())
                {
                    return;
                }

                if (CALAMVIEC == "Ca 1")
                {
                    MSCALV = "C1";
                }
                else if (CALAMVIEC == "Ca 2")
                {
                    MSCALV = "C2";
                }
                else if (CALAMVIEC == "Ca 3")
                {
                    MSCALV = "C3";
                }
                else
                {
                    MSCALV = "FULLTIME";
                }
                SDT = SDT.Trim();
                // create new NHANVIEN
                var newNhanVien = new Model.NHANVIEN()
                {
                    TENNV = TENNV,
                    USERNAME = SDT,
                    EMAIL = EMAIL,
                    GIOITINH = GIOITINH,
                    NGAYSINH = NGAYSINH.Date,
                    CMND = CMND,
                    MSCLV = MSCALV,
                    DIACHI = DIACHI,
                    NGAYVAOLAM = NGAYVAOLAM.Date,
                    CHUCVU = CHUCVU,
                    TIENLUONG = (int)Int32.Parse(TIENLUONG.Trim()),
                    ROLE = 1,
                    SDT = SDT,
                    ACTIVE = true,
                };

                // create new TAIKHOAN
                Model.TAIKHOAN newTK = new Model.TAIKHOAN();
                newTK.USERNAME = SDT;
                newTK.PASSWORD = Base64Encode("1");
                newTK.ACTIVE = true;

                DataProvider.Ins.DB.TAIKHOANs.Add(newTK);
                DataProvider.Ins.DB.SaveChanges();

                DataProvider.Ins.DB.NHANVIENs.Add(newNhanVien);
                DataProvider.Ins.DB.SaveChanges();

                NhanVienList.Add(newNhanVien);

                MessageBox.Show("Tạo Nhân Viên Và Tài Khoản Thành Công\n Tên tài khoản là: " + SDT + "\n Password: 1 (mặc định)\n\n *Vui lòng đăng nhập để đổi mật khẩu");
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

        void LoadNhanVien()
        {
            NhanVienList = new ObservableCollection<Model.NHANVIEN>();
            FullNhanVienList = new ObservableCollection<Model.NHANVIEN>();
            TempNhanVienList = new ObservableCollection<Model.NHANVIEN>();

            var list = DataProvider.Ins.DB.NHANVIENs.Where(i => i.ACTIVE);

            foreach (var item in list)
            {
                NhanVienList.Add(item);
                TempNhanVienList.Add(item);
                FullNhanVienList.Add(item);
            }
        }

        void LoadChucVuVaCa()
        {
            ChucVuList = new ObservableCollection<string>();
            CaLamViecList = new ObservableCollection<string>();
            GioiTinhList = new ObservableCollection<string>();

            ChucVuList.Add("Phục Vụ");
            ChucVuList.Add("Thu Ngân");
            ChucVuList.Add("Quản Lý");
            ChucVuList.Add("Nhân Viên Kho");
            ChucVuList.Add("Pha Chế");

            CaLamViecList.Add("Ca 1");
            CaLamViecList.Add("Ca 2");
            CaLamViecList.Add("Ca 3");
            CaLamViecList.Add("FULLTIME");

            GioiTinhList.Add("Nam");
            GioiTinhList.Add("Nữ");
        }

        bool ValidateNhanVien()
        {
            var itemNV = DataProvider.Ins.DB.NHANVIENs.Where(i => i.SDT == SDT).SingleOrDefault();
            if (itemNV != null) { MessageBox.Show("SDT đã tồn tại"); return false; }
            if (DataProvider.Ins.DB.NHANVIENs.Where(i => i.CMND == CMND).SingleOrDefault() != null)
            {
                MessageBox.Show("CMND đã tồn tại"); return false;
            }
            return true;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
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
