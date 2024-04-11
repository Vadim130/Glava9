﻿using Nito.AsyncEx;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

public class Task984
{
    public static async Task Main(string[] args)
    {
        var _asyncQueue = new AsyncProducerConsumerQueue<int>();
        // Код-производитель
        await _asyncQueue.EnqueueAsync(7);
        await _asyncQueue.EnqueueAsync(13);
        _asyncQueue.CompleteAdding();
        // Код-потребитель
        // Выводит "7", затем "13".
        while (await _asyncQueue.OutputAvailableAsync())
            Trace.WriteLine(await _asyncQueue.DequeueAsync());
        while (true)
        {
            int item;
            try
            {
                item = await _asyncQueue.DequeueAsync();
            }
            catch (InvalidOperationException)
            {
                break;
            }
            Trace.WriteLine(item);
        }
    }
}