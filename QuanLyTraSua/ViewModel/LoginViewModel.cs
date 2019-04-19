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
    public partial class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; } = false;
        public bool IsCreateTK { get; set; } = false;
        public Account Account { get; set; }

        private String _UserName;
        public String UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }

        private String _Password;
        public String Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        private String _RePassword;
        public String RePassword { get => _RePassword; set { _RePassword = value; OnPropertyChanged(); } }

        public ICommand ClickCloseLoginForm { get; set; }
        public ICommand ClickLoginButton { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand RePasswordChangedCommand { get; set; }

        private PasswordBox _PasswordBox1 { get; set; }
        public PasswordBox PasswordBox1 { get => _PasswordBox1; set { _PasswordBox1 = value; OnPropertyChanged(); } }

        private PasswordBox _PasswordBox2 { get; set; }
        public PasswordBox PasswordBox2 { get => _PasswordBox2; set { _PasswordBox2 = value; OnPropertyChanged(); } }

        private String _Collapsed = "Collapsed";
        public String Collapsed { get => _Collapsed; set { _Collapsed = value; OnPropertyChanged(); } }

        public LoginViewModel()
        {

            // Close login form
            ClickCloseLoginForm = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });

            // Set Password = Password on Form
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return p == null ? false : true; }, (p) => { PasswordBox1 = p as PasswordBox; Password = p.Password; });

            RePasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return p == null ? false : true; }, (p) => { PasswordBox2 = p as PasswordBox; RePassword = p.Password; });

            ClickLoginButton = new RelayCommand<Window>((p) => { return true; }, (p) => { checkLogin(p); });

            // Check IsLogin Yet
            void checkLogin(Window p)
            {
                if (p == null)
                {
                    return;
                }
                if (Password == null || UserName == null)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ");
                    return;
                }
                if (IsCreateTK) // Change Password for new Account
                {
                    if (Password == RePassword && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(RePassword))
                    {
                        var itemTK = DataProvider.Ins.DB.TAIKHOANs.Where(item => item.USERNAME == UserName).SingleOrDefault();
                        var pa = Base64Encode(Password).Trim();
                        itemTK.PASSWORD = pa;
                        DataProvider.Ins.DB.SaveChanges();
                        Collapsed = "Collapsed";
                        RePassword = "";
                        Password = "";
                        MessageBox.Show("Đổi Mật Khẩu Thành Công. Hãy Đăng Nhập Lại");
                        IsCreateTK = false;
                        PasswordBox1.Password = string.Empty;
                        PasswordBox2.Password = string.Empty;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Mật Khẩu Không giống nhau");
                    }
                }
                else
                {
                    Password = Base64Encode(Password);
                    var pass = Password;
                    var accCount = DataProvider.Ins.DB.TAIKHOANs.Where(item => item.USERNAME == UserName && item.PASSWORD == pass && item.ACTIVE).SingleOrDefault();
                    if (accCount != null)
                    {
                        if (Password == Base64Encode("1"))
                        {
                            Collapsed = "Visible";
                            RePassword = "";
                            Password = "";
                            IsCreateTK = true;
                            MessageBox.Show("Đây là lần đăng nhập lần đầu tiên nên hãy tạo mật khẩu mới và đăng nhập lại");

                            PasswordBox1.Password = string.Empty;
                            return;
                        }
                        else
                        {
                            Account = new Account(accCount.USERNAME, accCount.PASSWORD);
                            IsLogin = true;
                            p.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ");
                        return;
                    }
                }
            }
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