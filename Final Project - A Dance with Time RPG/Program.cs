using System.IO;
using System.Runtime.CompilerServices;

using System.Text.Json;

#region GlobalVariables
string area = "unknown";
List<Character> dialoguePartners = new();
int textSpeed;
#endregion

#region Characters
Character MC = new(){
    Name = "MC",
    attack = 3,
    defence = 1,
    dodgeChance = 30,
    maxHP = 20,
    colour = ConsoleColor.Blue
};

Character Unknown = new(){
    Name = "???",
    colour = ConsoleColor.DarkGray
};

Character Paige = new(){
    Name = "Paige",
    attack = 1,
    defence = 2,
    dodgeChance = 0,
    maxHP = 10,
    colour = ConsoleColor.Green
};

Character Gabriel = new(){
    Name = "Gabriel",
    attack = 35,
    defence = 10,
    dodgeChance = 0,
    maxHP = 1500,
    colour = ConsoleColor.DarkYellow
};

Character Gragerfourth = new(){
    Name = "Gragerfourth",
    isShopkeeper = true,
    colour = ConsoleColor.Red,
    items = new(){
        ("Cinnamon Bun", 5), ("Yorkshire Pudding", 10), ("Apple Pie", 7), ("Crêpe", 5), ("Waffle", 5)
    }
};
#endregion

#region Parties
Party MCParty = new(){
    partyName = ""
};
MCParty.party.Add(MC);
MCParty.party.Add(Gabriel);
#endregion

#region PersistenceHandling
string partyData = JsonSerializer.Serialize(MCParty.party);
File.WriteAllText("mainParty.json", partyData);

partyData = File.ReadAllText("mainParty.json");
MCParty.party = JsonSerializer.Deserialize<List<Character>>(partyData);

/*/ For the following "File.Exists()", each check is for a different persistence check. If the player 
has a new party member, for example, it will be accounted for. Each code block is a different check,
explained by its respective textfile name. /*/
if (File.Exists("speedPreference.txt")){
    textSpeed = Persistence.ReadPersistenceInt("TxtSpd");
    if (area == "invalid"){
        area = "unknown";
    }
    Text.ColourText("The player has already made a choice, which was ", ConsoleColor.Green);
    Console.Write(textSpeed);
    Console.WriteLine();
}
else{
    Text.NoSpeedPreference();
    textSpeed = Text.DecideTextSpeed();
}

if (File.Exists("mainParty.json")){
    MCParty.party = JsonSerializer.Deserialize<List<Character>>(partyData);
}

if (File.Exists("currentArea")){
    area = Persistence.ReadPersistenceTxt
}
#endregion

#region Gameplay
if (area == "unknown"){    
    Character.Talk(Unknown, "Christ.. this headache is killing me.");
    Character.Talk(Unknown, "W... who are you?");
    dialoguePartners = new(){Paige};
    string paigeJoin = Interaction.Dialogue("paigeEncounter", dialoguePartners);
    if (paigeJoin == "Paige joins"){
        Interaction.NewMember(Paige, MCParty);
        Thread.Sleep(10*textSpeed);
    }
    partyData = 
    area = "Rancher Refuge";
}

if (area == "Rancher Refuge"){
    if (MCParty.party.Count > 1){
        dialoguePartners = new(){Paige, Gabriel};
    }
    area = Interaction.Dialogue("rancherRefugePrologue", dialoguePartners);
}
#endregion