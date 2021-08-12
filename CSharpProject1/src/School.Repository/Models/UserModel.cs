using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace School.Repository.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        //public UserModel(int userId, string userName, string userEmail, string userPassword)
        //{
        //    UserId = userId;
        //    UserName = userName
        //    UserEmail = userEmail;
        //    UserPassword = userPassword;
        //}
    }
}
