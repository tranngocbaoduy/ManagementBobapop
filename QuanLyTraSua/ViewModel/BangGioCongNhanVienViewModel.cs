
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
    public partial class BangGioCongNhanVienViewModel : BaseViewModel
    { 
        public ICommand LoadedBangGioCongNhanVienWindowCommand { get; set; } 

        private ObservableCollection<Model.NHANVIEN> _NhanVienList;
        public ObservableCollection<Model.NHANVIEN> NhanVienList { get => _NhanVienList; set { _NhanVienList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.CHECKINGIOLAMVIEC> _CheckinNVTodayList;
        public ObservableCollection<Model.CHECKINGIOLAMVIEC> CheckinNVTodayList { get => _CheckinNVTodayList; set { _CheckinNVTodayList = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _CaLamViecList;
        public ObservableCollection<String> CaLamViecList { get => _CaLamViecList; set { _CaLamViecList = value; OnPropertyChanged(); } }
         
        private ObservableCollection<NhanVienCheckin> _NhanVienLamByCaList;
        public ObservableCollection<NhanVienCheckin> NhanVienLamByCaList { get => _NhanVienLamByCaList; set { _NhanVienLamByCaList = value; OnPropertyChanged(); } }

        private ObservableCollection<NhanVienCheckin> _NhanVienLamByCaListAll;
        public ObservableCollection<NhanVienCheckin> NhanVienLamByCaListAll { get => _NhanVienLamByCaListAll; set { _NhanVienLamByCaListAll = value; OnPropertyChanged(); } }
         

        private String _SelectedCa = "";
        public String SelectedCa
        {
            get => _SelectedCa; set
            {
                _SelectedCa = value; OnPropertyChanged();
                if (SelectedCa != null)
                {
                    if (SelectedCa == "CA 1")
                    {
                        NhanVienLamByCaList.Clear();
                        var listNVByCa = NhanVienLamByCaListAll.Where(i => i.CALAM == "CA 1");
                        foreach (var item in listNVByCa)
                        {
                            NhanVienLamByCaList.Add(item);
                        }
                    }
                    if (SelectedCa == "CA 2")
                    {
                        NhanVienLamByCaList.Clear();
                        var listNVByCa = NhanVienLamByCaListAll.Where(i => i.CALAM == "CA 2");
                        foreach (var item in listNVByCa)
                        {
                            NhanVienLamByCaList.Add(item);
                        }
                    }
                    if (SelectedCa == "CA 3")
                    {
                        NhanVienLamByCaList.Clear();
                        var listNVByCa = NhanVienLamByCaListAll.Where(i => i.CALAM == "CA 3");
                        foreach (var item in listNVByCa)
                        {
                            NhanVienLamByCaList.Add(item);
                        }
                    }
                    if (SelectedCa == "FULLTIME")
                    {
                        NhanVienLamByCaList.Clear();
                        var listNVByCa = NhanVienLamByCaListAll.Where(i => i.CALAM == "FULLTIME");
                        foreach (var item in listNVByCa)
                        {
                            NhanVienLamByCaList.Add(item);
                        }
                    }
                }
            }
        }

        private NhanVienCheckin _SelectedItemNhanVien;
        public NhanVienCheckin SelectedItemNhanVien
        {
            get => _SelectedItemNhanVien; set
            {
                _SelectedItemNhanVien = value; OnPropertyChanged();
                if (SelectedItemNhanVien != null)
                {
                    MessageBox.Show(SelectedItemNhanVien.SDT);
                }
            }
        } 

        public BangGioCongNhanVienViewModel()
        { 
            LoadedBangGioCongNhanVienWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null)
                { 
                    LoadCaLamViec();
                    CreateCheckinGioLamViecNhanViec();
                    LoadListCheckinNVToday();
                    LoadNhanVienCheckIn();
                }
            }); 

        }

        void CreateCheckinGioLamViecNhanViec()
        {
            var listNhanVien = DataProvider.Ins.DB.NHANVIENs.Where(i => i.ACTIVE == true);
            foreach (var item in listNhanVien)
            {
                var itemCheckinGioLamViec = DataProvider.Ins.DB.CHECKINGIOLAMVIECs.Where(i => DateTime.Today.Day == i.NGAYCHECKIN.Day && DateTime.Today.Month == i.NGAYCHECKIN.Month && DateTime.Today.Year == i.NGAYCHECKIN.Year && item.MSNV == i.MSNV).SingleOrDefault();
                if (itemCheckinGioLamViec == null)
                {
                    Model.CHECKINGIOLAMVIEC newCheck = new Model.CHECKINGIOLAMVIEC();
                    newCheck.NGAYCHECKIN = DateTime.Today;
                    newCheck.TRANGTHAI = 0;
                    newCheck.MSNV = item.MSNV;
                    newCheck.TRE = false;
                    newCheck.SOM = false;
                    newCheck.THOIGIANVAOCA = DateTime.Parse("2012/12/12 00:00:00.000");
                    newCheck.THOIGIANKETTHUCCA = DateTime.Parse("2012/12/12 00:00:00.000");

                    DataProvider.Ins.DB.CHECKINGIOLAMVIECs.Add(newCheck);
                }
            }
            DataProvider.Ins.DB.SaveChanges();
        }

        bool ValidateNhanVien(Model.NHANVIEN item)
        {
            if (item == null) { MessageBox.Show("Thông tin nhập không hợp lệ!"); return false; }
            if (string.IsNullOrEmpty(item.TENNV))
                return false;
            if (string.IsNullOrEmpty(item.GIOITINH) && (item.GIOITINH != "Nam" || item.GIOITINH != "Nữ"))
                return false;
            return true;
        }

        void LoadCaLamViec()
        {
            CaLamViecList = new ObservableCollection<string>();
            var listCaLamViec = DataProvider.Ins.DB.CALAMVIECs;
            //CaLamViecList.Add("ALL");
            foreach (var item in listCaLamViec)
            {
                if (item.MSCLV == "C1")
                {
                    CaLamViecList.Add("CA 1");
                }
                else if (item.MSCLV == "C2")
                {
                    CaLamViecList.Add("CA 2");
                }
                else if (item.MSCLV == "C3")
                {
                    CaLamViecList.Add("CA 3");
                }
                else
                {
                    CaLamViecList.Add("FULLTIME");
                }
            }
        }

        void LoadListCheckinNVToday()
        {
            CheckinNVTodayList = new ObservableCollection<CHECKINGIOLAMVIEC>();
            var listCheckinNVToday = DataProvider.Ins.DB.CHECKINGIOLAMVIECs.Where(i => DateTime.Today.Day == i.NGAYCHECKIN.Day && DateTime.Today.Month == i.NGAYCHECKIN.Month && DateTime.Today.Year == i.NGAYCHECKIN.Year);

            foreach (var item in listCheckinNVToday)
            {
                CheckinNVTodayList.Add(item);
            } 

        }

        void LoadNhanVienCheckIn()
        {
            NhanVienLamByCaListAll = new ObservableCollection<NhanVienCheckin>();
            NhanVienLamByCaList = new ObservableCollection<NhanVienCheckin>();

            var listNVByCa = DataProvider.Ins.DB.NHANVIENs.Where(i => i.ACTIVE == true);

            foreach (var itemCheckinNV in CheckinNVTodayList)
            {
                var itemNV = DataProvider.Ins.DB.NHANVIENs.Where(i => i.ACTIVE == true && i.MSNV == itemCheckinNV.MSNV).SingleOrDefault();
                if(itemNV != null)
                { 
                    NhanVienCheckin temp = new NhanVienCheckin();
                    temp.TENNV = itemNV.TENNV;
                    temp.SDT = itemNV.SDT;
                    temp.CMND = itemNV.CMND;
                    if(itemCheckinNV.THOIGIANVAOCA.Day == DateTime.Today.Day && itemCheckinNV.THOIGIANVAOCA.Month == DateTime.Today.Month && itemCheckinNV.THOIGIANVAOCA.Year == DateTime.Today.Year)
                    {
                        temp.TRANGTHAI = 1;
                        temp.ISCHECKIN = true;
                        temp.ISCHECKINYET_ = false;
                        temp.ISCHECKOUTYET_ = true;
                        if (itemCheckinNV.TRE)
                        {
                            temp.PASSIN = itemCheckinNV.THOIGIANVAOCA.ToString() + " (T)";
                        }
                        else
                        {
                            temp.PASSIN = itemCheckinNV.THOIGIANVAOCA.ToString();
                        }
                    }
                    else
                    {
                        temp.ISCHECKIN = false; 
                        temp.ISCHECKOUTYET_ = false;
                    }

                    if (itemCheckinNV.THOIGIANKETTHUCCA.Day == DateTime.Today.Day && itemCheckinNV.THOIGIANKETTHUCCA.Month == DateTime.Today.Month && itemCheckinNV.THOIGIANKETTHUCCA.Year == DateTime.Today.Year)
                    {
                        temp.TRANGTHAI = 2;
                        temp.ISCHECKOUT = true; 
                        if (itemCheckinNV.SOM)
                        { 
                            temp.PASSOUT = itemCheckinNV.THOIGIANKETTHUCCA.ToString() + " (S)";
                        }
                        else
                        {
                            temp.PASSOUT = itemCheckinNV.THOIGIANKETTHUCCA.ToString();
                        }
                        temp.ISCHECKOUTYET_ = false;
                    }
                    else
                    {
                        temp.ISCHECKOUT = false; 
                        temp.ISCHECKOUTYET_ = true;
                    }


                    temp.EARLY = false;
                    temp.LATE = false;
                    if (itemNV.MSCLV == "C1")
                    {
                        temp.CALAM = "CA 1";
                    }
                    else if (itemNV.MSCLV == "C2")
                    {
                        temp.CALAM = "CA 2";
                    }
                    else if (itemNV.MSCLV == "C3")
                    {
                        temp.CALAM = "CA 3";
                    }
                    else if (itemNV.MSCLV == "FULLTIME")
                    {
                        temp.CALAM = "FULLTIME";
                    }

                    NhanVienLamByCaListAll.Add(temp);
                }
            }
        }
    }
}
