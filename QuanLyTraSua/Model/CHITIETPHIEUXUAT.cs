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
    
    public partial class CHITIETPHIEUXUAT
    {
        public int MSPX { get; set; }
        public int MSNL { get; set; }
        public int SOLUONG { get; set; }
        public int MSKHO { get; set; }
    
        public virtual KHO KHO { get; set; }
        public virtual NGUYENLIEU NGUYENLIEU { get; set; }
        public virtual PHIEUXUAT PHIEUXUAT { get; set; }
    }
}
