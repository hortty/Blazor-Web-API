using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Models;

namespace Movie.Domain.Dtos.ShoppingCartMovieDto
{
    [AutoMap(typeof(ShoppingCartMovie), ReverseMap = true)]
    public class CreateShoppingCartMovieDto
    {
        public int Amount { get; set; }

        public Guid ShoppingCartId { get; set; }

        public Guid FilmId { get; set; }
    }
}