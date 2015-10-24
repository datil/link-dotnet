using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatilClientLibrary
{
    class ApiRequest
    {
        public RequestOptions requestOptions;

        public ApiRequest(RequestOptions options) {
            requestOptions = options;
        }

        public String SendRequest(String body = null)
        {

            var client = new RestClient(requestOptions.Url);
            var request = new RestRequest();
            request.AddHeader("X-Key", requestOptions.ApiKey);
            request.AddHeader("X-Password", requestOptions.Password);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            if (body == null)
            {
                request.Method = Method.GET;
            }
            else
            {
                request.Method = Method.POST;
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                //var jsonobj  = JsonConvert.DeserializeObject(json);
                //Console.WriteLine(JsonConvert.SerializeObject(jsonobj));
                //request.AddBody(jsonobj);
            }

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine(content);
            Console.ReadLine();
            return content;
        }

    }

}
