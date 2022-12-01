using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaNamSite.Models.EF;

namespace HaNamSite.Models.DAO
{
    public class LocationDao
    {
        QLDL db = null;
        public LocationDao()
        {
            db = new QLDL();
        }

        public List<ImgDiaDiem> imgLocation(DiaDiem local)
        {
            return db.ImgDiaDiems.Where(x => x.IdDiaDiem == local.ID).ToList();
        }

        public DiaDiem detailsLocation(long id)
        {
            return db.DiaDiems.Find(id);
        }

        

    }
}