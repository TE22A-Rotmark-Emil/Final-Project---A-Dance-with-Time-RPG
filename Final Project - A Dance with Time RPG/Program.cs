using System.IO;
using System.Runtime.CompilerServices;

using System.Text.Json;

#region GlobalVariables
string area = "unknown";
bool gameplayLoop = true;
List<Character> dialoguePartners = new();
int textSpeed;
string partyData = "";
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
    attack = 4,
    defence = 2,
    dodgeChance = 0,
    maxHP = 15,
    colour = ConsoleColor.Green
};

Character Gabriel = new(){
    Name = "Gabriel",
    level = 77,
    attack = 35,
    defence = 10,
    dodgeChance = 0,
    maxHP = 1500,
    colour = ConsoleColor.DarkYellow
};

Character Gragerfourth = new(){
    maxHP = 20,
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
#endregion

#region PersistenceHandling
/* For the following "File.Exists()", each check is for a different persistence check. If the player 
has a new party member, for example, it will be accounted for. Each code block is a different check,
explained by its respective textfile name. */
if (File.Exists("speedPreference.txt") || File.Exists("mainParty.json") || File.Exists("currentArea.txt")){
    Text.ColourTextline("A save file was discovered. Would you like to continue on this file? If you answer 'no', your file will be deleted.", ConsoleColor.Yellow);
    List<string >validResponse = new(){"yes", "no"};
    string persistenceConsent = Console.ReadLine();
    persistenceConsent = Input.CheckValid(persistenceConsent, validResponse);
    if (persistenceConsent == "no"){
        File.Delete("speedPreference.txt");
        File.Delete("mainParty.json");
        File.Delete("currentArea.txt");
    }
    else{
        if (File.Exists("mainParty.json")){
            partyData = File.ReadAllText("mainParty.json");
        }
    }
}

if (File.Exists("speedPreference.txt")){
    textSpeed = Persistence.ReadPersistenceInt("TxtSpd", "speedPreference.txt");
    if (area == "invalid"){
        area = "unknown";
    }
    // Text.ColourText("The player has already made a choice, which was ", ConsoleColor.Green);
    // Console.Write(textSpeed);
    // Console.WriteLine();
}
else{
    Text.NoSpeedPreference();
    textSpeed = Text.DecideTextSpeed();
}

if (File.Exists("mainParty.json")){
    MCParty.party = JsonSerializer.Deserialize<List<Character>>(partyData);
}

if (File.Exists("currentArea.txt")){
    area = Persistence.ReadPersistenceTxt("curArea", "currentArea.txt");
}
// Console.WriteLine("Successfully read all persistence");
for (int i = 0; i < MCParty.party.Count; i++){
    Console.WriteLine(MCParty.party[i].Name);
}
// Console.WriteLine("Player area is " + area);
// Console.ReadLine();
#endregion

Party gragParty = new(){
    partyName = ""
};
gragParty.party.Add(Gragerfourth);
gragParty.party.Add(Paige);

Battle.Fight(MCParty.party, gragParty.party);

Shop.purchaseItem(MCParty.party, Gragerfourth, "PaigeInitialised");

#region Gameplay
while (gameplayLoop == true){

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
    area = "rancherRefugeSelection";
    
    SaveGame();
}

if (area == "rancherRefugeSelection"){
    if (MCParty.party.Count > 1){
        dialoguePartners = new(){Paige};
    }
    Interaction.Dialogue("rancherRefugeInsanityEncounter", dialoguePartners);
    if (MCParty.party.Count > 1){
        dialoguePartners = new(){Gragerfourth, Paige};
    }
    else{
        dialoguePartners = new(){Gragerfourth};
    }
    Interaction.Dialogue("rancherRefuge", dialoguePartners);
    if(MCParty.party.Count > 1){
        Shop.purchaseItem(MCParty.party, Gragerfourth, "PaigeInitialised");
    }
    else{

    }
}
#endregion

void SaveGame(){
    partyData = JsonSerializer.Serialize(MCParty.party);
    File.WriteAllText("mainParty.json", partyData);
    partyData = File.ReadAllText("mainParty.json");
    MCParty.party = JsonSerializer.Deserialize<List<Character>>(partyData);

    File.WriteAllText("currentArea.txt", "curArea: " + area);

    Text.ColourTextline("Game saved successfully", ConsoleColor.Yellow);
}