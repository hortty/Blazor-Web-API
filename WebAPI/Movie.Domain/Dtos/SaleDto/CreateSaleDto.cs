using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Models;

namespace Movie.Domain.Dtos.SaleDto
{
    [AutoMap(typeof(Sale), ReverseMap = true)]
    public class CreateSaleDto
    {
        public long Total { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public Guid UserId { get; set; }
    }
}