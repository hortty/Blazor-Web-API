using AutoMapper;
using Movie.Domain.Models;

namespace Movie.Domain.Dtos.ShoppingCartMovieDto
{
    [AutoMap(typeof(ShoppingCartMovie), ReverseMap = true)]
    public class UpdatedShoppingCartMovieDto
    {
        public Guid? Id { get; set; }
        public long Amount { get; set; }

        public Guid ShoppingCartId { get; set; }

        public Guid FilmId { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}

