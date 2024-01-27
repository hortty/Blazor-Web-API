using AutoMapper;
using Movie.Domain.Models;

namespace Movie.Domain.Dtos
{
    [AutoMap(typeof(ShoppingCartMovie), ReverseMap = true)]
    public class UpdatedShoppingCartMovieDto
    {
        public long? Id { get; set; }
        public long Amount { get; set; }

        public long ShoppingCartId { get; set; }

        public long FilmId { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; } = String.Empty;
    }
}

