using System.ComponentModel;

namespace Interfaces;

// TODO

public class Paper : IThrowable
{    
    public string Name {get; set;}
    public string Emoji {get; set;}

    public Paper(string emoji)
    {
        Emoji = emoji;
        Name = "Paper";
    }

    public override string ToString()
    {
        return Name;
    }

    public Outcome Duel(IThrowable o)
    {
        if (o is Rock)
            return Outcome.Win;
        else if (o is Scissors || o is ChuckNorris)
            return Outcome.Loss;
        else
            return Outcome.Tie;
    }
}
