using Movie.Domain.Dtos.FilmDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Domain.Interfaces
{
    public interface IShoppingCartMovieService : IGenericService
    {
        public Task<List<FoundFilmDto>> GetFilmsByShoppingCartId(Guid shoppingCartId);
    }
}