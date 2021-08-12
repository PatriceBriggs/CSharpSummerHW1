using System;
using System.Collections.Generic;

namespace School.DB
{
    public partial class ClassMaster
    {
        public ClassMaster()
        {
            UserClass = new HashSet<UserClass>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public decimal ClassPrice { get; set; }
        public int ClassSessions { get; set; }

        public ICollection<UserClass> UserClass { get; set; }
    }
}
