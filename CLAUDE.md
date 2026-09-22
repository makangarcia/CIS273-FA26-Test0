# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this is

A CIS273 coursework solution (Test0). It's a Visual Studio solution (`Test0.sln`) with four independent C# console exercise projects plus one MSTest project that specifies the expected behavior for all of them. **The tests are the spec**: each exercise class is a stub (often just `// TODO` and an empty body), and the corresponding test file in `UnitTests/` defines exactly what members/behavior need to be implemented. When asked to "finish" or "implement" an exercise, read its test file first.

Exercise → test file mapping:
- `Inheritance/` → `UnitTests/InheritanceTests.cs` — Rock/Paper/Scissors modeled via an abstract base class (`ThrowableObject`), currently empty.
- `Interfaces/` → `UnitTests/InterfacesTests.cs` — the same Rock/Paper/Scissors game modeled via an `IThrowable` interface instead of a base class, plus a `ChuckNorris` class that beats everything and ties only itself.
- `Shapes/` → `UnitTests/ShapesTests.cs` — shape classes (`Rectangle`, `Triangle`, `RegularHexagon`) implementing `IShape : IComparable<IShape>, IEquatable<IShape>`. `Rectangle` is the reference/worked example (see below); `Triangle` and `RegularHexagon` are still stubs.
- `LineSegment/` → `UnitTests/LineSegmentTests.cs` — a `Position` struct and a `LineSegment` struct (start/end points, slope, midpoint, length), both still stubs.

Comparing the `Inheritance` and `Interfaces` projects side by side is useful: they implement the identical Rock/Paper/Scissors ruleset (win/loss/tie via `Duel`) through two different OOP mechanisms, which is the point of the exercise.

## Commands

Build/test everything from the repo root:
```
dotnet build                     # build the whole solution
dotnet test                      # run all MSTest tests (UnitTests project)
dotnet test --filter "FullyQualifiedName~ShapesTests"   # run one test class
dotnet test --filter "Name=TestRectangleEquals"          # run one test method
```
Run an individual exercise's console app (has no runtime behavior yet beyond stubs):
```
dotnet run --project Shapes
dotnet run --project Inheritance
dotnet run --project Interfaces
dotnet run --project LineSegment
```

## Known repo issue

`UnitTests/UnitTests.csproj` has a `<ProjectReference>` to `..\ParameterModifiers\ParameterModifiers.csproj`, but no `ParameterModifiers` project exists in this repo and it is not part of `Test0.sln`. This reference breaks `dotnet build`/`dotnet test` for the whole solution until it is either removed or the missing project is added.

All five projects (`Shapes`, `LineSegment`, `UnitTests`, `Inheritance`, `Interfaces`) target `net10.0`.

## Architecture notes

- Every exercise project is its own `net9.0`/`net10.0` executable (`OutputType>Exe`) with `Nullable` and `ImplicitUsings` enabled, and each has its own namespace matching the folder name (`Inheritance`, `Interfaces`, `Shapes`, `LineSegment`).
- `UnitTests.csproj` references all four exercise projects and pulls their public types in via `using <Namespace>;` at the top of each test file — it is the only project that ties them together.
- `Shapes/Rectangle.cs` is the completed reference implementation for the `IShape` pattern: it implements `CompareTo` by comparing `Area`, and implements `Equals` at three levels (`object?`, `IShape?`, `Rectangle?`) with the interesting rule that two rectangles are equal if their dimensions match either in order or swapped (i.e. a 2×5 rectangle equals a 5×2 rectangle). Use this as the template when filling in `Triangle` and `RegularHexagon`.
- `IShape` requires both `IComparable<IShape>` and `IEquatable<IShape>` — new shapes need `NumSides` (an `init` property), `Area`, `Perimeter`, `CompareTo`, and the `Equals` overload chain.
