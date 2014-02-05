using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace StudentNotifier.Models
{
    public class LoginNotifier : Inotifier
    {
        StudentNotifierEntities sn = new StudentNotifierEntities();
        [ValidateAntiForgeryToken]
        public Login SignUp(Login log)
        {
            sn.Logins.Add(log);
            sn.SaveChanges();
            return log;
        }
        public Login Login(String name, String pass)
        {
            return sn.Logins.First(x => x.password.Equals(pass) && x.username.Equals(name));
        }
        public void AddSCourse(String Course, Login log)
        {
            Student s = sn.Students.First(x => x.LogID == log.Id);
            s.Courses += Course;
            sn.Entry(s).State = EntityState.Modified;
            sn.SaveChanges();
        }
        public void saveStudent(int semes, Login log)
        {
            Student s = new Student();
            s.FullName = log.FullName;
            s.LogID = log.Id;
            s.RollNo = log.username;
            s.Semester = semes;
            sn.Students.Add(s);
            sn.SaveChanges();
        }
        public void saveTeacher(Login log)
        {
            Teacher t = new Teacher();
            t.FullName = log.FullName;
            t.LogID = log.Id;
            t.username = log.username;
            sn.Teachers.Add(t);
            sn.SaveChanges();
        }
        public void AddSCourseForTeacher(String course, int semes, Login log)
        {
            Cours c = new Cours();
            c.Courses = course;
            c.SemesterNo = semes;
            c.Teacher = log.FullName;
            sn.Courses.Add(c);
            Teacher t = sn.Teachers.First(x => x.LogID == log.Id);
            t.Courses += course + ";";
            sn.Entry(t).State = EntityState.Modified;
            sn.SaveChanges();
        }
        public void saveNotification(String noti, int smes, String course, String fileName, Login log)
        {
            Notification notif = new Notification();
            notif.Course = course;
            notif.filePath = fileName;
            Teacher t = sn.Teachers.First(x => x.LogID == log.Id);
            notif.TId = t.Id;
            notif.notification1 = noti;
            notif.semester = smes;
            sn.Notifications.Add(notif);
            sn.SaveChanges();

        }
    }
}