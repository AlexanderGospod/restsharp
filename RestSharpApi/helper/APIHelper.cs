using Newtonsoft.Json;
using RestSharp;
using System.IO;
using static RestSharpApi.endpoints.ApiEndPoints;
namespace RestSharpApi.helper
{
    public class APIHelper<T>
    {
        public RestClient client;
        public RestRequest request;

        public RestClient SetUrl(string endpoint)
        {
            string url = Path.Combine(BaseUrl, endpoint);
            client = new RestClient(url);
            return client;
        }

        public RestRequest CreatePostRequest (string payload) 
        {
            request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", payload, ParameterType.RequestBody);
            return request;
        }

        public RestRequest CreatePutRequest(string payload)
        {
            request = new RestRequest(Method.PUT);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", payload, ParameterType.RequestBody);
            return request;
        }

        public RestRequest CreateGetRequest()
        {
            request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            return request;
        }
        public RestRequest CreateDeleteRequest()
        {
            request = new RestRequest(Method.DELETE);
            request.AddHeader("Accept", "application/json");
            return request;
        }

        public IRestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        public DTO GetContent <DTO>(RestResponse response) 
        { 
            string content = response.Content;
            DTO dtoObject = JsonConvert.DeserializeObject<DTO>(content);
            return dtoObject;
        }

        public string SerializeObjToString (dynamic content)
        {
            return JsonConvert.SerializeObject(content);
        }


    }
}
