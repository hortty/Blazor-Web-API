using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Models;

namespace Movie.Domain.Dtos
{
    [AutoMap(typeof(ShoppingCartMovie), ReverseMap = true)]
    public class CreatedShoppingCartMovieDto
    {
        public long Id { get; set; }
    }
}