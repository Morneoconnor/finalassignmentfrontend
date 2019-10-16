using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPUTUserManager.Models
{
    public class SubjectViewModel
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public int CRUD { get; set; }
        public bool IsAdmin { get; set; }
    }
}
