
public class Character
{
    private int _maxHP;

    public string Name { get; set; }
    public ConsoleColor colour { get; set; }
    public int level { get; set; } = 1;
    public int exp { get; set; } = 0;
    public int maxHP
    {
        get => _maxHP;
        set
        {
            _maxHP = value;
            currentHP = value;
        }
    }
    public int currentHP { get; set; }
    public int attack { get; set; }
    public int defence { get; set; }
    public int dodgeChance { get; set; }
    public int accuracy { get; set; } = 100;
    // public bool isDown { get; set; } = false;
    // public bool isDead { get; set; } = false;
    public bool isShopkeeper { get; set; } = false;
    public List<(string name, int price, string identifier)> items { get; set; } = new();
    public (string name, int stat, string identifier) equippedItem { get; set; } = ("Fist", 0, "Weapon");

    /*/     Due to the removal of the "textSpeed" variable, this code is reused in the Text class, since the NoSpeedPreference method requires a variable textSpeed.
    This is acceptable since I'm unlikely to need a variable textSpeed for any future encounter, and it becomes a lot easier to work with if textSpeed only needs to specified once.    /*/
    public static void Talk(Character speaker, string dialogue)
    {
        int textSpeed = Persistence.ReadPersistenceInt("TxtSpd", "speedPreference.txt");
        int insanityVariable = 1;
        if (speaker.Name == "Insanity")
        {
            insanityVariable = 2;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
        }
        else
        {
            Text.ColourText(speaker.Name + ": ", speaker.colour);
        }
        foreach (char a in dialogue)
        {
            Console.Write(a);
            if (a is ',')
            {
                Thread.Sleep(insanityVariable * textSpeed * 3);
            }
            else if (a is '.' or '?' or '!')
            {
                Thread.Sleep(insanityVariable * textSpeed * 6);
            }
            else if (a is ' ')
            {
                Thread.Sleep(textSpeed * 0);
            }
            else
            {
                Thread.Sleep(insanityVariable * textSpeed);
            }
        }
        Console.WriteLine();
        Thread.Sleep(insanityVariable * textSpeed * 18);
        Console.ResetColor();
    }
    public static void Act(Character actor, string action)
    {
        int textSpeed = Persistence.ReadPersistenceInt("TxtSpd", "speedPreference.txt");
        int insanityVariable = 1;
        if (actor.Name == "???")
        {
            actor.Name = "They";
            actor.colour = ConsoleColor.Gray;
        }
        if (actor.Name == "Insanity")
        {
            insanityVariable = 2;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
        }
        else
        {
            Console.Write("* ");
            Text.ColourText(actor.Name + " ", actor.colour);
        }
        foreach (char a in action)
        {
            Console.Write(a);
            Thread.Sleep(insanityVariable * textSpeed);
        }
        Console.WriteLine();
        if (actor.Name == "They")
        {
            actor.Name = "???";
            actor.colour = ConsoleColor.DarkGray;
        }
        else if (actor.Name == "")
        {
            actor.Name = "Insanity";
        }
        Thread.Sleep(insanityVariable * textSpeed * 9);
        Console.ResetColor();
    }
}