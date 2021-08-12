using System;
using System.Collections.Generic;
using System.Text;

namespace School.Business.Models
{
    public class UserClassModel
    {
        public int ClassId { get; set; }

        public int UserId { get; set; }

        public UserClassModel(int classId, int userId)
        {
            ClassId = classId;
            UserId = userId;
        }
        
    }
}
