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
            not.AddSCourse(course,log);
            return View("Student");
        }
        public ActionResult AddCourse(Login log)
        {
            int semestr = int.Parse(Request["semester"]);
            String course = Request["course"];
            not.AddSCourseForTeacher(course , semestr, log);
            return View("Teacher");
        }
        [HttpPost]
        public ActionResult SaveNotification(Login log)
        {
            String semes = Request["semSelector"];
            String course = Request["courseSelctor"];
            String notification = Request["notification"];
            String filePath = "";
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i];
                file.SaveAs(Server.MapPath(@"~\Files\" + file.FileName));
                filePath = @"\Files\" + file.FileName;
            }
            not.saveNotification(notification, int.Parse(semes), filePath, log);

            return View("Index");
        }
    }
}
