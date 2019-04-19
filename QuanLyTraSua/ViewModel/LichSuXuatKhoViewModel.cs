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
    public partial class LichSuXuatKhoViewModel : BaseViewModel
    {
        public ICommand LoadedPhieuXuatWindowCommand { get; set; }
        public ICommand GetAllCommand { get; set; }

        private ObservableCollection<Model.PHIEUXUAT> _PhieuXuatKhoList;
        public ObservableCollection<Model.PHIEUXUAT> PhieuXuatKhoList { get => _PhieuXuatKhoList; set { _PhieuXuatKhoList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.PHIEUXUAT> _TempPhieuXuatKhoList;
        public ObservableCollection<Model.PHIEUXUAT> TempPhieuXuatKhoList { get => _TempPhieuXuatKhoList; set { _TempPhieuXuatKhoList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.PHIEUXUAT> _FullPhieuXuatKhoList;
        public ObservableCollection<Model.PHIEUXUAT> FullPhieuXuatKhoList { get => _FullPhieuXuatKhoList; set { _FullPhieuXuatKhoList = value; OnPropertyChanged(); } }


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
                            var listPhieuXuatByFilter = FullPhieuXuatKhoList.Where(i => DateTime.Compare(NGAYBATDAU, i.NGAYXUAT) <= 0 && DateTime.Compare(i.NGAYXUAT, NGAYKETTHUC) <= 0);
                            if (listPhieuXuatByFilter != null && listPhieuXuatByFilter.Count() > 0)
                            { 
                                foreach (var item in listPhieuXuatByFilter)
                                {
                                    if (!TempPhieuXuatKhoList.Contains(item))
                                    {
                                        TempPhieuXuatKhoList.Add(item);
                                    }
                                }
                                if (TempPhieuXuatKhoList != null && TempPhieuXuatKhoList.Count() > 0)
                                {
                                    PhieuXuatKhoList.Clear();
                                    foreach (var item in TempPhieuXuatKhoList)
                                    {
                                        PhieuXuatKhoList.Add(item);
                                    }
                                }
                                TempPhieuXuatKhoList.Clear();
                                listPhieuXuatByFilter = null;
                            }
                        }
                        else
                        {
                            PhieuXuatKhoList.Clear();
                            LoadPhieuXuat();
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
                            var listPhieuXuatByFilter = FullPhieuXuatKhoList.Where(i => DateTime.Compare(NGAYBATDAU, i.NGAYXUAT) <= 0 && DateTime.Compare(i.NGAYXUAT, NGAYKETTHUC) <= 0);
                            if (listPhieuXuatByFilter != null && listPhieuXuatByFilter.Count() > 0)
                            {
                                TempPhieuXuatKhoList.Clear();
                                foreach (var item in listPhieuXuatByFilter)
                                {
                                    if (!TempPhieuXuatKhoList.Contains(item))
                                    {
                                        TempPhieuXuatKhoList.Add(item);
                                    }
                                }
                                if (TempPhieuXuatKhoList != null && TempPhieuXuatKhoList.Count() > 0)
                                {
                                    PhieuXuatKhoList.Clear();
                                    foreach (var item in TempPhieuXuatKhoList)
                                    {
                                        PhieuXuatKhoList.Add(item);
                                    }
                                }
                                TempPhieuXuatKhoList.Clear();
                                listPhieuXuatByFilter = null;
                            }
                        }
                        else
                        {
                            PhieuXuatKhoList.Clear();
                            LoadPhieuXuat();
                        }
                    }
                }
                catch { }

            }
        }

        private ObservableCollection<ChiTietNguyenLieuPhieuXuat> _ChiTietPhieuXuatKhoList;
        public ObservableCollection<ChiTietNguyenLieuPhieuXuat> ChiTietPhieuXuatKhoList { get => _ChiTietPhieuXuatKhoList; set { _ChiTietPhieuXuatKhoList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.NGUYENLIEU> _NguyenLieuList;
        public ObservableCollection<Model.NGUYENLIEU> NguyenLieuList { get => _NguyenLieuList; set { _NguyenLieuList = value; OnPropertyChanged(); } }

        private Model.PHIEUXUAT _SelectedItem;
        public Model.PHIEUXUAT SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    SelectedPhieuXuatKho = SelectedItem.MSPX;
                }
                LoadChiTietPhieuXuat();
            }
        }
        private int _SelectedPhieuXuatKho;
        public int SelectedPhieuXuatKho { get => _SelectedPhieuXuatKho; set { _SelectedPhieuXuatKho = value; OnPropertyChanged(); } }

        public LichSuXuatKhoViewModel()
        {
            NGAYBATDAU = DateTime.Today;
            NGAYKETTHUC = DateTime.Today;

            FullPhieuXuatKhoList = new ObservableCollection<Model.PHIEUXUAT>();
            TempPhieuXuatKhoList = new ObservableCollection<Model.PHIEUXUAT>();

            LoadedPhieuXuatWindowCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { LoadPhieuXuat(); });

            GetAllCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { LoadPhieuXuat(); });
        }

        void LoadPhieuXuat()
        {
            PhieuXuatKhoList = new ObservableCollection<Model.PHIEUXUAT>();
            var listPhieuXuat = DataProvider.Ins.DB.PHIEUXUATs;
            foreach (var item in listPhieuXuat)
            {
                PhieuXuatKhoList.Add(item);
            }
            foreach (var item in PhieuXuatKhoList)
            {
                TempPhieuXuatKhoList.Add(item);
                FullPhieuXuatKhoList.Add(item);
            }

            NguyenLieuList = new ObservableCollection<Model.NGUYENLIEU>();
            var listNguyenLieu = DataProvider.Ins.DB.NGUYENLIEUx;
            foreach (var item in listNguyenLieu)
            {
                NguyenLieuList.Add(item);
            }
        }

        void LoadChiTietPhieuXuat()
        {
            ChiTietPhieuXuatKhoList = new ObservableCollection<ChiTietNguyenLieuPhieuXuat>();
            var listChiTietPhieuXuat = DataProvider.Ins.DB.CHITIETPHIEUXUATs.Where(i => i.MSPX == SelectedPhieuXuatKho);
            foreach (var item in listChiTietPhieuXuat)
            {
                ChiTietNguyenLieuPhieuXuat temp = new ChiTietNguyenLieuPhieuXuat();
                temp.CHITIETPHIEUXUAT = item;
                foreach (var i in NguyenLieuList)
                {
                    if (item.MSNL == i.MSNL)
                    {
                        temp.TENNL = i.TENNL;
                        break;
                    }
                }
                ChiTietPhieuXuatKhoList.Add(temp);
            }
        }
    }
}
