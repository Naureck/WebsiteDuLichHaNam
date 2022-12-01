using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaNamSite.Models.EF;

namespace HaNamSite.Models.DAO
{
    public class UserDao
    {
        QLDL db = null;
        public UserDao()
        {
            db = new QLDL();
        }

        public List<User> UserOrder()
        {
            return db.Users.OrderBy(x => x.CreatedDate).ToList();
        }
    }
}