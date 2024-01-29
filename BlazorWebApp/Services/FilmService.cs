using BlazorWebApp.DTOs;
using BlazorWebApp.DTOs.Film;
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
    public class FilmService : BaseAPI, IFilmService
    {
        public FilmService(HttpClient client, IOptions<ConfigAPI> myConfiguration) : base(client, myConfiguration)
        {
            _httpClient = client;
            _myConfiguration = myConfiguration.Value;
        }

        public async Task<ResultDTO<FoundFilmDto>> GetById(GetFilmDto getFilmDto)
        {
            try
            {
                adress = $"auth/authenticateUser";
                var request = new HttpRequestMessage(HttpMethod.Post, adress);
                request.Content = GetStringContent(getFilmDto);

                var response = await this._httpClient.SendAsync(request);
                var responseAsString = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDTO<FoundFilmDto>>(responseAsString);
            }
            catch(Exception ex)
            {
                return new ResultDTO<FoundFilmDto>(false, ex.Message, null);
            }
        }

        public async Task<ResultDTO<List<FoundFilmDto>>> GetByName(GetFilmDto getFilmDto)
        {
            try
            {
                adress = $"auth/authenticateUser";
                var request = new HttpRequestMessage(HttpMethod.Post, adress);
                request.Content = GetStringContent(getFilmDto);

                var response = await this._httpClient.SendAsync(request);
                var responseAsString = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDTO<List<FoundFilmDto>>>(responseAsString);
            }
            catch(Exception ex)
            {
                return new ResultDTO<List<FoundFilmDto>>(false, ex.Message, null);
            }
        }

        public async Task<ResultDTO<CreatedFilmDto>> CreateFilm(CreateFilmDto createFilmDto)
        {
            try
            {
                adress = $"Film/createFilm";
                var request = new HttpRequestMessage(HttpMethod.Post, adress);
                request.Content = GetStringContent(createFilmDto);

                var response = await this._httpClient.SendAsync(request);
                var responseAsString = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDTO<CreatedFilmDto>>(responseAsString);
            }
            catch (Exception ex)
            {
                return new ResultDTO<CreatedFilmDto>(false, ex.Message, null);
            }
        }

        public async Task<ResultDTO<List<FoundFilmDto>>> GetAllPaginated(int page)
        {
            try
            {
                adress = $"Film/getAll/{page}";
                var request = new HttpRequestMessage(HttpMethod.Get, adress);

                var response = await this._httpClient.SendAsync(request);
                var responseAsString = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDTO<List<FoundFilmDto>>>(responseAsString);
            }
            catch (Exception ex)
            {
                return new ResultDTO<List<FoundFilmDto>>(false, ex.Message, null);
            }
        }
    }
}
