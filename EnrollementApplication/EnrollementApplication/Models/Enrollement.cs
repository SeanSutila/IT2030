using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnrollementApplication.Models
{
    public class Enrollement
    {
        public virtual int EnrollementId { get; set; }
        public virtual int StudentId { get; set; }
        public virtual int CourseId { get; set; }
        public virtual decimal Grade { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}