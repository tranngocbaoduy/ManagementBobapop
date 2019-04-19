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
    public partial class QuanLyChamCongViewModel : BaseViewModel
    {

        public ICommand LoadedQuanLyChamCongWindowCommand { get; set; }

        private ObservableCollection<NhanVienChamCong> _QuanLyChamCongNhanVienList;
        public ObservableCollection<NhanVienChamCong> QuanLyChamCongNhanVienList { get => _QuanLyChamCongNhanVienList; set { _QuanLyChamCongNhanVienList = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _NgayTreList;
        public ObservableCollection<String> NgayTreList { get => _NgayTreList; set { _NgayTreList = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _NgaySomList;
        public ObservableCollection<String> NgaySomList { get => _NgaySomList; set { _NgaySomList = value; OnPropertyChanged(); } }

        private NhanVienChamCong _SelectedItem;
        public NhanVienChamCong SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    NgaySomList.Clear();
                    NgayTreList.Clear();
                    foreach (var item in SelectedItem.LichSuSom)
                    {
                        NgaySomList.Add(item);
                    }
                    foreach (var item in SelectedItem.LichSuTre)
                    {
                        NgayTreList.Add(item);
                    }
                }
            }
        }

        private String _ThangNamText { get; set; }
        public String ThangNamText { get => _ThangNamText; set { _ThangNamText = value; OnPropertyChanged(); } }

        private DateTime _ThangNam { get; set; }
        public DateTime ThangNam
        {
            get => _ThangNam; set
            {
                _ThangNam = value; OnPropertyChanged();
                if (ThangNam != null)
                {
                    ThangNamText = "Tháng " + ThangNam.Month + " Năm: " + ThangNam.Year;
                    LoadQuanLyChamCongNhanVienList(ThangNam.Month, ThangNam.Year);
                    CalSalary();
                }
            }
        }

        public QuanLyChamCongViewModel()
        {
            ThangNam = DateTime.Today;
            ThangNamText = ThangNam.ToLongDateString();
            LoadedQuanLyChamCongWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                {
                    LoadQuanLyChamCongNhanVienList(ThangNam.Month, ThangNam.Year);
                    CalSalary();
                }
            });
        }

        void CalSalary()
        {
            // 1 tuan tinh tu tuan thu 3 trong thang duoc tang 1 ngay cong
            // lam 7 ngay tuong duong lam 7 ngay
            // lam 14 ngay tuong duong lam 14 ngay
            // lam 21 ngay tuong duong lam 22 ngay
            // lam 28 ngay tuong duong lam 30 ngay
            foreach (var item in QuanLyChamCongNhanVienList)
            {
                double congMotNgay = item.LuongCoBanSo / 30;
                var soNgayLam = item.SoNgayLam - item.SoNgaySom * 0.5 - item.SoNgayTre * 0.5;
                if (item.SoNgayLam >= 21 && item.SoNgayLam < 28)
                {
                    soNgayLam += 1;
                }
                else if (item.SoNgayLam >= 28)
                {
                    soNgayLam += 2;
                }
                item.Luong = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", congMotNgay * soNgayLam);
            }
        }

        void LoadQuanLyChamCongNhanVienList(int month, int year)
        {
            QuanLyChamCongNhanVienList = new ObservableCollection<NhanVienChamCong>();
            NgayTreList = new ObservableCollection<String>();
            NgaySomList = new ObservableCollection<String>();

            var listNhanVien = DataProvider.Ins.DB.NHANVIENs;
            foreach (var itemNV in listNhanVien)
            {
                NhanVienChamCong newNVChamCong = new NhanVienChamCong();
                newNVChamCong.MSNV = itemNV.MSNV;
                newNVChamCong.TenNV = itemNV.TENNV;
                newNVChamCong.LuongCoBanSo = (double)itemNV.TIENLUONG;
                newNVChamCong.LuongSo = 0;
                newNVChamCong.LuongCoBan = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", itemNV.TIENLUONG);
                newNVChamCong.ThoiGian = DateTime.Today;
                newNVChamCong.SoNgayLam = 0;
                newNVChamCong.SoNgaySom = 0;
                newNVChamCong.SoNgayTre = 0;

                newNVChamCong.Luong = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", "0");
                QuanLyChamCongNhanVienList.Add(newNVChamCong);
            }

            foreach (var item in QuanLyChamCongNhanVienList)
            {
                var listCheckinGioCong = DataProvider.Ins.DB.CHECKINGIOLAMVIECs.Where(i => i.NGAYCHECKIN.Month == month && i.NGAYCHECKIN.Year == year && i.MSNV == item.MSNV);

                for (int j = 1; j <= 31; j++)
                {
                    var itemCHC = listCheckinGioCong.Where(i => i.NGAYCHECKIN.Day == j);
                    if (itemCHC.Count() == 1)
                    {
                        var itemGioCong = itemCHC.SingleOrDefault();
                        if (itemGioCong.TRANGTHAI != 0)
                        {
                            item.SoNgayLam += 1;
                            if (itemGioCong.SOM)
                            {
                                item.SoNgaySom += 1;
                                item.LichSuSom.Add(itemGioCong.THOIGIANKETTHUCCA + "");
                            }
                            if (itemGioCong.TRE)
                            {
                                item.SoNgayTre += 1;
                                item.LichSuTre.Add(itemGioCong.THOIGIANVAOCA + "");
                            }
                        }
                        item.CheckinList.Add(itemGioCong);
                    }
                    else
                    {
                        Model.CHECKINGIOLAMVIEC temp = new CHECKINGIOLAMVIEC();
                        temp.MSNV = item.MSNV;
                        temp.NGAYCHECKIN = DateTime.Today;
                        temp.TRE = false;
                        temp.SOM = false;
                        temp.THOIGIANVAOCA = DateTime.Now;
                        temp.THOIGIANKETTHUCCA = DateTime.Now;
                        item.CheckinList.Add(temp);
                    }
                }
            }
        }
    }
}
