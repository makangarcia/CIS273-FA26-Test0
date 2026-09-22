namespace UnitTests;

using Interfaces;

[TestClass]
public class InterfacesTests
{
    [TestMethod]
    public void TestPaper()
    {
        Paper p = new Paper("📜");

        Assert.AreEqual("Paper", p.ToString());
        Assert.AreEqual("📜", p.Emoji);
        Assert.AreEqual("Paper", p.Name);
    }

    [TestMethod]
    public void TestRock()
    {
        Rock r = new Rock("🪨");

        Assert.AreEqual("Rock", r.ToString());
        Assert.AreEqual("🪨", r.Emoji);
        Assert.AreEqual("Rock", r.Name);
    }

    [TestMethod]
    public void TestScissors()
    {
        Scissors s = new Scissors("✂️");

        Assert.AreEqual("Scissors", s.ToString());
        Assert.AreEqual("✂️", s.Emoji);
        Assert.AreEqual("Scissors", s.Name);
    }

    [TestMethod]
    public void TestChuckNorris()
    {
        ChuckNorris c = new ChuckNorris("👨‍");

        Assert.AreEqual("Chuck Norris", c.ToString());
        Assert.AreEqual("👨‍", c.Emoji);
        Assert.AreEqual("Chuck Norris", c.Name);
    }

    [TestMethod]
    public void TestPaperScissors()
    {
        Paper p = new Paper("📜");
        Scissors s = new Scissors("✂️");

        Assert.AreEqual(Outcome.Loss, p.Duel(s));
        Assert.AreEqual(Outcome.Win, s.Duel(p));
    }

    [TestMethod]
    public void TestPaperRock()
    {
        Paper p = new Paper("📜");
        Rock r = new Rock("🪨");

        Assert.AreEqual(Outcome.Win, p.Duel(r));
        Assert.AreEqual(Outcome.Loss, r.Duel(p));
    }

    [TestMethod]
    public void TestRockScissors()
    {
        Rock r = new Rock("🪨");
        Scissors s = new Scissors("✂️");

        Assert.AreEqual(Outcome.Win, r.Duel(s));
        Assert.AreEqual(Outcome.Loss, s.Duel(r));
    }

    [TestMethod]
    public void TestTies()
    {
        Paper p = new Paper("📜");
        Rock r = new Rock("🪨");
        Scissors s = new Scissors("✂️");

        Assert.AreEqual(Outcome.Tie, p.Duel(p));
        Assert.AreEqual(Outcome.Tie, r.Duel(r));
        Assert.AreEqual(Outcome.Tie, s.Duel(s));
    }

    [TestMethod]
    public void TestPolymorphism()
    {
        IThrowable p = new Paper("📜");
        IThrowable r = new Rock("🪨");
        IThrowable s = new Scissors("✂️");

        Assert.AreEqual(Outcome.Loss, p.Duel(s));
        Assert.AreEqual(Outcome.Win, s.Duel(p));

        Assert.AreEqual(Outcome.Win, p.Duel(r));
        Assert.AreEqual(Outcome.Loss, r.Duel(p));

        Assert.AreEqual(Outcome.Win, r.Duel(s));
        Assert.AreEqual(Outcome.Loss, s.Duel(r));

        Assert.AreEqual(Outcome.Tie, p.Duel(p));
        Assert.AreEqual(Outcome.Tie, r.Duel(r));
        Assert.AreEqual(Outcome.Tie, s.Duel(s));
    }


    [TestMethod]
    public void TestChuckNorrisVsEverything()
    {
        IThrowable p = new Paper("📜");
        IThrowable r = new Rock("🪨");
        IThrowable s = new Scissors("✂️");
        ChuckNorris c = new ChuckNorris("👨‍");


        Assert.AreEqual(Outcome.Win, c.Duel(p));
        Assert.AreEqual(Outcome.Loss, p.Duel(c));

        Assert.AreEqual(Outcome.Win, c.Duel(r));
        Assert.AreEqual(Outcome.Loss, r.Duel(c));

        Assert.AreEqual(Outcome.Win, c.Duel(s));
        Assert.AreEqual(Outcome.Loss, s.Duel(c));

        Assert.AreEqual(Outcome.Tie, c.Duel(c));
    }
}


