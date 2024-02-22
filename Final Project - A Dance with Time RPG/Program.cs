using System.IO;

int textSpeed = 1;

Shopkeeper Gragerfourth = new(){
    name = "Gragerfourth",
    isConArtist = false,
    colour = ConsoleColor.Red,
    items = new(){
        ("Cinnamon Bun", 5), ("Yorkshire Pudding", 10), ("Apple Pie", 7), ("Crêpe", 5), ("Waffle", 5)
    }
};

if (File.Exists("PersistentChoice.txt")){
    textSpeed = ReadPersistence("TxtSpd");
    Text.ColourText("The player has already made a choice, which was ", ConsoleColor.Green);
    Console.Write(textSpeed);
    Console.WriteLine();
}
else{
    Text.NoSpeedPreference();
    textSpeed = Text.DecideTextSpeed();
}

Gragerfourth.ShopkeeperDialogue("What are you doing here? These brats, they're always trying to take my stuff!", textSpeed);
string test = Console.ReadLine().ToLower();
if (test == "delete"){
    File.Delete("PersistentChoice.txt");
}

static int ReadPersistence(string identifier){
    foreach (string state in File.ReadAllLines("PersistentChoice.txt")){
        string[] states = state.Split(": ");
        int value = Convert.ToInt32(states[1]);
        if (identifier == states[0]){
            return value;
        }
    }
    return 1;
}