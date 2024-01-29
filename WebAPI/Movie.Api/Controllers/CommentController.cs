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
    [Route("Comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentsService _comment;

        public CommentController(ICommentsService comment)
        {
            _comment = comment;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var foundResult = _comment.ListAll();

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
                var foundResult = _comment.ListByFilmId(filmId);

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
        //    Comment comment = new Comment { Id = Id };
        //    var deleted = _comment.Delete(comment);

        //    return Ok(deleted);
        //}

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] CreateCommentDto createCommentDto)
        {
            return Ok(_comment.Create(createCommentDto));
        }

        //[HttpPut]
        //[Route("{id}")]
        //public IActionResult Update([FromBody] Comment comment, [FromRoute] string id)
        //{
        //    comment.Id = id;
        //    var updated = _comment.Update(comment);

        //    return Ok(updated);
        //}

    }
}
