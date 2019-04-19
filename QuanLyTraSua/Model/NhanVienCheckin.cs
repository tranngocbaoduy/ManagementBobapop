using QuanLyTraSua.DBConnection;
using QuanLyTraSua.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyTraSua.Model
{
    public partial class NhanVienCheckin : BaseViewModel
    {

        private String _TENNV;
        public String TENNV { get => _TENNV; set { _TENNV = value; OnPropertyChanged(); } }

        private String _SDT;
        public String SDT { get => _SDT; set { _SDT = value; OnPropertyChanged(); } }

        private String _CMND;
        public String CMND { get => _CMND; set { _CMND = value; OnPropertyChanged(); } }

        private String _PASSIN;
        public String PASSIN { get => _PASSIN; set { _PASSIN = value; OnPropertyChanged(); } }

        private String _PASSOUT;
        public String PASSOUT { get => _PASSOUT; set { _PASSOUT = value; OnPropertyChanged(); } }

        private String _CALAM;
        public String CALAM { get => _CALAM; set { _CALAM = value; OnPropertyChanged(); } }

        private int _TRANGTHAI;
        public int TRANGTHAI { get => _TRANGTHAI; set { _TRANGTHAI = value; OnPropertyChanged(); } }

        private Boolean _LATE;
        public Boolean LATE { get => _LATE; set { _LATE = value; OnPropertyChanged(); } }

        private Boolean _ISCHECKINYET_ = true;
        public Boolean ISCHECKINYET_ { get => _ISCHECKINYET_; set { _ISCHECKINYET_ = value; OnPropertyChanged(); } }

        private Boolean _ISCHECKOUTYET_ = true;
        public Boolean ISCHECKOUTYET_ { get => _ISCHECKOUTYET_; set { _ISCHECKOUTYET_ = value; OnPropertyChanged(); } }

        private Boolean _ISCHECKINYET;
        public Boolean ISCHECKINYET { get => _ISCHECKINYET; set { _ISCHECKINYET = value; OnPropertyChanged(); } }

        private Boolean _ISCHECKOUTYET;
        public Boolean ISCHECKOUTYET { get => _ISCHECKOUTYET; set { _ISCHECKOUTYET = value; OnPropertyChanged(); } }

        private Boolean _EARLY;
        public Boolean EARLY { get => _EARLY; set { _EARLY = value; OnPropertyChanged(); } }

        private DateTime _TIMEIN;
        public DateTime TIMEIN { get => _TIMEIN; set { _TIMEIN = value; OnPropertyChanged(); } }

        private DateTime _TIMEOUT;
        public DateTime TIMEOUT { get => _TIMEOUT; set { _TIMEOUT = value; OnPropertyChanged(); } }

        private Boolean _ISCHECKIN;
        public Boolean ISCHECKIN
        {
            get => _ISCHECKIN; set
            {
                _ISCHECKIN = value; OnPropertyChanged();
                if (ISCHECKIN)
                {
                    if (TRANGTHAI == 0)
                    {
                        if (MessageBox.Show("Check giờ vào làm?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        {
                            //do no stuff
                            ISCHECKIN = false;
                            return;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(PASSIN) || string.IsNullOrEmpty(TENNV)) { MessageBox.Show("Nhập Mật Khẩu Để Check"); ISCHECKIN = false; return; }

                            var itemNV = DataProvider.Ins.DB.NHANVIENs.Where(i => i.ACTIVE == true && i.CMND == CMND).SingleOrDefault();
                            if (itemNV != null)
                            {
                                var passIn = Base64Encode(PASSIN);
                                var itemTK = DataProvider.Ins.DB.TAIKHOANs.Where(i => i.USERNAME == itemNV.USERNAME && i.PASSWORD == passIn).SingleOrDefault();
                                if (itemTK != null)
                                {
                                    TIMEIN = DateTime.Now;
                                    PASSIN = TIMEIN.ToString();
                                    var itemNVCheckin = DataProvider.Ins.DB.CHECKINGIOLAMVIECs.Where(i => i.MSNV == itemNV.MSNV && TIMEIN.Day == i.NGAYCHECKIN.Day && TIMEIN.Month == i.NGAYCHECKIN.Month && TIMEIN.Year == i.NGAYCHECKIN.Year).SingleOrDefault();
                                    if (itemNVCheckin != null)
                                    {
                                        itemNVCheckin.THOIGIANVAOCA = TIMEIN;
                                        itemNVCheckin.TRANGTHAI = 1;
                                        TRANGTHAI = 1;
                                        if (itemNV.MSCLV == "C1") // Ca1
                                        {
                                            var itemMaCa = DataProvider.Ins.DB.CALAMVIECs.Where(i => i.MSCLV == "C1").SingleOrDefault();
                                            if (TIMEIN.Hour == itemMaCa.TUGIO.Hours) // vao dung gio
                                            {
                                                if (TIMEIN.Minute == itemMaCa.TUGIO.Minutes)
                                                {
                                                    if (TIMEIN.Millisecond == itemMaCa.TUGIO.Milliseconds)
                                                    {

                                                    }
                                                    else if (TIMEIN.Millisecond < itemMaCa.TUGIO.Milliseconds)
                                                    {

                                                    }
                                                    else
                                                    {
                                                        itemNVCheckin.TRE = true;
                                                    }
                                                }
                                                else if (TIMEIN.Minute < itemMaCa.TUGIO.Minutes)
                                                {

                                                }
                                                else
                                                {
                                                    itemNVCheckin.TRE = true;
                                                }
                                            }
                                            else if (TIMEIN.Hour < itemMaCa.TUGIO.Hours)
                                            {
                                                // k tre
                                            }
                                            else // vao tre
                                            {
                                                itemNVCheckin.TRE = true;
                                            }
                                        }
                                        else if (itemNV.MSCLV == "C2") // Ca 2
                                        {
                                            var itemMaCa = DataProvider.Ins.DB.CALAMVIECs.Where(i => i.MSCLV == "C2").SingleOrDefault();
                                            if (TIMEIN.Hour == itemMaCa.TUGIO.Hours) // vao dung gio
                                            {
                                                if (TIMEIN.Minute == itemMaCa.TUGIO.Minutes)
                                                {
                                                    if (TIMEIN.Millisecond == itemMaCa.TUGIO.Milliseconds)
                                                    {

                                                    }
                                                    else if (TIMEIN.Millisecond < itemMaCa.TUGIO.Milliseconds)
                                                    {

                                                    }
                                                    else
                                                    {
                                                        itemNVCheckin.TRE = true;
                                                    }
                                                }
                                                else if (TIMEIN.Minute < itemMaCa.TUGIO.Minutes)
                                                {

                                                }
                                                else
                                                {
                                                    itemNVCheckin.TRE = true;
                                                }
                                            }
                                            else if (TIMEIN.Hour < itemMaCa.TUGIO.Hours)
                                            {
                                                // k tre
                                            }
                                            else // vao tre
                                            {
                                                itemNVCheckin.TRE = true;
                                            }
                                        }
                                        else if (itemNV.MSCLV == "C3") // Ca 3
                                        {
                                            var itemMaCa = DataProvider.Ins.DB.CALAMVIECs.Where(i => i.MSCLV == "C3").SingleOrDefault();
                                            if (TIMEIN.Hour == itemMaCa.TUGIO.Hours) // vao dung gio
                                            {
                                                if (TIMEIN.Minute == itemMaCa.TUGIO.Minutes)
                                                {
                                                    if (TIMEIN.Millisecond == itemMaCa.TUGIO.Milliseconds)
                                                    {

                                                    }
                                                    else if (TIMEIN.Millisecond < itemMaCa.TUGIO.Milliseconds)
                                                    {

                                                    }
                                                    else
                                                    {
                                                        itemNVCheckin.TRE = true;
                                                    }
                                                }
                                                else if (TIMEIN.Minute < itemMaCa.TUGIO.Minutes)
                                                {

                                                }
                                                else
                                                {
                                                    itemNVCheckin.TRE = true;
                                                }
                                            }
                                            else if (TIMEIN.Hour < itemMaCa.TUGIO.Hours)
                                            {
                                                // k tre
                                            }
                                            else // vao tre
                                            {
                                                itemNVCheckin.TRE = true;
                                            }
                                        }
                                        else if (itemNV.MSCLV == "FULLTIME") // FULLTIME
                                        {
                                            var itemMaCa = DataProvider.Ins.DB.CALAMVIECs.Where(i => i.MSCLV == "FULLTIME").SingleOrDefault();
                                            if (TIMEIN.Hour == itemMaCa.TUGIO.Hours) // vao dung gio
                                            {
                                                if (TIMEIN.Minute == itemMaCa.TUGIO.Minutes)
                                                {
                                                    if (TIMEIN.Millisecond == itemMaCa.TUGIO.Milliseconds)
                                                    {

                                                    }
                                                    else if (TIMEIN.Millisecond < itemMaCa.TUGIO.Milliseconds)
                                                    {

                                                    }
                                                    else
                                                    {
                                                        itemNVCheckin.TRE = true;
                                                    }
                                                }
                                                else if (TIMEIN.Minute < itemMaCa.TUGIO.Minutes)
                                                {

                                                }
                                                else
                                                {
                                                    itemNVCheckin.TRE = true;
                                                }
                                            }
                                            else if (TIMEIN.Hour < itemMaCa.TUGIO.Hours)
                                            {
                                                // k tre
                                            }
                                            else // vao tre
                                            {
                                                itemNVCheckin.TRE = true;
                                            }
                                        }
                                        if (itemNVCheckin.TRE)
                                        {
                                            PASSIN = PASSIN + " (T)";
                                        }

                                        DataProvider.Ins.DB.SaveChanges();
                                        ISCHECKINYET = true;
                                        ISCHECKINYET_ = !ISCHECKINYET;
                                        ISCHECKOUTYET_ = ISCHECKINYET;
                                        MessageBox.Show("Check Thành Công Vào Lúc \n" + TIMEIN);
                                    }
                                    else { MessageBox.Show("Sai Mật Khẩu"); ISCHECKIN = false; return; }
                                    return;

                                }
                                else { MessageBox.Show("Sai Mật Khẩu"); ISCHECKIN = false; return; }
                            }
                        }
                    }

                }
            }
        }

        private Boolean _ISCHECKOUT = false;
        public Boolean ISCHECKOUT
        {
            get => _ISCHECKOUT; set
            {
                _ISCHECKOUT = value; OnPropertyChanged();
                if (ISCHECKOUT)
                {
                    if (TRANGTHAI == 1)
                    {
                        if (MessageBox.Show("Check out giờ làm?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        {
                            //do no stuff
                            ISCHECKOUT = false;
                            return;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(PASSOUT) || string.IsNullOrEmpty(TENNV)) { MessageBox.Show("Nhập Mật Khẩu Để Check"); ISCHECKOUT = false; return; }

                            var itemNV = DataProvider.Ins.DB.NHANVIENs.Where(i => i.ACTIVE == true && i.CMND == CMND).SingleOrDefault();
                            if (itemNV != null)
                            { 
                                var passOut = Base64Encode(PASSOUT);
                                var itemTK = DataProvider.Ins.DB.TAIKHOANs.Where(i => i.USERNAME == itemNV.USERNAME && i.PASSWORD == passOut).SingleOrDefault();
                                if (itemTK != null)
                                {
                                    TIMEOUT = DateTime.Now;
                                    PASSOUT = TIMEOUT.ToString();
                                    var itemNVCheckin = DataProvider.Ins.DB.CHECKINGIOLAMVIECs.Where(i => i.MSNV == itemNV.MSNV && TIMEOUT.Day == i.NGAYCHECKIN.Day && TIMEOUT.Month == i.NGAYCHECKIN.Month && TIMEOUT.Year == i.NGAYCHECKIN.Year).SingleOrDefault();
                                    if (itemNVCheckin != null)
                                    {
                                        itemNVCheckin.THOIGIANKETTHUCCA = TIMEOUT;
                                        itemNVCheckin.TRANGTHAI = 2;
                                        TRANGTHAI = 2;

                                        if (itemNV.MSCLV == "C1") // Ca1
                                        {
                                            var itemMaCa = DataProvider.Ins.DB.CALAMVIECs.Where(i => i.MSCLV == "C1").SingleOrDefault();
                                            if (TIMEOUT.Hour == itemMaCa.DENGIO.Hours) // vao dung gio
                                            {
                                                if (TIMEOUT.Minute == itemMaCa.DENGIO.Minutes)
                                                {
                                                    if (TIMEOUT.Millisecond == itemMaCa.DENGIO.Milliseconds)
                                                    {

                                                    }
                                                    else if (TIMEOUT.Millisecond > itemMaCa.DENGIO.Milliseconds)
                                                    {

                                                    }
                                                    else
                                                    {
                                                        itemNVCheckin.SOM = true;
                                                    }
                                                }
                                                else if (TIMEOUT.Minute > itemMaCa.DENGIO.Minutes)
                                                {

                                                }
                                                else
                                                {
                                                    itemNVCheckin.SOM = true;
                                                }
                                            }
                                            else if (TIMEOUT.Hour > itemMaCa.DENGIO.Hours)
                                            {
                                                // k tre
                                            }
                                            else // vao tre
                                            {
                                                itemNVCheckin.SOM = true;
                                            }
                                        }
                                        else if (itemNV.MSCLV == "C2") // Ca 2
                                        {
                                            var itemMaCa = DataProvider.Ins.DB.CALAMVIECs.Where(i => i.MSCLV == "C2").SingleOrDefault();
                                            if (TIMEOUT.Hour == itemMaCa.DENGIO.Hours) // vao dung gio
                                            {
                                                if (TIMEOUT.Minute == itemMaCa.DENGIO.Minutes)
                                                {
                                                    if (TIMEOUT.Millisecond == itemMaCa.DENGIO.Milliseconds)
                                                    {

                                                    }
                                                    else if (TIMEOUT.Millisecond > itemMaCa.DENGIO.Milliseconds)
                                                    {

                                                    }
                                                    else
                                                    {
                                                        itemNVCheckin.SOM = true;
                                                    }
                                                }
                                                else if (TIMEOUT.Minute > itemMaCa.DENGIO.Minutes)
                                                {

                                                }
                                                else
                                                {
                                                    itemNVCheckin.SOM = true;
                                                }
                                            }
                                            else if (TIMEOUT.Hour > itemMaCa.DENGIO.Hours)
                                            {
                                                // k tre
                                            }
                                            else // vao tre
                                            {
                                                itemNVCheckin.SOM = true;
                                            }
                                        }
                                        else if (itemNV.MSCLV == "C3") // Ca 3
                                        {
                                            var itemMaCa = DataProvider.Ins.DB.CALAMVIECs.Where(i => i.MSCLV == "C3").SingleOrDefault();
                                            if (TIMEOUT.Hour == itemMaCa.DENGIO.Hours) // ra dung gio
                                            {
                                                if (TIMEOUT.Minute == itemMaCa.DENGIO.Minutes)
                                                {
                                                    if (TIMEOUT.Millisecond == itemMaCa.DENGIO.Milliseconds)
                                                    {

                                                    }
                                                    else if (TIMEOUT.Millisecond > itemMaCa.DENGIO.Milliseconds)
                                                    {

                                                    }
                                                    else
                                                    {
                                                        itemNVCheckin.SOM = true;
                                                    }
                                                }
                                                else if (TIMEOUT.Minute > itemMaCa.DENGIO.Minutes)
                                                {

                                                }
                                                else
                                                {
                                                    itemNVCheckin.SOM = true;
                                                }
                                            }
                                            else if (TIMEOUT.Hour > itemMaCa.DENGIO.Hours)
                                            {
                                                // k som
                                            }
                                            else // vao tre
                                            {
                                                itemNVCheckin.SOM = true;
                                            }
                                        }
                                        else if (itemNV.MSCLV == "FULLTIME") // FULLTIME
                                        {
                                            var itemMaCa = DataProvider.Ins.DB.CALAMVIECs.Where(i => i.MSCLV == "FULLTIME").SingleOrDefault();
                                            if (TIMEOUT.Hour == itemMaCa.DENGIO.Hours) // vao dung gio
                                            {
                                                if (TIMEOUT.Minute == itemMaCa.DENGIO.Minutes)
                                                {
                                                    if (TIMEOUT.Millisecond == itemMaCa.DENGIO.Milliseconds)
                                                    {

                                                    }
                                                    else if (TIMEOUT.Millisecond > itemMaCa.DENGIO.Milliseconds)
                                                    {

                                                    }
                                                    else
                                                    {
                                                        itemNVCheckin.SOM = true;
                                                    }
                                                }
                                                else if (TIMEOUT.Minute > itemMaCa.DENGIO.Minutes)
                                                {

                                                }
                                                else
                                                {
                                                    itemNVCheckin.SOM = true;
                                                }
                                            }
                                            else if (TIMEOUT.Hour > itemMaCa.DENGIO.Hours)
                                            {
                                                // k tre
                                            }
                                            else // vao tre
                                            {
                                                itemNVCheckin.SOM = true;
                                            }
                                        }
                                        if (itemNVCheckin.SOM)
                                        {
                                            PASSOUT = PASSOUT + " (S)";
                                        }
                                        DataProvider.Ins.DB.SaveChanges();
                                        ISCHECKOUTYET = true;
                                        ISCHECKOUTYET_ = !ISCHECKOUTYET;
                                        MessageBox.Show("Check Thành Công Vào Lúc \n" + TIMEOUT);
                                    }
                                    else { MessageBox.Show("Sai Mật Khẩu"); ISCHECKOUT = false; return; }
                                    return;

                                }
                                else { MessageBox.Show("Sai Mật Khẩu"); ISCHECKOUT = false; return; }
                            }
                        }
                    }

                }
            }
        }
        public NhanVienCheckin()
        {

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
