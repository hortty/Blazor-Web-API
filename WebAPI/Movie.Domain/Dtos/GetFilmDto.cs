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
    public class GetFilmDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = String.Empty;
    }
}
