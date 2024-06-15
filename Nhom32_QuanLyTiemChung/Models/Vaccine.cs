//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nhom32_QuanLyTiemChung.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vaccine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vaccine()
        {
            this.ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
            this.ChiTietPhieuXuats = new HashSet<ChiTietPhieuXuat>();
            this.ChiTietTiemChungs = new HashSet<ChiTietTiemChung>();
        }
    
        public int idVaccine { get; set; }
        public string tenVaccine { get; set; }
        public string nuocSanXuat { get; set; }
        public string nhaSanXuat { get; set; }
        public string moTaBenh { get; set; }
        public Nullable<int> kyTiem { get; set; }
        public Nullable<int> soLuongMuiTiem { get; set; }
        public Nullable<int> soLuongConLai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietTiemChung> ChiTietTiemChungs { get; set; }
    }
}
