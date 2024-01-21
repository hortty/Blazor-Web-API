using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Models;

namespace Movie.Domain.Dtos
{
    [AutoMap(typeof(Customer), ReverseMap = true)]
    public class UpdatedCustomerDto
    {
        public string Name { get; set; } = String.Empty;

        public string Phone { get; set; } = String.Empty;

 	    public string Address { get; set; } = String.Empty;

        public int Age { get; set; }

    }
}