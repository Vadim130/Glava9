using System.Collections.Immutable;
using System.Diagnostics;

public class Task913
{
    public static void Main(string[] args)
    {
        ImmutableQueue<int> queue = ImmutableQueue<int>.Empty;
        queue = queue.Enqueue(13);
        queue = queue.Enqueue(7);
        // Выводит "13", затем "7".
        foreach (int item in queue)
            Trace.WriteLine(item);
        int nextItem;
        queue = queue.Dequeue(out nextItem);
        // Выводит "13".
        Trace.WriteLine(nextItem);
    }
}