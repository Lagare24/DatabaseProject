using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LagareCRUD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var listOfUser = new List<user>();
            using (var db = new user_dbEntities())
            {
                listOfUser = db.users.ToList();
            }

            return View(listOfUser);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(user u)
        {
            using (var db = new user_dbEntities())
            {
                var newUser = new user();
                newUser.firstName = u.firstName;
                newUser.lastName = u.lastName;
                newUser.birthMonth = Convert.ToInt32(u.birthMonth);
                newUser.birthday = u.birthday;
                newUser.birthYear = u.birthYear;
                newUser.username = u.username;
                newUser.password = u.password;

                db.users.Add(newUser);
                db.SaveChanges();

                TempData["msg"] = $"Added {newUser.username} Successfully!";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var existingUser = new user();
            using (var db = new user_dbEntities())
            {
                existingUser = db.users.Find(id);
            }
            return View(existingUser);
        }
        [HttpPost]
        public ActionResult Update(user u)
        {
            using (var db = new user_dbEntities())
            {
                var existingUser = db.users.Find(u.userId);
                existingUser.firstName = u.firstName;
                existingUser.lastName = u.lastName;
                existingUser.birthMonth = Convert.ToInt32(u.birthMonth);
                existingUser.birthday = u.birthday;
                existingUser.birthYear = u.birthYear;
                existingUser.username = u.username;
                existingUser.password = u.password;

                db.SaveChanges();

                TempData["msg"] = $"Updated {existingUser.username} Successfully!";
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var existingUser = new user();
            using (var db = new user_dbEntities())
            {
                existingUser = db.users.Find(id);


                db.users.Remove(existingUser);
                db.SaveChanges();

                TempData["msg"] = $"Deleted {existingUser.username} Successfully!";
            }
            return RedirectToAction("Index");
        }
    }
}
