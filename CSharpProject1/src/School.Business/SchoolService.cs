using School.Business.Models;
using School.Repository;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace School.Business
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository schoolRepository;

        public SchoolService(ISchoolRepository schoolRepository)
        {
            this.schoolRepository = schoolRepository;
        }

        public ClassMasterModel[] Classes
        {
            get
            {
                return schoolRepository.Classes
                                         .Select(c => new ClassMasterModel(c.ClassId, c.ClassName, c.ClassDescription, c.ClassPrice, c.ClassSessions))
                                         .ToArray();
            }
        }

        public ClassMasterModel ClassMaster(int classId)
        {
            var classMasterModel = schoolRepository.ClassMaster(classId);
            return new ClassMasterModel(classMasterModel.ClassId, classMasterModel.ClassName, classMasterModel.ClassDescription,
                                        classMasterModel.ClassPrice, classMasterModel.ClassSessions);
        }

        public SelectList PopulateClassesDropDownList()
        {
            var classList = schoolRepository.Classes;

            var classQuery = from c in classList
                             orderby c.ClassName // Sort by name.
                             select new { c.ClassId, c.ClassName };

            object selectedClass = null;
            SelectList classListSL = new SelectList(classQuery,
                        "ClassId", "ClassName", selectedClass);

            return classListSL;
        }

        public List<StudentClassModel> GetClassesForStudent(int userId)
        {
            return schoolRepository.GetClassesForStudent(userId)
                        .Select(c =>
                             new StudentClassModel
                             {
                                 UserId = c.UserId,
                                 ClassId = c.ClassId,
                                 ClassName = c.ClassName,
                                 ClassDescription = c.ClassDescription,
                                 ClassPrice = c.ClassPrice
                             })
                        .ToList();
        }

        public void AddClassForUser(int userId, int classId)
        {
            SchoolRepository.AddClassForUser(userId, classId);
            return;

        }

    }
}

