using Microsoft.EntityFrameworkCore;
using Movie.Domain.Dtos.UserDto;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;
using Movie.Infrastructure.Context;

namespace Movie.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    protected readonly DbSet<User> _dbSet;
    public UserRepository(DataContext dbContext) : base(dbContext)
    {
        _dbSet = dbContext.Set<User>();
    }

    public async Task<User> FindUserByLogin(GetUserDTO getUserDTO)
    {
        var foundUser = await _dbSet.FirstOrDefaultAsync(x => x.Username == getUserDTO.Username);

        return foundUser;
    }
}
