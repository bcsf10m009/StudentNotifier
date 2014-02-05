using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentNotifier.Models;

namespace StudentNotifier.Controllers
{
    public class HomeController : Controller
    {
        private StudentNotifierEntities sn = new StudentNotifierEntities();
        Inotifier e;
        public HomeController( Inotifier i )
        {
            e = i;
        }
        //
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult Teacher(Login log)
        {
            return View(log);
        }
        public ActionResult Student(Login log)
        {
            return View(log);
        }
        //
        // POST: /Student/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Login log)
        {
            if (ModelState.IsValid)
            {
                Login log2 = e.SignUp(log);
                if (log2.type.Equals("Student"))
                {
                    return RedirectToAction("Student", "Home", log2);
                }
                else
                {
                    return RedirectToAction("Teacher", "Home", log2);
                }
            }

            return View(log);
        }
        [HttpPost]
        public ActionResult Login()
        {
            String name = Request["name"];
            String pass = Request["pass"];
            Login log = e.Login(name, pass);
                        // var verify = from x in sn.Logins
            //              where x.password.Equals(pass) && x.username.Equals(name)
            //              select new { x };
            if (log.type.Equals("Student"))
            {
                return RedirectToAction("Student", "Menues", log);
            }
            else if (log.type.Equals("Teacher"))
            {
                return RedirectToAction("Teacher", "Menues", log);
            }
            return View("index");
        }
        public JsonResult GetTeachers(int id)
        {
            //int id = int.Parse(Request["semesterSelector"]);
            List<Models.Cours> cities = new List<Models.Cours>();
            cities.Add(new Models.Cours( 1 , 1 , "Hello", "hello"));
            var teachers = sn.Courses.Where(m => m.SemesterNo.Equals(id)).Select(a => a).ToList();
           // System.Console.WriteLine("hello");
            return this.Json(teachers, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourses(int id,String name)
        {
            //int id = int.Parse(Request["semesterSelector"]);
           // List<Models.Cours> cities = new List<Models.Cours>();
           // cities.Add(new Models.Cours(1, 1, "Hello", "hello"));
            var courses = sn.Courses.Where(m => m.SemesterNo.Equals(id) && m.Teacher.Equals(name)).Select(a => a).ToList();
            // System.Console.WriteLine("hello");
            return this.Json(courses, JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            sn.Dispose();
            base.Dispose(disposing);
        }

    }
}
