namespace BaiTH2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HangHoa")]
    public partial class HangHoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HangHoa()
        {
            GiaBans = new HashSet<GiaBan>();
        }

        [Key]
        public int MaHang { get; set; }

        public int MaLoai { get; set; }

        [StringLength(50)]
        public string TenHang { get; set; }

        public int? SoLuong { get; set; }

        public int? SoLuongCon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiaBan> GiaBans { get; set; }

        public virtual LoaiHang LoaiHang { get; set; }
    }
}
