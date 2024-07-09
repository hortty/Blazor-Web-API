using BlazorWebApp.DTOs;
using BlazorWebApp.DTOs.Film;
using BlazorWebApp.DTOs.OrderDto;
using BlazorWebApp.Interfaces;
using BlazorWebApp.Util;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWebApp.Services
{
    public class EmailService : BaseAPI, IEmailService
    {
        public EmailService(HttpClient client, IOptions<ConfigAPI> myConfiguration) : base(client, myConfiguration)
        {
            _httpClient = client;
            _myConfiguration = myConfiguration.Value;
        }

        public async Task<ResultDTO<bool>> CreateOrder(CreateOrderDto createOrderDto)
        {
            try
            {
                adress = $"Email/createOrder";
                var request = new HttpRequestMessage(HttpMethod.Post, adress);
                request.Content = GetStringContent(createOrderDto);

                var response = await this._httpClient.SendAsync(request);
                var responseAsString = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDTO<bool>>(responseAsString);
            }
            catch (Exception ex)
            {
                return new ResultDTO<bool>(false, ex.Message, false);
            }
        }
    }
}
