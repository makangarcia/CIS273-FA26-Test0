namespace Shapes;

// TODO
public class RegularHexagon : IShape, IEquatable<RegularHexagon>
{
	public double Side{get; set;}
    
    public double Area => 3 * Math.Sqrt(3) /2 * Side * Side ;

    public int NumSides {get; init;} = 6;

    public double Perimeter => Side * NumSides;


        public int CompareTo(IShape other)
    {
        if (other == null)
        {
            throw new NullReferenceException();
        }

        return this.Area.CompareTo(other.Area);
        //  if(this.Area < other.Area)
        //      return -1;
        //  else if(this.Area==other.Area)
        //      return 0;
        //  else
        //      return 1;
    }

        public bool Equals(IShape? other)
    {
        if(other==null)
            return false;

        if(other is not RegularHexagon)
            return false;

        RegularHexagon otherHexagon = (RegularHexagon)other;

        if(this.Side==otherHexagon.Side)
            return true;
        else
            return false;

    }
    
        public bool Equals(RegularHexagon? other)
    {
        if (other == null)
            return false;
        else
            return this.Side == other.Side;
    }
}

