using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;

public class Task922
{
    public static void Main(string[] args)
    {
        // Лучший способ перебора ImmutableList<T>.
        var list = ImmutableList<int>.Empty;
        list = list.AddRange(Enumerable.Range(1, 10));
        foreach (var item in list)
            Trace.WriteLine(item);
        // Тоже будет работать, но намного медленнее.
        for (int i = 0; i != list.Count; ++i)
            Trace.WriteLine(list[i]);
    }
}
