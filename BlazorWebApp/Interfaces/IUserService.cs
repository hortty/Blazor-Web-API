using BlazorWebApp.DTOs;
using Movie.Domain.Dtos.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebApp.Interfaces
{
    public interface IUserService
    {
        public Task<ResultDTO<List<FoundUserDTO>>> GetAll();

    }
}
