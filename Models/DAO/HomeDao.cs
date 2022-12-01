using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaNamSite.Models.EF;

namespace HaNamSite.Models.DAO
{
    public class HomeDao
    {
        QLDL db = null;
        public HomeDao()
        {
            db = new QLDL();
        }

        public List<TourDuLich> listTours(int top)
        {
            var data = (from q in db.TourDuLiches
                        orderby q.NgayKhoiHanh
                        descending
                        select q).Take(top);
            return data.Where(x => x.Status == true && x.NgayKhoiHanh > DateTime.Now).OrderBy(x => x.NgayKhoiHanh).ToList();
            
        }

        public List<TourDuLich> listToursHot(int top)
        {
            return db.TourDuLiches.Where(x => x.Status == true && x.NgayKhoiHanh > DateTime.Now).OrderBy(x => x.tophop).Take(top).ToList();
        }
        public List<DiaDiem> listLocation(int top)
        {
            return db.DiaDiems.Take(top).ToList();
        }

        public KhachHang getKhachHang(string TaiKhoan, string MatKhau)
        {
            return db.KhachHangs.SingleOrDefault(n => n.taikhoan == TaiKhoan && n.matkhau.ToString() == MatKhau);
        }

        public bool info(string TaiKhoan, string MatKhau)
        {
            try
            {
                var kh = db.KhachHangs.SingleOrDefault(n => n.taikhoan == TaiKhoan && n.matkhau.ToString() == MatKhau);
                if (kh != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch
            {
                return false;
            }
        }


    }
}