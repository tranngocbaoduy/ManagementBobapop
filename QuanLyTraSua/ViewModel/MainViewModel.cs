using QuanLyTraSua.DBConnection;
using QuanLyTraSua.Entity;
using QuanLyTraSua.Model;
using QuanLyTraSua.ViewModel;
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
    public class MainViewModel : BaseViewModel
    {
        private static Account _Account { get; set; }
        public Account Account { get => _Account; set { _Account = value; OnPropertyChanged(); } }

        public bool IsLoaded = false;
        public ICommand LoadedWindowCommand { get; set; }

        #region commands
        public ICommand NhanVienWindowCommand { get; set; }
        public ICommand TonKhoWindowCommand { get; set; }
        public ICommand NhapKhoWindowCommand { get; set; }
        public ICommand NhaCungCapWindowCommand { get; set; }
        public ICommand BanHangWindowCommand { get; set; }
        public ICommand KhachHangWindowCommand { get; set; }
        public ICommand CheckinNhanVienWindowCommand { get; set; }
        public ICommand ThuChiLoiNhuanWindowCommand { get; set; }
        public ICommand QuanLySanPhanWindowCommand { get; set; }
        public ICommand ThietLapWindowCommand { get; set; }
        public ICommand ThongKeWindowCommand { get; set; }
        #endregion

        private List<SPHienHanh> _listSPHienHanh { get; set; }
        public List<SPHienHanh> listSPHienHanh { get => _listSPHienHanh; set { _listSPHienHanh = value; OnPropertyChanged(); } }

        private String _SOSPBAN;
        public String SOSPBAN { get => _SOSPBAN; set { _SOSPBAN = value; OnPropertyChanged(); } }

        private String _SODONBAN;
        public String SODONBAN { get => _SODONBAN; set { _SODONBAN = value; OnPropertyChanged(); } }

        private String _TIENTRAHANG;
        public String TIENTRAHANG { get => _TIENTRAHANG; set { _TIENTRAHANG = value; OnPropertyChanged(); } }

        private String _TIENBANHANG;
        public String TIENBANHANG { get => _TIENBANHANG; set { _TIENBANHANG = value; OnPropertyChanged(); } }

        private String _TIENBANHANGYESTERDAY;
        public String TIENBANHANGYESTERDAY { get => _TIENBANHANGYESTERDAY; set { _TIENBANHANGYESTERDAY = value; OnPropertyChanged(); } }

        private String _SOSPTONKHO;
        public String SOSPTONKHO { get => _SOSPTONKHO; set { _SOSPTONKHO = value; OnPropertyChanged(); } }

        private String _SOSPHETHANG;
        public String SOSPHETHANG { get => _SOSPHETHANG; set { _SOSPHETHANG = value; OnPropertyChanged(); } }

        private String _SOSPSAPHET;
        public String SOSPSAPHET { get => _SOSPSAPHET; set { _SOSPSAPHET = value; OnPropertyChanged(); } }

        private String _SODONBANTEXT;
        public String SODONBANTEXT { get => _SODONBANTEXT; set { _SODONBANTEXT = value; OnPropertyChanged(); } }

        private String _SOSPTEXT;
        public String SOSPTEXT { get => _SOSPTEXT; set { _SOSPTEXT = value; OnPropertyChanged(); } }

        private String _SOSPTONKHOTEXT;
        public String SOSPTONKHOTEXT { get => _SOSPTONKHOTEXT; set { _SOSPTONKHOTEXT = value; OnPropertyChanged(); } }

        private String _SOSPSAPHETTEXT;
        public String SOSPSAPHETTEXT { get => _SOSPSAPHETTEXT; set { _SOSPSAPHETTEXT = value; OnPropertyChanged(); } }

        private String _SOSPHIENHANH;
        public String SOSPHIENHANH { get => _SOSPHIENHANH; set { _SOSPHIENHANH = value; OnPropertyChanged(); } }

        private String _SOSPBANCHAY;
        public String SOSPBANCHAY { get => _SOSPBANCHAY; set { _SOSPBANCHAY = value; OnPropertyChanged(); } }

        private String _SPDANGHOT;
        public String SPDANGHOT { get => _SPDANGHOT; set { _SPDANGHOT = value; OnPropertyChanged(); } }

        public class SPHienHanh
        {
            public int MaSP;
            public String TenSP;
            public int SoLuong;
        }

        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                // Show form login when start program
                if (p != null)
                {
                    IsLoaded = true;
                    p.Hide();
                    Login loginForm = new Login();
                    loginForm.ShowDialog();


                    if (loginForm.DataContext == null)
                    {
                        return;
                    }

                    // get value IsLogin of LoginViewModel check IsLogin ?? 
                    var loginVM = loginForm.DataContext as LoginViewModel;
                    if (loginVM.IsLogin)
                    {
                        Account = loginVM.Account;
                        p.Show();
                        LoadStat();
                        LoadStatYesterday();
                        LoadStatTonKho();
                        LoadSP();
                    }
                    else
                    {
                        p.Close();
                    }

                }
            });

            NhanVienWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    var itemNV = DataProvider.Ins.DB.NHANVIENs.Where(i => i.USERNAME == Account.UserName).SingleOrDefault();
                    if (Account.UserName == "admin" || (itemNV != null && itemNV.CHUCVU == "Quản Lý"))
                    {
                        p.Hide();
                        NhanVien NhanVienForm = new NhanVien();
                        NhanVienForm.ShowDialog();
                        p.Show();
                    }
                    else
                    {
                        MessageBox.Show("Chỉ quản lý mới có thể vào");
                    }
                }
            });

            CheckinNhanVienWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    p.Hide();
                    BangGioCongNhanVien BangGioForm = new BangGioCongNhanVien();
                    BangGioForm.ShowDialog();
                    p.Show();
                }
            });

            TonKhoWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    var itemNV = DataProvider.Ins.DB.NHANVIENs.Where(i => i.USERNAME == Account.UserName).SingleOrDefault();
                    if (Account.UserName == "admin" || (itemNV != null && (itemNV.CHUCVU == "Nhân Viên Kho" || itemNV.CHUCVU == "Quản Lý")))
                    {
                        p.Hide();
                        TonKho TKForm = new TonKho();
                        TKForm.ShowDialog();
                        LoadStat(); LoadStatTonKho();
                        p.Show();
                    }
                    else
                    {
                        MessageBox.Show("Chỉ quản lý hoặc nhân viên kho mới có thể vào");
                    }

                }
            });

            NhaCungCapWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    p.Hide();
                    NhaCungCap NCCForm = new NhaCungCap();
                    NCCForm.ShowDialog();
                    p.Show();
                }
            });

            BanHangWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    p.Hide();
                    BanHang BHForm = new BanHang();
                    BHForm.ShowDialog(); LoadStat();
                    LoadStatTonKho();
                    LoadSP();
                    p.Show();
                }
            });

            KhachHangWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    p.Hide();
                    KhachHang KHForm = new KhachHang();
                    KHForm.ShowDialog();
                    p.Show();
                }
            });

            ThuChiLoiNhuanWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    MessageBox.Show("Chức Năng Đang Được Xây Dựng");
                }
            });

            ThietLapWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    MessageBox.Show("Chức Năng Đang Được Xây Dựng");
                }
            });

            ThongKeWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    p.Hide();
                    ThongKe ThongKeForm = new ThongKe();
                    ThongKeForm.ShowDialog();
                    p.Show();
                }
            });

            QuanLySanPhanWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    //MessageBox.Show("Chức Năng Đang Được Xây Dựng");
                    var itemNV = DataProvider.Ins.DB.NHANVIENs.Where(i => i.USERNAME == Account.UserName).SingleOrDefault();
                    if (Account.UserName == "admin" || (itemNV != null && itemNV.CHUCVU == "Quản Lý"))
                    {
                        p.Hide();
                        QuanLySanPham QuanLySPForm = new QuanLySanPham();
                        QuanLySPForm.ShowDialog();
                        p.Show();
                    }
                    else
                    {
                        MessageBox.Show("Chỉ quản lý mới có thể vào"); 
                    }
                }
            });
        }

        void LoadStatTonKho()
        {
            int soSPTonKho = 0;
            int soSPHetHang = 0;
            int soSPSapHet = 0;

            var listNguyenLieu = DataProvider.Ins.DB.NGUYENLIEUx;


            foreach (var itemNL in listNguyenLieu)
            {
                soSPTonKho++;
                var listPhieuNhap = DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Where(i => i.MSNL == itemNL.MSNL);
                var listPhieuXuat = DataProvider.Ins.DB.CHITIETPHIEUXUATs.Where(i => i.MSNL == itemNL.MSNL);

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

                if (soLuongNguyenLieuNhap - soLuongNguyenLieuXuat == 0)
                {
                    soSPHetHang++;
                }
                else if (soLuongNguyenLieuNhap - soLuongNguyenLieuXuat <= 10)
                {
                    soSPSapHet++;
                }
            }

            SOSPHETHANG = soSPHetHang.ToString();
            SOSPSAPHET = soSPSapHet.ToString();
            SOSPTONKHO = soSPTonKho.ToString();

            SOSPTONKHOTEXT = "Số NL Tồn: " + soSPTonKho.ToString();
            SOSPSAPHETTEXT = "Sắp Hết: " + soSPSapHet.ToString();
        }

        void LoadSP()
        {
            SPDANGHOT = "";
            SOSPHIENHANH = "";
            SOSPBANCHAY = "";

            listSPHienHanh = new List<SPHienHanh>();

            var listHoaDon = DataProvider.Ins.DB.HOADONs.Where(i => i.NGAYXUAT.Month == DateTime.Today.Month && i.NGAYXUAT.Year == DateTime.Today.Year);
            foreach (var item in listHoaDon)
            {
                var listChiTietHoaDon = DataProvider.Ins.DB.CHITIETHOADONs.Where(i => i.MSHD == item.MSHD);
                foreach (var itemCT in listChiTietHoaDon)
                {
                    var itemMH = DataProvider.Ins.DB.MATHANGs.Where(i => i.MSMH == itemCT.MSMH).SingleOrDefault();

                    if (listSPHienHanh.Where(i => i.MaSP == itemCT.MSMH).Count() == 0) // chưa tồn tại
                    {
                        SPHienHanh newSP = new SPHienHanh();
                        newSP.MaSP = itemMH.MSMH;
                        newSP.TenSP = itemMH.TENMH;
                        newSP.SoLuong = itemCT.SOLUONG;

                        listSPHienHanh.Add(newSP);
                    }
                    else // đã tồn tại
                    {
                        var itemSPHienHanh = listSPHienHanh.Where(i => i.MaSP == itemCT.MSMH).SingleOrDefault();
                        itemSPHienHanh.SoLuong += itemCT.SOLUONG;
                    }

                }
            }

            int maxSoLuong = int.MinValue;
            int maxMSMH = int.MinValue;
            foreach (var item in listSPHienHanh)
            {
                if (item.SoLuong > maxSoLuong)
                {
                    maxMSMH = item.MaSP;
                    maxSoLuong = item.SoLuong;
                }
            }

            int spBanChayCount = 1;
            foreach (var item in listSPHienHanh)
            {
                if (item.SoLuong >= maxSoLuong - (maxSoLuong * 20 / 100))
                {
                    spBanChayCount++;
                }
            }
            SOSPBANCHAY = spBanChayCount.ToString();

            var itemSPHot = listSPHienHanh.Where(i => i.MaSP == maxMSMH).SingleOrDefault();
            if (itemSPHot != null)
            {
                SPDANGHOT = itemSPHot.TenSP;
            }

            SOSPHIENHANH = DataProvider.Ins.DB.MATHANGs.Count().ToString();
        }

        void LoadStat()
        {
            int tienBanHang = 0;
            int soDonHang = 0;
            int soSP = 0;
            int tienTraHang = 0;

            var listHoaDon = DataProvider.Ins.DB.HOADONs.Where(i => i.NGAYXUAT.Day == DateTime.Today.Day && i.NGAYXUAT.Month == DateTime.Today.Month && i.NGAYXUAT.Year == DateTime.Today.Year);
            foreach (var item in listHoaDon)
            {
                soDonHang++;
                tienBanHang += item.TONGTIEN;
                var listChiTietHoaDon = DataProvider.Ins.DB.CHITIETHOADONs.Where(i => i.MSHD == item.MSHD);
                foreach (var itemCT in listChiTietHoaDon)
                {
                    soSP = soSP + itemCT.SOLUONG;
                }
            }

            var listPhieuNhap = DataProvider.Ins.DB.PHIEUNHAPs.Where(i => i.NGAYNHAP.Day == DateTime.Today.Day && i.NGAYNHAP.Month == DateTime.Today.Month && i.NGAYNHAP.Year == DateTime.Today.Year);
            foreach (var item in listPhieuNhap)
            {
                tienTraHang += item.TONGTIEN;
            }

            SOSPBAN = soSP.ToString();
            SODONBAN = soDonHang.ToString();
            TIENBANHANG = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", tienBanHang);
            TIENTRAHANG = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", tienTraHang);
        }

        void LoadStatYesterday()
        {
            int tienBanHang = 0;
            int soDonHang = 0;
            int soSP = 0;
            int tienTraHang = 0;

            var listHoaDon = DataProvider.Ins.DB.HOADONs.Where(i => i.NGAYXUAT.Day == DateTime.Today.Day - 1 && i.NGAYXUAT.Month == DateTime.Today.Month && i.NGAYXUAT.Year == DateTime.Today.Year);
            foreach (var item in listHoaDon)
            {
                soDonHang++;
                tienBanHang += item.TONGTIEN;
                var listChiTietHoaDon = DataProvider.Ins.DB.CHITIETHOADONs.Where(i => i.MSHD == item.MSHD);
                foreach (var itemCT in listChiTietHoaDon)
                {
                    soSP = soSP + itemCT.SOLUONG;
                }
            }

            var listPhieuNhap = DataProvider.Ins.DB.PHIEUNHAPs.Where(i => i.NGAYNHAP.Day == DateTime.Today.Day && i.NGAYNHAP.Month == DateTime.Today.Month && i.NGAYNHAP.Year == DateTime.Today.Year);
            foreach (var item in listPhieuNhap)
            {
                tienTraHang += item.TONGTIEN;
            }
            TIENBANHANGYESTERDAY = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", tienBanHang);
            SOSPTEXT = "Số SP Bán: " + soSP.ToString();
            SODONBANTEXT = "Số Đơn Bán: " + soDonHang.ToString();
        }
    }
}
