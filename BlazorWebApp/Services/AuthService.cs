using BlazorWebApp.DTOs;
using BlazorWebApp.Interfaces;
using BlazorWebApp.Util;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Json;
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

        public async Task<ResultDTO<AuthorizedUser>> AuthenticateUser(AuthenticateUserDTO auth)
        {
            try
            {
                adress = $"auth/authenticateUser";
                var request = new HttpRequestMessage(HttpMethod.Post, adress);
                request.Content = GetStringContent(auth);

                var response = await this._httpClient.SendAsync(request);
                var responseAsString = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDTO<AuthorizedUser>>(responseAsString);
            }
            catch(Exception ex)
            {
                return new ResultDTO<AuthorizedUser>(false, ex.Message, null);
            }
        }

        public async Task<ResultDTO> ForgetPassword(UserDTO user)
        {
            try
            {
                adress = $"auth/forgetPassword";
                var request = new HttpRequestMessage(HttpMethod.Post, adress);
                request.Content = GetStringContent(user);

                var response = await this._httpClient.SendAsync(request);
                var responseAsString = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDTO>(responseAsString);
            }
            catch (Exception ex)
            {
                return new ResultDTO(false, ex.Message);
            }
        }

        public async Task<ResultDTO> RedefinePassword(UserDTO user)
        {
            try
            {
                adress = $"auth/redefinePassword";
                var request = new HttpRequestMessage(HttpMethod.Post, adress);
                request.Content = GetStringContent(user);

                var response = await this._httpClient.SendAsync(request);
                var responseAsString = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDTO>(responseAsString);
            }
            catch (Exception ex)
            {
                return new ResultDTO(false, ex.Message);
            }
        }

        public async Task<ResultDTO> RegisterUser(UserDTO user)
        {
            try
            {
                adress = $"auth/registerUser";
                var request = new HttpRequestMessage(HttpMethod.Post, adress);
                request.Content = GetStringContent(user);

                var response = await this._httpClient.SendAsync(request);
                var responseAsString = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDTO>(responseAsString);
            }
            catch (Exception ex)
            {
                return new ResultDTO(false, ex.Message);
            }
        }
    }
}
