using System.Diagnostics;
using System.Threading.Channels;
using System.Threading.Tasks.Dataflow;

public class Task9121
{
    public static async Task Main(string[] args)
    {
        var queue = new BufferBlock<int>();
        // Код-производитель
        await queue.SendAsync(7);
        await queue.SendAsync(13);
        queue.Complete();
        // Для одного потребителя
        while (await queue.OutputAvailableAsync())
            Trace.WriteLine(await queue.ReceiveAsync());
        // Для нескольких потребителей
        while (true)
        {
            int item;
            try
            {
                item = await queue.ReceiveAsync();
            }
            catch (InvalidOperationException)
            {
                break;
            }
            Trace.WriteLine(item);
        }
    }
}