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
        public void AddSCourse(String Course , Login log)
        {
            Student s = sn.Students.First(x => x.LogID==log.Id);
            s.Courses += Course;
            sn.Entry(s).State = EntityState.Modified;
            sn.SaveChanges();
        }
    }
}