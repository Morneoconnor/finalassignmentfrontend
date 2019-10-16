using CPUTUserManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPUTUserManager.Component.Interface
{
    public interface IHomeComponent
    {
        LoginViewModel Login(LoginViewModel model);
        RestModel UserDetails(string userName);
    }
}
