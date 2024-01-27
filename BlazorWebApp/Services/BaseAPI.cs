using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Text;
using BlazorWebApp.Util;

namespace BlazorWebApp.Services
{
    public class BaseAPI
    {
        public string _token = string.Empty;
        public string adress = string.Empty;
        public ConfigAPI _myConfiguration;
        public HttpClient _httpClient;
        public BaseAPI(HttpClient client, IOptions<ConfigAPI> myConfiguration)
        {
            _myConfiguration = myConfiguration.Value;
            _httpClient = client; 
            _httpClient.Timeout = new TimeSpan(0, 10, 0);
            _httpClient.BaseAddress = new Uri(_myConfiguration.Url);
        }

        public StringContent GetStringContent(object objectDTO)
        {

            string serializedObj = Newtonsoft.Json.JsonConvert.SerializeObject(objectDTO);

            return new StringContent(serializedObj, Encoding.UTF8, "application/json");
        }

    }
}
