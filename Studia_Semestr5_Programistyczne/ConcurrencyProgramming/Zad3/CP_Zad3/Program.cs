var readSemaphore = new SimpleSemaphore(1, 1);
var writeSemaphore = new SimpleSemaphore(1, 1);
var readCountSemaphore = new SimpleSemaphore(1, 1);
var waitingReadersSemaphore = new SimpleSemaphore(1, 1);

int readCount = 0;
int waitingReaders = 0;

for (int i = 0; i < 6; i++)
{
    int readerId = i;
    var thread = new Thread(() => ReadersWritersProblem.ReaderRoutine(
        readerId,
        readSemaphore,
        writeSemaphore,
        readCountSemaphore,
        waitingReadersSemaphore,
        ref readCount,
        ref waitingReaders));
    thread.Start();
}

for (int i = 0; i < 2; i++)
{
    int writerId = i;
    var thread = new Thread(() => ReadersWritersProblem.WriterRoutine(
        writerId,
        writeSemaphore,
        waitingReadersSemaphore,
        ref waitingReaders));
    thread.Start();
}

Console.ReadLine();

public static class ReadersWritersProblem
{
    public static void ReaderRoutine(
        int readerId,
        SimpleSemaphore readSemaphore,
        SimpleSemaphore writeSemaphore,
        SimpleSemaphore readCountSemaphore,
        SimpleSemaphore waitingReadersSemaphore,
        ref int readCount,
        ref int waitingReaders)
    {
        while (true)
        {
            waitingReadersSemaphore.Wait();
            waitingReaders++;
            waitingReadersSemaphore.Release();

            readCountSemaphore.Wait();
            if (readCount == 0)
            {
                writeSemaphore.Wait();
            }
            readCount++;
            readCountSemaphore.Release();

            waitingReadersSemaphore.Wait();
            waitingReaders--;
            waitingReadersSemaphore.Release();

            Console.WriteLine($"Reader {readerId} is reading...");
            Thread.Sleep(new Random().Next(1000, 2000));

            readCountSemaphore.Wait();
            readCount--;
            if (readCount == 0)
            {
                writeSemaphore.Release();
            }
            readCountSemaphore.Release();

            Thread.Sleep(new Random().Next(1000, 2000));
        }
    }

    public static void WriterRoutine(
        int writerId,
        SimpleSemaphore writeSemaphore,
        SimpleSemaphore waitingReadersSemaphore,
        ref int waitingReaders)
    {
        while (true)
        {
            waitingReadersSemaphore.Wait();
            if (waitingReaders > 0)
            {
                waitingReadersSemaphore.Release();
                Thread.Sleep(new Random().Next(100, 200)); 
                continue;
            }
            waitingReadersSemaphore.Release();

            writeSemaphore.Wait();
            Console.WriteLine($"Writer {writerId} is writing...");
            Thread.Sleep(new Random().Next(2000, 3000));
            writeSemaphore.Release();

            Thread.Sleep(new Random().Next(1000, 2000));
        }
    }
}

public class SimpleSemaphore
{
    private volatile int _count;
    private readonly int _maxCount;

    public SimpleSemaphore(int initialCount, int maxCount)
    {
        if (initialCount < 0 || initialCount > maxCount)
        {
            throw new ArgumentOutOfRangeException(nameof(initialCount), "Initial count must be between 0 and maxCount.");
        }

        _count = initialCount;
        _maxCount = maxCount;
    }

    public void Wait()
    {
        while (true)
        {
            int original = _count;
            if (original > 0 && Interlocked.CompareExchange(ref _count, original - 1, original) == original)
            {
                return;
            }
            Thread.Sleep(1);
        }
    }

    public void Release()
    {
        while (true)
        {
            int original = _count;
            if (original < _maxCount && Interlocked.CompareExchange(ref _count, original + 1, original) == original)
            {
                return;
            }
            if (original >= _maxCount)
            {
                throw new InvalidOperationException("Cannot release beyond the maximum count.");
            }
        }
    }
}

