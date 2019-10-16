using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CPUTUserManager.Models
{
    public class LoginViewModel
    {
        [DisplayName("userName")]
        public string Username { get; set; }

        [DisplayName("password")]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}
