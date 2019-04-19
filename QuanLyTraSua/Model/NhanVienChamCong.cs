using QuanLyTraSua.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTraSua.Model
{
    public partial class NhanVienChamCong : BaseViewModel
    {
        private int _MSNV { get; set; }
        public int MSNV { get => _MSNV; set { _MSNV = value; OnPropertyChanged(); } }

        private String _TenNV { get; set; }
        public String TenNV { get => _TenNV; set { _TenNV = value; OnPropertyChanged(); } }

        private DateTime _ThoiGian { get; set; }
        public DateTime ThoiGian { get => _ThoiGian; set { _ThoiGian = value; OnPropertyChanged(); } }

        private String _Luong { get; set; }
        public String Luong { get => _Luong; set { _Luong = value; OnPropertyChanged(); } }

        private double _LuongSo { get; set; }
        public double LuongSo { get => _LuongSo; set { _LuongSo = value; OnPropertyChanged(); } }

        private double _LuongCoBanSo { get; set; }
        public double LuongCoBanSo { get => _LuongCoBanSo; set { _LuongCoBanSo = value; OnPropertyChanged(); } }

        private int _SoNgayLam { get; set; }
        public int SoNgayLam { get => _SoNgayLam; set { _SoNgayLam = value; OnPropertyChanged(); } }

        private int _SoNgayTre { get; set; }
        public int SoNgayTre { get => _SoNgayTre; set { _SoNgayTre = value; OnPropertyChanged(); } }

        private int _SoNgaySom { get; set; }
        public int SoNgaySom { get => _SoNgaySom; set { _SoNgaySom = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _LichSuSom { get; set; }
        public ObservableCollection<String> LichSuSom { get => _LichSuSom; set { _LichSuSom = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _LichSuTre { get; set; }
        public ObservableCollection<String> LichSuTre { get => _LichSuTre; set { _LichSuTre = value; OnPropertyChanged(); } }

        private String _LuongCoBan { get; set; }
        public String LuongCoBan { get => _LuongCoBan; set { _LuongCoBan = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.CHECKINGIOLAMVIEC> _CheckinList;
        public ObservableCollection<Model.CHECKINGIOLAMVIEC> CheckinList { get => _CheckinList; set { _CheckinList = value; OnPropertyChanged(); } }


        public NhanVienChamCong()
        {
            CheckinList = new ObservableCollection<CHECKINGIOLAMVIEC>();
            LichSuTre = new ObservableCollection<String>();
            LichSuSom = new ObservableCollection<String>();
        }

    }
}



