namespace UnitTests;

using Shapes;

[TestClass]
public class ShapesTests
{
    [TestMethod]
    public void TestRectangleAreaPerimeter()
    {
        Rectangle rectangle1 = new Rectangle();
        rectangle1.Length = 8;
        rectangle1.Width = 4;

        Assert.AreEqual(32, rectangle1.Area);
        Assert.AreEqual(24, rectangle1.Perimeter);

        Rectangle rectangle2 = new Rectangle();
        rectangle2.Length = 8;
        rectangle2.Width = 8;

        Assert.AreEqual(64, rectangle2.Area);
        Assert.AreEqual(32, rectangle2.Perimeter);

    }

    [TestMethod]
    public void TestRectangleEquals()
    {
        Rectangle rectangle1 = new Rectangle();
        rectangle1.Length = 8;
        rectangle1.Width = 4;

        Rectangle rectangle2 = new Rectangle();
        rectangle2.Length = 8;
        rectangle2.Width = 8;

        Assert.IsFalse(rectangle1.Equals(rectangle2));
        Assert.IsTrue(rectangle1.Equals(rectangle1));
        rectangle2.Width = 4;
        Assert.IsTrue(rectangle1.Equals(rectangle2));
    }

    [TestMethod]
    public void TestRectangleCompareTo()
    {
        Rectangle rectangle1 = new Rectangle();
        rectangle1.Length = 8;
        rectangle1.Width = 4;

        Rectangle rectangle2 = new Rectangle();
        rectangle2.Length = 8;
        rectangle2.Width = 8;

        Assert.AreEqual(-1, rectangle1.CompareTo(rectangle2));
        Assert.AreEqual(1, rectangle2.CompareTo(rectangle1));
        Assert.AreEqual(0, rectangle1.CompareTo(rectangle1));
        rectangle2.Width = 4;
        Assert.AreEqual(0, rectangle1.CompareTo(rectangle2));
        rectangle2.Width = 2;
        Assert.AreEqual(1, rectangle1.CompareTo(rectangle2));
        Assert.AreEqual(-1, rectangle2.CompareTo(rectangle1));
    }

    [TestMethod]
    public void TestTriangleAreaPerimeter()
    {
        Triangle triangle = new Triangle();
        triangle.Sides[0] = 4;
        triangle.Sides[1] = 3;
        triangle.Sides[2] = 5;

        Assert.AreEqual(6, triangle.Area);
        Assert.AreEqual(12, triangle.Perimeter);

        triangle.Sides[1] = 8;
        Assert.AreEqual(8.181534085976786, triangle.Area, 1e-7);
        Assert.AreEqual(17, triangle.Perimeter);

    }

    [TestMethod]
    public void TestTriangleEquals()
    {
        Triangle triangle1 = new Triangle();
        triangle1.Sides[0] = 4;
        triangle1.Sides[1] = 3;
        triangle1.Sides[2] = 5;

        Triangle triangle2 = new Triangle();
        triangle2.Sides[0] = 5;
        triangle2.Sides[1] = 4;
        triangle2.Sides[2] = 3;

        Assert.IsTrue(triangle1.Equals(triangle2));
        Assert.IsTrue(triangle1.Equals(triangle1));
        triangle2.Sides[0] = 6;
        Assert.IsFalse(triangle1.Equals(triangle2));

    }

    [TestMethod]
    public void TestTriangleCompareTo()
    {
        Triangle triangle1 = new Triangle();
        triangle1.Sides[0] = 4;
        triangle1.Sides[1] = 3;
        triangle1.Sides[2] = 5;

        Triangle triangle2 = new Triangle();
        triangle2.Sides[0] = 5;
        triangle2.Sides[1] = 7;
        triangle2.Sides[2] = 3;

        Assert.AreEqual(-1, triangle1.CompareTo(triangle2));
        Assert.AreEqual(1, triangle2.CompareTo(triangle1));
        Assert.AreEqual(0, triangle1.CompareTo(triangle1));
        triangle2.Sides[1] = 4;
        Assert.AreEqual(0, triangle1.CompareTo(triangle2));
        triangle2.Sides[1] = 3;
        Assert.AreEqual(1, triangle1.CompareTo(triangle2));
        Assert.AreEqual(-1, triangle2.CompareTo(triangle1));
    }

    [TestMethod]
    public void TestRegularHexagonAreaPerimeter()
    {
        RegularHexagon regularHexagon = new RegularHexagon();
        regularHexagon.Side = 3;

        Assert.AreEqual(23.3826859021, regularHexagon.Area, 1e-6);
        Assert.AreEqual(18, regularHexagon.Perimeter);

    }
    [TestMethod]
    public void TestRegularHexagonEquals()
    {
        RegularHexagon regularHexagon1 = new RegularHexagon();
        regularHexagon1.Side = 3;

        RegularHexagon regularHexagon2 = new RegularHexagon();
        regularHexagon2.Side = 3;

        Assert.IsTrue(regularHexagon1.Equals(regularHexagon2));
        Assert.IsTrue(regularHexagon1.Equals(regularHexagon1));
        regularHexagon2.Side = 1;
        Assert.IsFalse(regularHexagon1.Equals(regularHexagon2));

    }

    [TestMethod]
    public void TestRegularHexagonCompareTo()
    {
        RegularHexagon regularHexagon1 = new RegularHexagon();
        regularHexagon1.Side = 3;

        RegularHexagon regularHexagon2 = new RegularHexagon();
        regularHexagon2.Side = 5;

        Assert.AreEqual(-1, regularHexagon1.CompareTo(regularHexagon2));
        Assert.AreEqual(1, regularHexagon2.CompareTo(regularHexagon1));
        Assert.AreEqual(0, regularHexagon1.CompareTo(regularHexagon1));
        regularHexagon2.Side = 3;
        Assert.AreEqual(0, regularHexagon1.CompareTo(regularHexagon2));
        regularHexagon2.Side = 2;
        Assert.AreEqual(1, regularHexagon1.CompareTo(regularHexagon2));
        Assert.AreEqual(-1, regularHexagon2.CompareTo(regularHexagon1));
    }
}

