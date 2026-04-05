public class UnionExample1
{

    public void RunDemo1(IntOrString s)
    {
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