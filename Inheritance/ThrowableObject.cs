namespace Inheritance;

// TODO
public abstract class ThrowableObject
{
    public string Name {get; set;}

    public string Emoji {get; set;}

    public ThrowableObject(string emoji = "")
    {
        Emoji = emoji;
    }

    public abstract Outcome Duel(ThrowableObject o);

    public override string ToString()
    {
        return Emoji;
    }
}