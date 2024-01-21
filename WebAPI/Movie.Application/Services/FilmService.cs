using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Dtos;
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