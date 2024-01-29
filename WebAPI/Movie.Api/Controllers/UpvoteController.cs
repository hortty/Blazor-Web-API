using BlazorWebApp.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.Services;
using Movie.Application.Validators;
using Movie.Domain.Dtos.CustomerDto;
using Movie.Domain.Dtos.FilmDto;
using Movie.Domain.Dtos.ShoppingCartMovieDto;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;

namespace Movie.Api.Controllers
{
    [Route("Upvote")]
    [ApiController]
    public class UpvoteController : ControllerBase
    {
        private IUpvoteService _upvote;

        public UpvoteController(IUpvoteService upvote)
        {
            _upvote = upvote;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var foundResult = _upvote.ListAll();

                return Ok(new ResultDTO(true, "Sucess", foundResult));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultDTO(false, ex.Message));
            }
        }

        [HttpGet]
        [Route("getByFilmId/{filmId}")]
        public IActionResult GetByFilmId([FromRoute] Guid filmId)
        {
            try
            {
                var foundResult = _upvote.ListByFilmId(filmId);

                return Ok(new ResultDTO(true, "Sucess", foundResult));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultDTO(false, ex.Message));
            }
        }

        //[HttpDelete]
        //[Route("{Id}")]
        //public IActionResult Remove([FromRoute] string Id)
        //{
        //    Upvote upvote = new Upvote { Id = Id };
        //    var deleted = _upvote.Delete(upvote);

        //    return Ok(deleted);
        //}

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] CreateUpvoteDto createUpvoteDto)
        {
            return Ok(_upvote.Create(createUpvoteDto));
        }

        //[HttpPut]
        //[Route("{id}")]
        //public IActionResult Update([FromBody] Upvote upvote, [FromRoute] string id)
        //{
        //    upvote.Id = id;
        //    var updated = _upvote.Update(upvote);

        //    return Ok(updated);
        //}

    }
}
