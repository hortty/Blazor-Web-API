using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movie.Domain.Dtos;
using Movie.Domain.Models;

namespace Movie.Domain.Interfaces
{
    public interface IFilmService : IGenericService
    {
        public IQueryable<FoundFilmDto> GetByName(GetFilmDto getFilmDto);
    }
}