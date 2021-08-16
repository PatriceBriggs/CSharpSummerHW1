using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.Website.Models
{
        public class ClassMasterModel
        {
            [Key]
            public int ClassId { get; set; }

            [Display(Name = "Class Name")]  
            public string ClassName { get; set; }

            [Display(Name = "Description ")]
            public string ClassDescription { get; set; }

            [UIHint("Currency")]
            [Display(Name = "Price")]
            public decimal ClassPrice { get; set; }

            public int ClassSessions { get; set; }
        }
    }
