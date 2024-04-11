using System.Collections.Immutable;
using System.Diagnostics;

public class Task911
{
    public static void Main(string[] args)
    {
        ImmutableStack<int> stack = ImmutableStack<int>.Empty;
        stack = stack.Push(13);
        stack = stack.Push(7);
        // Выводит "7", затем "13".
        foreach (int item in stack)
            Trace.WriteLine(item);
        int lastItem;
        stack = stack.Pop(out lastItem);
        // lastItem == 7
    }
}