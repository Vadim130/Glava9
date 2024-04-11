using System.Diagnostics;
using System.Threading.Channels;
using System.Threading.Tasks.Dataflow;

public class Task9125
{
    public static void Main(string[] args)
    {
        Channel<int> queue = Channel.CreateBounded<int>(10);
        // Код-производитель
        ChannelWriter<int> writer = queue.Writer;
        Task.Run(async () =>
        {
            await writer.WriteAsync(7);
            await writer.WriteAsync(13);
            writer.Complete();
        }).GetAwaiter().GetResult();
        // Код-потребитель
        ChannelReader<int> reader = queue.Reader;
        Task.Run(async () =>
        {
            while (await reader.WaitToReadAsync())
                while (reader.TryRead(out int value))
                    Trace.WriteLine(value);
        }).GetAwaiter().GetResult();
    }
}