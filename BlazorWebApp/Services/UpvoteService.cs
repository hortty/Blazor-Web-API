using BlazorWebApp.DTOs;
using BlazorWebApp.DTOs.CommentDto;
using BlazorWebApp.DTOs.Film;
using BlazorWebApp.DTOs.UpvoteDto;
using BlazorWebApp.Interfaces;
using BlazorWebApp.Util;
using Microsoft.Extensions.Options;
using Movie.Domain.Dtos.CustomerDto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWebApp.Services
{
    public class UpvoteService : BaseAPI, IUpvoteService
    {
        public UpvoteService(HttpClient client, IOptions<ConfigAPI> myConfiguration) : base(client, myConfiguration)
        {
            _httpClient = client;
            _myConfiguration = myConfiguration.Value;
        }

        public async Task<CreatedUpvoteDto> Create(CreateUpvoteDto createUpvoteDto)
        {
            try
            {
                adress = $"Upvote/create";
                var request = new HttpRequestMessage(HttpMethod.Post, adress);
                request.Content = GetStringContent(createUpvoteDto);

                var response = await this._httpClient.SendAsync(request);
                var responseAsString = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<CreatedUpvoteDto>(responseAsString);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ResultDTO<List<FoundUpvoteDto>>> GetByFilmId(Guid filmId)
        {
            try
            {
                adress = $"Upvote/getByFilmId/{filmId}";
                var request = new HttpRequestMessage(HttpMethod.Get, adress);

                var response = await this._httpClient.SendAsync(request);
                var responseAsString = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDTO<List<FoundUpvoteDto>>>(responseAsString);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ResultDTO<GetUpvoteRatingDto>> UpvoteRating(Guid filmId)
        {
            try
            {
                adress = $"Upvote/upvoteRatingByFilmId/{filmId}";
                var request = new HttpRequestMessage(HttpMethod.Get, adress);

                var response = await this._httpClient.SendAsync(request);
                var responseAsString = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDTO<GetUpvoteRatingDto>>(responseAsString);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
