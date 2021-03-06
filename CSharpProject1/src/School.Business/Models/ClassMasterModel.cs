using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace School.Business.Models
{
    public class ClassMasterModel
    {
        [Key]
        public int ClassId { get; set; }

        public string ClassName { get; set; }

        public string ClassDescription { get; set; }

        public decimal ClassPrice { get; set; }

        public int ClassSessions { get; set; }

        public ClassMasterModel(int classId, string className, string classDescription, decimal classPrice, int classSessions)
        {
            ClassId = classId;
            ClassName = className;
            ClassDescription = classDescription;
            ClassPrice = classPrice;
            ClassSessions = classSessions;
        }
    }
}
