using BlazorWebApp.DTOs;
using BlazorWebApp.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebApp.Interfaces
{
    public interface ICustomerService
    {
        public Task<ResultDTO<CreatedCustomerDto>> CreateCustomer(CreateCustomerDto createCustomerDto);

    }
}
