namespace Interfaces;

// TODO

public class Scissors : IThrowable
{    
    public string Name {get; set;}
    public string Emoji {get; set;}

    public Scissors(string emoji)
    {
        Emoji = emoji;
        Name = "Scissors";
    }

    public override string ToString()
    {
        return Name;
    }

    public Outcome Duel(IThrowable o)
    {
        if (o is Paper)
            return Outcome.Win;
        else if (o is Rock || o is ChuckNorris)
            return Outcome.Loss;
        else
            return Outcome.Tie;
    }
}
