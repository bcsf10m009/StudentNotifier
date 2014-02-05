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
    }
}
