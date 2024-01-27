using BlazorWebApp.DTOs;
using BlazorWebApp.DTOs.Film;
using BlazorWebApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebApp.Interfaces
{
    public interface IFilmService
    {
        public Task<ResultDTO<FoundFilmDto>> GetById(GetFilmDto getFilmDto);

        public Task<ResultDTO<List<FoundFilmDto>>> GetByName(GetFilmDto getFilmDto);

        public Task<ResultDTO<PaginatedList<FoundFilmDto>>> GetAllPaginated();
    }
}
