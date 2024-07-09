using BlazorWebApp.DTOs;
using BlazorWebApp.DTOs.CommentDto;
using BlazorWebApp.DTOs.Film;
using BlazorWebApp.DTOs.UpvoteDto;
using BlazorWebApp.Interfaces;
using BlazorWebApp.Util;
using Microsoft.Extensions.Options;
using Movie.Domain.Dtos.CustomerDto;
using Movie.Domain.Dtos.UserDto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWebApp.Services
{
    public class UserService : BaseAPI, IUserService
    {
        public UserService(HttpClient client, IOptions<ConfigAPI> myConfiguration) : base(client, myConfiguration)
        {
            _httpClient = client;
            _myConfiguration = myConfiguration.Value;
        }

        public async Task<ResultDTO<List<FoundUserDTO>>> GetAll()
        {
            try
            {
                adress = $"User/getAll";
                var request = new HttpRequestMessage(HttpMethod.Get, adress);

                var response = await this._httpClient.SendAsync(request);
                var responseAsString = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDTO<List<FoundUserDTO>>>(responseAsString);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
