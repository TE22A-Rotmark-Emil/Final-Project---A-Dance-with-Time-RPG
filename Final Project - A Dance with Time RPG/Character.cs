
public class Character()
{
    public string Name { get; set; }
    public ConsoleColor colour { get; set; }
    public int maxHP { get; set; }
    public int currentHP { get; set; }
    public int attack { get; set; }
    public int defence { get; set; }
    public int dodgeChance { get; set; }
    public int accuracy { get; set; } = 100;
    public bool isDown { get; set; } = false;
    public bool isDead { get; set; } = false;
    public bool isShopkeeper { get; set; } = false;
    public List<(string, int)> items { get; set; }

    /*/     Due to the removal of the "textSpeed" variable, this code is reused in the Text class, since the NoSpeedPreference method requires a variable textSpeed.
    This is acceptable since I'm unlikely to need a variable textSpeed for any future encounter, and it becomes a lot easier to work with if textSpeed only needs to specified once.    /*/
    public static void Talk(Character speaker, string dialogue)
    {
        // int textSpeed = Persistence.ReadPersistence("TxtSpd");
        int textSpeed = 3;
        int insanityVariable = 1;
        if (speaker.Name == "Insanity"){
            insanityVariable = 2;
        }
        else{
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
    }
    public static void Act(Character actor, string action)
    {
        // int textSpeed = Persistence.ReadPersistence("TxtSpd");
        int textSpeed = 3;
        int insanityVariable = 1;
        if (actor.Name == "Insanity"){
            insanityVariable = 2;
        }
        else{
            Console.Write("* ");
        }
        if (actor.Name == "???")
        {
            actor.Name = "They";
            actor.colour = ConsoleColor.Gray;
        }
        else if (actor.Name == "Insanity")
        {
            actor.Name = "";
        }
        Text.ColourText(actor.Name + " ", actor.colour);
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
        Thread.Sleep(insanityVariable * textSpeed * 9);
    }
}