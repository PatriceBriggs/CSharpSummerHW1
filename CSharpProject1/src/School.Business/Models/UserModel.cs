using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace School.Business.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        public bool UserIsAdmin { get; set; }

        //public UserModel(int userId, string userEmail, string userPassword, bool userIsAdmin)
        //{
        //    UserId = userId;
        //    UserEmail = userEmail;
        //    UserPassword = userPassword;
        //    UserIsAdmin = userIsAdmin;
        //}
    }
}
