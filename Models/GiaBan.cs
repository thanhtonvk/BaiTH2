namespace BaiTH2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaBan")]
    public partial class GiaBan
    {
        [Key]
        public int MaGB { get; set; }

        public int MaHang { get; set; }

        public int? Gia { get; set; }

        [StringLength(30)]
        public string DVTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDB { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKT { get; set; }

        public virtual HangHoa HangHoa { get; set; }
    }
}
