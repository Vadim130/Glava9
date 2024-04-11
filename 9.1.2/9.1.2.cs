using System.Collections.Immutable;
using System.Diagnostics;

public class Task912
{
    public static void Main(string[] args)
    {
        ImmutableStack<int> stack = ImmutableStack<int>.Empty;
        stack = stack.Push(13);
        ImmutableStack<int> biggerStack = stack.Push(7);
        // Выводит "7", затем "13".
        foreach (int item in biggerStack)
            Trace.WriteLine(item);
        // Выводит только "13".
        foreach (int item in stack)
            Trace.WriteLine(item);
    }
}