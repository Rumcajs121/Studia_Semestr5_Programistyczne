var forks = new SimpleSemaphore[5];
for (int i = 0; i < forks.Length; i++)
{
    forks[i] = new SimpleSemaphore(1, 1);
}
for (int i = 0; i < 5; i++)
{
    int philosopherId = i;
    var thread = new Thread(() => PhilosopherProblem.PhilosopherRoutin(philosopherId, forks));
    thread.Start();
}

Console.ReadLine();

public static class PhilosopherProblem
{
    public static void PhilosopherRoutin(int philosopher, SimpleSemaphore[] forks)
    {
        int leftFork = philosopher;
        int rightFork = (philosopher + 1) % forks.Length; 

        while (true)
        {
            Console.WriteLine($"Philosopher {philosopher} thinking...");
            Thread.Sleep(new Random().Next(1000, 2000));
            
            forks[leftFork].Wait();
            forks[rightFork].Wait();

            try
            {
                Console.WriteLine($"Philosopher {philosopher} eating.");
                Thread.Sleep(new Random().Next(1000, 2000));
            }
            finally
            {
                forks[rightFork].Release();
                forks[leftFork].Release();
            }
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
            if (_count > 0)
            {
                _count--;
                return;
            }
        }
    }

    public void Release()
    {
        if (_count < _maxCount)
        {
            _count++;
        }
        else
        {
            throw new InvalidOperationException("Cannot release beyond the maximum count.");
        }
    }
}

