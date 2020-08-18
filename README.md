## Parking Lot Management

### How to run?
Simply clone this repo and then:

```c#
dotnet restore
dotnet build
cd WebApi
dotnet run
```

If you are Visual Studio Community instead of VSCode, all you need to do is hit F5.

### Main technologies and concepts used

- ASP .NET Core (3.1.6);
- EntityFrameworkCore (3.1.7);
- MediatR (8.1.0);
- xUnit, Moq and OpenCover;
---
- Clean Architecture principles with Mediator Pattern;
- Repository Pattern;
- TDD (Domain Unit Tests only);
- Command Query Separation.