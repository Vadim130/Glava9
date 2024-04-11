using System.Collections.Concurrent;
using System.Diagnostics;

public class Task971
{
    public static void Main(string[] args)
    {
        BlockingCollection<int> _blockingStack = new BlockingCollection<int>(
         new ConcurrentStack<int>());
        BlockingCollection<int> _blockingBag = new BlockingCollection<int>(
         new ConcurrentBag<int>());
        // Код-производитель
        _blockingStack.Add(7);
        _blockingStack.Add(13);
        _blockingStack.CompleteAdding();
        // Код-потребитель
        // Выводит "13", затем "7".
        foreach (int item in _blockingStack.GetConsumingEnumerable())
            Trace.WriteLine(item);

    }
}