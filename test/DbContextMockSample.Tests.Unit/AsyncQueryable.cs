using System.Collections;
using System.Linq.Expressions;

namespace DbContextMockSample.Tests.Unit;

/// <summary>
///
/// </summary>
internal class AsyncQueryable<T> : IAsyncEnumerable<T>, IQueryable<T>
{
    private IQueryable<T> Source;

    public AsyncQueryable(IQueryable<T> source)
    {
        Source = source;
    }

    public Type ElementType => typeof(T);

    public Expression Expression => Source.Expression;

    public IQueryProvider Provider => new AsyncQueryProvider<T>(Source.Provider);

    public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken)
    {
        return new AsyncEnumeratorWrapper<T>(Source.GetEnumerator());
    }

    public IEnumerator<T> GetEnumerator() => Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
