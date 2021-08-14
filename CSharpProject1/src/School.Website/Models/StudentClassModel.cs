using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.Website.Models
{
    public class StudentClassModel // One Class
    {
        public int UserId { get; set; }

        public int ClassId { get; set; }

        [Display(Name = "Class Name")]
        public string ClassName { get; set; }

        [Display(Name = "Description ")]
        public string ClassDescription { get; set; }

        [Display(Name = "Price")]
        public decimal ClassPrice { get; set; }      
    }
}
