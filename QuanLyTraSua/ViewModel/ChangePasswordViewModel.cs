using QuanLyTraSua.DBConnection;
using QuanLyTraSua.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyTraSua.ViewModel
{
    public partial class ChangePasswordViewModel : BaseViewModel
    {
        public Account Account { get; set; }

        private String _UserName;
        public String UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }

        private String _Password;
        public String Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        private String _RePassword;
        public String RePassword { get => _RePassword; set { _RePassword = value; OnPropertyChanged(); } }

        private String _OldPassword;
        public String OldPassword { get => _OldPassword; set { _OldPassword = value; OnPropertyChanged(); } }

        public ICommand ClickCloseLoginForm { get; set; }
        public ICommand ClickResetPasswordButton { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand RePasswordChangedCommand { get; set; }
        public ICommand PasswordOldChangedCommand { get; set; }

        private String _Collapsed = "Collapsed";
        public String Collapsed { get => _Collapsed; set { _Collapsed = value; OnPropertyChanged(); } }

        public ChangePasswordViewModel()
        {

            // Close login form
            ClickCloseLoginForm = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });

            // Set Password = Password on Form
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return p == null ? false : true; }, (p) => { Password = p.Password; });

            RePasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return p == null ? false : true; }, (p) => { RePassword = p.Password; });

            PasswordOldChangedCommand = new RelayCommand<PasswordBox>((p) => { return p == null ? false : true; }, (p) => { OldPassword = p.Password; });

            ClickResetPasswordButton = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                var passOld = Base64Encode(OldPassword).Trim();
                var itemTK = DataProvider.Ins.DB.TAIKHOANs.Where(i => i.USERNAME == UserName && i.PASSWORD == passOld).SingleOrDefault();
                if (itemTK != null)
                {
                    if (Password == RePassword && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(RePassword))
                    {
                        var pa = Base64Encode(Password).Trim();
                        itemTK.PASSWORD = pa;
                        DataProvider.Ins.DB.SaveChanges();
                        Collapsed = "Collapsed";
                        RePassword = "";
                        Password = "";
                        MessageBox.Show("Đổi Mật Khẩu Thành Công. Hãy Đăng Nhập Lại");
                        p.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mật Khẩu Không giống nhau");
                    }
                }
                else
                {
                    MessageBox.Show("Mật Khẩu sai hoặc tài khoản không đúng");
                }
            });


        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }

}