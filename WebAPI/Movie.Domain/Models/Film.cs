using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Models
{
    public class Film : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = String.Empty;

        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = String.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public long Amount { get; set; }

    }
}
