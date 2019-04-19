using QuanLyTraSua.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTraSua.Entity
{
    public class Account :BaseViewModel
    {
      
        private string _UserName { set; get; }
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }

        public string Password { set; get; }

        public int Role { set; get; }

        public Account()
        {

        }

        public Account(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }


    }
}
