using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Website.Models
{
    public class EnrollViewModel
    {
        //public int UserId { get; set; }

       // public ClassMasterModel[]  ClassList { get; set; }

        public SelectList ClassListSL { get; set; }

        //public void PopulateClassesDropDownList(minicstructorContext _context,
        //   object selectedClass = null)
        //{
        //    var classQuery = from c in _context.ClassMaster
        //                           orderby c.ClassName // Sort by name.
        //                           select c;

        //    ClassListSL = new SelectList(classQuery.AsNoTracking(),
        //                "ClassId", "ClassName", selectedClass);
        //}

    }
}
