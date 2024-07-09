using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Dtos.UserDto;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;

namespace Movie.Application.Services
{
    public class UserService : GenericService<User, IUserRepository>, IUserService
    {
        public readonly IUserRepository _repository;
        public readonly IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<FoundUserDTO> FindUserByLogin(GetUserDTO getUserDTO)
        {
            var foundUser = await _repository.FindUserByLogin(getUserDTO);

            if (foundUser == null) throw new Exception("Usuário não encontrado");

            var foundUserDTO = _mapper.Map<FoundUserDTO>(foundUser);

            return foundUserDTO;
        }
    }
}