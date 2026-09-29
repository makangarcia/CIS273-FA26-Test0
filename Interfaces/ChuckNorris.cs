namespace Interfaces;

// TODO
public class ChuckNorris: IThrowable
{
    public string Name{ get; set;}
    public string Emoji{ get; set;}

    public ChuckNorris(string emoji)
    {
        Emoji = emoji;
        Name = "Chuck Norris";
    }

    public override string ToString()
    {
        return Name;
    }
       public Outcome Duel(IThrowable o)
    {
        if (o is ChuckNorris)
            return Outcome.Tie;
        else
            return Outcome.Win;

    }
}
