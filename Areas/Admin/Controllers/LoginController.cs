using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaNamSite.Models.EF;
using HaNamSite.Models;
namespace HaNamSite.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        QLDL db = new QLDL();
        // GET: Admin/Login
        
        public ActionResult LoginHome()
        {
            return View();
        }
        
        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("LoginHome");
            }
            return View();
        }

        [HttpPost]
        public ActionResult LoginHome(string tdn, string mk)
        {
            var user = db.Users.SingleOrDefault(n => n.UserName == tdn && n.Password == mk);
            if (tdn == user.UserName && mk == user.Password)
            {
                Session.Add("User", tdn);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ThongBao = "Sai tên đăng nhập hoặc mật khẩu";
                return View();
            }
        }

        //[HttpPost]
        //public ActionResult LoginHomme(string tdn, string mk)
        //{
        //    var user = db.Users.SingleOrDefault(n => n.UserName == tdn && n.Password == mk);
        //    if (string.IsNullOrEmpty(tdn))
        //    {
        //        ViewBag.Error1 = "Tên đăng nhập không được để trống !";
        //    }
        //    else if(string.IsNullOrEmpty(mk))
        //    {
        //        ViewBag.Error2 = "Vui lòng nhập mật khẩu !";
        //    } 
        //    else
        //    {
                
        //        if (user != null)
        //        {
        //            ViewBag.ThongBao = "Dang nhap thanh cong!";
        //            Session.Add("User", tdn);
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ViewBag.ThongBao = "Sai tai khoan hoac mat khau";
        //        }
        //    }
        //    return View();
            
        //}
        

    }
}