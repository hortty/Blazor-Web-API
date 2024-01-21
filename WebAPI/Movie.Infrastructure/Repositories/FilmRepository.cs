using Microsoft.EntityFrameworkCore;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;
using Movie.Infrastructure.Context;

namespace Movie.Infrastructure.Repositories;

public class FilmRepository : GenericRepository<Film>, IFilmRepository
{
    private readonly DataContext _dbContext;
    private readonly DbSet<Film> _dbSet;


    public FilmRepository(DataContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;

        _dbSet = dbContext.Set<Film>();
    }

    public IQueryable<Film> GetByName(Film film)
    {
        var foundFilms = _dbSet.Where(u => u.Name.Contains(film.Name));
        return foundFilms;
    }
}
