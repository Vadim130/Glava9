using System.Collections.Immutable;
using System.Diagnostics;

public class Task941
{
    public static void Main(string[] args)
    {
        ImmutableDictionary<int, string> dictionary =
         ImmutableDictionary<int, string>.Empty;
        dictionary = dictionary.Add(10, "Ten");
        dictionary = dictionary.Add(21, "Twenty-One");
        dictionary = dictionary.SetItem(10, "Diez");
        // Выводит "10Diez" и "21Twenty-One" в непредсказуемом порядке.
        foreach (KeyValuePair<int, string> item in dictionary)
            Trace.WriteLine(item.Key + item.Value);
        string ten = dictionary[10];
        // ten == "Diez"
        
        dictionary = dictionary.Remove(21);
        foreach (KeyValuePair<int, string> item in dictionary)
            Trace.WriteLine(item.Key + item.Value);
    }
}
