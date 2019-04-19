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
    public partial class QuanLyKhoViewModel : BaseViewModel
    {
        public ICommand LoadedQuanLyKhoWindowCommand { get; set; }
        public ICommand OnKeyUpCommand { get; set; }

        private ObservableCollection<Inventory> _TonKhoList;
        public ObservableCollection<Inventory> TonKhoList { get => _TonKhoList; set { _TonKhoList = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _KhoList;
        public ObservableCollection<String> KhoList { get => _KhoList; set { _KhoList = value; OnPropertyChanged(); } }

        private ObservableCollection<Inventory> _TempTonKhoList;
        public ObservableCollection<Inventory> TempTonKhoList { get => _TempTonKhoList; set { _TempTonKhoList = value; OnPropertyChanged(); } }

        private ObservableCollection<Inventory> _FullTonKhoList;
        public ObservableCollection<Inventory> FullTonKhoList { get => _FullTonKhoList; set { _FullTonKhoList = value; OnPropertyChanged(); } }

        private Inventory _SelectedNguyenLieu;
        public Inventory SelectedNguyenLieu { get => _SelectedNguyenLieu; set { _SelectedNguyenLieu = value; OnPropertyChanged(); } }

        private String _SelectedKho;
        public String SelectedKho
        {
            get => _SelectedKho;
            set
            {
                _SelectedKho = value;
                OnPropertyChanged();
                if (SelectedKho == "Lấy Tất Cả")
                {
                    LoadTonKho();
                }
                else if (SelectedKho == "Chưa Nhập Vào Kho")
                {
                    var listNguyenLieuByKho = FullTonKhoList.Where(i => i.KHO == null );

                    if (listNguyenLieuByKho != null)
                    {
                        TempTonKhoList.Clear();
                        foreach (var item in listNguyenLieuByKho)
                        {
                            TempTonKhoList.Add(item);
                        }
                        if (TempTonKhoList != null && TempTonKhoList.Count() > 1)
                        {
                            TonKhoList = TempTonKhoList;
                        }
                    }
                }
                else if (SelectedKho != null)
                { 
                    var listNguyenLieuByKho = FullTonKhoList.Where(i => i.KHO != null && i.KHO.TENKHO == SelectedKho);

                    if (listNguyenLieuByKho != null)
                    {
                        TempTonKhoList.Clear();
                        foreach (var item in listNguyenLieuByKho)
                        {
                            TempTonKhoList.Add(item);
                        }
                        if (TempTonKhoList != null && TempTonKhoList.Count() >1)
                        {
                            TonKhoList = TempTonKhoList;
                        }
                    } 
                }
            }
        }


        public QuanLyKhoViewModel()
        {
            LoadedQuanLyKhoWindowCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { LoadTonKho(); });

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
        }


        void LoadTonKho()
        {
            KhoList = new ObservableCollection<String>();
            TonKhoList = new ObservableCollection<Inventory>();
            TempTonKhoList = new ObservableCollection<Inventory>();
            FullTonKhoList = new ObservableCollection<Inventory>();
            var listNguyenLieu = DataProvider.Ins.DB.NGUYENLIEUx;
            var listNhaCungCap = DataProvider.Ins.DB.NHACUNGCAPs;
            var listKho = DataProvider.Ins.DB.KHOes;

            // load list Kho
            foreach (var item in listKho)
            {
                KhoList.Add(item.TENKHO);
            }
            // get all
            KhoList.Add("Lấy Tất Cả");
            KhoList.Add("Chưa Nhập Vào Kho");

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

    }
}
