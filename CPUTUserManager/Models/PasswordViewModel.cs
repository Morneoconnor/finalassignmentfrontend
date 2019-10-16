using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPUTUserManager.Models
{
    public class PasswordViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? CRUD { get; set; }
        public bool IsAdmin { get; set; }
    }
}
