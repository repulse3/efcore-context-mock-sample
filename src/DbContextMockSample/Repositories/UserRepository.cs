using DbContextMockSample.Database;
using DbContextMockSample.Models;
using Microsoft.EntityFrameworkCore;

namespace DbContextMockSample.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly UserContext _userContext;

    public UserRepository(UserContext userContext)
    {
        _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
    }

    public Task<User> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return _userContext.Users.FirstAsync(x => x.Id == id, token);
    }

    public Task<List<User>> GetAllAsync(CancellationToken token = default)
    {
        return _userContext.Users.Include(x => x.UserPosts)
            .ToListAsync(token);
    }
}
