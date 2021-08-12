using School.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Business
{
    public interface IUserService
    {
        UserModel LogIn(string email, string password);
        UserModel Register(string email, string password);
    }
}
