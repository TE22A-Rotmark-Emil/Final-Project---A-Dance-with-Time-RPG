using System.IO;

#region Definitions
int textSpeed;

Character MC = new(){
    name = "MC",
    attack = 3,
    defence = 1,
    dodgeChance = 30,
    maxHP = 20,
    colour = ConsoleColor.Blue
};

Character Millylith = new(){
    name = "Millylith",
    attack = 1,
    defence = 2,
    dodgeChance = 0,
    maxHP = 10,
    colour = ConsoleColor.Green
};

Party MCParty = new(){
    partyName = ""
};

Character Gragerfourth = new(){
    name = "Gragerfourth",
    isShopkeeper = true,
    colour = ConsoleColor.Red,
    items = new(){
        ("Cinnamon Bun", 5), ("Yorkshire Pudding", 10), ("Apple Pie", 7), ("Crêpe", 5), ("Waffle", 5)
    }
};
#endregion

if (File.Exists("PersistentChoice.txt")){
    textSpeed = Persistence.ReadPersistence("TxtSpd");
    Text.ColourText("The player has already made a choice, which was ", ConsoleColor.Green);
    Console.Write(textSpeed);
    Console.WriteLine();
}
else{
    Text.NoSpeedPreference();
    textSpeed = Text.DecideTextSpeed();
}

Character.talk(Millylith, "Christ.. this headache, it's killing me.");

string test = Console.ReadLine().ToLower();
if (test == "delete"){
    File.Delete("PersistentChoice.txt");
}