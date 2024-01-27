using System;

namespace BlazorWebApp.DTOs.ShoppingCartMovieDTO
{
    public class FoundShoppingCartMovieDto
    {
        public Guid Id { get; set; }

        public int Amount { get; set; }

        public Guid ShoppingCartId { get; set; }

        public Guid FilmId { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }
    }


}
