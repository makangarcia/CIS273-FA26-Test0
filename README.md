# Test 0 — OOP in C#

## CIS 273

This assignment practices four core C# OOP tools by implementing the same
kind of small domain model four different ways: an **abstract base class**,
an **interface**, a **struct**, and the built-in `.NET` interfaces
`IComparable<T>` / `IEquatable<T>`.

The solution (`Test0.sln`) has one project per part, plus a shared
`UnitTests` project (MSTest) that is the actual grading spec — each test
file below defines exactly what members and behavior are required.

| Part | Project | Tests |
|---|---|---|
| 1 — Inheritance | [`Inheritance/`](Inheritance) | [`UnitTests/InheritanceTests.cs`](UnitTests/InheritanceTests.cs) |
| 2 — Interfaces | [`Interfaces/`](Interfaces) | [`UnitTests/InterfacesTests.cs`](UnitTests/InterfacesTests.cs) |
| 3 — Structs | [`LineSegment/`](LineSegment) | [`UnitTests/LineSegmentTests.cs`](UnitTests/LineSegmentTests.cs) |
| 4 — .NET Interfaces (Shapes) | [`Shapes/`](Shapes) | [`UnitTests/ShapesTests.cs`](UnitTests/ShapesTests.cs) |

## Building and testing

```
dotnet build                                              # build the whole solution
dotnet test                                               # run every test
dotnet test --filter "FullyQualifiedName~ShapesTests"     # run one test class
dotnet test --filter "Name=TestRectangleEquals"           # run one test method
```

---

## Part 1: Inheritance

Model Rock/Paper/Scissors using an abstract base class.

### `Outcome` (enum)

- `Win`
- `Loss`
- `Tie`

### `ThrowableObject` (abstract class)

- **Constructor:** `ThrowableObject(string emoji = "")` — sets `Emoji`
- **Properties:** `string Name`, `string Emoji`
- **Methods:**
  - `Outcome Duel(ThrowableObject o)` — abstract
  - `string ToString()` — returns `Emoji`

### `Paper`, `Rock`, `Scissors` (subclasses of `ThrowableObject`)

Each has a constructor `(string emoji)` that sets `Name` to its type name
(`"Paper"`, `"Rock"`, `"Scissors"`) and implements `Duel` with standard
rock-paper-scissors rules (same type vs. same type is a `Tie`).

### Example usage

```csharp
void TestPRS()
{
    Paper p = new Paper("📜");
    Rock r = new Rock("🪨");
    Scissors s = new Scissors("✂️");

    Battle(p, r);
    Battle(p, s);
    Battle(r, s);

    Battle(r, p);
    Battle(s, p);
    Battle(s, r);

    Battle(p, p);
    Battle(r, r);
    Battle(s, s);
}

void Battle(ThrowableObject t1, ThrowableObject t2)
{
    Outcome outcome = t1.Duel(t2);

    if (outcome == Outcome.Win)
        Console.WriteLine(t1 + " wins versus " + t2);
    else if (outcome == Outcome.Loss)
        Console.WriteLine(t1 + " loses versus " + t2);
    else if (outcome == Outcome.Tie)
        Console.WriteLine(t1 + " ties versus " + t2);
}
```

---

## Part 2: Interfaces

The same Rock/Paper/Scissors game, modeled with an interface instead of a
base class, plus a fourth combatant who beats everyone.

### `Outcome` (enum)

- `Win`
- `Loss`
- `Tie`

### `IThrowable` (interface)

- **Properties:** `string Name`, `string Emoji`
- **Methods:** `Outcome Duel(IThrowable o)`

### `Paper`, `Rock`, `Scissors` (implement `IThrowable`)

Each has a constructor `(string emoji)` that sets `Name` to its type name,
overrides `ToString()` to return `Name`, and implements `Duel` with the
usual rules.

### `ChuckNorris` (implements `IThrowable`)

- **Constructor:** `ChuckNorris(string emoji)` — sets `Name` to `"Chuck Norris"`
- **Properties:** `string Name`, `string Emoji`
- **Methods:**
  - `string ToString()` — returns `Name`
  - `Outcome Duel(IThrowable o)` — beats everything except himself; ties himself

> **Note:** the original assignment sheet listed a parameterless
> `ChuckNorris()` constructor, but [`UnitTests/InterfacesTests.cs`](UnitTests/InterfacesTests.cs)
> constructs him the same way as the other throwables
> (`new ChuckNorris("👨‍")`). The tests are the source of truth — implement
> the `(string emoji)` constructor.

### Example usage

```csharp
void TestPRS()
{
    Paper p = new Paper("📜");
    Rock r = new Rock("🪨");
    Scissors s = new Scissors("✂️");

    ChuckNorris cn = new ChuckNorris("👨‍🦰");

    Battle(p, r);
    Battle(p, s);
    Battle(r, s);

    Battle(r, p);
    Battle(s, p);
    Battle(s, r);

    Battle(p, p);
    Battle(r, r);
    Battle(s, s);

    // Chuck Norris stuff
}

void Battle(IThrowable t1, IThrowable t2)
{
    Outcome outcome = t1.Duel(t2);

    if (outcome == Outcome.Win)
        Console.WriteLine(t1 + " wins versus " + t2);
    else if (outcome == Outcome.Loss)
        Console.WriteLine(t1 + " loses versus " + t2);
    else if (outcome == Outcome.Tie)
        Console.WriteLine(t1 + " ties versus " + t2);
}
```

---

## Part 3: Structs

### `Position` (struct)

- **Properties:** `double X`, `double Y`
- **Methods:**
  - `string ToString()` — must override; returns e.g. `"(3, 5)"`

### `LineSegment` (struct)

- **Constructor:** `LineSegment(Position start, Position end)`
- **Properties:**
  - `Position StartPoint`
  - `Position EndPoint`
  - `double Slope` (read-only)
  - `Position Midpoint` (read-only)
  - `double Length` (read-only)
- **Methods:**
  - `string ToString()` — must override; returns start and end as e.g.
    `"(3, 5) , (6, 9)"`

---

## Part 4: .NET Interfaces — Shapes

Three shapes, all comparable by area and equatable by their own rules.

### `IShape` (interface; extends `IComparable<IShape>`, `IEquatable<IShape>`)

- **Properties:**
  - `int NumSides` (read-only, `init`)
  - `double Area` (read-only)
  - `double Perimeter` (read-only)

### `Triangle` (class; implements `IShape`, `IEquatable<Triangle>`)

- **Properties:** `double[] Sides`
- **`CompareTo(Triangle other)`:** compares by `Area`
- **`Equals(Triangle other)`:** equal if the same 3 side lengths match, in
  any order

### `Rectangle` (class; implements `IShape`, `IEquatable<Rectangle>`)

- **Properties:** `double Length`, `double Width`
- **`CompareTo(Rectangle other)`:** compares by `Area`
- **`Equals(Rectangle other)`:** equal if `Length`/`Width` match, in either
  order (a 2×5 rectangle equals a 5×2 rectangle)
- Already implemented — see [`Shapes/Rectangle.cs`](Shapes/Rectangle.cs)
  for the reference pattern the other two shapes should follow.

### `RegularHexagon` (class; implements `IShape`, `IEquatable<RegularHexagon>`)

- **Properties:** `double Side`
- **`CompareTo(RegularHexagon other)`:** compares by `Area`
- **`Equals(RegularHexagon other)`:** equal if `Side` matches
