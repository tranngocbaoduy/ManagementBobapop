using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTraSua.ViewModel
{
    public class SanPhamChart : BaseViewModel
    {
        public string _Name = "";
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        public int _Count = 0;
        public int Count { get => _Count; set { _Count = value; OnPropertyChanged(); } }
         
        public SanPhamChart(string name, int count)
        {
            this.Name = name;
            this.Count = count;
        }

        public SanPhamChart()
        {
        }
    }
}
