using QuanLyTraSua.DBConnection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyTraSua.ViewModel
{
    public partial class QuanLyTaiKhoanViewModel : BaseViewModel
    {
        public ICommand GetAllCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand LoadedQuanLyTaiKhoanWindowCommand { get; set; }
        public ICommand OnKeyUpTaiKhoanSearchCommand { get; set; }
        public ICommand ActiveCommand { get; set; }
        public ICommand InActiveCommand { get; set; }

        private ObservableCollection<Model.TAIKHOAN> _TaiKhoanList;
        public ObservableCollection<Model.TAIKHOAN> TaiKhoanList { get => _TaiKhoanList; set { _TaiKhoanList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.TAIKHOAN> _TempTaiKhoanList;
        public ObservableCollection<Model.TAIKHOAN> TempTaiKhoanList { get => _TempTaiKhoanList; set { _TempTaiKhoanList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.TAIKHOAN> _FullTaiKhoanList;
        public ObservableCollection<Model.TAIKHOAN> FullTaiKhoanList { get => _FullTaiKhoanList; set { _FullTaiKhoanList = value; OnPropertyChanged(); } }


        private Model.TAIKHOAN _SelectedItem;
        public Model.TAIKHOAN SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    USERNAME = SelectedItem.USERNAME;
                    ACTIVE = SelectedItem.ACTIVE.ToString();
                }
            }
        }

        private String _USERNAME;
        public String USERNAME { get => _USERNAME; set { _USERNAME = value; OnPropertyChanged(); } }

        private String _ACTIVE;
        public String ACTIVE { get => _ACTIVE; set { _ACTIVE = value; OnPropertyChanged(); } }



        public QuanLyTaiKhoanViewModel()
        {
            LoadedQuanLyTaiKhoanWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoadTaiKhoan(); });

            GetAllCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoadTaiKhoan(); });

            RefreshCommand = new RelayCommand<object>((p) => { return true; }, (p) => { RefreshTaiKhoan(); });

            ActiveCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null) { return false; }
                return true;
            }, (p) => { ActiveTaiKhoan(); });

            InActiveCommand = new RelayCommand<object>((p) => { return true; }, (p) => { InActiveTaiKhoan(); });

            OnKeyUpTaiKhoanSearchCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                try
                {
                    StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;
                    if (p != null && p.Text != "")
                    {
                        var listTemp = DataProvider.Ins.DB.TAIKHOANs;
                        TempTaiKhoanList.Clear();
                        foreach (var item in listTemp)
                        {
                            if (item.USERNAME.StartsWith(p.Text, comparison))
                            {
                                foreach (var prop in FullTaiKhoanList)
                                {
                                    if (item.USERNAME == prop.USERNAME)
                                    {
                                        TempTaiKhoanList.Add(prop);
                                    }
                                }
                            }
                        }
                        if (TempTaiKhoanList != null)
                        {
                            TaiKhoanList = TempTaiKhoanList;
                        }
                    }
                    else
                    {
                        LoadTaiKhoan();
                    }
                }
                catch  
                {
                    // bỏ qua lỗi null tham số
                }
            });

        }

        void ActiveTaiKhoan()
        {
            if (MessageBox.Show("Active Tài Khoản Này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            { 
                var itemTK = DataProvider.Ins.DB.TAIKHOANs.Where(i => i.USERNAME == SelectedItem.USERNAME).SingleOrDefault();
                if (itemTK.ACTIVE)
                {
                    MessageBox.Show("Tài khoản đang ACTIVE");
                    return;
                }
                if (itemTK != null)
                {
                    itemTK.ACTIVE = true;
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("ACTIVE tài khoản thành công");
                }
                RefreshTaiKhoan();
                LoadTaiKhoan();
            }
        }

        void InActiveTaiKhoan()
        {
            if (MessageBox.Show("InActive Tài Khoản Này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                var itemTK = DataProvider.Ins.DB.TAIKHOANs.Where(i => i.USERNAME == SelectedItem.USERNAME).SingleOrDefault();
                if (!itemTK.ACTIVE)
                {
                    MessageBox.Show("Tài khoản đang INACTIVE");
                    return;
                }
                if (itemTK != null)
                {
                    itemTK.ACTIVE = false;
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("INACTIVE tài khoản thành công");
                }
                RefreshTaiKhoan();
                LoadTaiKhoan();
            }
        }

        void RefreshTaiKhoan()
        {
            USERNAME = "";
            ACTIVE = "";
        }

        void LoadTaiKhoan()
        {
            TaiKhoanList = new ObservableCollection<Model.TAIKHOAN>();
            TempTaiKhoanList = new ObservableCollection<Model.TAIKHOAN>();
            FullTaiKhoanList = new ObservableCollection<Model.TAIKHOAN>();

            var listTaiKhoan = DataProvider.Ins.DB.TAIKHOANs;

            foreach (var item in listTaiKhoan)
            {
                var itemNV = DataProvider.Ins.DB.NHANVIENs.Where(i => i.USERNAME == item.USERNAME).SingleOrDefault();
                if(itemNV!= null && itemNV.CHUCVU == "Quản Lí")
                {
                    continue;
                }
                if(item.USERNAME == "admin")
                {
                    continue;
                }
                TaiKhoanList.Add(item);
                TempTaiKhoanList.Add(item);
                FullTaiKhoanList.Add(item);
            }
        }

        public static System.Boolean IsNumeric(System.Object Expression)
        {
            if (Expression == null || Expression is DateTime)
                return false;

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;

            try
            {
                if (Expression is string)
                    Double.Parse(Expression as string);
                else
                    Double.Parse(Expression.ToString());
                return true;
            }
            catch { } // just dismiss errors but return false
            return false;
        }
    }
}
