using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaNamSite.Models.EF;

namespace HaNamSite.Models.DAO
{
    public class ToursDao
    {
        QLDL db = null;
        public ToursDao()
        {
            db = new QLDL();
        }

        public List<TourDuLich> listTours(int top)
        {
            return db.TourDuLiches.Where(x => x.Status == true && x.NgayKhoiHanh > DateTime.Now).OrderBy(x => x.NgayKhoiHanh).Take(top).ToList();
        }

        public TourDuLich infoTours(long id)
        {
            return db.TourDuLiches.Find(id);        
        }

    }
}