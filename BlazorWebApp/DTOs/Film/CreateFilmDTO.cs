using System;

namespace BlazorWebApp.DTOs.Film
{
    public class CreateFilmDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }

}
