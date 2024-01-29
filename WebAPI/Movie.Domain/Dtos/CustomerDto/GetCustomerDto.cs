using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Models;

namespace Movie.Domain.Dtos.CustomerDto
{
    [AutoMap(typeof(Customer), ReverseMap = true)]
    public class GetCustomerDto
    {
        public Guid Id { get; set; }
    }
}
