namespace Shapes;

// TODO
public class Triangle : IShape, IEquatable<Triangle>
{
    public int NumSides {get; init;} = 3;
    public double Perimeter => Sides[0] + Sides[1] + Sides[2];

    public double Area
    {
        get
        {
            double s = Perimeter / 2;
            return Math.Sqrt(s * (s - Sides[0]) * (s - Sides[1]) * (s - Sides[2]));
        }
    }

    public double[] Sides{get; set;} = new double [3];

    public int CompareTo(IShape? other)
    {
        if (other == null)
        {
            throw new NullReferenceException();
        }
        return this.Area.CompareTo(other.Area);
    }

    public bool Equals(IShape? other)
    {
        if(other==null)
            return false;

        if(other is not Triangle)
            return false;

        Triangle otherTriangle = (Triangle)other;
    
        double[] first = (double[])this.Sides.Clone();
        double[] second = (double[])otherTriangle.Sides.Clone();

        Array.Sort(first);
        Array.Sort(second);

        return first[0] == second[0] && first[1] == second[1] && first[2] == second[2];
    }
    public bool Equals(Triangle? other)
    {
        if(other==null)
            return false;
    
        double[] first = (double[])this.Sides.Clone();
        double[] second = (double[])other.Sides.Clone();

        Array.Sort(first);
        Array.Sort(second);

        return first[0] == second[0] && first[1] == second[1] && first[2] == second[2];
    }
}

