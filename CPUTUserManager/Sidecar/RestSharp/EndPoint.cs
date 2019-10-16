using CPUTUserManager.Sidecar.RestSharp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPUTUserManager.Sidecar.RestSharp
{
    public class EndPoint : IEndPoint
    {
        public string Endpoint { get; set; }

        public EndPoint(string endPoint)
        {
            Endpoint = endPoint;
        }

    }
}
