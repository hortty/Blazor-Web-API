using BlazorWebApp.DTOs;
using BlazorWebApp.DTOs.Customer;
using BlazorWebApp.Interfaces;
using BlazorWebApp.Util;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWebApp.Services
{
    public class CustomerService : BaseAPI, ICustomerService
    {
        public CustomerService(HttpClient client, IOptions<ConfigAPI> myConfiguration) : base(client, myConfiguration)
        {
            _httpClient = client;
            _myConfiguration = myConfiguration.Value;
        }

        public async Task<ResultDTO<CreatedCustomerDto>> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            try
            {
                adress = $"Customer/createCustomer";
                var request = new HttpRequestMessage(HttpMethod.Post, adress);
                request.Content = GetStringContent(createCustomerDto);

                var response = await this._httpClient.SendAsync(request);
                var responseAsString = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDTO<CreatedCustomerDto>>(responseAsString);
            }
            catch (Exception ex)
            {
                return new ResultDTO<CreatedCustomerDto>(false, ex.Message, null);
            }
        }
    }
}
