using CPUTUserManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPUTUserManager.Component.Interface
{
    public interface IContentComponent
    {
        PasswordViewModel ReadPassword(LoginViewModel model);
        bool PasswordAction(PasswordViewModel model);
        CourseViewModel ReadCourse(LoginViewModel model);
        bool CourseAction(CourseViewModel model);
        SosPasswordViewModel ReadSosPassword(LoginViewModel model);
        bool SosPasswordAction(SosPasswordViewModel model);
        PersonalDetailViewModel ReadPersonalDetail(LoginViewModel model);
        RestModel PersonalDetailAction(PersonalDetailViewModel model);
        SubjectViewModel ReadSubject(LoginViewModel model);
        bool SubjectAction(SubjectViewModel model);
        EmergencyContactViewModel ReadEmergencyContact(LoginViewModel model);
        bool EmergencyContactAction(EmergencyContactViewModel model);

    }
}
