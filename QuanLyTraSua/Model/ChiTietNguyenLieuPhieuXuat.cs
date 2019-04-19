using QuanLyTraSua.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTraSua.Model
{
    public class ChiTietNguyenLieuPhieuXuat : BaseViewModel
    { 
        private Model.CHITIETPHIEUXUAT _CHITIETPHIEUXUAT { get; set; }
        public Model.CHITIETPHIEUXUAT CHITIETPHIEUXUAT { get => _CHITIETPHIEUXUAT; set { _CHITIETPHIEUXUAT = value; OnPropertyChanged(); } }

        private String _TENNL { get; set; }
        public String TENNL { get => _TENNL; set { _TENNL = value; OnPropertyChanged(); } }
    }
}
