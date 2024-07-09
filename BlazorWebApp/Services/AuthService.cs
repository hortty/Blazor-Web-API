using BlazorWebApp.DTOs;
using BlazorWebApp.Interfaces;
using BlazorWebApp.Util;
using Microsoft.Extensions.Options;
using Movie.Domain.Dtos.UserDto;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWebApp.Services
{
    public class AuthService : BaseAPI, IAuthService
    {
        public AuthService(HttpClient client, IOptions<ConfigAPI> myConfiguration) : base(client, myConfiguration)
        {
            _httpClient = client;
            _myConfiguration = myConfiguration.Value;
        }

        public async Task<ResultDTO<AuthorizedUserDTO>> AuthenticateUser(AuthUserDTO authUserDTO)
        {
            try
            {
                adress = $"Login/logarUsuario";
                var request = new HttpRequestMessage(HttpMethod.Post, adress);
                request.Content = GetStringContent(authUserDTO);

                var response = await this._httpClient.SendAsync(request);
                var responseAsString = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDTO<AuthorizedUserDTO>>(responseAsString);
            }
            catch(Exception ex)
            {
                return new ResultDTO<AuthorizedUserDTO>(false, ex.Message, null);
            }
        }
    }
}
