using CPUTUserManager.Sidecar.RestSharp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace CPUTUserManager.Sidecar.RestSharp
{
    public class RestBroker : IRestBroker
    {
        public IRestResponse Get(string endPoint, string resource, dynamic model, string securityToken)
        {
            return Process(endPoint, resource, model, Method.GET, securityToken);
        }

        public IRestResponse Get<IRestResponse>(string endPoint, string resource, dynamic model, string securityToken)
        {
            return Process(endPoint, resource, model, Method.GET, securityToken);
        }

        public IRestResponse Post(string endPoint, string resource, dynamic model, string securityToken)
        {
            return Process(endPoint, resource, model, Method.POST, securityToken);
        }

        public IRestResponse Post<IRestResponse>(string endPoint, string resource, dynamic model, string securityToken)
        {
            return Process(endPoint, resource, model, Method.POST, securityToken);
        }
        private IRestResponse Process(string endPoint, string resource, dynamic model, Method methodType,
            string securityToken = null, string contentType = "application/json")
        {
            var restClient = new RestClient();
            var restRequest = new RestRequest(methodType);

            var apiEndpoint = String.Format($"{endPoint}{resource}");

            restClient.BaseUrl = new Uri(apiEndpoint);
            if (methodType != Method.GET)
            {
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddHeader("Cache-Control", "No-Cache");
                restRequest.AddJsonBody(model);
            }


            var response = restClient.Execute(restRequest);

            //var result = JsonConvert.DeserializeObject<IRestResponse>(response);
            return response;
        }
        //private IRestResponse Process<IRestResponse>(string endPoint, string resource, dynamic model, Method methodType,
        //    string securityToken = null, string contentType = "application/json")
        //{
        //    var restClient = new RestClient();
        //    var restRequest = new RestRequest(methodType);

        //    var apiEndpoint = String.Format($"{endPoint}{resource}");

        //    restClient.BaseUrl = new Uri(apiEndpoint);
        //    if(methodType != Method.GET)
        //    {
        //        restRequest.AddHeader("Content-Type", "application/json");
        //        restRequest.AddHeader("Cache-Control", "No-Cache");
        //        restRequest.AddJsonBody(model);
        //    }

                   
        //    var response = restClient.Execute(restRequest);

        //    //var result = JsonConvert.DeserializeObject<IRestResponse>(response);
        //    return response;
        //}
    }
}
