using System;

namespace BlazorWebApp.DTOs.Customer
{
    public class CreateCustomerDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public Guid UserId { get; set; }
    }
}
