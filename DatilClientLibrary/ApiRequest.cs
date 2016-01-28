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
       // private static readonly ILog log = LogManager.GetLogger("DatilClientLibrary");

        public RequestOptions requestOptions;
        private RestClient client;
        private RestRequest request;

        public ApiRequest(RequestOptions options) {
           // BasicConfigurator.Configure();
            requestOptions = options;
            client = new RestClient(requestOptions.Url);
            request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("X-Key", requestOptions.ApiKey);
            request.AddHeader("X-Password", requestOptions.Password);
            request.RequestFormat = DataFormat.Json;
        }

        public String Get()
        {
            Console.WriteLine(" Making GET request to Datil: " + requestOptions.Url);
            //Console.WriteLine(" Making GET request to Datil: " + requestOptions.Url);
            request.Method = Method.GET;
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine("Datil Response: " + content);
//            Console.ReadLine();
            return content;
        }

        public String Post(String body)
        {
            Console.WriteLine("Datil Request Body:" + body);
            if (body == null)
            {
                Console.WriteLine("Body is null");
            }
            else
            {
                Console.WriteLine("Making POST request to Datil: " + requestOptions.Url);
                request.Method = Method.POST;
                request.AddParameter("application/json", body, ParameterType.RequestBody);
            }
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine("Datil Response: " + content);
            // Console.ReadLine();
            return content;
        }

    }

}
