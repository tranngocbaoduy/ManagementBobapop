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
    
    public partial class CHITIETHOADON
    {
        public int MSHD { get; set; }
        public int MSMH { get; set; }
        public int SOLUONG { get; set; }
        public int DONGIA { get; set; }
    
        public virtual HOADON HOADON { get; set; }
    }
}
