//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyTraSua.Model
{
    using QuanLyTraSua.ViewModel;
    using System;
    using System.Collections.Generic;

    public partial class NHACUNGCAP : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHACUNGCAP()
        {
            this.NGUYENLIEUx = new HashSet<NGUYENLIEU>();
        }

        private int _MSNCC { get; set; }
        public int MSNCC { get => _MSNCC; set { _MSNCC = value; OnPropertyChanged(); } }

        private string _TENNCC { get; set; }
        public string TENNCC { get => _TENNCC; set { _TENNCC = value; OnPropertyChanged(); } }

        private string _DIACHI { get; set; }
        public string DIACHI { get => _DIACHI; set { _DIACHI = value; OnPropertyChanged(); } }

        private string _SDT { get; set; }
        public string SDT { get => _SDT; set { _SDT = value; OnPropertyChanged(); } }

        private string _EMAIL { get; set; }
        public string EMAIL { get => _EMAIL; set { _EMAIL = value; OnPropertyChanged(); } }

        public bool ACTIVE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NGUYENLIEU> NGUYENLIEUx { get; set; }
    }
}
