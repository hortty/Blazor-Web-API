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
    public class CommentService : ICommentsService
    {
        protected readonly IMapper _mapper;
        protected readonly ICommentsRepository _repository;

        public CommentService(ICommentsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CreatedCommentDto Create(CreateCommentDto createCommentDto)
        {
            var comment = _mapper.Map<Comment>(createCommentDto);
            var created = _repository.Create(comment);
            return _mapper.Map<CreatedCommentDto>(created);
        }

        public List<FoundCommentDto> ListAll()
        {
            var comments = _repository.ListAll();
            return _mapper.Map<List<FoundCommentDto>>(comments);
        }

        public List<FoundCommentDto> ListByFilmId(Guid filmId)
        {
            var comments = _repository.ListByFilmId(filmId);
            return _mapper.Map<List<FoundCommentDto>>(comments);
        }
    }
}