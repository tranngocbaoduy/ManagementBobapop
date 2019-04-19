using QuanLyTraSua.DBConnection;
using QuanLyTraSua.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static QuanLyTraSua.ViewModel.XuatKhoViewModel;

namespace QuanLyTraSua.ViewModel
{
    public partial class NhapKhoViewModel : BaseViewModel
    {
        public ICommand LoadedNhapKhoWindowCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand RefreshAllCommand { get; set; }
        public ICommand SavePhieuNhapCommand { get; set; }

        public List<NhanVienCMND> NhanVienCMNDList;

        private ObservableCollection<String> _KhoList;
        public ObservableCollection<String> KhoList { get => _KhoList; set { _KhoList = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _NguyenLieuList;
        public ObservableCollection<String> NguyenLieuList { get => _NguyenLieuList; set { _NguyenLieuList = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _NhanVienList;
        public ObservableCollection<String> NhanVienList { get => _NhanVienList; set { _NhanVienList = value; OnPropertyChanged(); } }

        private ObservableCollection<Inventory> _NguyenLieuNhapList;
        public ObservableCollection<Inventory> NguyenLieuNhapList { get => _NguyenLieuNhapList; set { _NguyenLieuNhapList = value; OnPropertyChanged(); } }

        private ObservableCollection<Inventory> _TempNguyenLieuNhapList;
        public ObservableCollection<Inventory> TempNguyenLieuNhapList { get => _TempNguyenLieuNhapList; set { _TempNguyenLieuNhapList = value; OnPropertyChanged(); } }

        private String _SelectedKho { get; set; }
        public String SelectedKho { get => _SelectedKho; set { _SelectedKho = value; OnPropertyChanged(); } }

        private String _TongTienWindow { get; set; }
        public String TongTienWindow { get => _TongTienWindow; set { _TongTienWindow = value; OnPropertyChanged(); } }

        private int _TongTien { get; set; }
        public int TongTien { get => _TongTien; set { _TongTien = value; OnPropertyChanged(); } }

        private String _SelectedNhanVien { get; set; }
        public String SelectedNhanVien { get => _SelectedNhanVien; set { _SelectedNhanVien = value; OnPropertyChanged(); } }

        private DateTime _NgayNhap { get; set; }
        public DateTime NgayNhap { get => _NgayNhap; set { _NgayNhap = value; OnPropertyChanged(); } }

        private Inventory _SelectedItem { get; set; }
        public Inventory SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }

        private String _SelectedNguyenLieu { get; set; }
        public String SelectedNguyenLieu { get => _SelectedNguyenLieu; set { _SelectedNguyenLieu = value; OnPropertyChanged(); } }

        private String _InputQuantity { get; set; }
        public String InputQuantity
        {
            get => _InputQuantity; set
            {
                _InputQuantity = value;
                OnPropertyChanged();
                if (InputQuantity != "")
                {
                    if (!IsNumeric(InputQuantity))
                    {
                        MessageBox.Show("Bạn phải nhập số"); InputQuantity = "";
                    }
                }
            }
        }

        private String _InputPrice { get; set; }
        public String InputPrice
        {
            get => _InputPrice; set
            {
                _InputPrice = value;
                OnPropertyChanged();
                if (InputPrice != "")
                {
                    if (!IsNumeric(InputPrice))
                    {
                        MessageBox.Show("Bạn phải nhập số"); InputPrice = "";
                    }
                }
            }
        }

        private String _Note { get; set; }
        public String Note { get => _Note; set { _Note = value; OnPropertyChanged(); } }

        public NhapKhoViewModel()
        {
            NguyenLieuNhapList = new ObservableCollection<Inventory>();

            NgayNhap = DateTime.Now;

            LoadedNhapKhoWindowCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { LoadDanhSachSP(); });

            AddCommand = new RelayCommand<Object>((p) =>
            {
                if (string.IsNullOrEmpty(SelectedNguyenLieu)) { return false; }
                if (string.IsNullOrEmpty(InputQuantity)) { return false; }
                if (string.IsNullOrEmpty(InputPrice)) { return false; }
                if (string.IsNullOrEmpty(SelectedKho)) { return false; }

                return true;
            }, (p) => { AddNguyenLieuNhap(); });

            DeleteCommand = new RelayCommand<Object>((p) =>
            {
                if (SelectedItem == null) { return false; }
                return true;
            }, (p) => { DeleteNguyenLieuNhap(); });

            SavePhieuNhapCommand = new RelayCommand<Object>((p) =>
            {
                if (string.IsNullOrEmpty(SelectedNhanVien)) { return false; } 
                //if (NgayNhap == null) { return false; }
                if (NguyenLieuNhapList.Count() <= 0) { return false; }
                return true;
            }, (p) => { SavePhieuNhap(); });

            RefreshCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { Refresh(); });

            RefreshAllCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { RefreshAll(); });
        }

        void AddNguyenLieuNhap()
        {
            if ((int)Int32.Parse(InputPrice) < 499)
            {
                MessageBox.Show("Giá không được nhỏ hơn 500"); InputPrice = "";
                return;
            }
            if ((int)Int32.Parse(InputQuantity) == 0)
            {
                MessageBox.Show("Số lượng không được nhỏ hơn 0"); InputQuantity = "";
                return;
            }
            var itemNguyenLieu = DataProvider.Ins.DB.NGUYENLIEUx.Where(i => i.TENNL == SelectedNguyenLieu).SingleOrDefault();
            var itemKho = DataProvider.Ins.DB.KHOes.Where(i => i.TENKHO == SelectedKho).SingleOrDefault();
            if (itemKho != null && itemNguyenLieu != null)
            {
                Inventory inventory = new Inventory();
                inventory.MSNL = itemNguyenLieu.MSNL;
                inventory.NGUYENLIEU = itemNguyenLieu;
                inventory.KHO = itemKho;
                inventory.Quantity = (int)Int32.Parse(InputQuantity);
                inventory.NGUYENLIEU.GIABAN = (int)Int32.Parse(InputPrice);
                NguyenLieuNhapList.Add(inventory);
                Refresh();
            }
            TongTien = NguyenLieuNhapList.Sum(i => i.Quantity * i.NGUYENLIEU.GIABAN);
            TongTienWindow = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", TongTien);
            TempNguyenLieuNhapList = NguyenLieuNhapList;
        }


        void DeleteNguyenLieuNhap()
        {
            if (MessageBox.Show("Bạn Muốn Xoá Nguyên Liệu?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                NguyenLieuNhapList.RemoveAt(NguyenLieuNhapList.IndexOf(SelectedItem));
                TongTien = NguyenLieuNhapList.Sum(i => i.Quantity * i.NGUYENLIEU.GIABAN);
                TongTienWindow = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", TongTien);
                TempNguyenLieuNhapList = NguyenLieuNhapList;
            }
        }

        void SavePhieuNhap()
        {
            if (MessageBox.Show("Phiếu Nhập Đã Hoàn Tất?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                var itemCMND = NhanVienCMNDList.Where(i => i.TENNV == SelectedNhanVien).SingleOrDefault();

                var itemNhanVien = DataProvider.Ins.DB.NHANVIENs.Where(i => i.CMND == itemCMND.CMND).SingleOrDefault();

                Model.PHIEUNHAP newPhieuNhap = new Model.PHIEUNHAP();
                NgayNhap = NgayNhap.ToLocalTime();
                newPhieuNhap.MSNV = itemNhanVien.MSNV;
                newPhieuNhap.TONGTIEN = TongTien;
                newPhieuNhap.NGAYNHAP = NgayNhap;
                newPhieuNhap.TRANGTHAI = "Đã Nhập Hàng";
                newPhieuNhap.NOTE = Note;

                newPhieuNhap = DataProvider.Ins.DB.PHIEUNHAPs.Add(newPhieuNhap);
                int res = DataProvider.Ins.DB.SaveChanges();

                // create cac chi tiet phieu nhap

                foreach (var item in NguyenLieuNhapList)
                {
                    Model.CHITIETPHIEUNHAP tempChiTietPhieuNhap = new Model.CHITIETPHIEUNHAP();
                    tempChiTietPhieuNhap.MSPN = newPhieuNhap.MSPN;
                    tempChiTietPhieuNhap.MSNL = item.MSNL;
                    tempChiTietPhieuNhap.SOLUONG = item.Quantity;
                    tempChiTietPhieuNhap.DONGIA = item.NGUYENLIEU.GIABAN;
                    tempChiTietPhieuNhap.MSKHO = item.KHO.MSKHO;

                    DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Add(tempChiTietPhieuNhap);
                    res = DataProvider.Ins.DB.SaveChanges();
                    if (res == 0)
                    {
                        MessageBox.Show("Quá trình lưu phiếu nhập đã bị lỗi xin thông báo với người lập trình");
                    }
                }
                MessageBox.Show("Lưu phiếu nhập thành công");
                RefreshAll();
            }
        }

        void LoadDanhSachSP()
        {
            KhoList = new ObservableCollection<String>();
            NguyenLieuList = new ObservableCollection<String>();
            NhanVienList = new ObservableCollection<string>();
            NhanVienCMNDList = new List<NhanVienCMND>();

            var listKho = DataProvider.Ins.DB.KHOes;
            var listNguyenLieu = DataProvider.Ins.DB.NGUYENLIEUx;
            var listNhanVien = DataProvider.Ins.DB.NHANVIENs.Where(i => i.CHUCVU == "Nhân Viên Kho");

            // load list Kho
            foreach (var item in listKho)
            {
                KhoList.Add(item.TENKHO);
            }
            foreach (var item in listNhanVien)
            {
                NhanVienList.Add(item.TENNV);
                NhanVienCMND temp = new NhanVienCMND();
                temp.TENNV = item.TENNV;
                temp.CMND = item.CMND;
                NhanVienCMNDList.Add(temp);
            }
            foreach (var item in listNguyenLieu)
            {
                NguyenLieuList.Add(item.TENNL);
            }
        }

        void Refresh()
        {
            SelectedKho = null;
            SelectedNguyenLieu = null;
            InputQuantity = "";
            InputPrice = "";
        }

        void RefreshAll()
        {
            SelectedNhanVien = null;
            TongTienWindow = "";
            TongTien = 0;
            SelectedKho = null;
            SelectedNguyenLieu = null;
            InputQuantity = "";
            InputPrice = "";
            Note = "";
            NgayNhap = DateTime.Today;
            NguyenLieuNhapList.Clear();
            TempNguyenLieuNhapList.Clear();
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

