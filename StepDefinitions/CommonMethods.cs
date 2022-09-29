using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_API_Test.StepDefinitions
{
    public class CommonMethods
    {
        public static Method GetMethod(string methodName)
        {
            return methodName switch
            {
                "POST" => Method.Post,
                "GET" => Method.Get,
                "PUT" => Method.Put,
                "DELETE" => Method.Delete,
                "PATCH" => Method.Patch,
                _ => throw new ArgumentException("Invalid method name")
            };
        }
    }
}
