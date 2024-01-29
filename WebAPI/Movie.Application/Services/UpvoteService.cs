using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Movie.Domain.Dtos.CustomerDto;
using Movie.Domain.Dtos.ShoppingCartMovieDto;
using Movie.Domain.Dtos.UserDto;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;

namespace Movie.Application.Services
{
    public class UpvoteService : IUpvoteService
    {
        protected readonly IMapper _mapper;
        protected readonly IUpvoteRepository _repository;

        public UpvoteService(IUpvoteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CreatedUpvoteDto Create(CreateUpvoteDto createUpvoteDto)
        {
            var upvote = _mapper.Map<Upvote>(createUpvoteDto);
            var created = _repository.Create(upvote);
            return _mapper.Map<CreatedUpvoteDto>(created);
        }

        public List<FoundUpvoteDto> ListAll()
        {
            var upvotes = _repository.ListAll();
            return _mapper.Map<List<FoundUpvoteDto>>(upvotes);
        }

        public List<FoundUpvoteDto> ListByFilmId(Guid filmId)
        {
            var upvotes = _repository.ListByFilmId(filmId);
            return _mapper.Map<List<FoundUpvoteDto>>(upvotes);
        }
    }
}