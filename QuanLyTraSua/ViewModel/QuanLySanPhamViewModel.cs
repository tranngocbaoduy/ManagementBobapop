using QuanLyTraSua.DBConnection;
using QuanLyTraSua.Model;
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
    public partial class QuanLySanPhamViewModel : BaseViewModel
    {

        public ICommand LoadedQuanLySanPhamWindowCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand GetAllCommand { get; set; }
        public ICommand LichSuXoaSanPhamCommand { get; set; }
        public ICommand OnKeyUpCommand { get; set; }
        public ICommand AddLMHCommand { get; set; }
        public ICommand DeleteLMHCommand { get; set; }
        public ICommand RestoreCommand { get; set; }
        public ICommand OnKeyUpThemLoaiMatHangCommand { get; set; }

        private ObservableCollection<Model.MATHANG> _SanPhamList;
        public ObservableCollection<Model.MATHANG> SanPhamList { get => _SanPhamList; set { _SanPhamList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.MATHANG> _TempSanPhamList;
        public ObservableCollection<Model.MATHANG> TempSanPhamList { get => _TempSanPhamList; set { _TempSanPhamList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.MATHANG> _FullSanPhamList;
        public ObservableCollection<Model.MATHANG> FullSanPhamList { get => _FullSanPhamList; set { _FullSanPhamList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.LOAIMATHANG> _LoaiSanPhamList;
        public ObservableCollection<Model.LOAIMATHANG> LoaiSanPhamList { get => _LoaiSanPhamList; set { _LoaiSanPhamList = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _TenLoaiSanPhamList;
        public ObservableCollection<String> TenLoaiSanPhamList { get => _TenLoaiSanPhamList; set { _TenLoaiSanPhamList = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _SizeList;
        public ObservableCollection<String> SizeList { get => _SizeList; set { _SizeList = value; OnPropertyChanged(); } }

        private Model.MATHANG _SelectedSanPham;
        public Model.MATHANG SelectedSanPham
        {
            get => _SelectedSanPham; set
            {
                _SelectedSanPham = value; OnPropertyChanged();
                if (SelectedSanPham != null)
                {
                    MSMH = SelectedSanPham.MSMH.ToString();
                    TENMH = SelectedSanPham.TENMH;
                    SIZE = SelectedSanPham.SIZE.Trim();
                    TENLMH = DataProvider.Ins.DB.LOAIMATHANGs.Where(i => i.MSLMH == SelectedSanPham.MSLMH).SingleOrDefault().TENLMH;
                    GIABAN = String.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:c}", SelectedSanPham.GIABAN);
                }
            }
        }

        private Model.LOAIMATHANG _SelectedLoaiSanPham;
        public Model.LOAIMATHANG SelectedLoaiSanPham
        {
            get => _SelectedLoaiSanPham; set
            {
                _SelectedLoaiSanPham = value; OnPropertyChanged();
                if (SelectedLoaiSanPham != null)
                {
                    LoadSanPham(SelectedLoaiSanPham.MSLMH);
                    ThemLoaiMatHang = SelectedLoaiSanPham.TENLMH;
                }
            }
        }

        private String _SelectedTenLoaiSanPham;
        public String SelectedTenLoaiSanPham { get => _SelectedTenLoaiSanPham; set { _SelectedTenLoaiSanPham = value; OnPropertyChanged(); } }

        private String _SelectedSize;
        public String SelectedSize { get => _SelectedSize; set { _SelectedSize = value; OnPropertyChanged(); } }

        private String _MSMH;
        public String MSMH { get => _MSMH; set { _MSMH = value; OnPropertyChanged(); } }
        private String _TENMH;
        public String TENMH { get => _TENMH; set { _TENMH = value; OnPropertyChanged(); } }
        private String _TENLMH;
        public String TENLMH { get => _TENLMH; set { _TENLMH = value; OnPropertyChanged(); } }
        private String _SIZE;
        public String SIZE { get => _SIZE; set { _SIZE = value; OnPropertyChanged(); } }
        private String _GIABAN;
        public String GIABAN { get => _GIABAN; set { _GIABAN = value; OnPropertyChanged(); } }
        private String _ThemLoaiMatHang;
        public String ThemLoaiMatHang { get => _ThemLoaiMatHang; set { _ThemLoaiMatHang = value; OnPropertyChanged(); } }
        private String _CollapsedButton = "Visible";
        public String CollapsedButton { get => _CollapsedButton; set { _CollapsedButton = value; OnPropertyChanged(); } }
        private String _CollapsedRestore = "Collapsed";
        public String CollapsedRestore { get => _CollapsedRestore; set { _CollapsedRestore = value; OnPropertyChanged(); } }


        public QuanLySanPhamViewModel()
        {
            LoadedQuanLySanPhamWindowCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { LoadLoaiSanPham(); LoadSanPham(); });

            OnKeyUpThemLoaiMatHangCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if (p != null && p.Text != "")
                { ThemLoaiMatHang = p.Text; }
            });

            OnKeyUpCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                try
                {
                    StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;
                    if (p != null && p.Text != "")
                    {
                        var listTemp = DataProvider.Ins.DB.MATHANGs;
                        TempSanPhamList.Clear();
                        foreach (var item in listTemp)
                        {
                            if (item.TENMH.StartsWith(p.Text, comparison))
                            {
                                foreach (var prop in FullSanPhamList)
                                {
                                    if (item.MSMH == prop.MSMH)
                                    {
                                        TempSanPhamList.Add(prop);
                                    }
                                }
                            }
                        }
                        if (TempSanPhamList != null)
                        {
                            SanPhamList = TempSanPhamList;
                        }
                    }
                    else
                    {
                        if (CollapsedRestore == "Visible")
                        {
                            LoadSanPhamDaXoa();
                        }
                        else
                        {
                            LoadSanPham();
                        }
                    }
                }
                catch 
                {
                    // bỏ qua lỗi null tham số
                }
            });

            AddCommand = new RelayCommand<Object>((p) =>
            {
                if (string.IsNullOrEmpty(TENMH)) { return false; }
                if (string.IsNullOrEmpty(GIABAN)) { return false; }
                if (string.IsNullOrEmpty(TENLMH)) { return false; }
                if (!IsNumeric(GIABAN)) { return false; }
                return true;
            }, (p) => { AddSanPham(); });

            DeleteCommand = new RelayCommand<Object>((p) =>
            {
                if (string.IsNullOrEmpty(MSMH)) { return false; }
                if (string.IsNullOrEmpty(TENMH)) { return false; }
                if (string.IsNullOrEmpty(GIABAN)) { return false; }
                if (string.IsNullOrEmpty(TENLMH)) { return false; }

                int MSMatHang = Int32.Parse(MSMH);

                var itemMH = DataProvider.Ins.DB.CHITIETHOADONs.Where(i => i.MSMH == MSMatHang).ToList();
                if (itemMH.Count() > 0)
                {
                    return false;
                }

                return true;
            }, (p) => { DeleteSanPham(); });

            RestoreCommand = new RelayCommand<Object>((p) =>
            {
                if (string.IsNullOrEmpty(MSMH)) { return false; }
                if (string.IsNullOrEmpty(TENMH)) { return false; }
                if (string.IsNullOrEmpty(GIABAN)) { return false; }
                if (string.IsNullOrEmpty(TENLMH)) { return false; }

                int MSMatHang = Int32.Parse(MSMH);

                var itemMH = DataProvider.Ins.DB.MATHANGs.Where(i => i.MSMH == MSMatHang && i.ACTIVE).ToList();
                if (itemMH.Count() > 0)
                {
                    return false;
                }
                return true;
            }, (p) => { RestoreSanPham(); });

            UpdateCommand = new RelayCommand<Object>((p) =>
            {
                if (string.IsNullOrEmpty(MSMH)) { return false; }
                if (string.IsNullOrEmpty(TENMH)) { return false; }
                if (string.IsNullOrEmpty(GIABAN)) { return false; }
                if (string.IsNullOrEmpty(TENLMH)) { return false; }

                return true;
            }, (p) => { UpdateSanPham(); });

            RefreshCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { RefreshSanPham(); });

            GetAllCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { CollapsedButton = "Visible"; CollapsedRestore = "Collapsed"; RefreshSanPham(); LoadLoaiSanPham(); LoadSanPham(); });

            LichSuXoaSanPhamCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { CollapsedButton = "Collapsed"; CollapsedRestore = "Visible"; LoadSanPhamDaXoa(); });

            AddLMHCommand = new RelayCommand<Object>((p) =>
            {
                if (string.IsNullOrEmpty(ThemLoaiMatHang)) { return false; }
                var itemLMH = DataProvider.Ins.DB.LOAIMATHANGs.Where(i => i.TENLMH == ThemLoaiMatHang).SingleOrDefault();
                if (itemLMH != null) { return false; }
                return true;
            }, (p) => { AddLoaiMatHang(); });
            try
            {
                DeleteLMHCommand = new RelayCommand<Object>((p) =>
            {
                if (string.IsNullOrEmpty(ThemLoaiMatHang)) { return false; }

                if (SelectedLoaiSanPham != null)
                {
                    var itemSelectedLMH = SelectedLoaiSanPham.MSLMH;
                }

                var listMatHang = DataProvider.Ins.DB.MATHANGs.Where(i => i.ACTIVE && i.MSLMH == SelectedLoaiSanPham.MSLMH);
                if (listMatHang != null) { return false; }
                return true;

            }, (p) => { DeleteLoaiMatHang(); });
            }
            catch { }
        }

        void AddLoaiMatHang()
        {
            if (MessageBox.Show("Thêm Loại Mặt Hàng Này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                Model.LOAIMATHANG newLMH = new Model.LOAIMATHANG();
                newLMH.TENLMH = ThemLoaiMatHang;
                newLMH.ACTIVE = true;
                DataProvider.Ins.DB.LOAIMATHANGs.Add(newLMH);
                DataProvider.Ins.DB.SaveChanges();
                RefreshSanPham();
                LoadLoaiSanPham(); LoadSanPham();
            }
        }

        void DeleteLoaiMatHang()
        {
            if (MessageBox.Show("Xoá Loại Mặt Hàng Này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                var itemLMH = DataProvider.Ins.DB.LOAIMATHANGs.Where(i => i.MSLMH == SelectedLoaiSanPham.MSLMH).SingleOrDefault();
                if (itemLMH == null) { MessageBox.Show("Vui lòng chọn Loại mặt hàng trong bảng"); return; }

                itemLMH.ACTIVE = false;
                DataProvider.Ins.DB.SaveChanges();
                LoadLoaiSanPham(); RefreshSanPham();
                LoadSanPham();
            }
        }

        void AddSanPham()
        {
            if (MessageBox.Show("Thêm Mặt Hàng Này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                Model.MATHANG newMH = new Model.MATHANG();
                newMH.TENMH = TENMH;
                if (string.IsNullOrEmpty(SIZE))
                {
                    newMH.SIZE = "";
                }
                else
                {
                    newMH.SIZE = SIZE.Trim();
                }
                newMH.GIABAN = (int)Int32.Parse(GIABAN);
                newMH.MSLMH = DataProvider.Ins.DB.LOAIMATHANGs.Where(i => i.TENLMH == TENLMH).SingleOrDefault().MSLMH;
                newMH.ACTIVE = true;
                DataProvider.Ins.DB.MATHANGs.Add(newMH);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Thêm Mặt Hàng Thành Công");
                LoadSanPham();
                RefreshSanPham();
            }
        }

        void DeleteSanPham()
        {
            if (MessageBox.Show("Xoá Mặt Hàng Này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                int MSMatHang = (int)Int32.Parse(MSMH);
                var itemMH = DataProvider.Ins.DB.MATHANGs.Where(i => i.MSMH == MSMatHang).SingleOrDefault();
                itemMH.ACTIVE = false;
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Xoá Mặt Hàng Thành Công");
                LoadSanPham();
                RefreshSanPham();
            }
        }

        void RestoreSanPham()
        {
            if (MessageBox.Show("Restore Mặt Hàng Này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                int MSMatHang = (int)Int32.Parse(MSMH);
                var itemMH = DataProvider.Ins.DB.MATHANGs.Where(i => i.MSMH == MSMatHang).SingleOrDefault();
                itemMH.ACTIVE = true;
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Restore Mặt Hàng Thành Công");
                LoadSanPhamDaXoa();
                RefreshSanPham();
            }
        }

        void UpdateSanPham()
        {
            if (MessageBox.Show("Cập Nhật Mặt Hàng Này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                var itemMH = DataProvider.Ins.DB.MATHANGs.Where(i => i.MSMH == (int)Int32.Parse(MSMH)).SingleOrDefault();
                itemMH.TENMH = TENMH;
                if (string.IsNullOrEmpty(SIZE))
                {
                    itemMH.SIZE = "";
                }
                else
                {
                    itemMH.SIZE = SIZE.Trim();
                }
                itemMH.GIABAN = (int)Int32.Parse(GIABAN);
                itemMH.MSLMH = DataProvider.Ins.DB.LOAIMATHANGs.Where(i => i.TENLMH == TENLMH).SingleOrDefault().MSLMH;

                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Cập Nhật Mặt Hàng Thành Công");
                LoadSanPham();
                RefreshSanPham();
            }
        }

        void RefreshSanPham()
        {
            TENMH = "";
            MSMH = "";
            TENLMH = "";
            GIABAN = "";
            SIZE = "";
            SelectedTenLoaiSanPham = "";
            SelectedSize = "";
            ThemLoaiMatHang = "";
        }

        void LoadLoaiSanPham()
        {
            LoaiSanPhamList = new ObservableCollection<Model.LOAIMATHANG>();
            TenLoaiSanPhamList = new ObservableCollection<String>();
            SizeList = new ObservableCollection<String>();

            SizeList.Add("S");
            SizeList.Add("M");

            var listLoaiSanPham = DataProvider.Ins.DB.LOAIMATHANGs.Where(i => i.ACTIVE);
            foreach (var item in listLoaiSanPham)
            {
                TenLoaiSanPhamList.Add(item.TENLMH);
                LoaiSanPhamList.Add(item);
            }
        }

        void LoadSanPham()
        {
            SanPhamList = new ObservableCollection<Model.MATHANG>();
            TempSanPhamList = new ObservableCollection<Model.MATHANG>();
            FullSanPhamList = new ObservableCollection<Model.MATHANG>();
            var listMatHang = DataProvider.Ins.DB.MATHANGs.Where(i => i.ACTIVE);
            foreach (var item in listMatHang)
            {
                SanPhamList.Add(item);
                TempSanPhamList.Add(item);
                FullSanPhamList.Add(item);
            }
        }

        void LoadSanPhamDaXoa()
        {
            SanPhamList = new ObservableCollection<Model.MATHANG>();
            TempSanPhamList = new ObservableCollection<Model.MATHANG>();
            FullSanPhamList = new ObservableCollection<Model.MATHANG>();
            var listMatHang = DataProvider.Ins.DB.MATHANGs.Where(i => !i.ACTIVE);
            foreach (var item in listMatHang)
            {
                SanPhamList.Add(item);
                TempSanPhamList.Add(item);
                FullSanPhamList.Add(item);
            }
        }

        void LoadSanPham(int MaLMH)
        {
            SanPhamList = new ObservableCollection<Model.MATHANG>();
            TempSanPhamList = new ObservableCollection<Model.MATHANG>();
            FullSanPhamList = new ObservableCollection<Model.MATHANG>();
            var listMatHang = DataProvider.Ins.DB.MATHANGs.Where(i => i.ACTIVE && i.MSLMH == MaLMH);
            foreach (var item in listMatHang)
            {
                SanPhamList.Add(item);
                TempSanPhamList.Add(item);
                FullSanPhamList.Add(item);
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
