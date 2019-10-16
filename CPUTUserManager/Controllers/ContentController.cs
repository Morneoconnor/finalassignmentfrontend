using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CPUTUserManager.Models;
using CPUTUserManager.Component.Interface;

namespace CPUTUserManager.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentComponent _contentComponent;

        public ContentController(IContentComponent contentComponent)
        {
            _contentComponent = contentComponent;
        }
        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Password(LoginViewModel model)
        {
            var result = _contentComponent.ReadPassword(model);
            result.IsAdmin = model.IsAdmin;
            return View(result);
        }

        [HttpPost]
        public IActionResult PasswordAction(PasswordViewModel model)
        {

            var result = _contentComponent.PasswordAction(model);
            return View(result);
        }

        [HttpPost]
        public IActionResult SosPassword(LoginViewModel model)
        {
            var result = _contentComponent.ReadSosPassword(model);
            result.IsAdmin = model.IsAdmin;
            return View(result);
        }

        [HttpPost]
        public IActionResult SosPasswordAction(SosPasswordViewModel model)
        {
            var result = _contentComponent.SosPasswordAction(model);
            return View(result);
        }

        [HttpPost]
        public IActionResult PersonalDetails(LoginViewModel model)
        {
            var result = _contentComponent.ReadPersonalDetail(model);
            return View(result);
        }

        [HttpPost]
        public IActionResult PersonalDetailsAction(PersonalDetailViewModel model)
        {
            var result = _contentComponent.PersonalDetailAction(model);
            return View(result);
        }

        [HttpPost]
        public IActionResult Subject(SubjectViewModel model)
        {
            var result = _contentComponent.ReadSubject(model);
            return View(result);
        }

        [HttpPost]
        public IActionResult SubjectAction(SubjectViewModel model)
        {
            var result = _contentComponent.SubjectAction(model);
            return View(result);
        }


        [HttpPost]
        public IActionResult Course(LoginViewModel model)
        {
            var result = _contentComponent.ReadCourse(model);
            return View(model);
        }

        [HttpPost]
        public IActionResult CourseAction(CourseViewModel model)
        {
            var result = _contentComponent.CourseAction(model);
            return View(model);
        }

        [HttpPost]
        public IActionResult EmergenctContact(EmergencyContactViewModel model)
        {
            var result = _contentComponent.ReadEmergencyContact(model);
            return View(result);
        }

        [HttpPost]
        public IActionResult EmergenctContactAction(EmergencyContactViewModel model)
        {
            var result = _contentComponent.EmergencyContactAction(model);
            return View(result);
        }

    }

}