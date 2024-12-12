Worker worker = new Worker();
Thread[] threads = new Thread[10];
for (int i = 0; i < threads.Length; i++)
{
    int threadId = i + 1;
    threads[i] = new Thread(() => worker.CountWorker(threadId));
    threads[i].Start();
}


foreach (Thread thread in threads)
{
    thread.Join();
}

public class Worker()
{

    public void CountWorker(int threadId)
    {
        for (int i = 0; i < 10; i++)
        { 
            int rnd = new Random().Next(1,10000);
            Console.WriteLine("Worker thread {0}: Random number: {1}",threadId, rnd);
            Thread.Sleep(100);
        }
    }
}