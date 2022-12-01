using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaNamSite.Models.EF;
namespace HaNamSite.Areas.Admin.Controllers
{
    public class ContactController : Controller
    {
        QLDL db = new QLDL();
        // GET: Admin/Contact
        public ActionResult Index()
        {
            var model = db.Contacts.ToList();
            return View(model);
        }
    }
}