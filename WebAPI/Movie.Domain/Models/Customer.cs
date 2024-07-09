using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Models
{
    public class Customer : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = String.Empty;

        [Required]
        [MaxLength(15)]
        public string Phone { get; set; } = String.Empty;

        public string Address { get; set; } = String.Empty;

        [Required]
        public int Age { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
