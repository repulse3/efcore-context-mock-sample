namespace DbContextMockSample.Tests.Unit;

/// <summary>
///
/// </summary>
internal class AsyncEnumeratorWrapper<T> : IAsyncEnumerator<T>
{
    private readonly IEnumerator<T> Source;

    public AsyncEnumeratorWrapper(IEnumerator<T> source)
    {
        Source = source;
    }

    public T Current => Source.Current;

    public ValueTask DisposeAsync()
    {
        return new ValueTask(Task.CompletedTask);
    }

    public ValueTask<bool> MoveNextAsync()
    {
        return new ValueTask<bool>(Source.MoveNext());
    }
}
