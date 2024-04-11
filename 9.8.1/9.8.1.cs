using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Channels;

public class Task983
{
    public static async Task Main(string[] args)
    {
        Channel<int> queue = Channel.CreateUnbounded<int>();
        // Код-производитель
        ChannelWriter<int> writer = queue.Writer;
        await writer.WriteAsync(7);
        await writer.WriteAsync(13);
        writer.Complete();
        // Код-потребитель
        // Выводит "7", затем "13".
        ChannelReader<int> reader = queue.Reader;
        await foreach (int value in reader.ReadAllAsync())
            Trace.WriteLine(value);
    }
}