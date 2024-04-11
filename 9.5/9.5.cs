using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Diagnostics;

public class Task95
{
    public static void Main(string[] args)
    {
        var dictionary = new ConcurrentDictionary<int, string>();
        string newValue = dictionary.AddOrUpdate(0,
         key => "Zero",
         (key, oldValue) => "Zero");
        dictionary[1] = "One";
        
        for (int i=0;i<3;i++)
        {
            string? value = null;
            if (dictionary.TryGetValue(i, out value))
                Console.WriteLine(i + ":" + value);
            else
                Console.WriteLine(i + ": not found");
        }

        for (int i = 1; i < 3; i++)
        {
            string? value = null;
            if (dictionary.TryRemove(i, out value))
                Console.WriteLine("Removed: "+i + ": " + value);
            else
                Console.WriteLine("Tried to remove "+ i + ": not found");
        }


        foreach (var data in dictionary)
            Console.WriteLine(data.Key+":"+data.Value);
    }
}
