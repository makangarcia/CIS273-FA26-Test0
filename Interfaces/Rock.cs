namespace Interfaces;

// TODO

public class Rock : IThrowable
{    
    public string Name {get; set;}
    public string Emoji {get; set;}

    public Rock(string emoji)
    {
        Emoji = emoji;
        Name = "Rock";
    }

    public override string ToString()
    {
        return Name;
    }

    public Outcome Duel(IThrowable o)
    {
        if (o is Scissors)
            return Outcome.Win;
        else if (o is Paper || o is ChuckNorris)
            return Outcome.Loss;
        else
            return Outcome.Tie;
    }
}

