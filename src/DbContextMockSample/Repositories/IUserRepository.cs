using DbContextMockSample.Models;

namespace DbContextMockSample.Repositories;

internal interface IUserRepository
{
    //public Task<User> GetByIdAsync(Guid id, CancellationToken token = default);

    Task<List<User>> GetAllAsync(CancellationToken token = default);
}
