using QuanLyTraSua.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTraSua.Model
{
    public partial class Event : BaseViewModel
    { 
        private Model.SUKIEN _SUKIEN { get; set; }
        public Model.SUKIEN SUKIEN { get => _SUKIEN; set { _SUKIEN = value; OnPropertyChanged(); } }

        private string _TENLSK { get; set; }
        public string TENLSK { get => _TENLSK; set { _TENLSK = value; OnPropertyChanged(); } }
    }
}
