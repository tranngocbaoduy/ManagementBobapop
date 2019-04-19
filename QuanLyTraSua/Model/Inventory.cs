using QuanLyTraSua.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTraSua.Model
{
    public class Inventory : BaseViewModel
    {
        private NGUYENLIEU _NGUYENLIEU { get; set; }
        public NGUYENLIEU NGUYENLIEU { get => _NGUYENLIEU; set { _NGUYENLIEU = value; OnPropertyChanged(); } }

        private int _MSNL { get; set; }
        public int MSNL { get => _MSNL; set { _MSNL = value; OnPropertyChanged(); } }

        private int _Quantity { get; set; }
        public int Quantity { get => _Quantity; set { _Quantity = value; OnPropertyChanged(); } }

        private NHACUNGCAP _NHACUNGCAP { get; set; }
        public NHACUNGCAP NHACUNGCAP { get => _NHACUNGCAP; set { _NHACUNGCAP = value; OnPropertyChanged(); } }

        private KHO _KHO { get; set; }
        public KHO KHO { get => _KHO; set { _KHO = value; OnPropertyChanged(); } }

        private String _GIACUOICUNG { get; set; }
        public String GIACUOICUNG { get => _GIACUOICUNG; set { _GIACUOICUNG = value; OnPropertyChanged(); } }

        private String _GIATRUNGBINH { get; set; }
        public String GIATRUNGBINH { get => _GIATRUNGBINH; set { _GIATRUNGBINH = value; OnPropertyChanged(); } }
         
        private String _GIACAONHAT { get; set; }
        public String GIACAONHAT { get => _GIACAONHAT; set { _GIACAONHAT = value; OnPropertyChanged(); } }
         
        private String _GIATHAPNHAT { get; set; }
        public String GIATHAPNHAT { get => _GIATHAPNHAT; set { _GIATHAPNHAT = value; OnPropertyChanged(); } }
         
        public Inventory()
        {
            NHACUNGCAP = new NHACUNGCAP();
            NGUYENLIEU = new NGUYENLIEU();
            MSNL = -1;
            Quantity = 0;
            KHO = new KHO();
            GIACUOICUNG = "";
            GIATRUNGBINH = "";
            GIACAONHAT = "";
            GIATHAPNHAT = "";
        }
    }
}
