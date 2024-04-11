using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

public class Task9123
{
    public static async Task Main(string[] args)
    {
        // Странно, не работает!
        // Код-потребитель передается конструктору очереди
        ActionBlock<int> queue = new ActionBlock<int>(item =>
            Trace.WriteLine(item));
        // Асинхронный код-производитель
        await queue.SendAsync(7);
        await queue.SendAsync(13);
        // Синхронный код-производитель
        queue.Post(7);
        queue.Post(13);
        queue.Complete();
    }
}