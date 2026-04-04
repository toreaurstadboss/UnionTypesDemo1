# uniontypesdemo1

Small C# demo showing preview union-type syntax and pattern matching.

The program defines three pet records (`Dog`, `Cat`, and `Bird`) and a union type (`Pet`). It then uses a switch expression to describe each pet at runtime.

## Prerequisites

- .NET SDK that supports `net11.0` and C# preview features

## Build

```powershell
dotnet build .\uniontypesdemo1.csproj
```

## Run

```powershell
dotnet run --project .\uniontypesdemo1.csproj
```

## Project Files

- `Program.cs`: Demo data, union definition, and pattern-matching output
- `RuntimePolyfill.cs`: Minimal runtime polyfill for union-related types/attributes used by the demo
- `uniontypesdemo1.csproj`: Target framework and language settings (`net11.0`, `LangVersion=preview`)

## Notes

- This project is intentionally minimal and focused on language experimentation.
- Union-related functionality may change in future preview SDK versions.
