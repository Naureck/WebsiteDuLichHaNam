namespace HaNamSite.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int ID { get; set; }

        public int IDTour { get; set; }

        public int IdKH { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        public int? SDT { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int? SoKhachLon { get; set; }

        public int? SoKhachTreEm { get; set; }

        public int? SoKhachTreNho { get; set; }

        public int? SoKhachSoSinh { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        [Column(TypeName = "money")]
        public decimal? TongGia { get; set; }

        public int? TongSoKhach { get; set; }

        public bool? HutThuoc { get; set; }

        public bool? PhongTangCao { get; set; }

        public bool? TreEmHieuDong { get; set; }

        public bool? AnChay { get; set; }

        public bool? NguoiKhuyetTat { get; set; }

        public bool? PhuNuCoThai { get; set; }
    }
}
