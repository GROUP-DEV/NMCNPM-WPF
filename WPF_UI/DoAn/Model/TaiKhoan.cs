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
    
    public partial class TaiKhoan
    {
        public int STT { get; set; }
        public string IdNguoiDung { get; set; }
        public string PassND { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDT { get; set; }
        public byte[] Avatar { get; set; }
        public Nullable<int> MaLoaiTK { get; set; }
    }
}