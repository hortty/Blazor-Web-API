using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.DTOs.Customer
{
    public class CreateCustomerDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Login é necessário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Senha é necessária")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; }

        [Required]
        [MaxLength(12)]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Age { get; set; }
        public Guid UserId { get; set; }
    }
}
