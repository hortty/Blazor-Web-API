using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movie.Domain.Models;

namespace Movie.Domain.Interfaces
{
    public interface IFilmRepository : IGenericRepository<Film>
    {
        public IQueryable<Film> GetByName(Film film);
    }
}