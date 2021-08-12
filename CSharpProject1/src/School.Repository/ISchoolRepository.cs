using School.Repository.Models;

namespace School.Repository
{
    public interface ISchoolRepository
    {
        ClassMasterModel[] Classes { get; }

        ClassMasterModel ClassMaster(int classId);

        UserModel LogIn(string email, string password);

        UserModel Register(string name, string email, string password);
    }
}