public class AnotherUnionTypeExample
{

    public void RunDemo(IntOrString s)
    {
        Console.WriteLine("DEMO STARTING ! Another union type example starting ...");
        Console.WriteLine(Describe(s));
    }

    private string Describe(IntOrString intOrString)
    {
        return intOrString switch
        {
            int i => $"Value is an integer{i}",
            string b => $"Value is a string {b}",
            null => "No value"            
        };
    }

    public union IntOrString(int?, string?);
    
}