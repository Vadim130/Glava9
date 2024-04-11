using System.Diagnostics;
using System.Threading.Channels;
using System.Threading.Tasks.Dataflow;

public class Task983
{
    public static async Task Main(string[] args)
    {
        var _asyncQueue = new BufferBlock<int>();
        // Код-производитель.
        await _asyncQueue.SendAsync(7);
        await _asyncQueue.SendAsync(13);
_asyncQueue.Complete();
        // Код-потребитель.
        // Выводит "7", затем "13".
        while (await _asyncQueue.OutputAvailableAsync())
            Trace.WriteLine(await _asyncQueue.ReceiveAsync());
        while (true)
        {
            int item;
            try
            {
                item = await _asyncQueue.ReceiveAsync();
            }
            catch (InvalidOperationException)
            {
                break;
            }
            Trace.WriteLine(item);
        }
    }
}