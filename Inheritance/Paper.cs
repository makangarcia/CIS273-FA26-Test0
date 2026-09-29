namespace Inheritance;

// TODO
public class Paper : ThrowableObject
{
    public Paper(string emoji) : base(emoji)
    {
        Name = "Paper";

    }
    public override Outcome Duel(ThrowableObject other)
    {
        if( other is Rock )
            return Outcome.Win;
        else if(other is Scissors)
            return Outcome.Loss;
        else
            return Outcome.Tie;
    }
}

