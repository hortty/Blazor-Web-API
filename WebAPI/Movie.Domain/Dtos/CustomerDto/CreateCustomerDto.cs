using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Models;

namespace Movie.Domain.Dtos.CustomerDto
{
    [AutoMap(typeof(Customer), ReverseMap = true)]
    public class CreateCustomerDto
    {
        public string Name { get; set; } = String.Empty;

        public string Login { get; set; } = String.Empty;

        public string Password { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string Phone { get; set; } = String.Empty;

        public string Address { get; set; } = String.Empty;

        public int Age { get; set; }

        public Guid UserId { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public bool Active { get; set; } = false;
    }
}