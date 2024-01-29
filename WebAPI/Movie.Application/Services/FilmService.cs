using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Dtos.FilmDto;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;

namespace Movie.Application.Services
{
    public class FilmService : GenericService<Film, IFilmRepository>, IFilmService
    {
        private IFilmRepository _filmRepository;
        private IMapper _mapper;

        public FilmService(IFilmRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _filmRepository = repository;
            _mapper = mapper;
        }

        public async override Task<TOutputDto> Create<TInputDto, TOutputDto>(TInputDto inputDto)
        where TInputDto : class
        where TOutputDto : class
        {
            if(inputDto == null) throw new ArgumentNullException(nameof(inputDto));

            if(inputDto is CreateFilmDto)
            {
                var createFilmDto = inputDto as CreateFilmDto;
                var bytes = Convert.FromBase64String(createFilmDto!.ImagemBase64.Split(',')[1]);

                Film film = new Film
                {
                    Name = createFilmDto.Name,
                    Description = createFilmDto.Description,
                    Price = createFilmDto.Price,
                    Amount = createFilmDto.Amount,
                    Image = bytes
                };

                film.CreationDate = DateTime.UtcNow;
                film.Ativo = true;

                var createdEntity = await _filmRepository.Create(film);

                CreatedFilmDto createdFilmDto = new CreatedFilmDto();
                createdFilmDto.Name = createdEntity.Name;

                return createdFilmDto as TOutputDto;
            }
            else
            {
                throw new Exception("Wrong DTO.");
            }
        }

        public IQueryable<FoundFilmDto> GetByName(GetFilmDto getFilmDto)
        {
            var filmEntity = _mapper.Map<Film>(getFilmDto);

            var foundEntities = _filmRepository.GetByName(filmEntity);

            var foundFilmsDto = foundEntities.Select(f => _mapper.Map<FoundFilmDto>(f));

            // var foundFilmDto = _mapper.Map<IQueryable<FoundFilmDto>>(foundEntities);

            return foundFilmsDto;
        }

    }
}