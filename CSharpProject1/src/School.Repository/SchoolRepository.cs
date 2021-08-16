using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using School.Repository.Models;
using System.Data.SqlClient;
using System.Data;

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

        public static void AddClassForUser(int userId, int classId)
        {
            // check if user is already registered for this class
            var classFound = DatabaseAccessor
                            .Instance
                            .UserClass
                            .FirstOrDefault(c => c.UserId == userId && c.ClassId == classId);
            if (classFound == null)
            {
                // add class
                var userClass = DatabaseAccessor.Instance.UserClass
                            .Add(new School.DB.UserClass
                            {
                                ClassId = classId,
                                UserId = userId
                            });
                DatabaseAccessor.Instance.SaveChanges();
            }

            return;
        }

        public List<StudentClassModel> GetClassesForStudent(int userId)
        {
            //check for valid user
            var userFound = DatabaseAccessor
                .Instance
                .User
                .FirstOrDefault(u => u.UserId == userId);

            if (userFound == null)
            {
                return null;
            }

            // now get classes for this user
            SqlParameter prmUserId = new SqlParameter("userId", userId);
            //List<UserClassModel> studentClasses = DatabaseAccessor.Instance.Database.SqlQuery<UserClassModel>("_sp_GetClassesForStudent @userId", prmUserId).ToLIst();
            //if (studentClasses != null)
            //{
            //    UserId = userId,
            //    ClassId = studentClass.IncludeDetailRows,
            //    ClassName = studentClass.ClassName,
            //    ClassDescription = studentClass.ClassDescription,
            //    ClassPrice = studentClass.ClassPrice,
            //}

            List<School.DB.UserClass> classes = DatabaseAccessor.Instance.UserClass.Where(u => u.UserId == userId).ToList();

            List<StudentClassModel> studentClasses = new List<StudentClassModel>();
            foreach (School.DB.UserClass myClass in classes){
                var oneClass = DatabaseAccessor.Instance.ClassMaster.Where(c => c.ClassId == myClass.ClassId).FirstOrDefault(); ;

                StudentClassModel studentClass = new StudentClassModel();

                studentClass = new StudentClassModel
                {
                    UserId = userId,
                    ClassId = oneClass.ClassId,
                    ClassName = oneClass.ClassName,
                    ClassDescription = oneClass.ClassDescription,
                    ClassPrice = oneClass.ClassPrice
                };

                studentClasses.Add(studentClass);                                       
            }

            
            return studentClasses;

        }
    }
}

