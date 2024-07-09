using Microsoft.EntityFrameworkCore;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;
using Movie.Infrastructure.Context;

namespace Movie.Infrastructure.Repositories;

public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
{
    protected readonly DbSet<ShoppingCart> _dbSet;
    public ShoppingCartRepository(DataContext dbContext) : base(dbContext)
    {
        _dbSet = dbContext.Set<ShoppingCart>();
    }

    public async Task<ShoppingCart> GetShoppingCartByUserId(Guid userId)
    {
        var shoppingCart = await _dbSet.FirstOrDefaultAsync(x => x.UserId == userId);

        return shoppingCart;
    }
}
