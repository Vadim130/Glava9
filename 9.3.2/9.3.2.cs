using System.Collections.Immutable;
using System.Diagnostics;

public class Task932
{
    public static void Main(string[] args)
    {
        ImmutableSortedSet<int> sortedSet = ImmutableSortedSet<int>.Empty;
        sortedSet = sortedSet.Add(13);
        sortedSet = sortedSet.Add(7);
        // Выводит "7", затем "13".
        foreach (int item in sortedSet)
            Trace.WriteLine(item);
        int smallestItem = sortedSet[0];
        // smallestItem == 7
        Trace.WriteLine("Smallest: " + smallestItem.ToString());
        sortedSet = sortedSet.Remove(7);
        foreach (int item in sortedSet)
            Trace.WriteLine(item);
    }
}
