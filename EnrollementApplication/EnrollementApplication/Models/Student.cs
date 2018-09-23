using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnrollementApplication.Models
{
    public class Student
    {
        public virtual int StudentId { get; set; }
        public virtual string Last { get; set; }
        public virtual string First { get; set; }
    }
}