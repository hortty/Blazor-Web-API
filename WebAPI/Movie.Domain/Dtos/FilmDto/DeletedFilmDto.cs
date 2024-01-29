using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Models;

namespace Movie.Domain.Dtos.FilmDto
{
    [AutoMap(typeof(Film), ReverseMap = true)]
    public class DeletedFilmDto
    {
        public Guid Id { get; set; }
    }
}