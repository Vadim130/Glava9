using System.Threading.Channels;

public class Task9101
{
    public static async Task Main(string[] args)
    {
        Channel<int> queue = Channel.CreateBounded<int>(
         new BoundedChannelOptions(1)
         {
             FullMode = BoundedChannelFullMode.DropWrite,
         });
        ChannelWriter<int> writer = queue.Writer;
        // Операция записи завершается немедленно.
        await writer.WriteAsync(7);
        // Операция записи тоже завершается немедленно.
        // Элемент 13 теряется, если только элемент 7 не был
        // немедленно извлечен потребителем.
        await writer.WriteAsync(13);
    }
}