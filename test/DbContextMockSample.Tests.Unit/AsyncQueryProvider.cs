using System.Linq.Expressions;

namespace DbContextMockSample.Tests.Unit;

/// <summary>
///
/// </summary>
internal class AsyncQueryProvider<T> : IQueryProvider
{
    private readonly IQueryProvider Source;

    public AsyncQueryProvider(IQueryProvider source)
    {
        Source = source;
    }

    public IQueryable CreateQuery(Expression expression) =>
        Source.CreateQuery(expression);

    public IQueryable<TElement> CreateQuery<TElement>(Expression expression) =>
        new AsyncQueryable<TElement>(Source.CreateQuery<TElement>(expression));

    public object? Execute(Expression expression) => Execute<T>(expression);

    public TResult Execute<TResult>(Expression expression) =>
        Source.Execute<TResult>(expression);
}
