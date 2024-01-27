using Movie.Domain.Interfaces;
using Movie.Domain.Models;
using Movie.Infrastructure.Context;

namespace Movie.Infrastructure.Repositories;

public class SaleRepository : GenericRepository<Sale>, ISaleRepository
{
    public SaleRepository(DataContext dbContext) : base(dbContext)
    {
    }
}
