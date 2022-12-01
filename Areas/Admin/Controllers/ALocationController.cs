using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HaNamSite.Models.EF;
using HaNamSite.Models.DAO;
using System.IO;

namespace HaNamSite.Areas.Admin.Controllers
{
    public class ALocationController : Controller
    {
        QLDL db = new QLDL();
        LocationDao dao = new LocationDao();
        // GET: Admin/ALocation
        public ActionResult Index()
        {
            var model = db.DiaDiems.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateLocations()
        {
            ViewBag.IdLocation = new SelectList(db.DiaDiems.OrderBy(n => n.TenDiaDiem), "ID", "TenDiaDiem");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CreateLocations(DiaDiem locations, HttpPostedFileBase fileUpload)
        {
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Chọn hình ảnh";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName1 = Path.GetFileName(fileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Asset/img"), fileName1);

                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                    }
                    else
                    {
                        fileUpload.SaveAs(path);

                    }

                    locations.Img = fileName1;

                    db.DiaDiems.Add(locations);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }

        public ActionResult EditLocations(int id)
        {

            var edit = db.DiaDiems.FirstOrDefault(n => n.ID == id);
            return View(edit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditLocations(DiaDiem locations, HttpPostedFileBase fileUpload)
        {

            var updatelocation = db.DiaDiems.Find(locations.ID) as DiaDiem;
            var fileName1 = Path.GetFileName(fileUpload.FileName);
            var path = Path.Combine(Server.MapPath("~/Asset/img"), fileName1);

            if (System.IO.File.Exists(path))
            {
                ViewBag.ThongBao = "Hình ảnh đã tồn tại";
            }
            else
            {
                fileUpload.SaveAs(path);

            }

            updatelocation.Img = fileName1;
            updatelocation.TenDiaDiem = locations.TenDiaDiem;
            updatelocation.Mota = locations.Mota;
            updatelocation.DiaChi = locations.DiaChi;
            updatelocation.Status = locations.Status;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteLocations(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaDiem DiaDiemDL = db.DiaDiems.Find(id);
            if (DiaDiemDL == null)
            {
                return HttpNotFound();
            }
            return View(DiaDiemDL);
        }

        [HttpPost, ActionName("DeleteLocations")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLocationsConfirmed(int? id)
        {
            DiaDiem DiaDiemDL = db.DiaDiems.Find(id);
            db.DiaDiems.Remove(DiaDiemDL);
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