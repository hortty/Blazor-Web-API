using Movie.Domain.Interfaces;
using Movie.Domain.Models;
using Movie.Infrastructure.Context;

namespace Movie.Infrastructure.Repositories;

public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
{
    public ShoppingCartRepository(DataContext dbContext) : base(dbContext)
    {
    }
}
