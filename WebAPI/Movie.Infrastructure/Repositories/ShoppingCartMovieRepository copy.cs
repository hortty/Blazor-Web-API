using Movie.Domain.Interfaces;
using Movie.Domain.Models;
using Movie.Infrastructure.Context;

namespace Movie.Infrastructure.Repositories;

public class ShoppingCartMovieRepository : GenericRepository<ShoppingCartMovie>, IShoppingCartMovieRepository
{
    public ShoppingCartMovieRepository(DataContext dbContext) : base(dbContext)
    {
    }
}
