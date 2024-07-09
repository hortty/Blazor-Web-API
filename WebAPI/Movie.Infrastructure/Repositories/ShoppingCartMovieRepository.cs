using Microsoft.EntityFrameworkCore;
using Movie.Domain.Dtos.FilmDto;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;
using Movie.Infrastructure.Context;

namespace Movie.Infrastructure.Repositories;

public class ShoppingCartMovieRepository : GenericRepository<ShoppingCartMovie>, IShoppingCartMovieRepository
{
    protected readonly DataContext _context;
    public ShoppingCartMovieRepository(DataContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }

    public async Task<List<FoundFilmDto>> GetFilmsByShoppingCartId(Guid shoppingCartId)
    {
        var films = await   (from sp in _context.ShoppingCartMovies
                             join fi in _context.Films on sp.FilmId equals fi.Id
                             where sp.ShoppingCartId == shoppingCartId
                             select new FoundFilmDto
                             {
                                 Id = sp.Id,
                                 Name = fi.Name,
                                 Description = fi.Description,
                                 Price = fi.Price,
                                 Amount = fi.Amount,
                                 Image = fi.Image
                             }).AsNoTracking().ToListAsync();

        return films;
    }
}