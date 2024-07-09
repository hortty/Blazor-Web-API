using BlazorWebApp.DTOs;
using BlazorWebApp.DTOs.CommentDto;
using BlazorWebApp.DTOs.Film;
using Microsoft.AspNetCore.Mvc;
using Movie.Domain.Dtos.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebApp.Interfaces
{
    public interface ICommentService
    {
        public Task<ResultDTO<List<FoundCommentDto>>> GetByFilmId(Guid filmId);

        public Task<CreatedCommentDto> Create(CreateCommentDto createCommentDto);
    }
}
