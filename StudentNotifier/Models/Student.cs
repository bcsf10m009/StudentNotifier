//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentNotifier.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public int Id { get; set; }
        public Nullable<int> LogID { get; set; }
        public string RollNo { get; set; }
        public string FullName { get; set; }
        public string Courses { get; set; }
    
        public virtual Login Login { get; set; }
    }
}
