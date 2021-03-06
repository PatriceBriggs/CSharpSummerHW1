using System;
using System.Collections.Generic;

namespace School.DB
{
    public partial class User
    {
        public User()
        {
            UserClass = new HashSet<UserClass>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }

        public ICollection<UserClass> UserClass { get; set; }
    }
}
