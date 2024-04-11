using System.Collections.Concurrent;
using System.Diagnostics;
public class BQTest
{
    private readonly BlockingCollection<int> _blockingQueue =
     new BlockingCollection<int>();
    public void Set()
    {
        _blockingQueue.Add(7);
        _blockingQueue.Add(13);
        _blockingQueue.CompleteAdding();
    }
    public void Get()
    {
        // Выводит "7", затем "13".
        foreach (int item in _blockingQueue.GetConsumingEnumerable())
            Trace.WriteLine(item);

    }
}
public class Task961
{
    public static void Main(string[] args)
    {
        var bq = new BQTest();
        Task.Run(() => bq.Set());
        bq.Get();

    }
}