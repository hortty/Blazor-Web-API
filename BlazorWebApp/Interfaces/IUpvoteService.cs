using BlazorWebApp.DTOs;
using BlazorWebApp.DTOs.CommentDto;
using BlazorWebApp.DTOs.Film;
using BlazorWebApp.DTOs.UpvoteDto;
using Microsoft.AspNetCore.Mvc;
using Movie.Domain.Dtos.CustomerDto;
using Movie.Domain.Dtos.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebApp.Interfaces
{
    public interface IUpvoteService
    {
        public Task<ResultDTO<List<FoundUpvoteDto>>> GetByFilmId(Guid filmId);

        public Task<CreatedUpvoteDto> Create(CreateUpvoteDto createUpvoteDto);

        public Task<ResultDTO<GetUpvoteRatingDto>> UpvoteRating(Guid filmId);

    }
}
