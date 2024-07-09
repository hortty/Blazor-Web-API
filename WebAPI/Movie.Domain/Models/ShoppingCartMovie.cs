using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Models
{
    public class ShoppingCartMovie : EntityBase
    {
        [Required]
        public long Amount { get; set; }

        public Guid ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public Guid FilmId { get; set; }

        public Film Film { get; set; }

    }
}
