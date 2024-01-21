using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;

namespace Movie.Application.Services
{
    public class CustomerService : GenericService<Customer, ICustomerRepository>, ICustomerService
    {
        public CustomerService(ICustomerRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}