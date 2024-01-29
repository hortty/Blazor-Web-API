using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Domain.Dtos.SaleDto;
using Movie.Domain.Interfaces;

namespace Movie.Api.Controllers
{
    [Route("Sale")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        // It could be implemented a way of blocking access, for secutity reasons, using authentication [Authorize] or something
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetSaleDto getSaleDto)
        {
            return Ok(await _saleService.ListById<GetSaleDto, FoundSaleDto>(getSaleDto));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //return Ok(await _saleService.ListAll<FoundSaleDto>());
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSaleDto createSaleDto)
        {
            return Ok(await _saleService.Create<CreateSaleDto, CreatedSaleDto>(createSaleDto));
        }

    }
}
