using QuanLyTraSua.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTraSua.Model
{
    public partial class DataChart : BaseViewModel
    {
        private string _Name { get; set; }
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private int _Data { get; set; }
        public int Data { get => _Data; set { _Data = value; OnPropertyChanged(); } }

        public DataChart()
        {
            this.Name = "";
            this.Data = 0;
        }

    }
}
