using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Models;

namespace Movie.Domain.Dtos.ShoppingCartMovieDto
{
    [AutoMap(typeof(ShoppingCart), ReverseMap = true)]
    public class CreateShoppingCartDTO
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Ativo { get; set; }
    }
}