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
    using System;
    using System.Collections.Generic;
    
    public partial class SUKIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUKIEN()
        {
            this.HOADONSUKIENs = new HashSet<HOADONSUKIEN>();
        }
    
        public int MASK { get; set; }
        public string TENSK { get; set; }
        public string NDSUKIEN { get; set; }
        public int DIEMTT { get; set; }
        public string GIAMGIA { get; set; }
        public bool ACTIVE { get; set; }
        public int MLSK { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADONSUKIEN> HOADONSUKIENs { get; set; }
        public virtual LOAISUKIEN LOAISUKIEN { get; set; }
    }
}
