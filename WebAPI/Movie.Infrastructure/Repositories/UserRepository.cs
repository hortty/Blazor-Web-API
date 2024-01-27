using Movie.Domain.Interfaces;
using Movie.Domain.Models;
using Movie.Infrastructure.Context;

namespace Movie.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(DataContext dbContext) : base(dbContext)
    {
    }
}
