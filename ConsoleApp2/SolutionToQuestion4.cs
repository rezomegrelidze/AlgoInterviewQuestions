public static class SolutionToQuestion4
{
    public static void ExampleUsage()
    {
        SpecialDict<string, int> dict = new();

        dict.Set("a",1);
        dict.Set("b", 2);
        dict.Set("c", 3);

        Console.WriteLine(dict.Get("a")); // 1
        Console.WriteLine(dict.Get("b")); // 2
        Console.WriteLine(dict.Get("c")); // 3

        dict.SetAll(0); // set all to 0

        dict.Set("a",1); // and only set key 'a' to 1

        Console.WriteLine(dict.Get("a")); // 1
        Console.WriteLine(dict.Get("b")); // 0
        Console.WriteLine(dict.Get("c")); // 0
    }
}

public class SpecialDict<TKey,TValue>
{
    private int _version;
    private TValue _globalValue;

    private Dictionary<TKey, (int version, TValue value)> 
        dict = new();

    public TValue Get(TKey key)
    {
        if (dict.TryGetValue(key, out var tuple)
            && tuple.version >= _version)
        {
            return tuple.value;
        }
        return _globalValue;
    }

    public void Set(TKey key, TValue value)
    {
        dict[key] =  (_version,value);
    }

    public void SetAll(TValue value)
    {
        _globalValue = value;
        _version++;
    }
}