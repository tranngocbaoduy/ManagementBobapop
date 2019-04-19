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
    public partial class TonKhoViewModel : BaseViewModel
    {

        public ICommand LoadedTonKhoWindowCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand NhaCungCapWindowCommand { get; set; }
        public ICommand OnKeyUpCommand { get; set; }
        public ICommand LichSuNhapKhoWindowCommand { get; set; }
        public ICommand LichSuXuatKhoWindowCommand { get; set; }
        public ICommand NhapKhoWindowCommand { get; set; }
        public ICommand XuatKhoWindowCommand { get; set; }
        public ICommand QuanLyKhoWindowCommand { get; set; }

        private ObservableCollection<String> _NhaCungCapList;
        public ObservableCollection<String> NhaCungCapList { get => _NhaCungCapList; set { _NhaCungCapList = value; OnPropertyChanged(); } }

        private ObservableCollection<Inventory> _TonKhoList;
        public ObservableCollection<Inventory> TonKhoList { get => _TonKhoList; set { _TonKhoList = value; OnPropertyChanged(); } }


        private ObservableCollection<Inventory> _TempTonKhoList;
        public ObservableCollection<Inventory> TempTonKhoList { get => _TempTonKhoList; set { _TempTonKhoList = value; OnPropertyChanged(); } }

        private ObservableCollection<Inventory> _FullTonKhoList;
        public ObservableCollection<Inventory> FullTonKhoList { get => _FullTonKhoList; set { _FullTonKhoList = value; OnPropertyChanged(); } }

        private Inventory _SelectedNguyenLieu;
        public Inventory SelectedNguyenLieu { get => _SelectedNguyenLieu; set { _SelectedNguyenLieu = value; OnPropertyChanged(); } }


        private String _SelectedNhaCungCap;
        public String SelectedNhaCungCap { get => _SelectedNhaCungCap; set { _SelectedNhaCungCap = value; OnPropertyChanged(); } }

        private String _MSNL;
        public String MSNL { get => _MSNL; set { _MSNL = value; OnPropertyChanged(); } }
        private String _TENNL;
        public String TENNL { get => _TENNL; set { _TENNL = value; OnPropertyChanged(); } }
        private String _DVT;
        public String DVT { get => _DVT; set { _DVT = value; OnPropertyChanged(); } }
        private String _QUANTITY;
        public String QUANTITY { get => _QUANTITY; set { _QUANTITY = value; OnPropertyChanged(); } }
        private String _MSNCC;
        public String MSNCC { get => _MSNCC; set { _MSNCC = value; OnPropertyChanged(); } }
        private String _TENNCC;
        public String TENNCC { get => _TENNCC; set { _TENNCC = value; OnPropertyChanged(); } }
        private String _GIABAN;
        public String GIABAN { get => _GIABAN; set { _GIABAN = value; OnPropertyChanged(); } }

        // gan selected Item cho select NhanVien hien thi Nhan Vien
        private Inventory _SelectedItem;
        public Inventory SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    SelectedNguyenLieu = SelectedItem;
                    MSNL = SelectedItem.MSNL.ToString();
                    TENNL = SelectedItem.NGUYENLIEU.TENNL;
                    DVT = SelectedItem.NGUYENLIEU.DVT;
                    GIABAN = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", SelectedItem.NGUYENLIEU.GIABAN);
                    QUANTITY = SelectedItem.Quantity.ToString();
                    MSNCC = SelectedItem.NHACUNGCAP.MSNCC.ToString();
                    TENNCC = SelectedItem.NHACUNGCAP.TENNCC;
                }
            }
        }

        public TonKhoViewModel()
        {
            LoadedTonKhoWindowCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { LoadNhaCungCap(); LoadTonKho(); });

            OnKeyUpCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                try
                {
                    StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;
                    if (p != null && p.Text != "")
                    {
                        var listTemp = DataProvider.Ins.DB.NGUYENLIEUx;
                        TempTonKhoList.Clear();
                        foreach (var item in listTemp)
                        {
                            if (item.TENNL.StartsWith(p.Text, comparison))
                            {
                                foreach (var prop in FullTonKhoList)
                                {
                                    if (item.MSNL == prop.MSNL)
                                    {
                                        TempTonKhoList.Add(prop);
                                    }
                                }
                            }
                        }
                        if (TempTonKhoList != null)
                        {
                            TonKhoList = TempTonKhoList;
                        }
                    }
                    else
                    {
                        LoadTonKho();
                    }
                }
                catch 
                {
                    // bỏ qua lỗi null tham số
                }
            });

            NhaCungCapWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                NhaCungCap NCCForm = new NhaCungCap();
                NCCForm.ShowDialog();
            });

            AddCommand = new RelayCommand<Object>((p) => { return true; }, (p) =>
            {
                AddNguyenLieu();
            });

            DeleteCommand = new RelayCommand<Object>((p) =>
            { 
                if (string.IsNullOrEmpty(MSNL)) { return false; }
                if (string.IsNullOrEmpty(TENNL)) { return false; }
                if (string.IsNullOrEmpty(GIABAN)) { return false; }
                if (string.IsNullOrEmpty(DVT)) { return false; } 
                if (string.IsNullOrEmpty(TENNCC)) { return false; }

                int MSNguyenLieu = (int)Int32.Parse(MSNL);
                if (DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Where(i => i.MSNL == MSNguyenLieu).Count() > 0)
                {
                    return false;
                };

                if (DataProvider.Ins.DB.CHITIETPHIEUXUATs.Where(i => i.MSNL == MSNguyenLieu).Count() > 0)
                {
                    return false;
                };

                return true;
            }, (p) => { DeleteNguyenLieu(); });

            UpdateCommand = new RelayCommand<Object>((p) =>
            {

                if (string.IsNullOrEmpty(MSNL)) { return false; }
                if (string.IsNullOrEmpty(TENNL)) { return false; }
                if (string.IsNullOrEmpty(DVT)) { return false; }
                if (string.IsNullOrEmpty(GIABAN)) { return false; }
                if (string.IsNullOrEmpty(MSNCC)) { return false; }
                if (string.IsNullOrEmpty(TENNCC)) { return false; }
                
                return true;
            }, (p) => { UpdateNguyenLieu(); });

            RefreshCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { Refresh(); });

            LichSuNhapKhoWindowCommand = new RelayCommand<Object>((p) => { return true; }, (p) =>
            {
                LichSuNhapKho LichSuNKForm = new LichSuNhapKho();
                LichSuNKForm.ShowDialog();
            });

            LichSuXuatKhoWindowCommand = new RelayCommand<Object>((p) => { return true; }, (p) =>
            {
                LichSuXuatKho LichSuXKForm = new LichSuXuatKho();
                LichSuXKForm.ShowDialog();
            });

            QuanLyKhoWindowCommand = new RelayCommand<Object>((p) => { return true; }, (p) =>
            {
                QuanLyKho QuanLyKhoForm = new QuanLyKho();
                QuanLyKhoForm.ShowDialog();
            });

            XuatKhoWindowCommand = new RelayCommand<Object>((p) => { return true; }, (p) =>
            {
                XuatKho XuatKhoForm = new XuatKho();
                XuatKhoForm.ShowDialog();
                LoadTonKho();
            });

            NhapKhoWindowCommand = new RelayCommand<Object>((p) => { return true; }, (p) =>
            {
                NhapKho NhapKhoForm = new NhapKho();
                NhapKhoForm.ShowDialog();
                LoadTonKho();
            });

        }

        void AddNguyenLieu()
        {
            if (!ValidateNguyenLieu()) { return; }
            var findNhaCungCap = DataProvider.Ins.DB.NHACUNGCAPs.Where(i => i.TENNCC == SelectedNhaCungCap).SingleOrDefault();
            if (findNhaCungCap == null) return;
            var MSNCC = findNhaCungCap.MSNCC;
            var newNguyenLieu = new Model.NGUYENLIEU()
            {
                TENNL = TENNL,
                DVT = DVT,
                GIABAN = 0,
                MSNCC = MSNCC,
                ACTIVE = true,
            };
            if (MessageBox.Show("Thêm Nguyên Liệu Này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                newNguyenLieu =  DataProvider.Ins.DB.NGUYENLIEUx.Add(newNguyenLieu);
                var k = DataProvider.Ins.DB.SaveChanges();
                if (k == 1)
                { 
                    var item = DataProvider.Ins.DB.NGUYENLIEUx.Where(i => i.MSNL == newNguyenLieu.MSNL).SingleOrDefault();
                    if (item != null)
                    {
                        Inventory newInventory = new Inventory();
                        newInventory.NGUYENLIEU.MSNCC = item.MSNCC;
                        newInventory.NGUYENLIEU.TENNL = item.TENNL;
                        newInventory.NGUYENLIEU.ACTIVE = item.ACTIVE;
                        newInventory.NGUYENLIEU.DVT = item.DVT;
                        newInventory.NGUYENLIEU.GIABAN = item.GIABAN;
                        newInventory.NHACUNGCAP.MSNCC = findNhaCungCap.MSNCC;
                        newInventory.NHACUNGCAP.SDT = findNhaCungCap.SDT;
                        newInventory.NHACUNGCAP.EMAIL = findNhaCungCap.EMAIL;
                        newInventory.NHACUNGCAP.DIACHI = findNhaCungCap.DIACHI;
                        newInventory.NHACUNGCAP.MSNCC = findNhaCungCap.MSNCC;
                        newInventory.NHACUNGCAP.ACTIVE = findNhaCungCap.ACTIVE;
                        newInventory.Quantity = 0;
                        newInventory.MSNL = item.MSNL;

                        TonKhoList.Add(newInventory);
                    } 
                }

                MessageBox.Show("Thêm Nguyên Liệu Thành Công");
            }
            Refresh();
        }

        void DeleteNguyenLieu()
        {
            if (MessageBox.Show("Xoá Nguyên Liệu Này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                int MSNguyenLieu = (int)Int32.Parse(MSNL);
                var item = DataProvider.Ins.DB.NGUYENLIEUx.Where(i => i.MSNL == MSNguyenLieu).SingleOrDefault();
                if (item != null)
                {
                    DataProvider.Ins.DB.NGUYENLIEUx.Remove(item);
                    DataProvider.Ins.DB.SaveChanges();
                    TonKhoList.RemoveAt(TonKhoList.IndexOf(TonKhoList.Where(i => i.MSNL == (int)Int32.Parse(MSNL)).SingleOrDefault()));
                    Refresh();
                    MessageBox.Show("Xoá Nguyên Liệu Thành Công");
                }
            }
        }

        void UpdateNguyenLieu()
        {
            if (MessageBox.Show("Bạn Muốn Cập Nhật?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                int MSNguyenLieu = (int)Int32.Parse(MSNL);
                var item = DataProvider.Ins.DB.NGUYENLIEUx.Where(i => i.MSNL == MSNguyenLieu).SingleOrDefault();
                if (item != null)
                {
                    item.TENNL = TENNL;
                    item.DVT = DVT; 
                    item.MSNCC = (int)Int32.Parse(MSNCC);
                    var check = DataProvider.Ins.DB.SaveChanges();
                    if (check == 1)
                    {
                        int temp = (int)Int32.Parse(MSNCC);
                        SelectedItem.NGUYENLIEU.TENNL = TENNL;
                        SelectedItem.NGUYENLIEU.DVT = DVT;
                        SelectedItem.NHACUNGCAP = DataProvider.Ins.DB.NHACUNGCAPs.Where(i => i.MSNCC == temp).SingleOrDefault();

                        MessageBox.Show("Cập Nhật Nguyên Liệu Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Cập Nhật Nguyên Liệu Thất Bại");
                    }

                    Refresh();
                }
            }
        }

        void Refresh()
        {
            MSNL = "";
            TENNL = "";
            DVT = "";
            QUANTITY = "";
            MSNCC = "";
            TENNCC = "";
            GIABAN = "";
            SelectedNhaCungCap = null;
        }

        bool ValidateNguyenLieu()
        {
            if (string.IsNullOrEmpty(TENNL))
            {
                MessageBox.Show("Tên Nguyên Liệu không được để trống");
                return false;
            }
            if (IsNumeric(DVT))
            {
                MessageBox.Show("Bạn phải nhập chữ");
            }
            if (string.IsNullOrEmpty(DVT))
            {
                MessageBox.Show("Đơn vị tính không được để trống");
                return false;
            }
            if (string.IsNullOrEmpty(SelectedNhaCungCap))
            {
                MessageBox.Show("Nhà Cung Cấp không được để trống");
                return false;
            }
            return true;
        }


        void LoadNhaCungCap()
        {
            NhaCungCapList = new ObservableCollection<String>();
            var listNhaCunCap = DataProvider.Ins.DB.NHACUNGCAPs;
            foreach (var item in listNhaCunCap)
            {
                NhaCungCapList.Add(item.TENNCC);
            }
        }

        void LoadTonKho()
        {
            TonKhoList = new ObservableCollection<Inventory>();
            TempTonKhoList = new ObservableCollection<Inventory>();
            FullTonKhoList = new ObservableCollection<Inventory>();
            var listNguyenLieu = DataProvider.Ins.DB.NGUYENLIEUx;
            var listNhaCungCap = DataProvider.Ins.DB.NHACUNGCAPs;

            // Lay so luong nhap xuat cua moi Item Nguyen Lieu sau do gan vao Ton kho

            foreach (var item in listNguyenLieu)
            {
                if (item.GIABAN != 0)
                {
                    var listPhieuNhap = DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Where(p => p.MSNL == item.MSNL).ToList();

                    var listPhieuXuat = DataProvider.Ins.DB.CHITIETPHIEUXUATs.Where(p => p.MSNL == item.MSNL).ToList();


                    int soLuongNguyenLieuNhap = 0;
                    int giaTrungBinh = 0;
                    int giaCuoiCung = 0;
                    int giaCaoNhat = 0;
                    int giaThapNhat = 0;

                    int soLuongNguyenLieuXuat = 0;

                    if (listPhieuNhap != null && listPhieuNhap.Count() > 0)
                    {
                        soLuongNguyenLieuNhap = (int)listPhieuNhap.Sum(p => p.SOLUONG);
                        giaTrungBinh = (int)listPhieuNhap.Sum(p => p.DONGIA * p.SOLUONG) / soLuongNguyenLieuNhap;
                        giaCuoiCung = DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Where(p => p.MSNL == item.MSNL).ToList().OrderByDescending(o => o.MSPN).FirstOrDefault().DONGIA;
                        giaCaoNhat = listPhieuNhap.Max(i => i.DONGIA);
                        giaThapNhat = listPhieuNhap.Min(i => i.DONGIA);
                    }

                    if (listPhieuXuat != null && listPhieuXuat.Count() > 0)
                    {
                        soLuongNguyenLieuXuat = (int)listPhieuXuat.Sum(p => p.SOLUONG);
                    }

                    Inventory inventory = new Inventory();
                    inventory.MSNL = item.MSNL;
                    inventory.NGUYENLIEU.MSNCC = item.MSNCC;
                    inventory.NGUYENLIEU.TENNL = item.TENNL;
                    inventory.NGUYENLIEU.ACTIVE = item.ACTIVE;
                    inventory.NGUYENLIEU.DVT = item.DVT;
                    inventory.GIACAONHAT = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", giaCaoNhat);
                    inventory.GIATHAPNHAT = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", giaThapNhat);
                    inventory.GIATRUNGBINH = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", giaTrungBinh);
                    inventory.GIACUOICUNG = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", giaCuoiCung);
                    foreach (var itemNCC in listNhaCungCap)
                    {
                        if (itemNCC.MSNCC == item.MSNCC)
                        {
                            inventory.NHACUNGCAP = itemNCC;
                            break;
                        }
                    }
                    inventory.Quantity = soLuongNguyenLieuNhap - soLuongNguyenLieuXuat;
                    inventory.NGUYENLIEU.GIABAN = (int)giaTrungBinh;
                    var itemNL = DataProvider.Ins.DB.NGUYENLIEUx.Where(p => p.MSNL == item.MSNL).SingleOrDefault();
                    itemNL.GIABAN = (int)giaTrungBinh;
                    TonKhoList.Add(inventory);
                }
                else
                {
                    Inventory inventory = new Inventory();
                    inventory.MSNL = item.MSNL;
                    inventory.NGUYENLIEU.MSNCC = item.MSNCC;
                    inventory.NGUYENLIEU.TENNL = item.TENNL;
                    inventory.NGUYENLIEU.ACTIVE = item.ACTIVE;
                    inventory.NGUYENLIEU.DVT = item.DVT;
                    inventory.NGUYENLIEU.GIABAN = item.GIABAN;
                    foreach (var itemNCC in listNhaCungCap)
                    {
                        if (itemNCC.MSNCC == item.MSNCC)
                        {
                            inventory.NHACUNGCAP = itemNCC;
                            break;
                        }
                    }
                    inventory.Quantity = 0;

                    TonKhoList.Add(inventory);
                }
            }

            DataProvider.Ins.DB.SaveChanges();
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
