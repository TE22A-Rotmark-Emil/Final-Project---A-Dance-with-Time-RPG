using System.IO;
using System.Runtime.CompilerServices;

#region Definitions
string area = "unknown";
List<Character> dialoguePartners = new();
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

Character Gabriel = new(){
    name = "Gabriel",
    attack = 35,
    defence = 10,
    dodgeChance = 0,
    maxHP = 1500,
    colour = ConsoleColor.DarkYellow
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

if (area == "unknown"){    
    Character.Talk(Unknown, "Christ.. this headache is killing me.");
    Character.Talk(Unknown, "W... who are you?");
    dialoguePartners = new(){Paige};
    string paigeJoin = Interaction.Dialogue("paigeEncounter", dialoguePartners);
    if (paigeJoin == "Paige joins"){
        Interaction.NewMember(Paige, MCParty);
        Thread.Sleep(10*textSpeed);
    }
    area = "Rancher Refuge";
}

if (area == "Rancher Refuge"){
    if (MCParty.party.Count > 1){
        dialoguePartners = new(){Paige, };
    }
    area = Interaction.Dialogue("", dialoguePartners);
}
