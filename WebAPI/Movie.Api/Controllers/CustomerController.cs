using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Domain.Dtos;
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

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerService.ListAll<FoundCustomerDto>());
        }

        // [HttpDelete]
        // [Route("{Id}")]
        // public async Task<IActionResult> Remove([FromRoute] DeleteCustomerDto deleteCustomerDto)
        // {
        //     return Ok(await _customerService.Delete<DeleteCustomerDto, DeletedCustomerDto>(deleteCustomerDto));
        // }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto createCustomerDto)
        {
            return Ok(await _customerService.Create<CreateCustomerDto, CreatedCustomerDto>(createCustomerDto));
        }

        // [HttpPut]
        // [Route("{Id}")]
        // public async Task<IActionResult> Update([FromRoute] long Id, [FromBody] UpdateCustomerDto updateCustomerDto)
        // {
        //     updateCustomerDto.Id = Id;
        //     return Ok(await _customerService.Update<UpdateCustomerDto, UpdatedCustomerDto>(updateCustomerDto));
        // }
    }
}
