using BlazorWebApp.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Domain.Dtos.CustomerDto;
using Movie.Domain.Dtos.FilmDto;
using Movie.Domain.Interfaces;

namespace Movie.Api.Controllers
{
    [Route("Email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private IOrderService _order;

        public EmailController(IOrderService order)
        {
            _order = order;
        }

        [HttpPost]
        [Route("createOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {
            try
            {
                var createdFilmDto = await _order.Create(createOrderDto); 
                return Ok(new ResultDTO(true, "Sucess", createdFilmDto));
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResultDTO(false, ex.Message));
            }
        }
    }
}
