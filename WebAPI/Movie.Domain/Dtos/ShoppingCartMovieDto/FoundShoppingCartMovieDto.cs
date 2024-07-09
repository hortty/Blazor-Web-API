using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Models;

namespace Movie.Domain.Dtos.ShoppingCartMovieDto
{
    [AutoMap(typeof(ShoppingCartMovie), ReverseMap = true)]
    public class FoundShoppingCartMovieDto
    {
        public long Amount { get; set; }

        public Guid ShoppingCartId { get; set; }

        public Guid FilmId { get; set; }

    }
}
