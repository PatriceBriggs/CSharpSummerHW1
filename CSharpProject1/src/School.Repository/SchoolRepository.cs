using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using School.Repository.Models;
using System.Data.SqlClient;

namespace School.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
     
        public ClassMasterModel[] Classes
        {
            get
            {
                return DatabaseAccessor
                    .Instance
                    .ClassMaster
                    .Select(c => new ClassMasterModel
                    {
                        ClassId = c.ClassId,
                        ClassName = c.ClassName,
                        ClassDescription = c.ClassDescription,
                        ClassPrice = c.ClassPrice,
                        ClassSessions = c.ClassSessions
                    }).ToArray();
            }
        }

        public ClassMasterModel ClassMaster(int classId)
        {
            var classMasterModel = DatabaseAccessor.Instance.ClassMaster.Where(c => c.ClassId == classId)
                .Select(c => new ClassMasterModel
                {
                    ClassId = c.ClassId,
                    ClassName = c.ClassName,
                    ClassDescription = c.ClassDescription,
                    ClassPrice = c.ClassPrice,
                    ClassSessions = c.ClassSessions
                }).FirstOrDefault();

            return classMasterModel;
        }

        public UserModel LogIn(string email, string password)
        {
            var user = DatabaseAccessor
                        .Instance
                        .User
                        .FirstOrDefault(t => t.UserEmail.ToLower() == email.ToLower());

            if (user == null)
            {
                return null;
            }

            return new UserModel { UserName = user.UserName, UserId = user.UserId, UserEmail = user.UserEmail };
        }

        public UserModel Register(string name, string email, string password)
        {
            var userFound = DatabaseAccessor
                            .Instance
                            .User
                            .FirstOrDefault(t => t.UserEmail.ToLower() == email.ToLower());

            if (userFound != null)
            {
                return null;
            }

            var user = DatabaseAccessor.Instance.User
                    .Add(new School.DB.User
                    {
                        UserName = name,
                        UserEmail = email,
                        UserPassword = password
                        
                    });

            DatabaseAccessor.Instance.SaveChanges();

            return new UserModel { UserId = user.Entity.UserId, UserEmail = user.Entity.UserEmail };
        }


        public List<StudentClassModel> GetClassesForStudent(int userId)
        {
            //check for valid user
            var userFound = DatabaseAccessor
                .Instance
                .User
                .FirstOrDefault(u => u.UserId == userId);

            if (userFound != null)
            {
                return null;
            }

            // now get classes for this user
            SqlParameter prmUserId = new SqlParameter("userId", userId);
            //List<StudentClassModel> studentClasses = _context.Database.SqlQuery<AlertReportFormat>("_sp_GetAlertReportFormatInfo @clientAlertID", prmClientAlertID).FirstOrDefault();
            //if (alertReportFormat != null)
            //{
            //    model.IsDetailRowsIncluded = alertReportFormat.IncludeDetailRows;
            //    model.IsTopRowTotalsIncluded = alertReportFormat.IncludeTopRowTotals;
            //    model.IncludeZeroValueMatters = alertReportFormat.IncludeZeroValueMatters;
            //    model.ExcludeZeroValueMatters = alertReportFormat.ExcludeZeroValueMatters;
            //}

            //DatabaseAccessor.Instance.Query<>

            List<StudentClassModel> studentClasses = new List<StudentClassModel>();
            return studentClasses;

        }
    }
}

