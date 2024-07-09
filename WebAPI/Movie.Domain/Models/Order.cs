using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Models
{
    public class Order
    {
        public string ContentBody { get; set; } = String.Empty;

        public string Title { get; set; } = String.Empty;

        public int OrderNumber { get; set; }

        public List<string> Emails { get; set; }
    }
}
