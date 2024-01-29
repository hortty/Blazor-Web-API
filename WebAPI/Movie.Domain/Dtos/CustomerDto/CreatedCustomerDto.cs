using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Models;

namespace Movie.Domain.Dtos.CustomerDto
{
    [AutoMap(typeof(Customer), ReverseMap = true)]
    public class CreatedCustomerDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}