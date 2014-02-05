using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using StudentNotifier.Models;

namespace StudentNotifier.Controllers
{
    public class MenuesController : Controller
    {
        private StudentNotifierEntities sn = new StudentNotifierEntities();
        private Inotifier not;
        //
        // GET: /Login/

        
        //
        // GET: /Student/Create
        public MenuesController(Inotifier not)
        {
            this.not = not;
        }
        public ActionResult Student(Login log)
        {
            return View(log);
        }
        public ActionResult Teacher(Login log)
        {
            return View(log);
        }
        public ActionResult AddSubject(Login log)
        {
            String semestr = Request["semesterSelector"];
            String teachr = Request["teacherSelctor"];
            String course = Request["courseSelctor"];
            not.AddSCourse(course, log);
            return View();
        }
    }
}
