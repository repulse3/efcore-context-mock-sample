namespace DbContextMockSample.Models;

internal sealed class UserPost
{
    public string Title { get; set; } = default!;

    public User User { get; set; } = default!;
}
