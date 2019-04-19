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
    public partial class KhachHangViewModel : BaseViewModel
    {
        public ICommand LoadedKhachHangWindowCommand { get; set; }
        public ICommand AddKHCommand { get; set; }
        public ICommand DeleteKHCommand { get; set; }
        public ICommand RefreshKHCommand { get; set; }
        public ICommand UpdateKHCommand { get; set; }
        public ICommand AddEventCommand { get; set; }
        public ICommand DeleteEventCommand { get; set; }
        public ICommand RefreshEventCommand { get; set; }
        public ICommand UpdateEventCommand { get; set; }
        public ICommand OnKeyUpSDTKhachHangCommand { get; set; }
        public ICommand GetAllKHCommand { get; set; }
        public ICommand GetAllEventCommand { get; set; }
        public ICommand KhachHangTiemNangCommand { get; set; }
        public ICommand SuKienTiemNangCommand { get; set; }
        public ICommand OnKeyUpKhachHangSearchCommand { get; set; }
        public ICommand OnKeyUpSuKienSearchCommand { get; set; }
        public ICommand LishSuXoaKHCommand { get; set; }
        public ICommand LishSuXoaSKCommand { get; set; }

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

        private ObservableCollection<String> _TenSuKienList;
        public ObservableCollection<String> TenSuKienList { get => _TenSuKienList; set { _TenSuKienList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.KHACHHANG> _KhachHangList;
        public ObservableCollection<Model.KHACHHANG> KhachHangList { get => _KhachHangList; set { _KhachHangList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.KHACHHANG> _TempKhachHangList;
        public ObservableCollection<Model.KHACHHANG> TempKhachHangList { get => _TempKhachHangList; set { _TempKhachHangList = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.KHACHHANG> _FullKhachHangList;
        public ObservableCollection<Model.KHACHHANG> FullKhachHangList { get => _FullKhachHangList; set { _FullKhachHangList = value; OnPropertyChanged(); } }

        private String _SelectedItemSuKienKH;
        public String SelectedItemSuKienKH { get => _SelectedItemSuKienKH; set { _SelectedItemSuKienKH = value; OnPropertyChanged(); } }

        private String _SDTKH { get; set; }
        public String SDTKH { get => _SDTKH; set { _SDTKH = value; OnPropertyChanged(); } }

        private String _SearchEvent = "";
        public String SearchEvent { get => _SearchEvent; set { _SearchEvent = value; OnPropertyChanged(); } }

        private String _SearchKH = "";
        public String SearchKH { get => _SearchKH; set { _SearchKH = value; OnPropertyChanged(); } }

        private String _TENKH { get; set; }
        public String TENKH { get => _TENKH; set { _TENKH = value; OnPropertyChanged(); } }

        private String _DIEMTT { get; set; }
        public String DIEMTT { get => _DIEMTT; set { _DIEMTT = value; OnPropertyChanged(); } }

        private String _GIAMGIA { get; set; }
        public String GIAMGIA { get => _GIAMGIA; set { _GIAMGIA = value; OnPropertyChanged(); } }

        private String _DIACHI { get; set; }
        public String DIACHI { get => _DIACHI; set { _DIACHI = value; OnPropertyChanged(); } }

        private String _EMAIL { get; set; }
        public String EMAIL { get => _EMAIL; set { _EMAIL = value; OnPropertyChanged(); } }

        private String _TENSK { get; set; }
        public String TENSK { get => _TENSK; set { _TENSK = value; OnPropertyChanged(); } }

        private String _DIEMTTEVENT { get; set; }
        public String DIEMTTEVENT { get => _DIEMTTEVENT; set { _DIEMTTEVENT = value; OnPropertyChanged(); } }

        private String _CONTENT { get; set; }
        public String CONTENT { get => _CONTENT; set { _CONTENT = value; OnPropertyChanged(); } }

        private String _GIAMGIAEVENT { get; set; }
        public String GIAMGIAEVENT { get => _GIAMGIAEVENT; set { _GIAMGIAEVENT = value; OnPropertyChanged(); } }

        private String _SelectedLoaiSuKien { get; set; }
        public String SelectedLoaiSuKien { get => _SelectedLoaiSuKien; set { _SelectedLoaiSuKien = value; OnPropertyChanged(); } }

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
        private Model.KHACHHANG _SelectedItemKhachHang;
        public Model.KHACHHANG SelectedItemKhachHang
        {
            get => _SelectedItemKhachHang; set
            {
                _SelectedItemKhachHang = value; OnPropertyChanged();
                if (SelectedItemKhachHang != null)
                {
                    SDTKH = SelectedItemKhachHang.SDT;
                    TENKH = SelectedItemKhachHang.TENKH;
                    DIEMTT = SelectedItemKhachHang.DIEMTT.ToString();
                     
                    if (SelectedItemKhachHang.DIEMTT > 100 && SelectedItemKhachHang.DIEMTT <= 1000)
                    {
                        GIAMGIA = "5 %";
                    }
                    else if (SelectedItemKhachHang.DIEMTT > 1000 && SelectedItemKhachHang.DIEMTT <= 5000)
                    {
                        GIAMGIA = "10 %";
                    }
                    else if (SelectedItemKhachHang.DIEMTT > 5000 && SelectedItemKhachHang.DIEMTT <= 10000)
                    {
                        GIAMGIA = "12 %";
                    }
                    else if (SelectedItemKhachHang.DIEMTT > 10000 && SelectedItemKhachHang.DIEMTT <= 100000)
                    {
                        GIAMGIA = "15 %";
                    }
                    else if (SelectedItemKhachHang.DIEMTT > 100000)
                    {
                        GIAMGIA = "17 %";
                    }
                    else
                    {
                        GIAMGIA = "0 %";
                    }
                }
            }
        }

        public KhachHangViewModel()
        {
            LoadedKhachHangWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { if (p != null) { LoadKhachHang(); LoadSuKien(); } });

            GetAllEventCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoadSuKien(); RefreshEvent(); });

            SuKienTiemNangCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoadSuKienTiemNang(); RefreshEvent(); });

            GetAllKHCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoadKhachHang(); RefreshKhachHang(); });

            KhachHangTiemNangCommand = new RelayCommand<object>((p) => { return true; }, (p) => { LoadKhachHangTiemNang(); RefreshKhachHang(); });

            LishSuXoaKHCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LichSuXoaKhachHang LichSuXoaKHForm = new LichSuXoaKhachHang();
                LichSuXoaKHForm.ShowDialog();
                LoadKhachHang();
            });

            LishSuXoaSKCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LichSuXoaSuKien LichSuXoaSKForm = new LichSuXoaSuKien();
                LichSuXoaSKForm.ShowDialog();
                LoadSuKien();
            });

            OnKeyUpSDTKhachHangCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                try
                {
                    StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;
                    if (p != null && p.Text != "")
                    {
                        if (!IsNumeric(p.Text))
                        {
                            MessageBox.Show("Bạn phải nhập số "); p.Text = "";
                            return;
                        }
                        var listTemp = DataProvider.Ins.DB.KHACHHANGs;
                        foreach (var item in listTemp)
                        {
                            if (item.SDT.StartsWith(p.Text, comparison))
                            {
                                SDTKH = p.Text;
                                TENKH = item.TENKH;
                                DIEMTT = item.DIEMTT.ToString();
                                DIACHI = item.DIACHI;
                                EMAIL = item.EMAIL;
                                if (SelectedItemKhachHang != null)
                                {
                                    if (SelectedItemKhachHang.DIEMTT > 100)
                                    {
                                        GIAMGIA = "5 %";
                                    }
                                    else if (SelectedItemKhachHang.DIEMTT > 1000)
                                    {
                                        GIAMGIA = "10 %";
                                    }
                                    else if (SelectedItemKhachHang.DIEMTT > 5000)
                                    {
                                        GIAMGIA = "12 %";
                                    }
                                    else if (SelectedItemKhachHang.DIEMTT > 10000)
                                    {
                                        GIAMGIA = "15 %";
                                    }
                                    else
                                    {
                                        GIAMGIA = "0 %";
                                    }
                                }
                                break;
                            }
                            else
                            {
                                TENKH = "";
                                DIEMTT = "";
                                GIAMGIA = "";
                                DIACHI = "";
                                EMAIL = "";
                            }
                        }
                    }
                    else
                    {
                        TENKH = "";
                        DIEMTT = "";
                        GIAMGIA = "";
                        DIACHI = "";
                        EMAIL = "";
                    }
                }
                catch  
                {
                    // bỏ qua lỗi null tham số
                }
            });

            OnKeyUpKhachHangSearchCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                try
                {
                    StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;
                    if (p != null && p.Text != "")
                    {
                        if (!IsNumeric(p.Text))
                        {
                            MessageBox.Show("Bạn phải nhập số "); p.Text = "";
                            return;
                        }
                        var listTemp = DataProvider.Ins.DB.KHACHHANGs;
                        TempKhachHangList.Clear();
                        foreach (var item in listTemp)
                        {
                            if (item.SDT.StartsWith(p.Text, comparison))
                            {
                                foreach (var prop in FullKhachHangList)
                                {
                                    if (item.SDT == prop.SDT)
                                    {
                                        TempKhachHangList.Add(prop);
                                    }
                                }
                            }
                        }
                        if (TempKhachHangList != null)
                        {
                            KhachHangList = TempKhachHangList;
                        }
                    }
                    else
                    {
                        LoadKhachHang();
                    }
                }
                catch  
                {
                    // bỏ qua lỗi null tham số
                }
            });

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
                        LoadSuKien();
                    }
                }
                catch  
                {
                    // bỏ qua lỗi null tham số
                }
            });

            AddKHCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(SDTKH)) { return false; }
                if (string.IsNullOrEmpty(TENKH)) { return false; }
                var itemSK = DataProvider.Ins.DB.SUKIENs.Where(i => i.TENSK == SelectedItemSuKienKH).SingleOrDefault();
                var itemKH = DataProvider.Ins.DB.KHACHHANGs.Where(i => i.SDT == SDTKH).SingleOrDefault();
                if (itemKH != null) { return false; }
                if (itemSK != null)
                {
                    if ((int)Int32.Parse(itemSK.GIAMGIA) > 0 && SelectedItemSuKienKH != "") // Giam gia theo tien
                    {
                        SelectedItemSuKienKH = TenSuKienList[0];
                        MessageBox.Show("Khi tạo mới chỉ là những sự kiện tăng điểm TT");
                        return false;
                    }
                }
                return true;
            }, (p) => { AddKhachHang(); });

            DeleteKHCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(SDTKH)) { return false; }
                if (string.IsNullOrEmpty(TENKH)) { return false; }
                var itemKH = DataProvider.Ins.DB.KHACHHANGs.Where(i => i.SDT == SDTKH).SingleOrDefault();
                if (itemKH == null) { return false; }

                return true;
            }, (p) => { DeleteKhachHang(); });

            UpdateKHCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(SDTKH)) { return false; }
                if (string.IsNullOrEmpty(TENKH)) { return false; }
                var itemKH = DataProvider.Ins.DB.KHACHHANGs.Where(i => i.SDT == SDTKH).SingleOrDefault();
                if (itemKH == null) { return false; }

                return true;
            }, (p) => { UpdateKhachHang(); });

            RefreshKHCommand = new RelayCommand<object>((p) => { return true; }, (p) => { RefreshKhachHang(); });

            AddEventCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TENSK)) { return false; }
                if (string.IsNullOrEmpty(CONTENT)) { return false; }
                return true;
            }, (p) => { AddEvent(); });

            DeleteEventCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItemSuKien == null) { return false; }
                if (SelectedItemSuKien.SUKIEN == null) { return false; }
                if (SelectedItemSuKien.SUKIEN.TENSK != TENSK) { return false; }
                if (SelectedItemSuKien.SUKIEN.NDSUKIEN != CONTENT) { return false; }
                if (SelectedItemSuKien.SUKIEN.DIEMTT.ToString() != DIEMTTEVENT) { return false; }
                if (SelectedItemSuKien.SUKIEN.GIAMGIA != GIAMGIAEVENT) { return false; }
                if (string.IsNullOrEmpty(TENSK)) { return false; }
                if (string.IsNullOrEmpty(CONTENT)) { return false; }
                return true;
            }, (p) => { DeleteEvent(); });

            UpdateEventCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItemSuKien == null) { return false; }
                if (SelectedItemSuKien.SUKIEN == null) { return false; }
                if (string.IsNullOrEmpty(TENSK)) { return false; }
                if (string.IsNullOrEmpty(CONTENT)) { return false; }
                return true;
            }, (p) => { UpdateEvent(); });

            RefreshEventCommand = new RelayCommand<object>((p) => { return true; }, (p) => { RefreshEvent(); });

        }

        void AddEvent()
        {
            var itemSK = DataProvider.Ins.DB.SUKIENs.Where(i => i.TENSK == TENSK).SingleOrDefault();
            if (itemSK != null) { MessageBox.Show("Trùng Tên Sự Kiện"); return; }

            if (MessageBox.Show("Thêm Sự Kiện Này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                var itemLSK = DataProvider.Ins.DB.LOAISUKIENs.Where(i => i.TENLSK == SelectedLoaiSuKien).SingleOrDefault();
                if (itemLSK != null)
                {
                    Model.SUKIEN newSK = new Model.SUKIEN();
                    newSK.TENSK = TENSK;
                    newSK.NDSUKIEN = CONTENT;
                    newSK.MLSK = itemLSK.MLSK;
                    newSK.ACTIVE = true;
                    if (itemLSK.MLSK == 1) // Sự kiện tăng điểm thân thiết
                    {
                        if (DIEMTTEVENT != null)
                        {
                            newSK.DIEMTT = (int)Int32.Parse(DIEMTTEVENT);
                        }
                        else
                        {
                            newSK.DIEMTT = 0;
                        }
                        newSK.GIAMGIA = "0";
                    }
                    else // Sự kiện giảm tiền
                    {
                        if (GIAMGIAEVENT != null)
                        {
                            newSK.GIAMGIA = GIAMGIAEVENT;
                        }
                        else
                        {
                            GIAMGIAEVENT = "0";
                        }
                        newSK.DIEMTT = 0;
                    }

                    newSK = DataProvider.Ins.DB.SUKIENs.Add(newSK);
                    DataProvider.Ins.DB.SaveChanges();

                    Event temp = new Event();
                    temp.SUKIEN = newSK;
                    temp.TENLSK = itemLSK.TENLSK;
                    SuKienList.Add(temp);
                    MessageBox.Show("Tạo Sự Kiện Thành Công");
                    LoadSuKien();
                    RefreshEvent();
                }
            }
        }

        void DeleteEvent()
        {
            if (MessageBox.Show("Xoá Sự Kiện Này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                if (SelectedItemSuKien.SUKIEN != null)
                {
                    var item = DataProvider.Ins.DB.SUKIENs.Where(i => i.MASK == SelectedItemSuKien.SUKIEN.MASK).SingleOrDefault();
                    if (item != null)
                    {
                        item.ACTIVE = false;
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    LoadSuKien();
                    MessageBox.Show("Xoá Sự Kiện Thành Công");
                    RefreshEvent();
                }
            }
        }

        void UpdateEvent()
        {
            if (MessageBox.Show("Cập Nhật Sự Kiện Này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                if (SelectedItemSuKien.SUKIEN != null)
                {
                    var item = DataProvider.Ins.DB.SUKIENs.Where(i => i.MASK == SelectedItemSuKien.SUKIEN.MASK).SingleOrDefault();
                    if (item != null)
                    {
                        item.TENSK = TENSK;
                        item.NDSUKIEN = CONTENT;
                        if (item.MLSK == 1) // sự kiện tăng điểm
                        {
                            item.DIEMTT = (int)Int32.Parse(DIEMTTEVENT);
                        }
                        else
                        {
                            if (item.MLSK == 2) // sự kiên giảm theo tiền cố định
                            {
                                item.GIAMGIA = GIAMGIAEVENT;
                            }
                            else if (item.MLSK == 3) // sự kiên giảm theo %
                            {
                                if ((int)Int32.Parse(GIAMGIAEVENT) >= 0 && (int)Int32.Parse(GIAMGIAEVENT) <= 100)
                                {
                                    item.GIAMGIA = GIAMGIAEVENT;
                                }
                                else
                                {
                                    MessageBox.Show("Vì là giảm giá theo % nên đối tượng giảm giá phải nằm trong 0 -> 100");
                                    return;
                                }
                            }
                        }
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    MessageBox.Show("Cập nhật Sự kiện Thành Công");
                    LoadSuKien();
                    RefreshEvent();
                }
            }
        }

        void AddKhachHang()
        {
            var itemKH = DataProvider.Ins.DB.KHACHHANGs.Where(i => i.SDT == SDTKH).SingleOrDefault();
            if (itemKH != null) { MessageBox.Show("Số điện thoại đã tồn tại"); return; }
            if (MessageBox.Show("Thêm Khách Hàng Này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                if (SDTKH.Count() > 11)
                {
                    MessageBox.Show("SDT sai quy định");
                    return;
                }
                Model.KHACHHANG newKH = new Model.KHACHHANG();
                newKH.SDT = SDTKH;
                newKH.TENKH = TENKH;
                newKH.DIEMTT = 0;
                newKH.ACTIVE = true;
                newKH.DIACHI = DIACHI;
                newKH.EMAIL = EMAIL;
                var itemSK = DataProvider.Ins.DB.SUKIENs.Where(i => i.TENSK == SelectedItemSuKienKH).SingleOrDefault();
                if (itemSK != null)
                {
                    newKH.DIEMTT = itemSK.DIEMTT;
                }
                else
                {
                    newKH.DIEMTT = 0;
                }
                newKH = DataProvider.Ins.DB.KHACHHANGs.Add(newKH);
                KhachHangList.Add(newKH);
                TempKhachHangList.Add(newKH);
                FullKhachHangList.Add(newKH);
                DataProvider.Ins.DB.SaveChanges();
                if (itemSK != null)
                {
                    MessageBox.Show("Tạo khách hàng thành công với sự kiện " + SelectedItemSuKienKH);
                }
                else
                {
                    MessageBox.Show("Tạo khách hàng thành công");
                    RefreshKhachHang();
                }
            }
        }

        void DeleteKhachHang()
        {
            var itemKH = DataProvider.Ins.DB.KHACHHANGs.Where(i => i.SDT == SDTKH && i.ACTIVE == true).SingleOrDefault();
            if (itemKH == null) { MessageBox.Show("Chưa chọn KH"); return; }
            if (MessageBox.Show("Xoá Khách Hàng Này?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                itemKH.ACTIVE = false;
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Xoá Khách Hàng Thành Công");
                LoadKhachHang();
            }
        }

        void UpdateKhachHang()
        {
            var itemKH = DataProvider.Ins.DB.KHACHHANGs.Where(i => i.SDT == SDTKH && i.ACTIVE == true).SingleOrDefault();
            if (itemKH == null) { MessageBox.Show("Chưa chọn KH"); return; }
            if (itemKH.SDT != SDTKH) { MessageBox.Show("SĐT không thay đổi được"); return; }
            if (MessageBox.Show("Cập Nhật Khách Hàng Này? " + itemKH.TENKH, "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                if (!String.IsNullOrEmpty(EMAIL))
                {
                    itemKH.EMAIL = EMAIL;
                }
                if (!String.IsNullOrEmpty(DIACHI))
                {
                    itemKH.DIACHI = DIACHI;
                }
                itemKH.TENKH = TENKH;
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Cập nhật Khách Hàng Thành Công");
                RefreshKhachHang();
                LoadKhachHang();
            }
        }

        void LoadKhachHang()
        {
            KhachHangList = new ObservableCollection<Model.KHACHHANG>();
            TempKhachHangList = new ObservableCollection<Model.KHACHHANG>();
            FullKhachHangList = new ObservableCollection<Model.KHACHHANG>();

            var listKhachHang = DataProvider.Ins.DB.KHACHHANGs;

            foreach (var item in listKhachHang)
            {
                if (item.ACTIVE == true)
                {
                    KhachHangList.Add(item);
                    TempKhachHangList.Add(item);
                    FullKhachHangList.Add(item);
                }
            }
        }

        void LoadKhachHangTiemNang()
        {
            KhachHangList = new ObservableCollection<Model.KHACHHANG>();
            TempKhachHangList = new ObservableCollection<Model.KHACHHANG>();
            FullKhachHangList = new ObservableCollection<Model.KHACHHANG>();

            var listKhachHang = DataProvider.Ins.DB.KHACHHANGs;
            var orderListKhachHang = new ObservableCollection<Model.KHACHHANG>(listKhachHang.OrderBy(i => i.DIEMTT));

            if (orderListKhachHang != null)
            {
                for (int i = orderListKhachHang.Count() - 1; i >= 0; i--)
                {
                    if (orderListKhachHang[i].ACTIVE == true)
                    {
                        KhachHangList.Add(orderListKhachHang[i]);
                        TempKhachHangList.Add(orderListKhachHang[i]);
                        FullKhachHangList.Add(orderListKhachHang[i]);
                    }
                }
            }
        }

        void LoadSuKienTiemNang()
        {
            LoaiSuKienList = new ObservableCollection<Model.LOAISUKIEN>();
            var listLoaiSuKien = DataProvider.Ins.DB.LOAISUKIENs;
            SuKienList = new ObservableCollection<Event>();
            var listSuKien = DataProvider.Ins.DB.SUKIENs;
            //listSuKien.OrderBy(i=> i.)
            foreach (var item in listSuKien)
            {
                if (item.ACTIVE == true)
                {
                    if (item.DIEMTT > 0)
                    {
                        TenSuKienList.Add(item.TENSK);
                    }
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
                }
            }
        }

        void LoadSuKien()
        {
            LoaiSuKienList = new ObservableCollection<Model.LOAISUKIEN>();

            SuKienList = new ObservableCollection<Event>();
            TempSuKienList = new ObservableCollection<Event>();
            FullSuKienList = new ObservableCollection<Event>();

            TenSuKienList = new ObservableCollection<String>();
            TenLoaiSuKienList = new ObservableCollection<String>();
            TenSuKienList.Add("");
            TenLoaiSuKienList.Add("");
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
                if (item.ACTIVE == true)
                {
                    if (item.DIEMTT > 0)
                    {
                        TenSuKienList.Add(item.TENSK);
                    }
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

        void RefreshKhachHang()
        {
            SDTKH = "";
            TENKH = "";
            DIEMTT = "";
            GIAMGIA = "";
            SelectedItemKhachHang = new Model.KHACHHANG();
            SearchKH = "";
            SelectedItemSuKienKH = TenSuKienList[0];
            DIACHI = "";
            EMAIL = "";
        }

        void RefreshEvent()
        {
            TENSK = "";
            DIEMTTEVENT = "";
            GIAMGIAEVENT = "";
            CONTENT = "";
            SelectedLoaiSuKien = TenLoaiSuKienList[0];
            SearchEvent = "";
            SelectedItemSuKien = new Event();
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
