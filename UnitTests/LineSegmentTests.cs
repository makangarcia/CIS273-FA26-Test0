namespace UnitTests;

using LineSegment;

[TestClass]
public class LineSegmentTests
{
    [TestMethod]
    public void TestPosition()
    {
        Position p = new Position();
        p.X = 3;
        p.Y = 5;

        Assert.AreEqual("(3, 5)", p.ToString());
        Assert.AreEqual(p.X, 3);
        Assert.AreEqual(p.Y, 5);
    }

    [TestMethod]
    public void TestLineSegmentConstructor()
    {
        Position p1 = new Position();
        p1.X = 3;
        p1.Y = 5;

        Position p2 = new Position();
        p2.X = -3;
        p2.Y = 5;

       LineSegment lineSegment = new LineSegment(p1, p2);

        Assert.AreEqual(p1, lineSegment.StartPoint);
        Assert.AreEqual(p2, lineSegment.EndPoint);

        Assert.AreEqual("(3, 5) , (-3, 5)", lineSegment.ToString());

    }

    [TestMethod]
    public void TestSlope()
    {
        Position p1 = new Position();
        p1.X = 3;
        p1.Y = 5;

        Position p2 = new Position();
        p2.X = -3;
        p2.Y = 5;

        LineSegment lineSegment = new LineSegment(p1, p2);
        Assert.AreEqual(0, lineSegment.Slope);

        lineSegment.EndPoint = new Position() { X = 6, Y = 10 };
        Assert.AreEqual(1.6666666666666, lineSegment.Slope, 1e-6);
    }


    [TestMethod]
    public void TestMidpoint()
    {
        Position p1 = new Position();
        p1.X = 3;
        p1.Y = 5;

        Position p2 = new Position();
        p2.X = -3;
        p2.Y = 5;

        Position midpoint = new Position();
        midpoint.X = 0;
        midpoint.Y = 5;

        LineSegment lineSegment = new LineSegment(p1, p2);
        //Assert.AreEqual(midpoint, lineSegment.Midpoint);

        lineSegment.EndPoint = new Position() { X = 6, Y = 10 };
        midpoint.X = 4.5;
        midpoint.Y = 7.5;
        Assert.AreEqual(midpoint, lineSegment.Midpoint);
    }

    [TestMethod]
    public void TestLength()
    {
        Position p1 = new Position();
        p1.X = 3;
        p1.Y = 5;

        Position p2 = new Position();
        p2.X = -3;
        p2.Y = 5;


        LineSegment lineSegment = new LineSegment(p1, p2);
        Assert.AreEqual(6, lineSegment.Length);

        lineSegment.EndPoint = new Position() { X = 6, Y = 10 };
        Assert.AreEqual(5.830951894845301, lineSegment.Length, 1e-6);
    }

}
