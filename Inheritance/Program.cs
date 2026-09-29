namespace Inheritance;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; //shows the emojis in the terminal. it was showing ?? for each emoji
        TestPRS();
    }
           static void TestPRS()
        {
            Paper p = new Paper("📜");
            Rock r = new Rock("🪨");
            Scissors s = new Scissors("✂️");

            Battle(p, r);
            Battle(p, s);
            Battle(r, s);

            Battle(r, p);
            Battle(s, p);
            Battle(s, r);

            Battle(p, p);
            Battle(r, r);
            Battle(s, s);
        }

        static void Battle(ThrowableObject t1, ThrowableObject t2)
        {
            Outcome outcome = t1.Duel(t2);

            if (outcome == Outcome.Win)
                Console.WriteLine(t1 + " wins versus " + t2);
            else if (outcome == Outcome.Loss)
                Console.WriteLine(t1 + " loses versus " + t2);
            else if (outcome == Outcome.Tie)
                Console.WriteLine(t1 + " ties versus " + t2);
        }
}

