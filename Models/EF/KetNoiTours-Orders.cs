using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaNamSite.Models.EF
{
    public class KetNoiTours_Orders
    {
        public TourDuLich tours { get; set; }

        public Order orders { get; set; }
    }
}