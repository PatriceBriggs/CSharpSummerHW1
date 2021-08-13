using School.Repository.Models;
using System.Collections.Generic;

namespace School.Repository
{
    public interface ISchoolRepository
    {
        ClassMasterModel[] Classes { get; }

        ClassMasterModel ClassMaster(int classId);

        UserModel LogIn(string email, string password);

        UserModel Register(string name, string email, string password);
      
        List<StudentClassModel> GetClassesForStudent(int userId);
    }
}