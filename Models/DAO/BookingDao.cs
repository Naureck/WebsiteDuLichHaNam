using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaNamSite.Models.EF;
namespace HaNamSite.Models.DAO
{
    public class BookingDao
    {
        QLDL db = null;
        public BookingDao()
        {
            db = new QLDL();
        }

        public Order infoOrder(long id)
        {
            return db.Orders.Find(id);
        }
    }
}