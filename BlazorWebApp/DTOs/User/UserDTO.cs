using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.DTOs
{
    public class UserDTO : BaseDTO
    {

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Login é necessário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Senha é necessária")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; }

        public Util.Enum.UserRole UserRole { get; set; }

        public string ActiveToken { get; set; }

        public bool Active { get; set; }

        public bool PasswordRedefinition { get; set; }

    }
}
