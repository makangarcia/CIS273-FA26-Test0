namespace Inheritance;

// TODO

public class Rock : ThrowableObject
{
      public Rock(string emoji) : base(emoji)
    {
        Name = "Rock";

    }
    public override Outcome Duel(ThrowableObject other)
    {
        if( other is Scissors )
            return Outcome.Win;
        else if(other is Paper)
            return Outcome.Loss;
        else
            return Outcome.Tie;
    }
}
