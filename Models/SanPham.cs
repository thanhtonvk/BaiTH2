namespace BaiTH2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [Key]
        public int Ma { get; set; }

        [StringLength(100)]
        public string Ten { get; set; }

        public int? DonGia { get; set; }

        public int MaDanhMuc { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }
    }
}
