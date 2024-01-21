using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Models
{
    public class User : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Username { get; set; } = String.Empty;

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = String.Empty;

        [Required]
        [MaxLength(100)]
        public string PasswordHash { get; set; } = String.Empty;
    }
}
