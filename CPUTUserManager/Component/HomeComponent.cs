using CPUTUserManager.Component.Interface;
using CPUTUserManager.Models;
using CPUTUserManager.Sidecar.RestSharp.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPUTUserManager.Component
{
    public class HomeComponent : IHomeComponent
    {
        private readonly IRestBroker _restBroker;
        private readonly IEndPoint _endPoint;

        public HomeComponent(IRestBroker restBroker, IEndPoint endPoint)
        {
            _restBroker = restBroker;
            _endPoint = endPoint;
        }

        public LoginViewModel Login(LoginViewModel model)
        {
            string resourse = "";
            if (model.IsAdmin == true)
            {
                resourse = $"admin/login/read/{model.Username}";
            }
            else
                resourse = $"student/login/read/{model.Username}";
            var result = _restBroker.Get(_endPoint.Endpoint, resourse, model.Username, null);
            
            var loginObj = JsonConvert.DeserializeObject<LoginModel>(result.Content);
            if (loginObj != null)
            {
                var loginViewModel = new LoginViewModel()
                {
                    Username = loginObj.Username,
                    Password = loginObj.Password,
                    IsAdmin = model.IsAdmin
                };

                return loginViewModel;
            }
            else
                return new LoginViewModel();
           
        }

        public RestModel UserDetails(string username)
        {
            var result = _restBroker.Post(_endPoint.Endpoint, $"", username, null);
            return JsonConvert.DeserializeObject<RestModel>(result.Content);
        }
    }
}
