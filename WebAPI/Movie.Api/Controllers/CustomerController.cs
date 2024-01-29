using BlazorWebApp.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Domain.Dtos.CustomerDto;
using Movie.Domain.Interfaces;

namespace Movie.Api.Controllers
{
    [Route("Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCustomerDto getCustomerDto)
        {
            return Ok(await _customerService.ListById<GetCustomerDto, FoundCustomerDto>(getCustomerDto));
        }

        [HttpPost]
        [Route("createCustomer")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto createCustomerDto)
        {
            try
            {
                var createdCustomerDto = await _customerService.Create<CreateCustomerDto, CreatedCustomerDto>(createCustomerDto);

                return Ok(new ResultDTO(true,"Sucesso", createdCustomerDto));
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResultDTO(false, ex.Message));
            }
        }

    }
}
