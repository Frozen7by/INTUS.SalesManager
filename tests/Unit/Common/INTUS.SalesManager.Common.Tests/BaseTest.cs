using Bogus;
using Moq;

namespace INTUS.SalesManager.Common.Tests;

public class BaseTest : IDisposable
{
    protected MockRepository MockRepository { get; private set; }

    protected static Faker Faker => new Faker();

    protected List<IDisposable> DisposableList { get; private set; }

    protected BaseTest()
    {
        MockRepository = new MockRepository(MockBehavior.Strict);
        DisposableList = new List<IDisposable>();
    }

    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                DisposableList.ForEach(it => it.Dispose());
                MockRepository.VerifyAll();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}