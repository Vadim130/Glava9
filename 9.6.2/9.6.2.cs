using System.Collections.Concurrent;
using System.Diagnostics;

public class Task962
{
    public static void Main(string[] args)
    {
        // Выводит "7", затем "13".
        foreach (int item in _blockingQueue.GetConsumingEnumerable())
            Trace.WriteLine(item);

    }
}