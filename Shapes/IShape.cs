using System.Formats.Asn1;
using System.Globalization;

namespace Shapes;

public interface IShape : IComparable<IShape> , IEquatable<IShape>
{
    int NumSides {get; init;}
    double Area {get;}

    double Perimeter {get;}
    
    
}


