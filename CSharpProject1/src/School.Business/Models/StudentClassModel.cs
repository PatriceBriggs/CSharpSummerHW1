using System;
using System.Collections.Generic;
using System.Text;

namespace School.Business.Models
{
    public class StudentClassModel
    {
        public int UserId { get; set; }

        public int ClassId { get; set; }

        public string ClassName { get; set; }

        public string ClassDescription { get; set; }

        public decimal ClassPrice { get; set; }
    }
}
