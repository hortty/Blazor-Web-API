using BlazorWebApp.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Domain.Dtos.FilmDto;
using Movie.Domain.Interfaces;

namespace Movie.Api.Controllers
{
    [Route("Film")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetFilmDto getFilmDto)
        {
            return Ok(await _filmService.ListById<GetFilmDto, FoundFilmDto>(getFilmDto));
        }

        [HttpGet]
        [Route("Name")]
        public IActionResult GetByName([FromQuery] GetFilmDto getFilmDto)
        {
            return Ok(_filmService.GetByName(getFilmDto));
        }

        [HttpGet]
        [Route("getAll/{page}")]
        public async Task<IActionResult> GetAll([FromRoute] int page)
        {
            try
            {
                GetFilmDto getFilmDto = new GetFilmDto { page = page };

                var filmList = await _filmService.ListAll<GetFilmDto, FoundFilmDto>(getFilmDto);

                return Ok(new ResultDTO(true, "Sucess", filmList));
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResultDTO(false, ex.Message));
            }
        }

        // [HttpDelete]
        // [Route("{Id}")]
        // public async Task<IActionResult> Remove([FromRoute] DeleteFilmDto deleteFilmDto)
        // {
        //     return Ok(await _filmService.Delete<DeleteFilmDto, DeletedFilmDto>(deleteFilmDto));
        // }

        [HttpPost]
        [Route("createFilm")]
        public async Task<IActionResult> Create([FromBody] CreateFilmDto createFilmDto)
        {
            try
            {
                var createdFilmDto = await _filmService.Create<CreateFilmDto, CreatedFilmDto>(createFilmDto); 
                return Ok(new ResultDTO(true, "Sucess", createdFilmDto));
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResultDTO(false, ex.Message));
            }
        }

        // [HttpPut]
        // [Route("{Id}")]
        // public async Task<IActionResult> Update([FromRoute] long Id, [FromBody] UpdateFilmDto updateFilmDto)
        // {
        //     updateFilmDto.Id = Id;
        //     return Ok(await _filmService.Update<UpdateFilmDto, UpdatedFilmDto>(updateFilmDto));
        // }
    }
}
