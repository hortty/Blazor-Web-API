using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebApp.DTOs.OrderDto
{
    public class CreateOrderDto
    {
        public string ContentBody { get; set; } = String.Empty;

        public string Title { get; set; } = String.Empty;

        public int OrderNumber { get; set; }

        public List<string> Emails { get; set; }
    }
}