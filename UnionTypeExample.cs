public class UnionTypeExample
{

    public void RunDemo()
    {

        Console.WriteLine("DEMO STARTING ! Starting Union type Demo ...");

        var pets = new Pet?[]
                {
            new Dog("Rex", true),
            new Cat("Misty", 9),
            new Bird("Polly", 35, true)
                };

        foreach (var pet in pets)
        {
            if (pet is null){
                continue; 
            }
            Console.WriteLine(Describe(pet));
            Console.WriteLine(pet.Value.Value);
        }
    }

    private static string Describe(Pet? pet)
    {
        return pet switch
        {
            Dog dog => $"{dog.Name} is a dog and {(dog.LovesFetch ? "loves" : "does not love")} fetch.",
            Cat cat => $"{cat.Name} is a cat with {cat.LivesLeft} lives left.",
            Bird bird => $"{bird.Name} is a bird with a wingspan of {bird.WingSpan} cm{(bird.LovesCrackers ? " and loves crackers" : "")}",
            null => "No pet"
        };
    }

}

sealed record Dog(string Name, bool LovesFetch);

sealed record Cat(string Name, int LivesLeft);

record Bird(string Name, double WingSpan, bool LovesCrackers);

public readonly union Pet(Dog, Cat, Bird);
