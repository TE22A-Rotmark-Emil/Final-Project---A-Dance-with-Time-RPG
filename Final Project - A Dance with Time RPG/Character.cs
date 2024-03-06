public class Character(){
    public string name;
    public ConsoleColor colour;
    public int maxHP;
    public int currentHP;
    public int attack;
    public int defence;
    public int dodgeChance;
    public int accuracy = 100;
    public bool isDown = false;
    public bool isDead = false;
    public bool isShopkeeper = false;
    public List<(string, int)> items;

    /*/     Due to the removal of the "textSpeed" variable, this code is reused in the Text class, since the NoSpeedPreference method requires a variable textSpeed.
    This is acceptable since I'm unlikely to need a variable textSpeed for any future encounter, and it becomes a lot easier to work with if textSpeed only needs to specified once.    /*/
    public static void Talk(Character speaker, string dialogue){
        int textSpeed = Persistence.ReadPersistence("TxtSpd");
        Text.ColourText(speaker.name + ": ", speaker.colour);
        foreach (char a in dialogue){
            Console.Write(a);
            if (a is ','){
                Thread.Sleep(textSpeed*3);
            }
            else if (a is '.' or '?' or '!'){
                Thread.Sleep(textSpeed*6);
            }
            else if (a is ' '){
                Thread.Sleep(textSpeed*0);
            }
            else{
                Thread.Sleep(textSpeed);
            }
        }
        Console.WriteLine();
        Thread.Sleep(textSpeed*18);
    }
    public static void Act(Character actor, string action){
        int textSpeed = Persistence.ReadPersistence("TxtSpd");
        Console.Write("* ");
        Text.ColourText(actor.name + " ", actor.colour);
        foreach (char a in action){
            Console.Write(a);
            Thread.Sleep(textSpeed);
        }
        Console.WriteLine();
        Thread.Sleep(textSpeed*9);
    }
}