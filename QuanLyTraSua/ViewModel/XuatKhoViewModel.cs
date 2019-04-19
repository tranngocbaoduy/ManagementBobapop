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

namespace QuanLyTraSua.ViewModel
{
    public partial class XuatKhoViewModel : BaseViewModel
    {
        public ICommand LoadedXuatKhoWindowCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand RefreshAllCommand { get; set; }
        public ICommand SavePhieuXuatCommand { get; set; }

        private ObservableCollection<String> _KhoList;
        public ObservableCollection<String> KhoList { get => _KhoList; set { _KhoList = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _NguyenLieuList;
        public ObservableCollection<String> NguyenLieuList { get => _NguyenLieuList; set { _NguyenLieuList = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _NhanVienList;
        public ObservableCollection<String> NhanVienList { get => _NhanVienList; set { _NhanVienList = value; OnPropertyChanged(); } }

        public class NhanVienCMND
        {
            public String TENNV = "";
            public String CMND = ""; 
        }

        public List<NhanVienCMND> NhanVienCMNDList; 

        private ObservableCollection<Inventory> _NguyenLieuXuatList;
        public ObservableCollection<Inventory> NguyenLieuXuatList { get => _NguyenLieuXuatList; set { _NguyenLieuXuatList = value; OnPropertyChanged(); } }

        private ObservableCollection<Inventory> _TempNguyenLieuXuatList;
        public ObservableCollection<Inventory> TempNguyenLieuXuatList { get => _TempNguyenLieuXuatList; set { _TempNguyenLieuXuatList = value; OnPropertyChanged(); } }

        private ObservableCollection<Inventory> _TonKhoList;
        public ObservableCollection<Inventory> TonKhoList { get => _TonKhoList; set { _TonKhoList = value; OnPropertyChanged(); } }

        private ObservableCollection<Inventory> _TempTonKhoList;
        public ObservableCollection<Inventory> TempTonKhoList { get => _TempTonKhoList; set { _TempTonKhoList = value; OnPropertyChanged(); } }

        private ObservableCollection<Inventory> _FullTonKhoList;
        public ObservableCollection<Inventory> FullTonKhoList { get => _FullTonKhoList; set { _FullTonKhoList = value; OnPropertyChanged(); } }

        private String _SelectedKho { get; set; }
        public String SelectedKho
        {
            get => _SelectedKho; set
            {
                _SelectedKho = value; OnPropertyChanged();
                if (SelectedKho != null)
                {
                    var listNguyenLieuByKho = FullTonKhoList.Where(i => i.KHO != null && i.KHO.TENKHO == SelectedKho);

                    if (listNguyenLieuByKho != null)
                    {
                        TempTonKhoList.Clear();
                        NguyenLieuList.Clear();
                        foreach (var item in listNguyenLieuByKho)
                        {
                            TempTonKhoList.Add(item);
                            NguyenLieuList.Add(item.NGUYENLIEU.TENNL);
                        }
                    }
                }
            }
        }


        private String _SelectedNhanVien { get; set; }
        public String SelectedNhanVien { get => _SelectedNhanVien; set { _SelectedNhanVien = value; OnPropertyChanged(); } }

        private DateTime _NgayXuat { get; set; }
        public DateTime NgayXuat { get => _NgayXuat; set { _NgayXuat = value; OnPropertyChanged(); } }

        private Inventory _SelectedItem { get; set; }
        public Inventory SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }

        private String _SelectedNguyenLieu { get; set; }
        public String SelectedNguyenLieu
        {
            get => _SelectedNguyenLieu; set
            {
                _SelectedNguyenLieu = value;
                OnPropertyChanged();
                if (SelectedNguyenLieu != null)
                {
                    SoLuongTon = FullTonKhoList.Where(i => i.NGUYENLIEU.TENNL == SelectedNguyenLieu).SingleOrDefault().Quantity.ToString();
                }
            }
        }

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

        private String _SoLuongTon { get; set; }
        public String SoLuongTon { get => _SoLuongTon; set { _SoLuongTon = value; OnPropertyChanged(); } }

        private String _Note { get; set; }
        public String Note { get => _Note; set { _Note = value; OnPropertyChanged(); } }

        public XuatKhoViewModel()
        {
            NguyenLieuXuatList = new ObservableCollection<Inventory>();

            NgayXuat = DateTime.Today;

            LoadedXuatKhoWindowCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { LoadDanhSachSP(); LoadTonKho(); });

            AddCommand = new RelayCommand<Object>((p) =>
            {
                if (string.IsNullOrEmpty(SelectedNguyenLieu)) { return false; }
                if (string.IsNullOrEmpty(InputQuantity)) { return false; }
                if (string.IsNullOrEmpty(SelectedKho)) { return false; }
                if (string.IsNullOrEmpty(SoLuongTon)) { return false; }
                if ((int) Int32.Parse(SoLuongTon) < (int)Int32.Parse(InputQuantity)) { return false; }

                return true;
            }, (p) => { AddNguyenLieuXuat(); });

            DeleteCommand = new RelayCommand<Object>((p) =>
            {
                if (SelectedItem == null) { return false; }
                return true;
            }, (p) => { DeleteNguyenLieuXuat(); });

            SavePhieuXuatCommand = new RelayCommand<Object>((p) =>
            {
                if (string.IsNullOrEmpty(SelectedNhanVien)) { return false; }
                //if (NgayXuat == null) { return false; }
                if (NguyenLieuXuatList.Count() <= 0) { return false; }
                return true;
            }, (p) => { SavePhieuXuat(); });

            RefreshCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { Refresh(); });

            RefreshAllCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { RefreshAll(); });
        }

        void AddNguyenLieuXuat()
        {
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
                NguyenLieuXuatList.Add(inventory);
                Refresh();
            }
            TempNguyenLieuXuatList = NguyenLieuXuatList;
        }


        void DeleteNguyenLieuXuat()
        {
            if (MessageBox.Show("Bạn Muốn Xoá Nguyên Liệu?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                NguyenLieuXuatList.RemoveAt(NguyenLieuXuatList.IndexOf(SelectedItem));
                TempNguyenLieuXuatList = NguyenLieuXuatList;
            }
        }

        void SavePhieuXuat()
        {
            if (MessageBox.Show("Phiếu Xuất Đã Hoàn Tất?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                var itemCMND = NhanVienCMNDList.Where(i => i.TENNV == SelectedNhanVien).SingleOrDefault();
                // create Phieu Xuat
                var itemNhanVien = DataProvider.Ins.DB.NHANVIENs.Where(i => i.CMND == itemCMND.CMND).SingleOrDefault();

                Model.PHIEUXUAT newPhieuXuat = new Model.PHIEUXUAT();
                NgayXuat = DateTime.Now;
                newPhieuXuat.MSNV = itemNhanVien.MSNV;
                newPhieuXuat.NGAYXUAT = NgayXuat;
                newPhieuXuat.NOTE = Note;

                newPhieuXuat = DataProvider.Ins.DB.PHIEUXUATs.Add(newPhieuXuat);
                int res = DataProvider.Ins.DB.SaveChanges();

                // create cac chi tiet phieu Xuat

                foreach (var item in NguyenLieuXuatList)
                {
                    Model.CHITIETPHIEUXUAT tempChiTietPhieuXuat = new Model.CHITIETPHIEUXUAT();
                    tempChiTietPhieuXuat.MSPX = newPhieuXuat.MSPX;
                    tempChiTietPhieuXuat.MSNL = item.MSNL;
                    tempChiTietPhieuXuat.SOLUONG = item.Quantity;
                    tempChiTietPhieuXuat.MSKHO = item.KHO.MSKHO;

                    DataProvider.Ins.DB.CHITIETPHIEUXUATs.Add(tempChiTietPhieuXuat);
                    res = DataProvider.Ins.DB.SaveChanges();
                    if (res == 0)
                    {
                        MessageBox.Show("Quá trình lưu phiếu xuất đã bị lỗi xin thông báo với người lập trình");
                    }
                }
                MessageBox.Show("Lưu phiếu xuất thành công");
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
            var listNhanVien = DataProvider.Ins.DB.NHANVIENs.Where(i=> i.CHUCVU == "Nhân Viên Kho");

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
        }

        void Refresh()
        {
            SelectedKho = null;
            SelectedNguyenLieu = null;
            InputQuantity = "";
            SoLuongTon = "";
        }

        void RefreshAll()
        {
            SelectedNhanVien = null;
            SelectedKho = null;
            SelectedNguyenLieu = null;
            InputQuantity = "";
            SoLuongTon = "";
            Note = "";
            NgayXuat = DateTime.Today;
            NguyenLieuXuatList.Clear();
            TempNguyenLieuXuatList.Clear();
        }

        void LoadTonKho()
        {
            TonKhoList = new ObservableCollection<Inventory>();
            TempTonKhoList = new ObservableCollection<Inventory>();
            FullTonKhoList = new ObservableCollection<Inventory>();
            var listNguyenLieu = DataProvider.Ins.DB.NGUYENLIEUx;
            var listNhaCungCap = DataProvider.Ins.DB.NHACUNGCAPs;
            var listKho = DataProvider.Ins.DB.KHOes;

            // Lay so luong nhap xuat cua moi Item Nguyen Lieu sau do gan vao Ton kho

            foreach (var item in listNguyenLieu)
            {
                if (item.GIABAN != 0)
                {
                    var listPhieuNhap = DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Where(p => p.MSNL == item.MSNL);

                    var listPhieuXuat = DataProvider.Ins.DB.CHITIETPHIEUXUATs.Where(p => p.MSNL == item.MSNL);


                    int soLuongNguyenLieuNhap = 0;
                    int soLuongNguyenLieuXuat = 0;

                    if (listPhieuNhap != null && listPhieuNhap.Count() > 0)
                    {
                        soLuongNguyenLieuNhap = (int)listPhieuNhap.Sum(p => p.SOLUONG);
                    }
                    if (listPhieuXuat != null && listPhieuXuat.Count() > 0)
                    {
                        soLuongNguyenLieuXuat = (int)listPhieuXuat.Sum(p => p.SOLUONG);
                    }

                    Inventory inventory = new Inventory();
                    inventory.MSNL = item.MSNL;
                    inventory.NGUYENLIEU = item;
                    foreach (var itemNCC in listNhaCungCap)
                    {
                        if (itemNCC.MSNCC == item.MSNCC)
                        {
                            inventory.NHACUNGCAP = itemNCC;
                            break;
                        }
                    }
                    if (listPhieuNhap != null && listPhieuNhap.Count() > 0)
                    {
                        foreach (var itemKho in listKho)
                        {
                            if (itemKho.MSKHO == listPhieuNhap.First().MSKHO)
                            {
                                inventory.KHO = itemKho;
                                break;
                            }
                        }
                    }
                    inventory.Quantity = soLuongNguyenLieuNhap - soLuongNguyenLieuXuat;

                    TonKhoList.Add(inventory);
                }
                else
                {
                    Inventory inventory = new Inventory();
                    inventory.MSNL = item.MSNL;
                    inventory.NGUYENLIEU = item;
                    foreach (var itemNCC in listNhaCungCap)
                    {
                        if (itemNCC.MSNCC == item.MSNCC)
                        {
                            inventory.NHACUNGCAP = itemNCC;
                            break;
                        }
                    }
                    inventory.KHO = new Model.KHO();
                    inventory.Quantity = 0;

                    TonKhoList.Add(inventory);
                }
            }
            FullTonKhoList = TonKhoList;
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

