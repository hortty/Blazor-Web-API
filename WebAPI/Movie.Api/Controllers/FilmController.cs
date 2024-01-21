using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Domain.Dtos;
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
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _filmService.ListAll<FoundFilmDto>());
        }

        // [HttpDelete]
        // [Route("{Id}")]
        // public async Task<IActionResult> Remove([FromRoute] DeleteFilmDto deleteFilmDto)
        // {
        //     return Ok(await _filmService.Delete<DeleteFilmDto, DeletedFilmDto>(deleteFilmDto));
        // }

        // [HttpPost]
        // public async Task<IActionResult> Create([FromBody] CreateFilmDto createFilmDto)
        // {
        //     return Ok(await _filmService.Create<CreateFilmDto, CreatedFilmDto>(createFilmDto));
        // }

        // [HttpPut]
        // [Route("{Id}")]
        // public async Task<IActionResult> Update([FromRoute] long Id, [FromBody] UpdateFilmDto updateFilmDto)
        // {
        //     updateFilmDto.Id = Id;
        //     return Ok(await _filmService.Update<UpdateFilmDto, UpdatedFilmDto>(updateFilmDto));
        // }
    }
}
