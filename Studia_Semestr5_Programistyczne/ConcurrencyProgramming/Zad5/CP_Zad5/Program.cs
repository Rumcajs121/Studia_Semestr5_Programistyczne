var forks = new CustomMonitor[5];
for (int i = 0; i < forks.Length; i++)
{
    forks[i] = new CustomMonitor();
}
for (int i = 0; i < 5; i++)
{
    int philosopherId = i;
    var thread = new Thread(() => PhilosopherProblem.PhilosopherRoutine(philosopherId, forks));
    thread.Start();
}

Console.ReadLine();

public static class PhilosopherProblem
{
    public static void PhilosopherRoutine(int philosopher, CustomMonitor[] forks)
    {
        int leftFork = philosopher;
        int rightFork = (philosopher + 1) % forks.Length; 

        while (true)
        {
            Console.WriteLine($"Philosopher {philosopher} is thinking...");
            Thread.Sleep(new Random().Next(1000, 2000));

            if (philosopher % 2 == 0)
            {
                forks[leftFork].Enter();
                forks[rightFork].Enter();
            }
            else
            {
                forks[rightFork].Enter();
                forks[leftFork].Enter();
            }

            try
            {
                Console.WriteLine($"Philosopher {philosopher} is eating...");
                Thread.Sleep(new Random().Next(1000, 2000));
            }
            finally
            {
                forks[rightFork].Exit();
                forks[leftFork].Exit();
            }
        }
    }
}

public class CustomMonitor
{
    private volatile bool _isLocked = false;
    private readonly Queue<Thread> _waitingThreads = new Queue<Thread>();

    public void Enter()
    {
        while (true)
        {
            lock (_waitingThreads)
            {
                if (!_isLocked)
                {
                    _isLocked = true;
                    return;
                }

                if (!_waitingThreads.Contains(Thread.CurrentThread))
                {
                    _waitingThreads.Enqueue(Thread.CurrentThread);
                }
            }

            while (_waitingThreads.Peek() != Thread.CurrentThread)
            {
                Thread.Sleep(1);
            }
        }
    }

    public void Exit()
    {
        lock (_waitingThreads)
        {
            _isLocked = false;
            if (_waitingThreads.Count > 0 && _waitingThreads.Peek() == Thread.CurrentThread)
            {
                _waitingThreads.Dequeue();
            }
        }
    }
}
