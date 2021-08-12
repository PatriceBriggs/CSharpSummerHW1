using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Website.Models
{
    public class StudentClassModel // One Class
    {
        public int UserId { get; set; }

        public int ClassId { get; set; }

        public string ClassName { get; set; }

        public string ClassDescription { get; set; }

        public decimal ClassPrice { get; set; }

        public List<StudentClassModel>  StudentClasses { get; set; } // all classes for one student
    }
}
