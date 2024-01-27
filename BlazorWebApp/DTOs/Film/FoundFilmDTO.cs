using System;

namespace BlazorWebApp.DTOs.Film
{
    public class FoundFilmDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string Imagem { get; set; }
    }


}
