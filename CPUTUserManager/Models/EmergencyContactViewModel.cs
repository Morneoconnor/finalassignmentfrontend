using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CPUTUserManager.Models
{
    public class EmergencyContactViewModel
    {
        public string UserName { get; set; }
        [DisplayName("name")]
        public string Name { get; set; }
        public string Mobile { get; set; }
        public int CRUD { get; set; }
        public bool IsAdmin { get; set; }
    }
}
