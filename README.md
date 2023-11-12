# SeparatingAxisTheorem

A Monogame implementation of the Separating Axis Theorem for convex polygon intersection.

[View on nuget](https://www.nuget.org/packages/Halfcut.SeparatingAxisTheorem.Lib/) or install directly with:

```shell
dotnet add package Halfcut.SeparatingAxisTheorem.Lib --version 0.0.2
```

## Usage

```c#
using Halfcut.SeparatingAxisTheorem.Lib;

private Polygon _polygon1 = PolygonFactory.CreateRectangle(x1, y1, w1, h2);
private Polygon _polygon2 = PolygonFactory.CreateRectangle(x2, y2, w2, h2);

bool isIntersecting = _polygon1.IntersectsWith(_polygon2);
```

## Demo

Run the demo code with:

```shell
git clone git@github.com:tedigc/SeparatingAxisTheorem.git
cd SeparatingAxisTheorem
dotnet build
dotnet run --project SeparatingAxisTheorem.Demo/SeparatingAxisTheorem.Demo.csproj
```

You can move the rotating square with WASD.

## Extensions

- [x] Circle collision
- [x] Improve api for translating and rotating polygons
- [x] Publish as a nuget package
- [ ] Calculate the minimum translation vector (MTV)
- [ ] Convex decomposition for non-convex polygons
- [ ] Exception handling

Created by Ted Cater ([tedigc](https://github.com/tedigc))
