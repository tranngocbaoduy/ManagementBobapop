using QuanLyTraSua.DBConnection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyTraSua.ViewModel
{
    public partial class LichSuXuatHoaDonViewModel : BaseViewModel
    {
        public ICommand LoadedHoaDonWindowCommand { get; set; }
        public ICommand GetKhachHangThanThietCommand { get; set; }
        public ICommand GetKhachVangLaiCommand { get; set; }
        public ICommand GetAllCommand { get; set; }

        private ObservableCollection<Model.HOADON> _HoaDonList;
        public ObservableCollection<Model.HOADON> HoaDonList { get => _HoaDonList; set { _HoaDonList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.HOADON> _TempHoaDonList;
        public ObservableCollection<Model.HOADON> TempHoaDonList { get => _TempHoaDonList; set { _TempHoaDonList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.HOADON> _FullHoaDonList;
        public ObservableCollection<Model.HOADON> FullHoaDonList { get => _FullHoaDonList; set { _FullHoaDonList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.CHITIETHOADON> _ChiTietHoaDonList;
        public ObservableCollection<Model.CHITIETHOADON> ChiTietHoaDonList { get => _ChiTietHoaDonList; set { _ChiTietHoaDonList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.SUKIEN> _SuKienList;
        public ObservableCollection<Model.SUKIEN> SuKienList { get => _SuKienList; set { _SuKienList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.HOADONSUKIEN> _HoaDonSuKienList;
        public ObservableCollection<Model.HOADONSUKIEN> HoaDonSuKienList { get => _HoaDonSuKienList; set { _HoaDonSuKienList = value; OnPropertyChanged(); } }


        private DateTime _NGAYBATDAU;
        public DateTime NGAYBATDAU
        {
            get => _NGAYBATDAU; set
            {
                _NGAYBATDAU = value;
                OnPropertyChanged();
                try
                {
                    if (NGAYBATDAU != null && NGAYKETTHUC != null)
                    {
                        if (DateTime.Compare(NGAYBATDAU, NGAYKETTHUC) <= 0)
                        {
                            var listPhieuXuatByFilter = FullHoaDonList.Where(i => DateTime.Compare(NGAYBATDAU, i.NGAYXUAT) <= 0 && DateTime.Compare(i.NGAYXUAT, NGAYKETTHUC) <= 0);
                            if (listPhieuXuatByFilter != null && listPhieuXuatByFilter.Count() > 0)
                            {
                                TempHoaDonList.Clear();
                                foreach (var item in listPhieuXuatByFilter)
                                {
                                    if (!TempHoaDonList.Contains(item))
                                    {
                                        TempHoaDonList.Add(item);
                                    }
                                }
                                if (TempHoaDonList != null && TempHoaDonList.Count() > 0)
                                {
                                    HoaDonList.Clear();
                                    foreach (var item in TempHoaDonList)
                                    {
                                        HoaDonList.Add(item);
                                    }
                                }
                                TempHoaDonList.Clear();
                                listPhieuXuatByFilter = null;
                            }
                        }
                        else
                        {
                            HoaDonList.Clear();
                            LoadHoaDon();
                        }
                    }
                }
                catch
                {

                }
            }
        }

        private DateTime _NGAYKETTHUC;
        public DateTime NGAYKETTHUC
        {
            get => _NGAYKETTHUC; set
            {
                _NGAYKETTHUC = value;
                OnPropertyChanged();
                try
                {
                    if (NGAYBATDAU != null && NGAYKETTHUC != null)
                    {
                        if (DateTime.Compare(NGAYBATDAU, NGAYKETTHUC) <= 0)
                        {
                            var listPhieuXuatByFilter = FullHoaDonList.Where(i => DateTime.Compare(NGAYBATDAU, i.NGAYXUAT) <= 0 && DateTime.Compare(i.NGAYXUAT, NGAYKETTHUC) <= 0);
                            if (listPhieuXuatByFilter != null && listPhieuXuatByFilter.Count() > 0)
                            {
                                foreach (var item in listPhieuXuatByFilter)
                                {
                                    if (!TempHoaDonList.Contains(item))
                                    {
                                        TempHoaDonList.Add(item);
                                    }
                                }
                                if (TempHoaDonList != null && TempHoaDonList.Count() > 0)
                                {
                                    HoaDonList.Clear();
                                    foreach (var item in TempHoaDonList)
                                    {
                                        HoaDonList.Add(item);
                                    }
                                }
                                TempHoaDonList.Clear();
                                listPhieuXuatByFilter = null;
                            }
                        }
                        else
                        {
                            HoaDonList.Clear();
                            LoadHoaDon();
                        }
                    }
                }
                catch { }

            }
        }

        private Model.HOADON _SelectedItem;
        public Model.HOADON SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    LoadChiTietHoaDon(SelectedItem.MSHD);
                    LoadHoaDonSuKienList(SelectedItem.MSHD);
                }
            }
        }

        public LichSuXuatHoaDonViewModel()
        {
            NGAYBATDAU = DateTime.Today;
            NGAYKETTHUC = DateTime.Today;

            LoadedHoaDonWindowCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { LoadHoaDon(); });

            GetKhachHangThanThietCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { LoadHoaDonKhachHangThanThiet(); });

            GetKhachVangLaiCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { LoadHoaDonKhachVangLai(); });

            GetAllCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { LoadHoaDon(); });
        }

        void LoadHoaDon()
        {
            HoaDonList = new ObservableCollection<Model.HOADON>();
            TempHoaDonList = new ObservableCollection<Model.HOADON>();
            FullHoaDonList = new ObservableCollection<Model.HOADON>();

            var listHoaDon = DataProvider.Ins.DB.HOADONs;
            if (listHoaDon != null)
            {
                foreach (var item in listHoaDon)
                {
                    HoaDonList.Add(item);
                    TempHoaDonList.Add(item);
                    FullHoaDonList.Add(item);
                }
            }
        }

        void LoadHoaDonKhachVangLai()
        {
            HoaDonList = new ObservableCollection<Model.HOADON>();
            TempHoaDonList = new ObservableCollection<Model.HOADON>();
            FullHoaDonList = new ObservableCollection<Model.HOADON>();

            var listHoaDon = DataProvider.Ins.DB.HOADONs.Where(i => i.SDT == "01234567891");
            if (listHoaDon != null)
            {
                foreach (var item in listHoaDon)
                {
                    item.SDT = "Khách Vãng Lai";
                    HoaDonList.Add(item);
                    TempHoaDonList.Add(item);
                    FullHoaDonList.Add(item);
                }
            }
        }
         void LoadHoaDonKhachHangThanThiet()
        {
            HoaDonList = new ObservableCollection<Model.HOADON>();
            TempHoaDonList = new ObservableCollection<Model.HOADON>();
            FullHoaDonList = new ObservableCollection<Model.HOADON>();

            var listHoaDon = DataProvider.Ins.DB.HOADONs.Where(i=>i.SDT != "01234567891");
            if(listHoaDon!= null)
            { 
                foreach (var item in listHoaDon)
                {
                    HoaDonList.Add(item);
                    TempHoaDonList.Add(item);
                    FullHoaDonList.Add(item);
                }
            }
        }

        void LoadChiTietHoaDon(int MSHD)
        {
            ChiTietHoaDonList = new ObservableCollection<Model.CHITIETHOADON>();

            var listChiTietHoaDon = DataProvider.Ins.DB.CHITIETHOADONs.Where(i => i.MSHD == MSHD);
            foreach (var item in listChiTietHoaDon)
            {
                ChiTietHoaDonList.Add(item);
            }
        }

        void LoadHoaDonSuKienList(int MSHD)
        {
            HoaDonSuKienList = new ObservableCollection<Model.HOADONSUKIEN>();

            var listHoaDonSuKienList = DataProvider.Ins.DB.HOADONSUKIENs.Where(i => i.MSHD == MSHD);

            foreach (var item in listHoaDonSuKienList)
            {
                HoaDonSuKienList.Add(item);
            }

            SuKienList = new ObservableCollection<Model.SUKIEN>();

            foreach (var item in HoaDonSuKienList)
            {
                var itemSK = DataProvider.Ins.DB.SUKIENs.Where(i => i.MASK == item.MASK).SingleOrDefault();
                SuKienList.Add(itemSK);
            }

        }
    }
}
