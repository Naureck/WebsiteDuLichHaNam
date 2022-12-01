namespace HaNamSite.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImgDiaDiem")]
    public partial class ImgDiaDiem
    {
        public int ID { get; set; }

        public int IdDiaDiem { get; set; }

        [Column(TypeName = "text")]
        public string Img { get; set; }
    }
}
