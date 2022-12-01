using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaNamSite.Models.DAO;
using HaNamSite.Models.EF;
using HaNamSite.Models;

namespace HaNamSite.Controllers
{
    
    public class ToursController : Controller
    {
        ToursDao dao= new ToursDao();
        QLDL db = new QLDL();
        // GET: Tours
        public ActionResult Index()
        {
            ViewBag.toursDL = dao.listTours(12);
            return View();
        }

        public ActionResult Details(long id)
        {
            var dao = new ToursDao();
            var model = dao.infoTours(id);
            //var dao2 = db.TourDuLiches.Where(n => n.ID == id).ToList();
            var viewTourDatTour = new KetNoiTours_Orders()
            {
                tours = model,
                orders = new Order()

            };

            return View(viewTourDatTour);
        }

        public ActionResult Booking(long id)
        {
            var dao = new ToursDao();
            var dao2 = new BookingDao();
            ViewBag.infoTours = dao.infoTours(id);
            var viewTourDatTour = new KetNoiTours_Orders()
            {
                tours = ViewBag.infoTours,
                orders = new Order()

            };

            return View(viewTourDatTour);
        }

        [HttpPost]
        public ActionResult Booking(KetNoiTours_Orders toursOrder , long id)
        {

            var returnData = new ReturnData();
            
            var sessionUser = Session["taikhoan"] as HaNamSite.Models.EF.KhachHang;
            var getUser = db.KhachHangs.Where(kh => kh.taikhoan == sessionUser.taikhoan).FirstOrDefault();
            var i = 1;
            if (sessionUser == null)
            {
                toursOrder.orders.IdKH = i++;
                toursOrder.orders.IDTour = toursOrder.tours.ID;
                toursOrder.orders.HoTen = toursOrder.orders.HoTen;
                toursOrder.orders.SDT = toursOrder.orders.SDT;
                toursOrder.orders.Email = toursOrder.orders.Email;
                toursOrder.orders.SoKhachLon = toursOrder.orders.SoKhachLon;
                toursOrder.orders.SoKhachTreEm = toursOrder.orders.SoKhachTreEm;
                toursOrder.orders.SoKhachTreNho = toursOrder.orders.SoKhachTreNho;
                toursOrder.orders.SoKhachSoSinh = toursOrder.orders.SoKhachSoSinh;
                toursOrder.orders.TongSoKhach = toursOrder.orders.SoKhachLon + toursOrder.orders.SoKhachTreEm + toursOrder.orders.SoKhachTreNho + toursOrder.orders.SoKhachSoSinh;
                toursOrder.orders.TongGia = (toursOrder.tours.GiaNguoiLon * toursOrder.orders.SoKhachLon) + (toursOrder.tours.GiaTreEm * toursOrder.orders.SoKhachTreEm) + (toursOrder.tours.GiaTreNho * toursOrder.orders.SoKhachTreNho) + (toursOrder.tours.GiaSoSinh * toursOrder.orders.SoKhachSoSinh);
                toursOrder.orders.GhiChu = toursOrder.orders.GhiChu;
                toursOrder.orders.HutThuoc = toursOrder.orders.HutThuoc;
                toursOrder.orders.PhongTangCao = toursOrder.orders.PhongTangCao;
                toursOrder.orders.AnChay = toursOrder.orders.AnChay;
                toursOrder.orders.NguoiKhuyetTat = toursOrder.orders.NguoiKhuyetTat;
                toursOrder.orders.PhuNuCoThai = toursOrder.orders.PhuNuCoThai;

                db.Orders.Add(new Order()
                {
                    IdKH = toursOrder.orders.IdKH,
                    IDTour = toursOrder.orders.IDTour,
                    HoTen = toursOrder.orders.HoTen,
                    SDT = toursOrder.orders.SDT,
                    Email = toursOrder.orders.Email,
                    SoKhachLon = toursOrder.orders.SoKhachLon,
                    SoKhachTreEm = toursOrder.orders.SoKhachTreEm,
                    SoKhachTreNho = toursOrder.orders.SoKhachTreNho,
                    SoKhachSoSinh = toursOrder.orders.SoKhachSoSinh,
                    TongSoKhach = toursOrder.orders.TongSoKhach,
                    TongGia = toursOrder.orders.TongGia,
                    GhiChu = toursOrder.orders.GhiChu,
                    HutThuoc = toursOrder.orders.HutThuoc,
                    PhongTangCao = toursOrder.orders.PhongTangCao,
                    AnChay = toursOrder.orders.AnChay,
                    NguoiKhuyetTat = toursOrder.orders.NguoiKhuyetTat,
                    PhuNuCoThai = toursOrder.orders.PhuNuCoThai,
                });

            }
            else
            {
                toursOrder.orders.IdKH = getUser.ID;
                toursOrder.orders.IDTour = toursOrder.tours.ID;
                toursOrder.orders.HoTen = toursOrder.orders.HoTen;
                toursOrder.orders.SDT = toursOrder.orders.SDT;
                toursOrder.orders.Email = toursOrder.orders.Email;
                toursOrder.orders.SoKhachLon = toursOrder.orders.SoKhachLon;
                toursOrder.orders.SoKhachTreEm = toursOrder.orders.SoKhachTreEm;
                toursOrder.orders.SoKhachTreNho = toursOrder.orders.SoKhachTreNho;
                toursOrder.orders.SoKhachSoSinh = toursOrder.orders.SoKhachSoSinh;
                toursOrder.orders.TongSoKhach = toursOrder.orders.SoKhachLon + toursOrder.orders.SoKhachTreEm + toursOrder.orders.SoKhachTreNho + toursOrder.orders.SoKhachSoSinh;
                toursOrder.orders.TongGia = (toursOrder.tours.GiaNguoiLon * toursOrder.orders.SoKhachLon) + (toursOrder.tours.GiaTreEm * toursOrder.orders.SoKhachTreEm) + (toursOrder.tours.GiaTreNho * toursOrder.orders.SoKhachTreNho) + (toursOrder.tours.GiaSoSinh * toursOrder.orders.SoKhachSoSinh);
                toursOrder.orders.GhiChu = toursOrder.orders.GhiChu;
                toursOrder.orders.HutThuoc = toursOrder.orders.HutThuoc;
                toursOrder.orders.PhongTangCao = toursOrder.orders.PhongTangCao;
                toursOrder.orders.AnChay = toursOrder.orders.AnChay;
                toursOrder.orders.NguoiKhuyetTat = toursOrder.orders.NguoiKhuyetTat;
                toursOrder.orders.PhuNuCoThai = toursOrder.orders.PhuNuCoThai;

                db.Orders.Add(new Order()
                {
                    IdKH = toursOrder.orders.IdKH,
                    IDTour = toursOrder.orders.IDTour,
                    HoTen = toursOrder.orders.HoTen,
                    SDT = toursOrder.orders.SDT,
                    Email = toursOrder.orders.Email,
                    SoKhachLon = toursOrder.orders.SoKhachLon,
                    SoKhachTreEm = toursOrder.orders.SoKhachTreEm,
                    SoKhachTreNho = toursOrder.orders.SoKhachTreNho,
                    SoKhachSoSinh = toursOrder.orders.SoKhachSoSinh,
                    TongSoKhach = toursOrder.orders.TongSoKhach,
                    TongGia = toursOrder.orders.TongGia,
                    GhiChu = toursOrder.orders.GhiChu,
                    HutThuoc = toursOrder.orders.HutThuoc,
                    PhongTangCao = toursOrder.orders.PhongTangCao,
                    AnChay = toursOrder.orders.AnChay,
                    NguoiKhuyetTat = toursOrder.orders.NguoiKhuyetTat,
                    PhuNuCoThai = toursOrder.orders.PhuNuCoThai,
                });
            }    
            //var geetID = db.TourDuLiches.Where(x => x.ID == id).Count();
            
            
            db.SaveChanges();
            return RedirectToAction("Payments", new { idKH = toursOrder.orders.IdKH, idTour = toursOrder.tours.ID });
        }

        public ActionResult Payments()
        {
            var dao = new KetNoiTours_Orders();
            //ViewBag.payment = db.Orders.Where(x => x.IDTour == idTours && x.IdKH == idKH).ToList();
            //ViewBag.tours = db.TourDuLiches.Where(x => x.ID == id).ToList();

            //if (ViewBag.payment.Count() > 0)
            //{
            //    ViewBag.listBills = ViewBag.payment;
            //    return View();

            //}
            //else
            //{
            //    return View();
            //}
            return View();
        }
    }
}