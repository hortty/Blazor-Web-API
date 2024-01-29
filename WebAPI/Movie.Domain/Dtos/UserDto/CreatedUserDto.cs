using AutoMapper;
using BlazorWebApp.DTOs;
using Movie.Domain.Models;
using System;

namespace Movie.Domain.Dtos.UserDto
{
    [AutoMap(typeof(User), ReverseMap = true)]
    public class CreatedUserDto : BaseDTO
    {
        public string Username { get; set; } = String.Empty;
    }
}
