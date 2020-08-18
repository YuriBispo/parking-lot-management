## Parking Lot Management

### How to run?
Simply clone this repo and then:

```c#
dotnet restore
dotnet build
cd WebApi
dotnet run
```

If you are using Visual Studio Community instead of VSCode, it might be necessary fix a few project reference issues.
I preloaded a .sln file to make it feel less painful :].

I worked on this in my linux machine, to be clear.

### Main technologies and concepts used

- ASP .NET Core (3.1.6);
- EntityFrameworkCore (3.1.7);
- MediatR (8.1.0);
- xUnit, Moq and OpenCover;
---
- Clean Architecture principles with Mediator Pattern;
- Repository Pattern;
- DDD concepts (Value Objects, Entities, Aggregates);
- TDD (Domain Unit Tests only);
- Command Query Separation.