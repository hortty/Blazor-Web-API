using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.DTOs.Film
{
    public class CreateFilmDto
    {
        [Required]
        [MinLength(3, ErrorMessage="Tamanho minimo 3")]
        public string Name { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Tamanho minimo 3")]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public long Amount { get; set; }
        public string ImagemBase64 { get; set; }
    }

}
