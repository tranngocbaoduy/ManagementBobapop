using QuanLyTraSua.DBConnection;
using QuanLyTraSua.Entity;
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
    public partial class BanHangViewModel : BaseViewModel
    {
        private Account _Account;
        public Account Account { get => _Account; set { _Account = value; OnPropertyChanged(); } }

        public ICommand LoadedMatHangWindowCommand { get; set; }
        public ICommand ChooseLMHWindowCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand PaymentCommand { get; set; }
        public ICommand OnKeyUpKhachHangCommand { get; set; }
        public ICommand OnKeyUpNguyenLieuCommand { get; set; }
        public ICommand LichSuXuatHoaDonCommand { get; set; }
        public ICommand PrintOrderCommand { get; set; }
        public ICommand PrintBillCommand { get; set; }

        private int _MaLoaiMH;
        public int MaLoaiMH { get => _MaLoaiMH; set { _MaLoaiMH = value; OnPropertyChanged(); } }

        private double _ThanhTienCommand = 0;
        public double ThanhTienCommand { get => _ThanhTienCommand; set { _ThanhTienCommand = value; OnPropertyChanged(); } }

        private int _GiamGiaCommand = 0;
        public int GiamGiaCommand { get => _GiamGiaCommand; set { _GiamGiaCommand = value; OnPropertyChanged(); } }

        private double _TongTienLastCommand = 0;
        public double TongTienLastCommand { get => _TongTienLastCommand; set { _TongTienLastCommand = value; OnPropertyChanged(); } }

        private double _TongTienCommand = 0;
        public double TongTienCommand { get => _TongTienCommand; set { _TongTienCommand = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _TenSuKienList;
        public ObservableCollection<String> TenSuKienList { get => _TenSuKienList; set { _TenSuKienList = value; OnPropertyChanged(); } }

        private String _SelectedItemSuKienKH = "";
        public String SelectedItemSuKienKH
        {
            get => _SelectedItemSuKienKH; set
            {
                _SelectedItemSuKienKH = value; OnPropertyChanged();
                if (SelectedItemSuKienKH != null)
                {
                    var itemSK = DataProvider.Ins.DB.SUKIENs.Where(i => i.TENSK == SelectedItemSuKienKH && i.ACTIVE == true).SingleOrDefault();
                    if (itemSK != null)
                    {
                        if (itemSK.MLSK == 2) // Sự kiện giảm theo tiền fix
                        {
                            GiamGiaEventCommand = ((int)Int32.Parse(itemSK.GIAMGIA));
                            GiamGiaEvent = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", (int)Int32.Parse(itemSK.GIAMGIA)); 

                            CalTongTien();
                        }
                        else if (itemSK.MLSK == 3) // Sự kiện giảm theo %
                        {
                            GiamGiaEventCommand = ((int)Int32.Parse(itemSK.GIAMGIA));
                            GiamGiaEvent = itemSK.GIAMGIA + " %";
                            CalTongTien();
                        }
                        else
                        {
                            GiamGiaEvent = "";
                            GiamGiaEventCommand = 0;
                        }
                    }
                    else
                    {
                        GiamGiaEvent = "";
                    }
                    CalTongTien();
                }
            }
        }
        private int _GiamGiaEventCommand = 0;
        public int GiamGiaEventCommand { get => _GiamGiaEventCommand; set { _GiamGiaEventCommand = value; OnPropertyChanged(); } }

        private String _GiamGiaEvent = "";
        public String GiamGiaEvent { get => _GiamGiaEvent; set { _GiamGiaEvent = value; OnPropertyChanged(); } }

        // Display Price Window
        private String _Note = "";
        public String Note { get => _Note; set { _Note = value; OnPropertyChanged(); } }

        private String _ThanhTien = "0";
        public String ThanhTien { get => _ThanhTien; set { _ThanhTien = value; OnPropertyChanged(); } }

        private String _GiamGia = "0";
        public String GiamGia { get => _GiamGia; set { _GiamGia = value; OnPropertyChanged(); } }

        private String _PhiDichVu = "0";
        public String PhiDichVu { get => _PhiDichVu; set { _PhiDichVu = value; OnPropertyChanged(); } }

        private String _ThueVat = "0";
        public String ThueVat { get => _ThueVat; set { _ThueVat = value; OnPropertyChanged(); } }

        private String _TongTien = "0";
        public String TongTien { get => _TongTien; set { _TongTien = value; OnPropertyChanged(); } }

        private Model.MATHANG _SelectedItem;
        public Model.MATHANG SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }

        // Selected mat hang trong danh sach DB 
        public Product SelectedMatHangInCart { get; set; }

        private String _IndexSelected;
        public String IndexSelected
        {
            get => _IndexSelected; set
            {
                SelectedMatHangInCart = new Product();
                _IndexSelected = value; OnPropertyChanged();
                if (IndexSelected != null && (int)Int32.Parse(IndexSelected) > -1)
                {
                    var item = MatHangInCart.ElementAt((int)Int32.Parse(IndexSelected));
                    SelectedMatHangInCart.Quantity = item.Quantity;
                    SelectedMatHangInCart.Price = item.Price;
                    var matHang = DataProvider.Ins.DB.MATHANGs.Where(i => i.MSMH == item.MatHang.MSMH).SingleOrDefault();
                    SelectedMatHangInCart.MatHang = matHang;
                }
            }
        }

        // Load loai MH len
        private ObservableCollection<Model.LOAIMATHANG> _LoadLMHCommand;
        public ObservableCollection<Model.LOAIMATHANG> LoadLMHCommand { get => _LoadLMHCommand; set { _LoadLMHCommand = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.MATHANG> _MatHangList;
        public ObservableCollection<Model.MATHANG> MatHangList { get => _MatHangList; set { _MatHangList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.MATHANG> _TempMatHangList;
        public ObservableCollection<Model.MATHANG> TempMatHangList { get => _TempMatHangList; set { _TempMatHangList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.MATHANG> _FullMatHangList;
        public ObservableCollection<Model.MATHANG> FullMatHangList { get => _FullMatHangList; set { _FullMatHangList = value; OnPropertyChanged(); } }

        private ObservableCollection<Product> _MatHangInCart;
        public ObservableCollection<Product> MatHangInCart { get => _MatHangInCart; set { _MatHangInCart = value; OnPropertyChanged(); } }

        private String _SelectedNhanVien { get; set; }
        public String SelectedNhanVien { get => _SelectedNhanVien; set { _SelectedNhanVien = value; OnPropertyChanged(); } }

        private String _SDTKH { get; set; }
        public String SDTKH { get => _SDTKH; set { _SDTKH = value; OnPropertyChanged(); } }

        private String _TENKH { get; set; }
        public String TENKH { get => _TENKH; set { _TENKH = value; OnPropertyChanged(); } }

        private String _DIEMTT { get; set; }
        public String DIEMTT { get => _DIEMTT; set { _DIEMTT = value; OnPropertyChanged(); } }

        private DateTime _NgayNhap { get; set; }
        public DateTime NgayNhap { get => _NgayNhap; set { _NgayNhap = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _NhanVienList;
        public ObservableCollection<String> NhanVienList { get => _NhanVienList; set { _NhanVienList = value; OnPropertyChanged(); } }

        private String _SelectedStyleCustomer { get; set; }
        public String SelectedStyleCustomer { get => _SelectedStyleCustomer; set { _SelectedStyleCustomer = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _StyleCustomerList;
        public ObservableCollection<String> StyleCustomerList { get => _StyleCustomerList; set { _StyleCustomerList = value; OnPropertyChanged(); } }

        public BanHangViewModel()
        {
            LoadLMHCommand = new ObservableCollection<Model.LOAIMATHANG>();
            MatHangList = new ObservableCollection<Model.MATHANG>();
            TempMatHangList = new ObservableCollection<Model.MATHANG>();
            FullMatHangList = new ObservableCollection<Model.MATHANG>();
            MatHangInCart = new ObservableCollection<Product>();

            NgayNhap = DateTime.Today;

            LoadedMatHangWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    LoadLoaiMatHang();
                    LoadTenSuKien();
                    LoadMatHang();
                }
            });

            OnKeyUpKhachHangCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if (SelectedStyleCustomer != "Tạo Mới KH")
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
                            foreach (var item in listTemp)
                            {
                                if (item.SDT.StartsWith(p.Text, comparison))
                                {
                                    SDTKH = p.Text;
                                    TENKH = item.TENKH;
                                    DIEMTT = item.DIEMTT.ToString();
                                    SelectedStyleCustomer = StyleCustomerList[1];
                                    int diemTT = (int)Int32.Parse(DIEMTT);
                                    if (diemTT > 100 && diemTT <= 1000)
                                    {
                                        GiamGiaCommand = 5;
                                    }
                                    else if (diemTT > 1000 && diemTT <= 5000)
                                    {
                                        GiamGiaCommand = 10;
                                    }
                                    else if (diemTT > 5000 && diemTT <= 10000)
                                    {
                                        GiamGiaCommand = 12;
                                    }
                                    else if (diemTT > 10000 && diemTT <= 100000)
                                    {
                                        GiamGiaCommand = 15;
                                    }
                                    else if (diemTT > 100000)
                                    {
                                        GiamGiaCommand = 17;
                                    }
                                    else
                                    {
                                        GiamGiaCommand = 0;
                                    }
                                    GiamGia = GiamGiaCommand + " %";
                                    CalTongTien();
                                    break;
                                }
                                else
                                {
                                    SelectedStyleCustomer = StyleCustomerList[0];
                                    TENKH = "";
                                    DIEMTT = "";
                                    GiamGiaCommand = 0;
                                    CalTongTien();
                                    GiamGia = GiamGiaCommand.ToString();
                                }
                            }

                        }
                        else
                        {
                            SelectedStyleCustomer = StyleCustomerList[0];
                            TENKH = "";
                            DIEMTT = "";
                            GiamGiaCommand = 0;
                            CalTongTien();
                            GiamGia = GiamGiaCommand.ToString();
                        }
                    }
                    catch  
                    {
                        // bỏ qua lỗi null tham số
                    }
                }
                else
                {
                    SDTKH = p.Text;
                    TENKH = "";
                    DIEMTT = "";
                    if (p != null && p.Text != "")
                    {
                        if (!IsNumeric(p.Text))
                        {
                            MessageBox.Show("Bạn phải nhập số"); p.Text = "";
                        }
                    }
                    SelectedStyleCustomer = StyleCustomerList[0];
                    CalTongTien();
                }
            });

            OnKeyUpNguyenLieuCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                try
                {
                    StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;
                    if (p != null && p.Text != "")
                    {
                        var listTemp = DataProvider.Ins.DB.MATHANGs;
                        TempMatHangList.Clear();
                        foreach (var item in listTemp)
                        {
                            if (item.TENMH.StartsWith(p.Text, comparison))
                            {
                                foreach (var prop in FullMatHangList)
                                {
                                    if (item.MSMH == prop.MSMH)
                                    {
                                        TempMatHangList.Add(prop);
                                    }
                                }
                            }
                        }
                        if (TempMatHangList != null)
                        {
                            MatHangList = TempMatHangList;
                        }
                    }
                    else
                    {
                        LoadMatHang();
                    }
                }
                catch  
                {
                    // bỏ qua lỗi null tham số
                }
            });

            ChooseLMHWindowCommand = new RelayCommand<Object>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    MatHangList.Clear();
                    var listMHInDB = DataProvider.Ins.DB.MATHANGs.Where(item => item.MSLMH.ToString() == p.ToString());
                    foreach (var item in listMHInDB)
                    {
                        MatHangList.Add(item);
                    }
                }
            });

            AddCommand = new RelayCommand<Object>((p) => { return true; }, (p) =>
            {
                AddMatHangInCart();
            });

            DeleteCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { DeleteMatHangInCart(); });

            RefreshCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { RefreshMatHangInCart(); });

            PaymentCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { ThanhToanHoaDon(); });

            PrintBillCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { MessageBox.Show("Vui lòng kết nối với máy in"); });

            PrintOrderCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { MessageBox.Show("Vui lòng kết nối với máy in"); });

            LichSuXuatHoaDonCommand = new RelayCommand<Object>((p) => { return true; }, (p) =>
            {
                LichSuXuatHoaDon LichSuXuatHDForm = new LichSuXuatHoaDon();
                LichSuXuatHDForm.ShowDialog();
            });
        }

        void LoadTenSuKien()
        {
            TenSuKienList = new ObservableCollection<String>();

            var listSuKien = DataProvider.Ins.DB.SUKIENs;
            TenSuKienList.Add("");
            foreach (var item in listSuKien)
            {
                if (item.ACTIVE == true && item.MLSK != 1)
                {
                    TenSuKienList.Add(item.TENSK);
                }
            }
        }

        void AddMatHangInCart()
        {
            if (SelectedItem != null)
            {
                if (MatHangInCart.Where(i => i.MatHang.MSMH == SelectedItem.MSMH).Count() == 1)
                {
                    var item = MatHangInCart.Where(i => i.MatHang.MSMH == SelectedItem.MSMH).SingleOrDefault();
                    item.Quantity++;
                }
                else
                {
                    Product temp = new Product();
                    temp.MatHang = SelectedItem;
                    temp.Quantity = 1;
                    MatHangInCart.Add(temp);
                }
                ThanhTienCommand = 0;
                foreach (var item in MatHangInCart)
                {
                    item.Price = item.Quantity * item.MatHang.GIABAN;
                    ThanhTienCommand += item.Price;
                }
                ThanhTien = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", ThanhTienCommand);
                ThueVat = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", (ThanhTienCommand * 10 / 100));
                TongTienCommand = (ThanhTienCommand + (ThanhTienCommand * 10 / 100));
                CalTongTien();
            }
        }

        void DeleteMatHangInCart()
        {
            if (SelectedMatHangInCart != null && MatHangInCart != null)
            {
                MatHangInCart.Remove(MatHangInCart.ElementAt((int)Int32.Parse(IndexSelected)));
                ThanhTienCommand = 0;
                foreach (var item in MatHangInCart)
                {
                    item.Price = item.Quantity * item.MatHang.GIABAN;
                    ThanhTienCommand += item.Price;
                }
                ThanhTien = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", ThanhTienCommand);
                ThueVat =  String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", (ThanhTienCommand * 10 / 100));
                TongTienCommand = (ThanhTienCommand + (ThanhTienCommand * 10 / 100));
                CalTongTien();
            }
            SelectedMatHangInCart = new Product();
        }

        void RefreshMatHangInCart()
        {
            SDTKH = "";
            TENKH = "";
            DIEMTT = "";
            NgayNhap = DateTime.Today;
            SelectedItemSuKienKH = TenSuKienList[0];
            GiamGiaEvent = "";
            SelectedStyleCustomer = StyleCustomerList.First();
            ThanhTienCommand = 0;
            TongTienCommand = 0;
            ThueVat = "";
            GiamGiaCommand = 0;
            GiamGia = GiamGiaCommand.ToString();
            TongTien = TongTienCommand.ToString("C0");
            ThanhTien = ThanhTienCommand.ToString("C0");
            if (MatHangInCart != null)
            {
                MatHangInCart.Clear();
            }
            SelectedNhanVien = NhanVienList[0];
            SelectedMatHangInCart = new Product();
        }

        void LoadLoaiMatHang()
        {
            LoadLMHCommand = new ObservableCollection<Model.LOAIMATHANG>();
            var listLoaiMHInDB = DataProvider.Ins.DB.LOAIMATHANGs;
            foreach (var item in listLoaiMHInDB)
            {
                LoadLMHCommand.Add(item);
            }
        }

        void LoadMatHang()
        {
            MatHangList = new ObservableCollection<Model.MATHANG>();
            NhanVienList = new ObservableCollection<string>();
            StyleCustomerList = new ObservableCollection<string>();

            NhanVienList.Add("");
            StyleCustomerList.Add("KH Vãng Lai");
            SelectedStyleCustomer = StyleCustomerList.First();
            StyleCustomerList.Add("KH Thân Thiết");
            StyleCustomerList.Add("Tạo Mới KH");

            var listNhanVien = DataProvider.Ins.DB.NHANVIENs.Where(i => i.CHUCVU == "Thu Ngân");
            var listMHInDB = DataProvider.Ins.DB.MATHANGs;

            foreach (var item in listMHInDB)
            {
                MatHangList.Add(item);
                TempMatHangList.Add(item);
                FullMatHangList.Add(item);
            }

            foreach (var item in listNhanVien)
            {
                NhanVienList.Add(item.TENNV);
            }
        }

        void CalTongTien()
        {
            if (TongTienCommand != 0)
            {
                var itemSK = DataProvider.Ins.DB.SUKIENs.Where(i => i.TENSK == SelectedItemSuKienKH && i.ACTIVE == true).SingleOrDefault();
                if (itemSK != null)
                {
                    if (itemSK.MLSK == 2) // Sự kiện giảm theo tiền fix
                    {
                        TongTien =  String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", (TongTienCommand - (TongTienCommand * GiamGiaCommand / 100) - GiamGiaEventCommand));
                        
                    }
                    else if (itemSK.MLSK == 3) // Sự kiện giảm theo %
                    {
                        TongTien = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", (TongTienCommand - (TongTienCommand * GiamGiaCommand / 100) - (TongTienCommand * GiamGiaEventCommand / 100)));
                    }
                }
                else
                { 
                    TongTien = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", (TongTienCommand - (TongTienCommand * GiamGiaCommand / 100)));

                }
            }
        }

        bool CheckHoaDon()
        {
            if (string.IsNullOrEmpty(SelectedNhanVien)) { MessageBox.Show("Chưa chọn nhân viên"); return false; }
            if (string.IsNullOrEmpty(SelectedStyleCustomer)) { MessageBox.Show("Chưa chọn loại KH"); return false; }
            if (DateTime.Compare(NgayNhap, DateTime.Today) != 0)
            {
                MessageBox.Show("Ngày lập hoá đơn không đúng");
                return false;
            }
            if (SelectedStyleCustomer == "KH Thân Thiết")
            {
                if (string.IsNullOrEmpty(SDTKH)) { MessageBox.Show("Số ĐT KH phải có dạng [0-9]*11"); return false; }
                if (string.IsNullOrEmpty(TENKH)) { MessageBox.Show("Tên KH không đúng"); return false; }
                var item = DataProvider.Ins.DB.KHACHHANGs.Where(i => i.SDT == SDTKH).SingleOrDefault();
                if (item == null || item.SDT != SDTKH) { MessageBox.Show("Số ĐT KH không đúng"); return false; }
            }
            if (SelectedStyleCustomer == "Tạo Mới KH")
            {
                if (string.IsNullOrEmpty(SDTKH)) { MessageBox.Show("Số ĐT KH phải có dạng [0-9]*11"); return false; }
                if (string.IsNullOrEmpty(TENKH)) { MessageBox.Show("Tên KH không đúng"); return false; }
                var item = DataProvider.Ins.DB.KHACHHANGs.Where(i => i.SDT == SDTKH).SingleOrDefault();
                if (item != null) { MessageBox.Show("Số ĐT KH đã tồn tại"); return false; }
            }
            if (MatHangInCart.Count() <= 0) { MessageBox.Show("Chưa chọn mặt hàng"); return false; }
            return true;
        }

        double CalTongTenLastTime()
        {
            if (TongTienCommand != 0)
            {
                var itemSK = DataProvider.Ins.DB.SUKIENs.Where(i => i.TENSK == SelectedItemSuKienKH && i.ACTIVE == true).SingleOrDefault();
                if (itemSK != null)
                {
                    if (itemSK.MLSK == 2) // Sự kiện giảm theo tiền fix
                    {
                        TongTienLastCommand = (TongTienCommand - (TongTienCommand * GiamGiaCommand / 100) - GiamGiaEventCommand);
                    }
                    else if (itemSK.MLSK == 3) // Sự kiện giảm theo %
                    {
                        TongTienLastCommand = (TongTienCommand - (TongTienCommand * GiamGiaCommand / 100) - (TongTienCommand * GiamGiaEventCommand / 100));
                    }
                }
                else
                {
                    TongTienLastCommand = (TongTienCommand - (TongTienCommand * GiamGiaCommand / 100));
                }
            }
            return TongTienLastCommand;
        }

        void ThanhToanHoaDon()
        { 
            if (MessageBox.Show("Thanh Toán?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                if (!CheckHoaDon()) { return; }
                double lastTongTien = CalTongTenLastTime();

                Model.HOADON newHoaDon = new Model.HOADON();
                newHoaDon.TONGTIEN = (int)TongTienCommand;
                newHoaDon.GIAMGIA = GiamGiaCommand.ToString();
                newHoaDon.NGAYXUAT = DateTime.Now;
                if (String.IsNullOrEmpty(Note)) { newHoaDon.NOTE = ""; } else { newHoaDon.NOTE = Note; }
                newHoaDon.MSNV = DataProvider.Ins.DB.NHANVIENs.Where(i => i.TENNV == SelectedNhanVien).SingleOrDefault().MSNV;
                if (SelectedStyleCustomer == "KH Thân Thiết")
                {
                    newHoaDon.SDT = SDTKH;
                    var itemKH = DataProvider.Ins.DB.KHACHHANGs.Where(i => i.SDT == SDTKH).SingleOrDefault();
                    if (itemKH == null) { MessageBox.Show("Không tồn tại KH Thân thiết. Vui lòng liền hệ với người lập trình để nhanh chóng fix lỗi"); return; }
                    itemKH.DIEMTT += (int)lastTongTien / 100;
                }
                else if (SelectedStyleCustomer == "Tạo Mới KH")
                {
                    newHoaDon.SDT = SDTKH;
                    Model.KHACHHANG newKH = new Model.KHACHHANG();
                    newKH.SDT = SDTKH;
                    newKH.TENKH = TENKH;
                    newKH.ACTIVE = true;
                    newKH.DIEMTT += (int)lastTongTien / 100;
                    newKH = DataProvider.Ins.DB.KHACHHANGs.Add(newKH);
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Tạo KH Thành Công");
                }
                else
                {
                    //Khách hàng vãng lai
                    newHoaDon.SDT = "01234567891";
                }
                newHoaDon.ACTIVE = true;
                newHoaDon = DataProvider.Ins.DB.HOADONs.Add(newHoaDon);
                DataProvider.Ins.DB.SaveChanges();

                // check su kien
                if (SelectedItemSuKienKH != null)
                {
                    var itemSK = DataProvider.Ins.DB.SUKIENs.Where(i => i.TENSK == SelectedItemSuKienKH && i.ACTIVE == true).SingleOrDefault();
                    if (itemSK != null)
                    {
                        Model.HOADONSUKIEN newHoaDonSuKien = new Model.HOADONSUKIEN();
                        newHoaDonSuKien.MASK = itemSK.MASK;
                        newHoaDonSuKien.MSHD = newHoaDon.MSHD;
                        newHoaDonSuKien.GIAMGIA = itemSK.GIAMGIA;
                        newHoaDonSuKien.MLSK = itemSK.MLSK;

                        DataProvider.Ins.DB.HOADONSUKIENs.Add(newHoaDonSuKien);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                }

                foreach (var item in MatHangInCart)
                {
                    Model.CHITIETHOADON newChiTietHoaDon = new Model.CHITIETHOADON();
                    newChiTietHoaDon.MSHD = newHoaDon.MSHD;
                    newChiTietHoaDon.MSMH = item.MatHang.MSMH;
                    newChiTietHoaDon.SOLUONG = item.Quantity;
                    newChiTietHoaDon.DONGIA = item.MatHang.GIABAN;
                    newChiTietHoaDon = DataProvider.Ins.DB.CHITIETHOADONs.Add(newChiTietHoaDon);
                    DataProvider.Ins.DB.SaveChanges();
                }
                MessageBox.Show("Thêm Hoá Đơn Thành Công");
                RefreshMatHangInCart();
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
