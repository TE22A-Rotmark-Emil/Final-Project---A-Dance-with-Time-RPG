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

    public static void talk(Character speaker, string Dialogue){
        int textSpeed = Persistence.ReadPersistence("TxtSpd");
        if (speaker.name != "dummy" && speaker.name != "MC"){
            Text.ColourText(speaker.name + ": ", speaker.colour);
        }
        foreach (char a in Dialogue){
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
}