using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaNamSite.Models.DAO;
using HaNamSite.Models.EF;

namespace HaNamSite.Controllers
{
    public class LocationController : Controller
    {
        QLDL db = new QLDL();
        HomeDao dao = new HomeDao();
        // GET: Location
        public ActionResult Index()
        {
            ViewBag.Location = dao.listLocation(12);
            return View();
        }

        public ActionResult Details(long id)
        {
            var dao = new LocationDao();
            ViewBag.orderbyLocation = db.DiaDiems.Where(n => n.ID == id).ToList();
            var model = dao.detailsLocation(id);
            return View(model);
        }
    }
}