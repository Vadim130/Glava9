using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

public class Task9122
{
    public static void Main(string[] args)
    {
        var queue = new BufferBlock<int>();
        // Код-производитель
        queue.Post(7);
        queue.Post(13);
        queue.Complete();
        // Код-потребитель
        while (true)
        {
            int item;
            try
            {
                item = queue.Receive();
            }
            catch (InvalidOperationException)
            {
                break;
            }
            Trace.WriteLine(item);
        }
    }
}