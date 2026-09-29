namespace LineSegment;

// TODO
public struct LineSegment
{
    public Position StartPoint { get; set;}
    public Position EndPoint { get; set;}

    public LineSegment(Position start, Position end)
    {
        StartPoint = start;
        EndPoint = end;
    }
    public double Slope => (EndPoint.Y - StartPoint.Y) / (EndPoint.X - StartPoint.X);

    public Position Midpoint => new Position()
    {
        X = (StartPoint.X + EndPoint.X) / 2,
        Y = (StartPoint.Y + EndPoint.Y) / 2
    };

    public double Length
    {
        get
        {
            double dx = EndPoint.X - StartPoint.X;
            double dy = EndPoint.Y - StartPoint.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }

    public override string ToString()
    {
        return $"{StartPoint} , {EndPoint}";
    }
}
