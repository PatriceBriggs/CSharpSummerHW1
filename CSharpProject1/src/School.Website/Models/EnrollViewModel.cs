using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;


namespace School.Website.Models
{
    public class EnrollViewModel
    {
        [Display(Name = "Class List")]
        public SelectList ClassListSL { get; set; }


    }
}
