namespace Inheritance;

// TODO
public class Scissors : ThrowableObject
{
      public Scissors(string emoji) : base(emoji)
    {
        Name = "Scissors";

    }
    public override Outcome Duel(ThrowableObject other)
    {
        if( other is Paper )
            return Outcome.Win;
        else if(other is Rock)
            return Outcome.Loss;
        else
            return Outcome.Tie;
    }
}
