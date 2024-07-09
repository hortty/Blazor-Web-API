using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlazorWebApp.DTOs;
using Movie.Domain.Dtos.FilmDto;
using Movie.Domain.Dtos.UserDto;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;

using BlazorWebApp.Util;

namespace Movie.Application.Services
{
    public class LoginService : ILoginService
    {
        private IUserService _userService;
        private IMapper _mapper;
        private IShoppingCartService _shoppingCartService;

        public LoginService(IUserService userService, IMapper mapper, IShoppingCartService shoppingCartService)
        {
            _userService = userService;
            _mapper = mapper;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<ResultDTO<AuthorizedUserDTO>> AuthenticateUser(AuthUserDTO authUserVO)
        {
            try
            {
                GetUserDTO getUserDTO = new GetUserDTO
                {
                    Username = authUserVO.Login
                };

                var foundUser = await _userService.FindUserByLogin(getUserDTO);

                if (foundUser == null || !foundUser.Ativo) throw new Exception("Usuário não encontrado!");

                if (foundUser.PasswordHash != authUserVO.PasswordHash)
                    throw new Exception("Senha não confere!");

                var shoppingCart = await _shoppingCartService.GetShoppingCartByUserId(foundUser.Id);

                string token = JwtHelper.GenerateJwtToken(foundUser.Id, foundUser.Username, foundUser.Role);

                AuthorizedUserDTO authorizedUserDTO = new AuthorizedUserDTO
                {
                    Id = foundUser.Id,
                    Login = foundUser.Username,
                    Role = foundUser.Role,
                    Token = token,
                    ShoppingCartId = shoppingCart.Id
                };

                return new ResultDTO<AuthorizedUserDTO>(true, "Sucesso", authorizedUserDTO);

            }
            catch(Exception ex)
            {
                return new ResultDTO<AuthorizedUserDTO>(false, ex.Message, null);
            }
        }
    }
}