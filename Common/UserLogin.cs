using HaNamSite.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaNamSite.Common
{
    public class UserLogin
    {
        public KhachHang taikhoan { get; set; }

        public long? IdKH { get; set; }
    }
}