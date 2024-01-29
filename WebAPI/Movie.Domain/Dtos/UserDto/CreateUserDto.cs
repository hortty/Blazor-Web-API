using AutoMapper;
using BlazorWebApp.DTOs;
using Movie.Domain.Models;
using System;

namespace Movie.Domain.Dtos.UserDto
{
    [AutoMap(typeof(User), ReverseMap = true)]
    public class CreateUserDto : BaseDTO
    {
        public string Username { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string PasswordHash { get; set; } = String.Empty;

        public string Role { get; set; } = String.Empty;
    }
}
