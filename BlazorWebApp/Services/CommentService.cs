using BlazorWebApp.DTOs;
using BlazorWebApp.DTOs.CommentDto;
using BlazorWebApp.DTOs.Film;
using BlazorWebApp.DTOs.UpvoteDto;
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
    public class CommentService : BaseAPI, ICommentService
    {
        public CommentService(HttpClient client, IOptions<ConfigAPI> myConfiguration) : base(client, myConfiguration)
        {
            _httpClient = client;
            _myConfiguration = myConfiguration.Value;
        }

        public async Task<CreatedCommentDto> Create(CreateCommentDto createCommentDto)
        {
            try
            {
                adress = $"Comment/create";
                var request = new HttpRequestMessage(HttpMethod.Post, adress);
                request.Content = GetStringContent(createCommentDto);

                var response = await this._httpClient.SendAsync(request);
                var responseAsString = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<CreatedCommentDto>(responseAsString);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async  Task<ResultDTO<List<FoundCommentDto>>> GetByFilmId(Guid filmId)
        {
            try
            {
                adress = $"Comment/getByFilmId/{filmId}";
                var request = new HttpRequestMessage(HttpMethod.Get, adress);

                var response = await this._httpClient.SendAsync(request);

                var responseAsString = await response.Content.ReadAsStringAsync();

                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDTO<List<FoundCommentDto>>>(responseAsString);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
