using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Models;

namespace Movie.Domain.Dtos.FilmDto
{
    [AutoMap(typeof(Film), ReverseMap = true)]
    public class FilmDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public long Amount { get; set; }
    }
}