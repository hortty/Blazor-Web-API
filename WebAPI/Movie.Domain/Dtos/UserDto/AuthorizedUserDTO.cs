using AutoMapper;
using BlazorWebApp.DTOs;
using Movie.Domain.Models;
using System;

namespace Movie.Domain.Dtos.UserDto
{
    [AutoMap(typeof(User), ReverseMap = true)]
    public class AuthorizedUserDTO : BaseDTO
    {
        public string Login { get; set; } = String.Empty;
        public string Token { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
        public Guid ShoppingCartId { get; set; }
    }
}
