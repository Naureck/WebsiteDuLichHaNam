using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaNamSite.Models
{
    public class Login
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Bạn cần phải nhập tài khoản")]
        public string taikhoan { set; get; }

        [Display(Name = "Mật Khẩu")]
        [Required(ErrorMessage = "Bạn cần phải nhập mật khẩu")]
        public string matkhau { set; get; }
    }
}