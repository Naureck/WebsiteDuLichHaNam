using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HaNamSite.Models.EF;
using HaNamSite.Models.DAO;
namespace HaNamSite.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        QLDL db = new QLDL();
        UserDao Dao = new UserDao();
        // GET: Admin/Users
        public ActionResult Index()
        {
            var model = Dao.UserOrder();
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateUsers()
        {
            ViewBag.IdUser = new SelectList(db.Users.OrderBy(n => n.UserName), "ID", "UserName");
            return View();
        }
        [HttpPost]
        public ActionResult CreateUsers(User users)
        {
            ViewBag.IdUser = new SelectList(db.Users.OrderBy(n => n.UserName), "ID", "UserName");
            if (ModelState.IsValid)
            {
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        public ActionResult EditUsers(int id)
        {

            var edit = db.Users.FirstOrDefault(n => n.ID == id);
            return View(edit);
        }
        [HttpPost]
        public ActionResult EditUsers(User users)
        {
            var updateUsers = db.Users.Find(users.ID) as User;
            updateUsers.UserName = users.UserName;
            updateUsers.Password = users.Password;
            updateUsers.Email = users.Email;
            updateUsers.ModifiedDate = users.ModifiedDate;
            updateUsers.ModifiedBy = users.ModifiedBy;
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);

        }

        public ActionResult DeleteUsers(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        [HttpPost, ActionName("DeleteUsers")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUsersConfirmed(int? id)
        {
            User users = db.Users.Find(id);
            db.Users.Remove(users);
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