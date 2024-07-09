using Movie.Domain.Dtos.FilmDto;
using Movie.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Interfaces
{
    public interface IShoppingCartMovieRepository : IGenericRepository<ShoppingCartMovie>
    {
        public Task<List<FoundFilmDto>> GetFilmsByShoppingCartId(Guid shoppingCartId);
    }
}
