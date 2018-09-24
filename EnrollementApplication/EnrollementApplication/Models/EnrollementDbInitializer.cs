using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnrollementApplication.Models
{
    public class EnrollementDbInitializer : System.Data.Entity.DropCreateDatabaseAlways<EnrollementDBContext>
{
        protected override void Seed(EnrollementDBContext context)
        {
            context.Enrollements.Add(new Enrollement
            {
                Student = new Student { First = "Sean", Last = "Sutila" },
                Course = new Course { Title = "IT-2030" },
                Grade = 100
            });
            base.Seed(context);
        }
    }
}