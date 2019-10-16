using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPUTUserManager.Models
{
    public class CourseViewModel
    {
        public string UserName { get; set; }
        public string Course { get; set; }
        public int? CRUD { get; set; }
        public bool IsAdmin { get; set; }
    }
}
