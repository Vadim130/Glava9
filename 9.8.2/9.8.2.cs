using System.Collections.Immutable;
using System.Diagnostics;
using System.Threading.Channels;

public class Task982
{
    public static async Task Main(string[] args)
    {
        Channel<int> queue = Channel.CreateUnbounded<int>();
        // Код-производитель
        ChannelWriter<int> writer = queue.Writer;
        await writer.WriteAsync(7);
        await writer.WriteAsync(13);
        writer.Complete();

        // Код-потребитель (старые платформы).
        // Выводит "7", затем "13".

        ChannelReader<int> reader = queue.Reader;
        while (await reader.WaitToReadAsync())
            while (reader.TryRead(out int value))
                Trace.WriteLine(value);
    }
}