using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPUTUserManager.Sidecar.RestSharp.Interface
{
    public interface IRestBroker
    {
        IRestResponse Get(string endPoint, string resource, dynamic model, string securityToken);
        IRestResponse Get<IRestResponse>(string endPoint, string resource, dynamic model, string securityToken);
        IRestResponse Post(string endPoint, string resource, dynamic model, string securityToken);
        IRestResponse Post<IRestResponse>(string endPoint, string resource, dynamic model, string securityToken);
    }
}
