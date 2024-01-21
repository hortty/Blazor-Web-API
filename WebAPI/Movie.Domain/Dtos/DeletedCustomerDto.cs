using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Models;

namespace Movie.Domain.Dtos
{
    [AutoMap(typeof(Customer), ReverseMap = true)]
    public class DeletedCustomerDto
    {
        public long Id { get; set; }
    }
}