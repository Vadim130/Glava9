using System.Diagnostics;
using System.Threading.Channels;

public class Task991
{
    public static async Task Main(string[] args)
    {
        Channel<int> queue = Channel.CreateBounded<int>(1);
        ChannelWriter<int> writer = queue.Writer;
        // Эта запись завершается немедленно.
        await writer.WriteAsync(7);
        // Эта запись (асинхронно) ожидает удаления 7
        // перед тем как ставить в очередь 13.
        await writer.WriteAsync(13);
        writer.Complete();
    }
}