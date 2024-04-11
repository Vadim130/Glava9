using System.Threading.Channels;

public class Task9101
{
    public static async Task Main(string[] args)
    {
        Channel<int> queue = Channel.CreateBounded<int>(
         new BoundedChannelOptions(1)
         {
             FullMode = BoundedChannelFullMode.DropOldest,
         });
        ChannelWriter<int> writer = queue.Writer;
        // Операция записи завершается немедленно.
        await writer.WriteAsync(7);
        // Операция записи тоже завершается немедленно.
        // Элемент 7 теряется, если только он не был
        // немедленно извлечен потребителем.
        await writer.WriteAsync(13);
    }
}