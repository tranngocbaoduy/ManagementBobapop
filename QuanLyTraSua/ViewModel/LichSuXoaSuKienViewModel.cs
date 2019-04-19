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
    public partial class LichSuXoaSuKienViewModel : BaseViewModel
    {
        public ICommand RestoreSKCommand { get; set; }
        public ICommand GetAllEventCommand { get; set; }
        public ICommand LoadedLichSuXoaSuKienWindowCommand { get; set; }
        public ICommand OnKeyUpSuKienSearchCommand { get; set; }

        private ObservableCollection<Event> _SuKienList;
        public ObservableCollection<Event> SuKienList { get => _SuKienList; set { _SuKienList = value; OnPropertyChanged(); } }

        private ObservableCollection<Event> _TempSuKienList;
        public ObservableCollection<Event> TempSuKienList { get => _TempSuKienList; set { _TempSuKienList = value; OnPropertyChanged(); } }

        private ObservableCollection<Event> _FullSuKienList;
        public ObservableCollection<Event> FullSuKienList { get => _FullSuKienList; set { _FullSuKienList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.LOAISUKIEN> _LoaiSuKienList;
        public ObservableCollection<Model.LOAISUKIEN> LoaiSuKienList { get => _LoaiSuKienList; set { _LoaiSuKienList = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _TenLoaiSuKienList;
        public ObservableCollection<String> TenLoaiSuKienList { get => _TenLoaiSuKienList; set { _TenLoaiSuKienList = value; OnPropertyChanged(); } }

        private String _SelectedLoaiSuKien { get; set; }
        public String SelectedLoaiSuKien { get => _SelectedLoaiSuKien; set { _SelectedLoaiSuKien = value; OnPropertyChanged(); } }

        private String _TENSK { get; set; }
        public String TENSK { get => _TENSK; set { _TENSK = value; OnPropertyChanged(); } }

        private String _DIEMTTEVENT { get; set; }
        public String DIEMTTEVENT { get => _DIEMTTEVENT; set { _DIEMTTEVENT = value; OnPropertyChanged(); } }

        private String _CONTENT { get; set; }
        public String CONTENT { get => _CONTENT; set { _CONTENT = value; OnPropertyChanged(); } }

        private String _GIAMGIAEVENT { get; set; }
        public String GIAMGIAEVENT { get => _GIAMGIAEVENT; set { _GIAMGIAEVENT = value; OnPropertyChanged(); } }

        private Model.Event _SelectedItemSuKien;
        public Model.Event SelectedItemSuKien
        {
            get => _SelectedItemSuKien;
            set
            {
                _SelectedItemSuKien = value; OnPropertyChanged();
                if (SelectedItemSuKien != null)
                {
                    if (SelectedItemSuKien.SUKIEN != null)
                    {
                        TENSK = SelectedItemSuKien.SUKIEN.TENSK;
                        DIEMTTEVENT = SelectedItemSuKien.SUKIEN.DIEMTT.ToString();
                        GIAMGIAEVENT = SelectedItemSuKien.SUKIEN.GIAMGIA;
                        CONTENT = SelectedItemSuKien.SUKIEN.NDSUKIEN;
                        SelectedLoaiSuKien = TenLoaiSuKienList.Where(i => i == SelectedItemSuKien.TENLSK).SingleOrDefault();
                    }

                }
            }
        }

        public LichSuXoaSuKienViewModel()
        {
            LoadedLichSuXoaSuKienWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoadLichSuSuKien(); });

            GetAllEventCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoadLichSuSuKien(); });

            RestoreSKCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItemSuKien == null) { return false; }
                if (SelectedItemSuKien.SUKIEN == null) { return false; }
                return true;
            }, (p) => { RestoreSuKien(); });

            OnKeyUpSuKienSearchCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                try
                {
                    StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;
                    if (p != null && p.Text != "")
                    {
                        var listTemp = FullSuKienList;
                        TempSuKienList.Clear();
                        foreach (var item in listTemp)
                        {
                            if (item.SUKIEN.TENSK.StartsWith(p.Text, comparison))
                            {
                                TempSuKienList.Add(item);
                            }
                        }
                        if (TempSuKienList != null)
                        {
                            SuKienList = TempSuKienList;
                        }
                    }
                    else
                    {
                        LoadLichSuSuKien();
                    }
                }
                catch 
                {
                    // bỏ qua lỗi null tham số
                }
            });


        }

        void RestoreSuKien()
        {
            if (MessageBox.Show("Restore Sự Kiện Này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                var itemKH = DataProvider.Ins.DB.SUKIENs.Where(i => i.MASK == SelectedItemSuKien.SUKIEN.MASK).SingleOrDefault();
                if (itemKH != null)
                {
                    itemKH.ACTIVE = true;
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Restore Sự Kiện Thành Công");
                }
                LoadLichSuSuKien();
            }
        }

        void LoadLichSuSuKien()
        {
            LoaiSuKienList = new ObservableCollection<Model.LOAISUKIEN>();

            SuKienList = new ObservableCollection<Event>();
            TempSuKienList = new ObservableCollection<Event>();
            FullSuKienList = new ObservableCollection<Event>();

            TenLoaiSuKienList = new ObservableCollection<String>();

            var listSuKien = DataProvider.Ins.DB.SUKIENs;
            var listLoaiSuKien = DataProvider.Ins.DB.LOAISUKIENs;

            foreach (var item in listLoaiSuKien)
            {
                if (item.ACTIVE == true)
                {
                    LoaiSuKienList.Add(item);
                    TenLoaiSuKienList.Add(item.TENLSK);
                }
            }

            foreach (var item in listSuKien)
            {
                if (item.ACTIVE == false)
                {
                    Event temp = new Event();
                    temp.SUKIEN = item;
                    foreach (var sukien in listLoaiSuKien)
                    {
                        if (item.MLSK == sukien.MLSK)
                        {
                            temp.TENLSK = sukien.TENLSK;
                            break;
                        }
                    }
                    SuKienList.Add(temp);
                    TempSuKienList.Add(temp);
                    FullSuKienList.Add(temp);
                }
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
