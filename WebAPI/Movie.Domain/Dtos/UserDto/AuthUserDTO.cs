using AutoMapper;
using BlazorWebApp.DTOs;
using Movie.Domain.Models;
using System;

namespace Movie.Domain.Dtos.UserDto
{
    [AutoMap(typeof(User), ReverseMap = true)]
    public class AuthUserDTO : BaseDTO
    {
        public string Login { get; set; } = String.Empty;
        public string PasswordHash { get; set; } = String.Empty;
    }
}
