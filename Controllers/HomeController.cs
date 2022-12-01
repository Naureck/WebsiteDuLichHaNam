using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaNamSite.Models.DAO;
using HaNamSite.Models.EF;
using HaNamSite.Models;
using HaNamSite.Common;
using System.Web.Security;

namespace HaNamSite.Controllers
{
    public class HomeController : Controller
    {
        QLDL db = new QLDL();
        HomeDao Dao = new HomeDao();
        // GET: Home
        public ActionResult Index()
        {

            ViewBag.Tours = Dao.listTours(4);
            ViewBag.Location = Dao.listLocation(3);
            ViewBag.ToursHot = Dao.listToursHot(4);
            return View(ViewBag);

        }

        public ActionResult BodyStyle1()
        {
            ViewBag.Location1 = Dao.listLocation(1);
            return View();
        }

        public ActionResult BodyStyle2()
        {
            ViewBag.Location2 = Dao.listLocation(1);
            return View();
        }

        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPage(Login model)
        {
            if (ModelState.IsValid)
            {

                var result = Dao.info(model.taikhoan, model.matkhau);
                KhachHang kh = Dao.getKhachHang(model.taikhoan, model.matkhau);
                if (result)
                {
                    Session["taikhoan"] = kh;
                    Session.Add(TrangThaiLogin.USER_SESSION, kh);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("LoginPage");
                }
            }
            else
            {

            }


            return Content("Tên đăng nhập hoặc mật khẩu không đúng");
        }

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.IdUser = new SelectList(db.KhachHangs.OrderBy(n => n.taikhoan), "ID", "taikhoan");
            return View();
        }
        [HttpPost]
        public ActionResult Register(KhachHang kh)
        {
            ViewBag.IdUser = new SelectList(db.KhachHangs.OrderBy(n => n.taikhoan), "ID", "taikhoan");
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                ViewBag.ThongBao = "Đăng ký thành công";
            }
            return RedirectToAction("Index");
            
        }

        public ActionResult Logout()
        {
            Session["taikhoan"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}