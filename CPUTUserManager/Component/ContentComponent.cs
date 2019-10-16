using CPUTUserManager.Component.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPUTUserManager.Models;
using CPUTUserManager.Sidecar.RestSharp.Interface;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace CPUTUserManager.Component
{
    public class ContentComponent : IContentComponent
    {
        private readonly IRestBroker _restBroker;
        private readonly IEndPoint _endPoint;
        private readonly ILogger<ContentComponent> _logger;

        public ContentComponent(IRestBroker restBroker, IEndPoint endPoint, ILogger<ContentComponent> logger)
        {
            _logger = logger;
            _restBroker = restBroker;
            _endPoint = endPoint;
        }

        public PasswordViewModel ReadPassword(LoginViewModel model)
        {
            try
            {
                string resource = "";
                if (model.IsAdmin == true)
                {
                    resource = $"admin/login/read/{model.Username}";
                }
                else
                    resource = $"student/login/read/{model.Username}";
                
                var result = _restBroker.Get(_endPoint.Endpoint, resource, model, null);
                _logger.LogInformation($"Sucess {result}");
                return JsonConvert.DeserializeObject<PasswordViewModel>(result.Content);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed ex: {ex}");
                throw ex;
            }
          
        }

        public bool PasswordAction(PasswordViewModel model)
        {
            try
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
                        resource = $"admin/login/{crud}/{model.UserName}";
                    }
                    else
                        resource = $"admin/login/{crud}/";
                }
                else
                {
                    if (model.CRUD == 3)
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
            catch(Exception ex)
            {
                _logger.LogError($"Failed ex: {ex}");
                throw ex;
            }
           
        }
        public CourseViewModel ReadCourse(LoginViewModel model)
        {
            try
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
            catch(Exception ex)
            {
                _logger.LogError($"Failed ex: {ex}");
                throw ex;
            }
           
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
            _logger.LogInformation($"Success {result}");
            return result.IsSuccessful;
           
        }
        public SosPasswordViewModel ReadSosPassword(LoginViewModel model)
        {
            try
            {
                string resource = "";
                if (model.IsAdmin == true)
                {
                    resource = $"admin/login/read/{model.Username}";
                }
                else
                    resource = $"student/login/read/{model.Username}";

                var result = _restBroker.Get(_endPoint.Endpoint, resource, model, null);
                _logger.LogInformation($"Success ex: {result}");
                return JsonConvert.DeserializeObject<SosPasswordViewModel>(result.Content);
            }
           catch(Exception ex)
            {
                _logger.LogError($"Failed ex: {ex}");
                throw ex;
            }     
        }

        public bool SosPasswordAction(SosPasswordViewModel model)
        {
            try
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
            catch(Exception ex)
            {
                _logger.LogError($"Failed ex: {ex}");
                throw ex;
            }
           
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
        public SubjectViewModel ReadSubject(LoginViewModel model)
        {
            string resource = "";
            if (model.IsAdmin == true)
            {
                resource = $"admin/subject/read/{model.Username}"; ;
            }
            else
                resource = $"student/subject/read/{model.Username}";

            var result = _restBroker.Get(_endPoint.Endpoint, resource, model.Username, null);
            return JsonConvert.DeserializeObject<SubjectViewModel>(result.Content);
        }

        public bool SubjectAction(SubjectViewModel model)
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
                resource = $"admin/subject/{crud}/{model.UserName}"; ;
            }
            else
                resource = $"student/subject/{crud}/{model.UserName}";

            var result = _restBroker.Post(_endPoint.Endpoint, resource, model, null);
            return result.IsSuccessful;
        }

        public EmergencyContactViewModel ReadEmergencyContact(LoginViewModel model)
        {
            string resource = "";
            if (model.IsAdmin == true)
            {
                resource = $"admin/emergencycontact/read/{model.Username}";
            }
            else
                resource = $"student/emergencycontact/read/{model.Username}";

            var result = _restBroker.Get(_endPoint.Endpoint, resource, model, null);
            return JsonConvert.DeserializeObject<EmergencyContactViewModel>(result.Content);
        }

        public bool EmergencyContactAction(EmergencyContactViewModel model)
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
                    resource = $"admin/emergencycontact/{crud}/{model.UserName}";
                }
                else
                    resource = $"admin/emergencycontact/{crud}/";
            }
            else
            {
                if (model.CRUD == 3)
                {
                    resource = $"student/emergencycontact/{crud}/{model.UserName}";
                }
                else
                    resource = $"student/emergencycontact/{crud}/";
            }

            var modelObj = new EmergencyContactModel()
            {
                UserName = model.UserName,
                Name = model.Name,
                Mobile = model.Mobile

            };
            var result = _restBroker.Get(_endPoint.Endpoint, resource, modelObj, null);
            return result.IsSuccessful;
        }
    }
}
