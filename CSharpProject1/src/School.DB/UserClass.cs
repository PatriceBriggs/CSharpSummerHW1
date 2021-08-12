using System;
using System.Collections.Generic;

namespace School.DB
{
    public partial class UserClass
    {
        public int ClassId { get; set; }
        public int UserId { get; set; }

        public ClassMaster Class { get; set; }
        public User User { get; set; }
    }
}
