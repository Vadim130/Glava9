using Nito.AsyncEx;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

public class Task9124
{
    public static async Task Main(string[] args)
    {
        var queue = new AsyncProducerConsumerQueue<int>();
        // Асинхронный код-производитель
        await queue.EnqueueAsync(7);
        await queue.EnqueueAsync(13);
        // Синхронный код-производитель
        queue.Enqueue(7);
        queue.Enqueue(13);
        queue.CompleteAdding();
        // Для одного асинхронного потребителя
        while (await queue.OutputAvailableAsync())
            Trace.WriteLine(await queue.DequeueAsync());
        // Для нескольких асинхронных потребителей
        while (true)
        {
            int item;
            try
            {
                item = await queue.DequeueAsync();
            }
            catch (InvalidOperationException)
            {
                break;
            }
            Trace.WriteLine(item);
        }
        // Синхронный код-потребитель
        foreach (int item in queue.GetConsumingEnumerable())
            Trace.WriteLine(item);
    }
}