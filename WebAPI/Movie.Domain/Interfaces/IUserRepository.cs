using Movie.Domain.Dtos.UserDto;
using Movie.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> FindUserByLogin(GetUserDTO getUserDTO);
    }
}
