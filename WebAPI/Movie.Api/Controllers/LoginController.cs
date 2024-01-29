using BlazorWebApp.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Domain.Dtos.CustomerDto;
using Movie.Domain.Dtos.UserDto;
using Movie.Domain.Interfaces;

namespace Movie.Api.Controllers
{
    [Route("Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("logarUsuario")]
        public async Task<IActionResult> AuthenticateUser([FromBody] AuthUserDTO authUserDTO)
        {
            try
            {
                var resultDTO = await _loginService.AuthenticateUser(authUserDTO);

                if (!resultDTO.Success)
                    throw new Exception(resultDTO.Message);

                return Ok(resultDTO);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResultDTO(false, ex.Message));
            }
        }

    }
}
