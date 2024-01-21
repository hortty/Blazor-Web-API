using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Models;

namespace Movie.Domain.Dtos
{
    [AutoMap(typeof(Film), ReverseMap = true)]
    public class FoundFilmDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public decimal Price { get; set; }

        public long Amount { get; set; }

        public byte[]? Imagem { get; set; }
    }
}
