using QuanLyTraSua.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTraSua.Model
{
    public class Product : BaseViewModel
    {
        public int STT { get; set; } = 0;
        public Model.MATHANG MatHang { get; set; }
        private int _Quantity { get; set; }
        public int Quantity { get => _Quantity; set { _Quantity = value; OnPropertyChanged(); } }
        private int _Price { get; set; }
        public int Price { get => _Price; set { _Price = value; OnPropertyChanged(); } }
         
    }
}