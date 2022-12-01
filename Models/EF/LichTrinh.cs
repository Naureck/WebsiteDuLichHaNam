namespace HaNamSite.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichTrinh")]
    public partial class LichTrinh
    {
        public int ID { get; set; }

        public int IDTours { get; set; }

        [StringLength(100)]
        public string TieuDe1 { get; set; }

        [StringLength(100)]
        public string TieuDe2 { get; set; }

        [StringLength(100)]
        public string TieuDe3 { get; set; }

        [Column(TypeName = "ntext")]
        public string ChiTiet1 { get; set; }

        [Column(TypeName = "ntext")]
        public string ChiTiet2 { get; set; }

        [Column(TypeName = "ntext")]
        public string ChiTiet3 { get; set; }
    }
}
