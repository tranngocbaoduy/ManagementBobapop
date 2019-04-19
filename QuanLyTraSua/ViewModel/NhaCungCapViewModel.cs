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
    public partial class NhaCungCapViewModel : BaseViewModel
    {

        public ICommand LoadedNhaCungCapWindowCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand OnKeyUpCommand { get; set; }

        private ObservableCollection<Model.NHACUNGCAP> _NhaCungCapList;
        public ObservableCollection<Model.NHACUNGCAP> NhaCungCapList { get => _NhaCungCapList; set { _NhaCungCapList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.NHACUNGCAP> _TempNhaCungCapList;
        public ObservableCollection<Model.NHACUNGCAP> TempNhaCungCapList { get => _TempNhaCungCapList; set { _TempNhaCungCapList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.NHACUNGCAP> _FullNhaCungCapList;
        public ObservableCollection<Model.NHACUNGCAP> FullNhaCungCapList { get => _FullNhaCungCapList; set { _FullNhaCungCapList = value; OnPropertyChanged(); } }

        private Model.NHACUNGCAP _SelectedNhaCungCap;
        public Model.NHACUNGCAP SelectedNhaCungCap { get => _SelectedNhaCungCap; set { _SelectedNhaCungCap = value; OnPropertyChanged(); } }


        private String _TENNHACUNGCAP;
        public String TENNHACUNGCAP { get => _TENNHACUNGCAP; set { _TENNHACUNGCAP = value; OnPropertyChanged(); } }

        private String _EMAIL;
        public String EMAIL { get => _EMAIL; set { _EMAIL = value; OnPropertyChanged(); } }

        private String _DIACHI;
        public String DIACHI { get => _DIACHI; set { _DIACHI = value; OnPropertyChanged(); } }

        private String _SDT;
        public String SDT { get => _SDT; set { _SDT = value; OnPropertyChanged(); } }

        private Model.NHACUNGCAP _SelectedItem;
        public Model.NHACUNGCAP SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    TENNHACUNGCAP = SelectedItem.TENNCC;
                    DIACHI = SelectedItem.DIACHI;
                    SDT = SelectedItem.SDT;
                    EMAIL = SelectedItem.EMAIL;
                }
            }
        } 

        public NhaCungCapViewModel()
        {
            LoadedNhaCungCapWindowCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { LoadNhaCungCap(); });

            OnKeyUpCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                try
                {
                    StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;
                    if (p != null && p.Text != "")
                    {
                        var listTemp = DataProvider.Ins.DB.NHACUNGCAPs;
                        TempNhaCungCapList.Clear();
                        foreach (var item in listTemp)
                        {
                            if (item.TENNCC.StartsWith(p.Text, comparison))
                            {
                                foreach (var prop in FullNhaCungCapList)
                                {
                                    if (item.MSNCC == prop.MSNCC)
                                    {
                                        TempNhaCungCapList.Add(prop);
                                    }
                                }
                            }
                        }
                        if (TempNhaCungCapList != null)
                        {
                            NhaCungCapList = TempNhaCungCapList;
                        }
                    }
                    else
                    {
                        LoadNhaCungCap();
                    }
                }
                catch 
                {
                    // bỏ qua lỗi null tham số
                }
            });

            AddCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { AddNhaCungCap(); });

            DeleteCommand = new RelayCommand<Object>((p) =>
            {
                if (string.IsNullOrEmpty(TENNHACUNGCAP)) { return false; }
                if (string.IsNullOrEmpty(DIACHI)) { return false; }
                if (string.IsNullOrEmpty(EMAIL)) { return false; }
                if (string.IsNullOrEmpty(SDT)) { return false; }

                return true;
            }, (p) => { DeleteNhaCungCap(); });

            UpdateCommand = new RelayCommand<Object>((p) =>
            {
                if (string.IsNullOrEmpty(TENNHACUNGCAP)) { return false; }
                if (string.IsNullOrEmpty(DIACHI)) { return false; }
                if (string.IsNullOrEmpty(EMAIL)) { return false; }
                if (string.IsNullOrEmpty(SDT)) { return false; }
                if (SelectedItem == null) { return false; }
                return true;
            }, (p) => { UpdateNhaCungCap(); });

            RefreshCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { Refresh(); });

        }

        void AddNhaCungCap()
        {
            if (!ValidateNhaCungCap()) return;
            if (MessageBox.Show("Thêm Nhà Cung Cấp Này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                var newNhaCungCap = new Model.NHACUNGCAP()
                {
                    TENNCC = TENNHACUNGCAP,
                    DIACHI = DIACHI,
                    SDT = SDT,
                    EMAIL = EMAIL,
                    ACTIVE = true,
                };
                DataProvider.Ins.DB.NHACUNGCAPs.Add(newNhaCungCap);
                DataProvider.Ins.DB.SaveChanges();
                NhaCungCapList.Add(newNhaCungCap);
                Refresh();
                MessageBox.Show("Thêm Nhà Cung Cấp Thành Công");
            }
        }

        void DeleteNhaCungCap()
        {
            if (MessageBox.Show("Xoá Nhà Cung Cấp Này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                var item = NhaCungCapList.Where(x => x.MSNCC == SelectedItem.MSNCC).SingleOrDefault();
                if (item != null)
                {
                    DataProvider.Ins.DB.NHACUNGCAPs.Remove(item);
                    DataProvider.Ins.DB.SaveChanges();
                    NhaCungCapList.RemoveAt(NhaCungCapList.IndexOf(item));
                }
                Refresh();
                MessageBox.Show("Xoá Nhà Cung Cấp Thành Công");
            }
        }

        void UpdateNhaCungCap()
        {
            if (MessageBox.Show("Bạn Muốn Cập Nhật?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                var item = NhaCungCapList.Where(x => x.MSNCC == SelectedItem.MSNCC).SingleOrDefault();
                if (item != null)
                {
                    item.TENNCC = TENNHACUNGCAP;
                    item.DIACHI = DIACHI;
                    item.EMAIL = EMAIL;
                    item.SDT = SDT;
                    DataProvider.Ins.DB.SaveChanges();
                }
                SelectedItem.TENNCC = TENNHACUNGCAP;
                SelectedItem.DIACHI = DIACHI;
                SelectedItem.EMAIL = EMAIL;
                SelectedItem.SDT = SDT; 
                Refresh();
                MessageBox.Show("Cập Nhật Nhà Cung Cấp Thành Công");
            }
        }

        void Refresh()
        {
            TENNHACUNGCAP = "";
            DIACHI = "";
            SDT = "";
            EMAIL = "";
        }

        bool ValidateNhaCungCap()
        {
            if (string.IsNullOrEmpty(TENNHACUNGCAP))
            {
                MessageBox.Show("Tên Nhà Cung Cấp không được để trống");
                return false;
            }
            if (string.IsNullOrEmpty(DIACHI))
            {
                MessageBox.Show("Địa chỉ Nhà Cung Cấpkhông được để trống");
                return false;
            }
            if (string.IsNullOrEmpty(SDT))
            {
                MessageBox.Show("SDT Nhà Cung Cấpkhông được để trống");
                return false;
            }
            if (string.IsNullOrEmpty(EMAIL))
            {
                MessageBox.Show("Email Nhà Cung Cấpkhông được để trống");
                return false;
            }
            var temp = NhaCungCapList.Where(i => i.SDT == SDT);
            if (temp.Count() != 0 || temp == null)
            {
                MessageBox.Show("Sđt không được trùng với nhà cung cấp khác");
                return false;
            }
            return true;
        }

        void LoadNhaCungCap()
        {
            NhaCungCapList = new ObservableCollection<Model.NHACUNGCAP>();
            FullNhaCungCapList = new ObservableCollection<Model.NHACUNGCAP>();
            TempNhaCungCapList = new ObservableCollection<Model.NHACUNGCAP>();
            var listNhaCunCap = DataProvider.Ins.DB.NHACUNGCAPs;
            foreach (var item in listNhaCunCap)
            {
                NhaCungCapList.Add(item);
            }
            FullNhaCungCapList = NhaCungCapList;
        }

    }
}
