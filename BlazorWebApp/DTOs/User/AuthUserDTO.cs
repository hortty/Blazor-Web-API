using BlazorWebApp.DTOs;
using System;

namespace Movie.Domain.Dtos.UserDto
{

    public class AuthUserDTO
    {
        public string Login { get; set; } = String.Empty;
        public string PasswordHash { get; set; } = String.Empty;
    }
}
