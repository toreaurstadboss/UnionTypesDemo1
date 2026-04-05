using System.Diagnostics;

public class OneOrMoreExample()
{
    OneOrMore<string> tag = "mytag";
    OneOrMore<string> tags = new[] { "some", "more", "tags", "here" };

    public void RunDemo()
    {
        Console.WriteLine("DEMO STARTING! Starting OneOrMore Demo 2... ");
        IterateItems(tag);
        Console.WriteLine("------------------------------");
        IterateItems(tags);
    }


    private void IterateItems<T>(OneOrMore<T> coll)
    {
        foreach (var item in coll.AsEnumerable())
        {
            Console.WriteLine(item);
        }
    }

}

public union OneOrMore<T>(T, IEnumerable<T>)
{

    public IEnumerable<T> AsEnumerable() => Value switch
    {
        T item => [item],
        IEnumerable<T> items => items,
        null => [],
        _ => throw new UnreachableException()
    };
}