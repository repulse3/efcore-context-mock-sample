using DbContextMockSample.Database;
using DbContextMockSample.Models;
using DbContextMockSample.Repositories;
using FluentAssertions;
using NSubstitute;

namespace DbContextMockSample.Tests.Unit;

public class UserRepositoryTests
{
    private readonly IUserRepository _sut;
    private readonly UserContext _userContext = Substitute.For<UserContext>();

    public UserRepositoryTests()
    {
        _sut = new UserRepository(_userContext);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoUsersExist()
    {
        // Arrange
        var mockedDbSet = MockHelper.GetMockedDbSetWithQueryable(new List<User>().AsQueryable());
        _userContext.Users.Returns(mockedDbSet);

        // Act
        var result = await _sut.GetAllAsync();

        // Assert
        result.Should().BeEmpty();
    }
}
