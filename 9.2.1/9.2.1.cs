using System.Collections.Immutable;
using System.Diagnostics;

public class Task921
{
    public static void Main(string[] args)
    {
        ImmutableList<int> list = ImmutableList<int>.Empty;
        list = list.Insert(0, 13);
        list = list.Insert(0, 7);
        // Выводит "7", затем "13".
        foreach (int item in list)
            Trace.WriteLine(item);
        list = list.RemoveAt(1);
        foreach (int item in list)
            Trace.WriteLine(item);
    }
}
