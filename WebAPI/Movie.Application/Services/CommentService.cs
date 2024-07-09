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
        protected readonly IUserService _userService;

        public CommentService(ICommentsRepository repository, IMapper mapper, IUserService userService)
        {
            _repository = repository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<CreatedCommentDto> Create(CreateCommentDto createCommentDto)
        {
            GetUserDTO getUserDTO = new GetUserDTO
            {
                Id = createCommentDto.UserId
            };

            var foundUser = await _userService.ListById<GetUserDTO, FoundUserDTO>(getUserDTO);

            var comment = _mapper.Map<Comment>(createCommentDto);

            comment.UserName = foundUser.Username;

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