# uniontypesdemo1

Small C# demo project for preview union-type syntax and pattern matching in .NET 11.

## What This Project Shows

- A `Pet` union (`Dog`, `Cat`, `Bird`) with switch-based pattern matching.
- An `IntOrString` union example with exhaustive-style matching.
- A generic `OneOrMore<T>` union that can hold one item or many and expose an enumerable view.

## Prerequisites

- VS Code Insiders
- .NET 11 preview SDK installed
- C# Dev Kit/C# extension in VS Code Insiders

You can verify your SDK with:

```powershell
dotnet --info
```

## Required Project Settings

This repo is configured for .NET 11 + preview C# features in `uniontypesdemo1.csproj`:

```xml
<PropertyGroup>
  <TargetFramework>net11.0</TargetFramework>
  <LangVersion>preview</LangVersion>
</PropertyGroup>
```

## Open and Run in VS Code Insiders

1. Open the folder in VS Code Insiders.
2. Open a terminal in the workspace root.
3. Build the project:

```powershell
dotnet build .\uniontypesdemo1.csproj
```

4. Run the project:

```powershell
dotnet run --project .\uniontypesdemo1.csproj
```

`Program.Main()` runs all demos.

## Code Snippets

### 1) Pet union and pattern matching

```csharp
sealed record Dog(string Name, bool LovesFetch);
sealed record Cat(string Name, int LivesLeft);
record Bird(string Name, double WingSpan, bool LovesCrackers);

public readonly union Pet(Dog, Cat, Bird);

private static string Describe(Pet? pet) => pet switch
{
	Dog dog => $"{dog.Name} is a dog and {(dog.LovesFetch ? "loves" : "does not love")} fetch.",
	Cat cat => $"{cat.Name} is a cat with {cat.LivesLeft} lives left.",
	Bird bird => $"{bird.Name} is a bird with a wingspan of {bird.WingSpan} cm{(bird.LovesCrackers ? " and loves crackers" : "")}",
	null => "No pet"
};
```

### 2) IntOrString union

```csharp
public union IntOrString(int?, string?);

private string Describe(IntOrString intOrString) => intOrString switch
{
	int i => $"Value is an integer {i}",
	string s => $"Value is a string {s}",
	null => "No value"
};
```

### 3) Generic OneOrMore<T> union

```csharp
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
```

## Notes

- This is an experimental preview playground.
- Union-related syntax/behavior can change between preview SDK versions.
- The fallback arm in `OneOrMore<T>.AsEnumerable()` is defensive for switch exhaustiveness over `Value`.

## Planned _possible_ Future Demos (C# 15 Union Types) (I might look into one ore more of these functional demos)

- `Result<T, TError>` pipeline demo: model validation and domain errors without exceptions, then compose multiple operations with pattern matching.
- HTTP/API response union demo: map a `Success | NotFound | Unauthorized | ValidationError` union to ASP.NET Core `IResult` values.
- State machine demo: represent workflow states as unions (for example `Draft | Submitted | Approved | Rejected`) and enforce legal transitions.
- Nested unions with collections demo: process `OneOrMore<Result<Order, OrderError>>` and aggregate successes/errors in one pass.
- Generic parsing demo: build `ParseResult<T>` unions and show reusable helpers for exhaustive matching, logging, and telemetry.
