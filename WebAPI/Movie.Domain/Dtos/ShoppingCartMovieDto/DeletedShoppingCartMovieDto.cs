using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Models;

namespace Movie.Domain.Dtos.ShoppingCartMovieDto
{
    [AutoMap(typeof(ShoppingCartMovie), ReverseMap = true)]
    public class DeletedShoppingCartMovieDto
    {
        public Guid Id { get; set; }
    }
}