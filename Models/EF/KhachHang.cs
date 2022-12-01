namespace HaNamSite.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        public int ID { get; set; }
        [Required]
        [StringLength(20)]
        [DisplayName("Tài khoản")]
        public string taikhoan { get; set; }
        [Required]
        [StringLength(20)]
        [DisplayName("Mật khẩu")]
        public string matkhau { get; set; }

        [StringLength(50)]
        [DisplayName("Họ và tên")]
        public string tenKH { get; set; }

        [StringLength(5)]
        [DisplayName("Giới tính")]
        public string gioiTinh { get; set; }

        public int? SDT { get; set; }

        [StringLength(50)]
        [DisplayName("Email")]
        public string email { get; set; }
        [DisplayName("Ngày sinh")]
        [Range(0, Int32.MaxValue, ErrorMessage ="Chỉ được nhập số")]
        public int? ngaySinh { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "Chỉ được nhập số")]
        public int? thangSinh { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "Chỉ được nhập số")]
        public int? namSinh { get; set; }
    }
}
