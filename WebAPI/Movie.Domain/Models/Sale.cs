using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Models
{
    public class Sale : EntityBase
    {
        [Required]
        public decimal Total { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
