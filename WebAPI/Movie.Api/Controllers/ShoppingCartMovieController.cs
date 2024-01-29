using BlazorWebApp.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.Services;
using Movie.Application.Validators;
using Movie.Domain.Dtos.FilmDto;
using Movie.Domain.Dtos.ShoppingCartMovieDto;
using Movie.Domain.Interfaces;

namespace Movie.Api.Controllers
{
    [Route("ShoppingCartMovie")]
    [ApiController]
    public class ShoppingCartMovieController : ControllerBase
    {
        private IShoppingCartMovieService _shoppingCartMovieService;

        public ShoppingCartMovieController(IShoppingCartMovieService shoppingCartMovieService)
        {
            _shoppingCartMovieService = shoppingCartMovieService;
        }

        [HttpGet]
        [Route("getAll/{shoppingCartId}")]
        public async Task<IActionResult> GetAll([FromRoute] Guid shoppingCartId)
        {
            try
            {
                var foundResult = await _shoppingCartMovieService.GetFilmsByShoppingCartId(shoppingCartId);

                return Ok(new ResultDTO(true, "Sucess", foundResult));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultDTO(false, ex.Message));
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Remove([FromRoute] Guid Id)
        {
            DeleteShoppingCartMovieDto deleteShoppingCartMovieDto = new DeleteShoppingCartMovieDto { Id = Id };

            return Ok(await _shoppingCartMovieService.Delete<DeleteShoppingCartMovieDto, DeletedShoppingCartMovieDto>(deleteShoppingCartMovieDto));
        }

        [HttpPost]
        [Route("colocarCarrinho")]
        public async Task<IActionResult> Create([FromBody] CreateShoppingCartMovieDto createShoppingCartMovieDto)
        {
            return Ok(await _shoppingCartMovieService.Create<CreateShoppingCartMovieDto, CreatedShoppingCartMovieDto>(createShoppingCartMovieDto));
        }

        //[HttpPut]
        //[Route("{id}")]
        //public async Task<IActionResult> Update([FromBody] UpdateShoppingCartMovieDto updateShoppingCartMovieDto, [FromRoute] Guid id)
        //{
        //    updateShoppingCartMovieDto.Id = id;
        //    return Ok(await _shoppingCartMovieService.Update<UpdateShoppingCartMovieDto, UpdatedShoppingCartMovieDto>(updateShoppingCartMovieDto));
        //}

    }
}
