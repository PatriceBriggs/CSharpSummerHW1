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

            public string ClassName { get; set; }

            public string ClassDescription { get; set; }

            public decimal ClassPrice { get; set; }

            public int ClassSessions { get; set; }
        }
    }
