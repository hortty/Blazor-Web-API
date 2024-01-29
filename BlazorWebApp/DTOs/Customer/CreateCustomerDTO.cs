using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.DTOs.Customer
{
    public class CreateCustomerDto
    {
        [Required(ErrorMessage = "Nome � obrigat�rio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Login � necess�rio")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Senha � necess�ria")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email � obrigat�rio")]
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
