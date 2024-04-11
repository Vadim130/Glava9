using System.Collections.Immutable;
using System.Diagnostics;

public class Task942
{
    public static void Main(string[] args)
    {
        ImmutableSortedDictionary<int, string> sortedDictionary =
         ImmutableSortedDictionary<int, string>.Empty;
        sortedDictionary = sortedDictionary.Add(10, "Ten");
        sortedDictionary = sortedDictionary.Add(21, "Twenty-One");
        sortedDictionary = sortedDictionary.SetItem(10, "Diez");
        // Выводит "10Diez", затем "21Twenty-One".
        foreach (KeyValuePair<int, string> item in sortedDictionary)
            Trace.WriteLine(item.Key + item.Value);
        string ten = sortedDictionary[10];
        // ten == "Diez"
        sortedDictionary = sortedDictionary.Remove(21);
        foreach (KeyValuePair<int, string> item in sortedDictionary)
            Trace.WriteLine(item.Key + item.Value);
    }
}
