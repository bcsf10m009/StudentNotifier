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
            return View("Student",log);
        }
        public ActionResult AddCourse(Login log)
        {
            int semestr = int.Parse(Request["semester"]);
            String course = Request["course"];
            not.AddSCourseForTeacher(course , semestr, log);
            return View("Teacher",log);
        }
        [HttpPost]
        public ActionResult SaveNotification(int id)
        {
            String semes = Request["semSelctor"];
            String course = Request["courseSlctr"];
            String notification = Request["notification"];
            String filePath = "";
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i];
                file.SaveAs(Server.MapPath(@"~\Files\" + file.FileName));
                filePath = @"\Files\" + file.FileName;
            }
            Login log = sn.Logins.Find(id);
            not.saveNotification(notification, int.Parse(semes), course, filePath ,log);

            return View("Teacher",log);
        }
    }
}
