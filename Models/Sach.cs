namespace BaiTH2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [Key]
        [StringLength(30)]
        public string MaSH { get; set; }

        [StringLength(100)]
        public string TenSach { get; set; }

        [StringLength(100)]
        public string TacGia { get; set; }

        [StringLength(100)]
        public string NhaXB { get; set; }

        public int? NamXB { get; set; }
    }
}
