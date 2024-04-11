using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;

public class Task931
{
    public static void Main(string[] args)
    {
        ImmutableHashSet<int> hashSet = ImmutableHashSet<int>.Empty;
        hashSet = hashSet.Add(13);
        hashSet = hashSet.Add(7);
        // Выводит "7" и "13" в непредсказуемом порядке.
        foreach (int item in hashSet)
            Trace.WriteLine(item);
        var hashSet2 = hashSet.Remove(7);
        foreach (int item in hashSet2)
            Trace.WriteLine(item);
        foreach (int item in hashSet)
            Trace.WriteLine(item);
    }
}
