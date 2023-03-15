namespace DbContextMockSample.Models;

internal sealed class User
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public string FullName { get; set; } = default!;

    public UserState State { get; set; }

    public ICollection<UserPost>? UserPosts { get; set; }
}
