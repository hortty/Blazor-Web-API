using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Dtos.FilmDto;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;

namespace Movie.Application.Services
{
    public class ShoppingCartMovieService : GenericService<ShoppingCartMovie, IShoppingCartMovieRepository>, IShoppingCartMovieService
    {
        protected readonly IShoppingCartMovieRepository _repository;
        public ShoppingCartMovieService(IShoppingCartMovieRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        public async Task<List<FoundFilmDto>> GetFilmsByShoppingCartId(Guid shoppingCartId)
        {
            var foundFilmDtoList = await _repository.GetFilmsByShoppingCartId(shoppingCartId);

            return foundFilmDtoList;
        }
    }
}