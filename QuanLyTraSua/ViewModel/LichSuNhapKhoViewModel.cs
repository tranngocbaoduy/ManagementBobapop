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
    public partial class LichSuNhapKhoViewModel : BaseViewModel
    {
        public ICommand LoadedPhieuNhapWindowCommand { get; set; }
        public ICommand GetAllCommand { get; set; }

        private ObservableCollection<Model.PHIEUNHAP> _PhieuNhapKhoList;
        public ObservableCollection<Model.PHIEUNHAP> PhieuNhapKhoList { get => _PhieuNhapKhoList; set { _PhieuNhapKhoList = value; OnPropertyChanged(); } }


        private ObservableCollection<Model.PHIEUNHAP> _TempPhieuNhapKhoList;
        public ObservableCollection<Model.PHIEUNHAP> TempPhieuNhapKhoList { get => _TempPhieuNhapKhoList; set { _TempPhieuNhapKhoList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.PHIEUNHAP> _FullPhieuNhapKhoList; 
        public ObservableCollection<Model.PHIEUNHAP> FullPhieuNhapKhoList { get => _FullPhieuNhapKhoList; set { _FullPhieuNhapKhoList = value; OnPropertyChanged(); } }
 
        private ObservableCollection<ChiTietNguyenLieuPhieuNhap> _ChiTietPhieuNhapKhoList;
        public ObservableCollection<ChiTietNguyenLieuPhieuNhap> ChiTietPhieuNhapKhoList { get => _ChiTietPhieuNhapKhoList; set { _ChiTietPhieuNhapKhoList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.NGUYENLIEU> _NguyenLieuList;
        public ObservableCollection<Model.NGUYENLIEU> NguyenLieuList { get => _NguyenLieuList; set { _NguyenLieuList = value; OnPropertyChanged(); } }


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
                            var listPhieuNhapByFilter = FullPhieuNhapKhoList.Where(i => DateTime.Compare(NGAYBATDAU, i.NGAYNHAP) <= 0 && DateTime.Compare(i.NGAYNHAP, NGAYKETTHUC) <= 0);
                            if (listPhieuNhapByFilter != null && listPhieuNhapByFilter.Count() > 0)
                            {
                                TempPhieuNhapKhoList.Clear();
                                foreach (var item in listPhieuNhapByFilter)
                                {
                                    if (!TempPhieuNhapKhoList.Contains(item))
                                    {
                                        TempPhieuNhapKhoList.Add(item);
                                    }
                                }
                                if (TempPhieuNhapKhoList != null && TempPhieuNhapKhoList.Count() > 0)
                                {
                                    PhieuNhapKhoList.Clear();
                                    foreach (var item in TempPhieuNhapKhoList)
                                    {
                                        PhieuNhapKhoList.Add(item);
                                    }
                                }
                                TempPhieuNhapKhoList.Clear();
                                listPhieuNhapByFilter = null;
                            }
                        }
                        else
                        { 
                            PhieuNhapKhoList.Clear();
                            LoadPhieuNhap();
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
                            var listPhieuNhapByFilter = FullPhieuNhapKhoList.Where(i => DateTime.Compare(NGAYBATDAU, i.NGAYNHAP) <= 0 && DateTime.Compare(i.NGAYNHAP, NGAYKETTHUC) <= 0);
                            if (listPhieuNhapByFilter != null && listPhieuNhapByFilter.Count() > 0)
                            { 
                                foreach (var item in listPhieuNhapByFilter)
                                {
                                    if (!TempPhieuNhapKhoList.Contains(item))
                                    {
                                        TempPhieuNhapKhoList.Add(item);
                                    }
                                }
                                if (TempPhieuNhapKhoList != null && TempPhieuNhapKhoList.Count() > 0)
                                {
                                    PhieuNhapKhoList.Clear();
                                    foreach (var item in TempPhieuNhapKhoList)
                                    {
                                        PhieuNhapKhoList.Add(item);
                                    }
                                }
                                TempPhieuNhapKhoList.Clear();
                                listPhieuNhapByFilter = null;
                            }
                        }
                        else
                        { 
                            PhieuNhapKhoList.Clear();
                            LoadPhieuNhap();
                        }
                    }
                }
                catch { }

            }
        }

        private Model.PHIEUNHAP _SelectedItem;
        public Model.PHIEUNHAP SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    SelectedPhieuNhapKho = SelectedItem.MSPN;
                }
                LoadChiTietPhieuNhap();
            }
        }
        private int _SelectedPhieuNhapKho;
        public int SelectedPhieuNhapKho { get => _SelectedPhieuNhapKho; set { _SelectedPhieuNhapKho = value; OnPropertyChanged(); } }

        public LichSuNhapKhoViewModel()
        {
            NGAYBATDAU = DateTime.Today; 
            NGAYKETTHUC = DateTime.Today;

            FullPhieuNhapKhoList = new ObservableCollection<Model.PHIEUNHAP>();
            TempPhieuNhapKhoList = new ObservableCollection<Model.PHIEUNHAP>();

            LoadedPhieuNhapWindowCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { LoadPhieuNhap(); });

            GetAllCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { LoadPhieuNhap(); });
        }

        void LoadPhieuNhap()
        {
            PhieuNhapKhoList = new ObservableCollection<Model.PHIEUNHAP>();
            var listPhieuNhap = DataProvider.Ins.DB.PHIEUNHAPs;
            foreach (var item in listPhieuNhap)
            {
                PhieuNhapKhoList.Add(item);
            } 
            foreach (var item in PhieuNhapKhoList)
            {
                TempPhieuNhapKhoList.Add(item);
                FullPhieuNhapKhoList.Add(item);
            }

            NguyenLieuList = new ObservableCollection<Model.NGUYENLIEU>();
            var listNguyenLieu = DataProvider.Ins.DB.NGUYENLIEUx;
            foreach (var item in listNguyenLieu)
            {
                NguyenLieuList.Add(item);
            }
        } 

        void LoadChiTietPhieuNhap()
        {
            ChiTietPhieuNhapKhoList = new ObservableCollection<ChiTietNguyenLieuPhieuNhap>();
            var listChiTietPhieuNhap = DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Where(i => i.MSPN == SelectedPhieuNhapKho);
            foreach (var item in listChiTietPhieuNhap)
            {
                ChiTietNguyenLieuPhieuNhap temp = new ChiTietNguyenLieuPhieuNhap();
                temp.CHITIETPHIEUNHAP = item;
                foreach (var i in NguyenLieuList)
                {
                    if (item.MSNL == i.MSNL)
                    {
                        temp.TENNL = i.TENNL;
                        break;
                    }
                }
                ChiTietPhieuNhapKhoList.Add(temp);
            }
        }

    }
}
