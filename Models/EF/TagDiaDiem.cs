namespace HaNamSite.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TagDiaDiem")]
    public partial class TagDiaDiem
    {
        public int ID { get; set; }

        public int IdDIaDiem { get; set; }

        public int? IdTourDuLich { get; set; }
    }
}
