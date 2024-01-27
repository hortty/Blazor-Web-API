using System;

namespace BlazorWebApp.DTOs.ShoppingCartMovieDTO
{
    public class CreateShoppingCartMovieDto
    {
        public int Amount { get; set; }

        public Guid ShoppingCartId { get; set; }

        public Guid FilmId { get; set; }
    }

}
