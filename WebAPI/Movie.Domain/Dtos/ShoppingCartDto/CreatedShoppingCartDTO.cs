using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Models;

namespace Movie.Domain.Dtos.ShoppingCartMovieDto
{
    [AutoMap(typeof(ShoppingCart), ReverseMap = true)]
    public class CreatedShoppingCartDTO
    {
        public Guid Id { get; set; }
    }
}