using School.Business.Models;
using School.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Business
{
    public class UserService : IUserService
    {
        private readonly ISchoolRepository schoolRepository;

        public UserService(ISchoolRepository schoolRepository)
        {
            this.schoolRepository = schoolRepository;
        }

        public UserModel LogIn(string email, string password)
        {
            var user = schoolRepository.LogIn(email, password);

            if (user == null)
            {
                return null;
            }

            return new UserModel { UserId = user.UserId, UserEmail = user.UserEmail };
        }

        public UserModel Register(string email, string password)
        {
            var user = schoolRepository.Register(email, password);

            if (user == null)
            {
                return null;
            }

            return new UserModel { UserId = user.UserId, UserEmail = user.UserEmail };
        }
    }
}
