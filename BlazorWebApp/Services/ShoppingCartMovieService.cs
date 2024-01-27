using BlazorWebApp.DTOs;
using BlazorWebApp.DTOs.ShoppingCartMovieDTO;
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
    public class ShoppingCartMovieService : BaseAPI, IShoppingCartMovieService
    {
        public ShoppingCartMovieService(HttpClient client, IOptions<ConfigAPI> myConfiguration) : base(client, myConfiguration)
        {
            _httpClient = client;
            _myConfiguration = myConfiguration.Value;
        }

        public async Task<ResultDTO<CreatedShoppingCartMovieDto>> CreateAsync(CreateShoppingCartMovieDto dto)
        {
            try
            {
                adress = $"auth/authenticateUser";
                var request = new HttpRequestMessage(HttpMethod.Post, adress);
                request.Content = GetStringContent(dto);

                var response = await this._httpClient.SendAsync(request);
                var responseAsString = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDTO<CreatedShoppingCartMovieDto>>(responseAsString);
            }
            catch (Exception ex)
            {
                return new ResultDTO<CreatedShoppingCartMovieDto>(false, ex.Message, null);
            }
        }

        public async Task<ResultDTO<DeletedShoppingCartMovieDTO>> DeleteAsync(DeleteShoppingCartMovieDTO dto)
        {
            try
            {
                adress = $"auth/authenticateUser";
                var request = new HttpRequestMessage(HttpMethod.Post, adress);
                request.Content = GetStringContent(dto);

                var response = await this._httpClient.SendAsync(request);
                var responseAsString = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDTO<DeletedShoppingCartMovieDTO>>(responseAsString);
            }
            catch(Exception ex)
            {
                return new ResultDTO<DeletedShoppingCartMovieDTO>(false, ex.Message, null);
            }
        }

        public async Task<ResultDTO<List<FoundShoppingCartMovieDto>>> GetAsync()
        {
            try
            {
                adress = $"auth/authenticateUser";
                var request = new HttpRequestMessage(HttpMethod.Post, adress);

                var response = await this._httpClient.SendAsync(request);
                var responseAsString = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDTO<List<FoundShoppingCartMovieDto>>>(responseAsString);
            }
            catch(Exception ex)
            {
                return new ResultDTO<List<FoundShoppingCartMovieDto>>(false, ex.Message, null);
            }
        }
    }
}
