using DbContextMockSample.Models;
using Microsoft.EntityFrameworkCore;

namespace DbContextMockSample.Database;

internal class UserContext : DbContext
{
    public virtual DbSet<User> Users { get; set; } = default!;

    public virtual DbSet<UserPost> UserPosts { get; set; } = default!;
}
