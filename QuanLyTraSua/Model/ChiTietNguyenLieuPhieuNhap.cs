using QuanLyTraSua.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTraSua.Model
{
    public class ChiTietNguyenLieuPhieuNhap : BaseViewModel
    { 
        private Model.CHITIETPHIEUNHAP _CHITIETPHIEUNHAP { get; set; }
        public Model.CHITIETPHIEUNHAP CHITIETPHIEUNHAP { get => _CHITIETPHIEUNHAP; set { _CHITIETPHIEUNHAP = value; OnPropertyChanged(); } }

        private String _TENNL { get; set; }
        public String TENNL { get => _TENNL; set { _TENNL = value; OnPropertyChanged(); } }
    }
}
