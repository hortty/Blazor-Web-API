using Movie.Domain.Dtos.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Domain.Interfaces
{
    public interface IUserService : IGenericService
    {
        Task<FoundUserDTO> FindUserByLogin(GetUserDTO getUserDTO);
    }
}