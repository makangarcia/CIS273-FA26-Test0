using System.Security.Cryptography.X509Certificates;

namespace Shapes;

// TODO
public class Rectangle : IShape
{
    public double Width {get; set;}
    public double Length {get; set;}
    
    public double Area => Width*Length;

    public int NumSides {get; init;} = 4;

    public double Perimeter => 2*Width + 2*Length;

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

        if(other is not Rectangle)
            return false;

        Rectangle otherRectangle = (Rectangle)other;

        if(this.Length==otherRectangle.Length && this.Width==otherRectangle.Width)
            return true;
        else if (this.Length == otherRectangle.Width && this.Width==otherRectangle.Length)
            return true;
        else
            return false;

    }
    
}
