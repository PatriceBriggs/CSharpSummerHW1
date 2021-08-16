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

        public SelectList ClassListSL { get; set; }


    }
}
