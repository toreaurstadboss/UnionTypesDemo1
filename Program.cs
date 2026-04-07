
public static class Program
{
	
    public static void Main()
    {
        (new UnionTypeExample()).RunDemo();
		(new AnotherUnionTypeExample()).RunDemo(4);
        (new OneOrMoreExample()).RunDemo();
        
        IntOrBool intOrBool = 42;
        Console.WriteLine($"Value of intOrBool (ToString()): {intOrBool}, as boolean: {intOrBool.AsBool()}. As integer: {intOrBool.AsInt()}");        intOrBool = true;
        Console.WriteLine($"Value of intOrBool after updating value (ToString()): {intOrBool}, as boolean: {intOrBool.AsBool()}. As integer: {intOrBool.AsInt()}");




    }

}

 