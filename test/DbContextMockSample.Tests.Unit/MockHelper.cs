using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace DbContextMockSample.Tests.Unit;

public static class MockHelper
{
    public static DbSet<TEntity> GetMockedDbSetWithQueryable<TEntity>(IQueryable<TEntity> queryable)
        where TEntity : class
    {
        var asyncQueryable = new AsyncQueryable<TEntity>(queryable);
        var mockSet = Substitute.For<DbSet<TEntity>, IQueryable<TEntity>, IAsyncEnumerable<TEntity>>();

        // setup all IQueryable methods using what you have from "data"
        ((IQueryable<TEntity>) mockSet)
            .Provider
            .Returns(asyncQueryable.Provider);

        ((IQueryable<TEntity>) mockSet).Expression
            .Returns(asyncQueryable.Expression);

        ((IQueryable<TEntity>) mockSet)
            .ElementType
            .Returns(asyncQueryable.ElementType);

        ((IQueryable<TEntity>) mockSet)
            .GetEnumerator()
            .Returns(asyncQueryable.GetEnumerator());

        ((IAsyncEnumerable<TEntity>) mockSet)
            .GetAsyncEnumerator(Arg.Any<CancellationToken>())
            .Returns(asyncQueryable.GetAsyncEnumerator(default));

        mockSet
            .AsAsyncEnumerable()
            .Returns(asyncQueryable);

        return mockSet;
    }
}
