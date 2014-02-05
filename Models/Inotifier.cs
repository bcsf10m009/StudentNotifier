using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentNotifier.Models
{
    public interface Inotifier
    {
        Login SignUp(Login log);
        Login Login(String name, String pass);
        void AddSCourse(String Course, Login log);
        void saveStudent(int semes, Login log);
        void saveTeacher( Login log);
        void AddSCourseForTeacher(String course, int semes, Login log);
        void saveNotification(String noti, int smes, String course, String fileName, Login log);
    }
}
