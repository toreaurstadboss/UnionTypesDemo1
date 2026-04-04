
public static class Program
{
	public static void Main()
	{
		var pets = new Pet[]
		{
			new Dog("Rex", true),
			new Cat("Misty", 9)
		};

		foreach (var pet in pets)
		{
			Console.WriteLine(Describe(pet));
		}
	}

	private static string Describe(Pet pet)
	{
		return pet switch
		{
			Dog dog => $"{dog.Name} is a dog and {(dog.LovesFetch ? "loves" : "does not love")} fetch.",
			Cat cat => $"{cat.Name} is a cat with {cat.LivesLeft} lives left.",
			null => "No pet"
		};
	}
}

sealed record Dog(string Name, bool LovesFetch);

sealed record Cat(string Name, int LivesLeft);

public union Pet(Dog, Cat);
