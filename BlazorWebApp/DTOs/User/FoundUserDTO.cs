using BlazorWebApp.DTOs;
using System;
using System.ComponentModel.DataAnnotations;

namespace Movie.Domain.Dtos.UserDto
{
    public class FoundUserDTO : BaseDTO
    {
        public string Username { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string PasswordHash { get; set; } = String.Empty;

        public string Role { get; set; } = String.Empty;
    }
}
