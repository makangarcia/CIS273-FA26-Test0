namespace Interfaces;

// TODO
public interface IThrowable
{
    public string Name{ get; set;}
    public string Emoji {get; set;}

    Outcome Duel(IThrowable o);
}