//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAn.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SANBAYTRUNGGIAN
    {
        public int STT { get; set; }
        public string MaSBTrungGian { get; set; }
        public string MaCB { get; set; }
        public string TenSB { get; set; }
        public Nullable<int> ThoiGianDung { get; set; }
        public string GhiChu { get; set; }
    
        public virtual SANBAY SANBAY { get; set; }
    }
}
