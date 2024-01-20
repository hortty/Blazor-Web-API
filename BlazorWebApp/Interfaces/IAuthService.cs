using BlazorWebApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebApp.Interfaces
{
    public interface IAuthService
    {
        public Task<ResultDTO<AuthorizedUser>> AuthenticateUser(AuthenticateUserDTO auth);
        public Task<ResultDTO> RegisterUser(UserDTO user);
        public Task<ResultDTO> RedefinePassword(UserDTO user);
        public Task<ResultDTO> ForgetPassword(UserDTO user);

    }
}
