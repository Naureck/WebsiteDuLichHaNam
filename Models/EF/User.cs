namespace HaNamSite.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int ID { get; set; }

        [StringLength(50)]
        [DisplayName("Tên tài khoản")]
        [Required(ErrorMessage = "Bạn chưa nhập tên tài khoản")]
        public string UserName { get; set; }

        [StringLength(50)]
        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu")]
        public string Password { get; set; }

        [StringLength(50)]
        [DisplayName("Tên người dùng")]
        public string Name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày tạo")]
        //[Required(ErrorMessage = "Bạn chưa nhập vào ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        [DisplayName("Người tạo")]
        public string CreatedBy { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày sửa")]
        //[Required(ErrorMessage = "Bạn chưa nhập vào ngày sửa")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        [DisplayName("Người sửa")]
        //[Required(ErrorMessage = "Bạn chưa nhập vào người sửa")]
        public string ModifiedBy { get; set; }
    }
}
