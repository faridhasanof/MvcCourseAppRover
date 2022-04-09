using MvcCourseAppRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCourseAppRover.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Courses()
        {
            return View();
        }
        public ActionResult Teachers()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Apply()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Apply(STUDENT stud)
        {
            using (var db = new DB1Entities())
            {
                var newstudent = db.STUDENT.Create();

                newstudent.NAME = stud.NAME;
                newstudent.SURNAME = stud.SURNAME;
                newstudent.MOBILE = stud.MOBILE;
                newstudent.EMAIL = stud.EMAIL;

                db.STUDENT.Add(newstudent);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Approve(int id)
        {
            var db = new DB1Entities();
            var student = db.STUDENT.FirstOrDefault(a => a.ID == id);
            if (student!=null)
            {
                student.APPROVED = true;
            }
            db.SaveChanges();
            return RedirectToAction("Appeals");
        }
        public ActionResult Appeals()
        {
            DB1Entities db = new DB1Entities();
            var USER = db.STUDENT.Where(a => a.APPROVED == false || a.APPROVED == null).ToList();
            if (USER.Count==0)
            {
                return RedirectToAction("Index", "Home");
            }
            db.Dispose();
            return View(USER);
        }
    }
}
