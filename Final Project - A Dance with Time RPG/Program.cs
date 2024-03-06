using System.IO;
using System.Runtime.CompilerServices;

#region Definitions
string area = "void";
int textSpeed;

Character MC = new(){
    name = "MC",
    attack = 3,
    defence = 1,
    dodgeChance = 30,
    maxHP = 20,
    colour = ConsoleColor.Blue
};

Character Unknown = new(){
    name = "???",
    colour = ConsoleColor.DarkGray
};

Character Paige = new(){
    name = "Paige",
    attack = 1,
    defence = 2,
    dodgeChance = 0,
    maxHP = 10,
    colour = ConsoleColor.Green
};

Party MCParty = new(){
    partyName = ""
};
MCParty.party.Add(MC);

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

#region InitialEncounter
Character.Talk(Unknown, "Christ.. this headache is killing me.");
Character.Talk(Unknown, "W... who are you?");
Interaction.Dialogue("paigeEncounter", Paige);
#endregion