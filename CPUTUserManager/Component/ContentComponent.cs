using CPUTUserManager.Component.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPUTUserManager.Models;
using CPUTUserManager.Sidecar.RestSharp.Interface;
using Newtonsoft.Json;

namespace CPUTUserManager.Component
{
    public class ContentComponent : IContentComponent
    {
        private readonly IRestBroker _restBroker;
        private readonly IEndPoint _endPoint;

        public ContentComponent(IRestBroker restBroker, IEndPoint endPoint)
        {
            _restBroker = restBroker;
            _endPoint = endPoint;
        }

        public PasswordViewModel ReadPassword(LoginViewModel model)
        {
            string resource = "";
            if (model.IsAdmin == true)
            {
                resource = $"admin/login/read/{model.Username}";
            }
            else
                resource = $"student/login/read/{model.Username}"; 

            var result = _restBroker.Get(_endPoint.Endpoint, resource, model, null);
            return JsonConvert.DeserializeObject<PasswordViewModel>(result.Content);
        }

        public bool PasswordAction(PasswordViewModel model)
        {
            string crud = "";
            string resource = "";
            if(model.CRUD == 1)
            {
                crud = "create";
            }
            else if(model.CRUD == 2)
            {
                crud = "update";
            }
            else if(model.CRUD == 3)
            {
                crud = "delete";
            }

            if (model.IsAdmin == true)
            {
                if(model.CRUD == 3)
                {
                    resource = $"admin/login/{crud}/{model.UserName}";
                }
                else
                resource = $"admin/login/{crud}/";
            }
            else
            {
                if(model.CRUD == 3)
                {
                    resource = $"student/login/{crud}/{model.UserName}";
                }
                else
                    resource = $"student/login/{crud}/";
            }
                
            var modelObj = new PasswordModel()
            {
                UserName = model.UserName,
                Password = model.Password

            };

            var result = _restBroker.Get(_endPoint.Endpoint, resource, modelObj, null);
            return result.IsSuccessful;
        }
        public CourseViewModel ReadCourse(LoginViewModel model)
        {
            string resource = "";
            if (model.IsAdmin == true)
            {
                resource = $"admin/course/read/{model.Username}";
            }
            else
                resource = resource = $"student/course/read/{model.Username}";

            var result = _restBroker.Get(_endPoint.Endpoint, resource, model, null);
            return JsonConvert.DeserializeObject<CourseViewModel>(result.Content);
        }

        public bool CourseAction(CourseViewModel model)
        {
            string crud = "";
            string resource = "";
            if (model.CRUD == 1)
            {
                crud = "create";
            }
            else if (model.CRUD == 2)
            {
                crud = "update";
            }
            else if (model.CRUD == 3)
            {
                crud = "delete";
            }

            if (model.IsAdmin == true)
            {
                if (model.CRUD == 3)
                {
                    resource = $"admin/course/{crud}/{model.UserName}";
                }
                else
                    resource = $"admin/course/{crud}/";
            }
            else
            {
                if (model.CRUD == 3)
                {
                    resource = $"student/course/{crud}/{model.UserName}";
                }
                else
                    resource = $"student/course/{crud}/";
            }

            var modelObj = new CourseModel()
            {
                UserName = model.UserName,
                Course = model.Course

            };

            var result = _restBroker.Get(_endPoint.Endpoint, resource, modelObj, null);
            return result.IsSuccessful;
           
        }
        public SosPasswordViewModel ReadSosPassword(LoginViewModel model)
        {
            string resource = "";
            if (model.IsAdmin == true)
            {
                resource = $"admin/login/read/{model.Username}";
            }
            else
                resource = $"student/login/read/{model.Username}";

            var result = _restBroker.Get(_endPoint.Endpoint, resource, model, null);
            return JsonConvert.DeserializeObject<SosPasswordViewModel>(result.Content);

           
        }

        public bool SosPasswordAction(SosPasswordViewModel model)
        {
            string crud = "";
            string resource = "";
            if (model.CRUD == 1)
            {
                crud = "create";
            }
            else if (model.CRUD == 2)
            {
                crud = "update";
            }
            else if (model.CRUD == 3)
            {
                crud = "delete";
            }

            if (model.IsAdmin == true)
            {
                if (model.CRUD == 3)
                {
                    resource = $"admin/sospassword/{crud}/{model.UserName}";
                }
                else
                    resource = $"admin/sospassword/{crud}/";
            }
            else
            {
                if (model.CRUD == 3)
                {
                    resource = $"student/sospassword/{crud}/{model.UserName}";
                }
                else
                    resource = $"student/sospassword/{crud}/";
            }

            var modelObj = new PasswordModel()
            {
                UserName = model.UserName,
                Password = model.Password

            };

            var result = _restBroker.Get(_endPoint.Endpoint, resource, modelObj, null);
            return result.IsSuccessful;
        }
        public PersonalDetailViewModel ReadPersonalDetail(LoginViewModel model)
        {
            string resource = "";
            if (model.IsAdmin == true)
            {
                resource = $"admin/personaldetail/read/{model.Username}";
            }
            else
                resource = $"student/personaldetail/read/{model.Username}";

            var result = _restBroker.Get(_endPoint.Endpoint, resource, model, null);
            return JsonConvert.DeserializeObject<PersonalDetailViewModel>(result.Content);


        }

        public RestModel PersonalDetailAction(PersonalDetailViewModel model)
        {
            string crud = "";
            string resource = "";

            if (model.CRUD == 1)
            {
                crud = "create";
            }
            else if (model.CRUD == 2)
            {
                crud = "update";
            }
            else if (model.CRUD == 3)
            {
                crud = "delete";
            }

            if (model.IsAdmin == true)
            {
                resource = $"admin/personaldetail/{crud}/{model.Id}";
            }
            else
                resource = $"student/personaldetail/{crud}/{model.Id}";

            var result = _restBroker.Post(_endPoint.Endpoint, resource, model, null);
            return JsonConvert.DeserializeObject<RestModel>(result.Content);
        }
        public SubjectModel ReadSubject(SubjectViewModel model)
        {
            string resource = "";
            if (model.IsAdmin == true)
            {
                resource = $"admin/subject/read/{model.Id}"; ;
            }
            else
                resource = $"student/subject/read/{model.Id}";

            var result = _restBroker.Get(_endPoint.Endpoint, resource, model.Id, null);
            return JsonConvert.DeserializeObject<SubjectModel>(result.Content);
        }

        public RestModel SubjectAction(SubjectViewModel model)
        {
            string crud = "";
            string resource = "";

            if (model.CRUD == 1)
            {
                crud = "create";
            }
            else if (model.CRUD == 2)
            {
                crud = "update";
            }
            else if (model.CRUD == 3)
            {
                crud = "delete";
            }

            if (model.IsAdmin == true)
            {
                resource = $"admin/subject/{crud}/{model.Id}"; ;
            }
            else
                resource = $"student/subject/{crud}/{model.Id}";

            var result = _restBroker.Post(_endPoint.Endpoint, resource, model, null);
            return JsonConvert.DeserializeObject<RestModel>(result.Content);
        }

        public EmergencyContactModel ReadEmergencyContact(EmergencyContactViewModel model)
        {
            string resource = "";
            if (model.IsAdmin == true)
            {
                resource = $"admin/emergencycontact/read/{model.Id}"; ;
            }
            else
                resource = $"student/emergencycontact/read/{model.Id}";

            var result = _restBroker.Get(_endPoint.Endpoint, resource, model.Id, null);
            return JsonConvert.DeserializeObject<EmergencyContactModel>(result.Content);
        }

        public RestModel EmergencyContactAction(EmergencyContactViewModel model)
        {
            string crud = "";
            string resource = "";

            if (model.CRUD == 1)
            {
                crud = "create";
            }
            else if (model.CRUD == 2)
            {
                crud = "update";
            }
            else if (model.CRUD == 3)
            {
                crud = "delete";
            }

            if (model.IsAdmin == true)
            {
                resource = $"admin/emergencycontact/{crud}/{model.Id}"; ;
            }
            else
                resource = $"student/emergencycontact/{crud}/{model.Id}";

            var result = _restBroker.Post(_endPoint.Endpoint, resource, model, null);
            return JsonConvert.DeserializeObject<RestModel>(result.Content);
        }
    }
}
