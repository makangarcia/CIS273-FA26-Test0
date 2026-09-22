namespace UnitTests;

using Inheritance;

[TestClass]
public class InheritanceTests
{
    [TestMethod]
    public void TestPaper()
    {
        Paper p = new Paper("📜");

        Assert.AreEqual("📜", p.ToString());
        Assert.AreEqual("📜", p.Emoji);
        Assert.AreEqual("Paper", p.Name);
    }

    [TestMethod]
    public void TestRock()
    {
        Rock r = new Rock("🪨");

        Assert.AreEqual("🪨", r.ToString());
        Assert.AreEqual("🪨", r.Emoji);
        Assert.AreEqual("Rock", r.Name);
    }

    [TestMethod]
    public void TestScissors()
    {
        Scissors s = new Scissors("✂️");

        Assert.AreEqual("✂️", s.ToString());
        Assert.AreEqual("✂️", s.Emoji);
        Assert.AreEqual("Scissors", s.Name);
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
        ThrowableObject p = new Paper("📜");
        ThrowableObject r = new Rock("🪨");
        ThrowableObject s = new Scissors("✂️");

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
}

