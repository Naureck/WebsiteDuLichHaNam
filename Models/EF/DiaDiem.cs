namespace HaNamSite.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiaDiem")]
    public partial class DiaDiem
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string TenDiaDiem { get; set; }

        [Column(TypeName = "ntext")]
        public string Mota { get; set; }

        [StringLength(500)]
        public string DiaChi { get; set; }

        public bool? Status { get; set; }

        [StringLength(150)]
        public string Img { get; set; }
    }
}
