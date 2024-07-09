using BlazorWebApp.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.Services;
using Movie.Application.Validators;
using Movie.Domain.Dtos.CustomerDto;
using Movie.Domain.Dtos.FilmDto;
using Movie.Domain.Dtos.ShoppingCartMovieDto;
using Movie.Domain.Dtos.UserDto;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;

namespace Movie.Api.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var foundResult = _userService.ListAll<GetUserPaginatedDTO, FoundUserDTO>(null);

                return Ok(new ResultDTO(true, "Sucess", foundResult));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultDTO(false, ex.Message));
            }
        }

    }
}
