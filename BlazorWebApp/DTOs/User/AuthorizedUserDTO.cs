using BlazorWebApp.DTOs;
using System;

namespace BlazorWebApp.DTOs
{
    public class AuthorizedUserDTO : BaseDTO
    {
        public string Login { get; set; } = String.Empty;
        public string Token { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
        public Guid ShoppingCartId { get; set; }
    }
}
