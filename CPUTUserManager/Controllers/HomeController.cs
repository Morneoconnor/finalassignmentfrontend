using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CPUTUserManager.Models;
using CPUTUserManager.Component.Interface;
using CPUTUserManager.Models;

namespace CPUTUserManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeComponent _homeComponent;

        public HomeController(IHomeComponent homeComponent)
        {
            _homeComponent = homeComponent;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public LoginViewModel Login(LoginViewModel loginModel)
        {
            var result = _homeComponent.Login(loginModel);
            return result;
        }


        public IActionResult ForgotPassword() =>
                new PartialViewResult
                {
                    ViewName = "ForgotPassword",
                    ViewData = null,
                };

        public RestModel UserDetails(string username)
        {
            var result = _homeComponent.UserDetails(username);
            return result;
        }


    }
}
