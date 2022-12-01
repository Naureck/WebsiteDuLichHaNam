using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HaNamSite.Models.EF;
namespace HaNamSite.Areas.Admin.Controllers
{
    public class AToursController : Controller
    {
        QLDL db = new QLDL();
        // GET: Admin/ATours
        public ActionResult Index()
        {
            var model = db.TourDuLiches.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult CreateTours()
        {
            ViewBag.IdTour = new SelectList(db.TourDuLiches.OrderBy(n => n.TieuDe), "ID", "TieuDe");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CreateTours(TourDuLich tours, HttpPostedFileBase fileUpload)
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

                    tours.Thumnail = fileName1;

                    db.TourDuLiches.Add(tours);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

        }

        public ActionResult EditTours(int id)
        {

            var edit = db.TourDuLiches.FirstOrDefault(n => n.ID == id);
            return View(edit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditTours(TourDuLich tours, HttpPostedFileBase fileUpload)
        {
            var updateTours = db.TourDuLiches.Find(tours.ID) as TourDuLich;
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

            updateTours.TieuDe = tours.TieuDe;
            updateTours.ThoiGian = tours.ThoiGian;
            updateTours.NgayKhoiHanh = tours.NgayKhoiHanh;
            updateTours.SoNgayDi = tours.SoNgayDi;
            updateTours.SoNgayDiShort = tours.SoNgayDiShort;
            updateTours.DiaDiemKhoiHanh = tours.DiaDiemKhoiHanh;
            updateTours.ChiTiet = tours.ChiTiet;
            updateTours.Thumnail = fileName1;
            updateTours.LoaiKhachSan = tours.LoaiKhachSan;
            updateTours.GiaNguoiLon = tours.GiaNguoiLon;
            updateTours.GiaTreEm = tours.GiaTreEm;
            updateTours.GiaTreNho = tours.GiaTreNho;
            updateTours.GiaSoSinh = tours.GiaSoSinh;
            updateTours.SoKhachToiDa = tours.SoKhachToiDa;
            updateTours.LuotXem = tours.LuotXem;
            updateTours.Status = tours.Status;

            db.SaveChanges();
            return RedirectToAction("Index");
            

            
        }

        public ActionResult DeleteTours(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourDuLich toursDL = db.TourDuLiches.Find(id);
            if (toursDL == null)
            {
                return HttpNotFound();
            }
            return View(toursDL);
        }

        [HttpPost, ActionName("DeleteTours")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteToursConfirmed(int? id)
        {
            TourDuLich toursDL = db.TourDuLiches.Find(id);
            db.TourDuLiches.Remove(toursDL);
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