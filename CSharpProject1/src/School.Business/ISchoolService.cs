using School.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace School.Business
{
    public interface ISchoolService
    {
        ClassMasterModel[] Classes { get; }

        ClassMasterModel ClassMaster(int classId);

        SelectList PopulateClassesDropDownList();
    }
}
