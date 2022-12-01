using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaNamSite.Models.EF;
using HaNamSite.Models.DAO;
using System.Net;

namespace HaNamSite.Areas.Admin.Controllers
{
    public class AOrdersController : Controller
    {
        QLDL db = new QLDL();
        // GET: Admin/AOrders
        public ActionResult Index()
        {
            var model = db.Orders.ToList();
            return View(model);
        }

        public ActionResult DeleteOrders(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        [HttpPost, ActionName("DeleteOrders")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOrdersConfirmed(int? id)
        {
            Order orders = db.Orders.Find(id);
            db.Orders.Remove(orders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}