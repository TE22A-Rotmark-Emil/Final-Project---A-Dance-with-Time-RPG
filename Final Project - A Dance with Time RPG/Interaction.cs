using System.IO.Pipes;
using System.Text.Json.Serialization;

public class Interaction(){
    public static void Dialogue(string dialogueType, Character dialoguePartner){
        // Since "Unknown" is defined outside of this parameter, they'll have to be redefined in Interaction since it is likely that an interaction can include Unknown.
        Character Unknown = new(){
            name = "???",
            colour = ConsoleColor.DarkGray
        };
        // Needed for some interactions, such as 'act'.
        Character MC = new(){
            name = "You",
            colour = ConsoleColor.White
        };
        string response = "";
        List<string> validResponse = new();
        if (dialogueType == "paigeEncounter"){
            if (response == ""){
                Text.ColourTextline("How do you respond?", ConsoleColor.Cyan);
                Text.ColourTextline("1. Who are you?", ConsoleColor.DarkCyan);
                Text.ColourTextline("2. I don't know my name, sorry.", ConsoleColor.Red);
                Text.ColourTextline("3. It'd be better if you avoided asking questions.", ConsoleColor.DarkRed);
                Text.ColourTextline("4. That's none of your business.", ConsoleColor.DarkRed);
                validResponse = new(){
                    "1", "2", "3", "4"
                };
                response = Console.ReadLine();
                response = Input.CheckValid(response, validResponse);
                // looks slightly ugly but takes up less space, will be used extensively
                if (response == "1") {response = "who are you?";}
                else if (response == "2") {response = "i don't know";}
                else if (response == "3") {response = "avoid asking questions";}
                else if (response == "4") {response = "no business";}
            }
            if (response == "who are you?"){
                Character.Talk(dialoguePartner, "I'm Paige, I'm an adventurer. Again, though, what is your name?");
                Text.ColourTextline("1. I don't know my name, sorry.", ConsoleColor.DarkCyan);
                Text.ColourTextline("2. That's none of your business.", ConsoleColor.DarkRed);
                validResponse = new(){
                    "1", "2"
                };
                response = Console.ReadLine();
                response = Input.CheckValid(response, validResponse);
                if (response == "1") {response = "no name, paige known";}
            }
            if (response == "no name, paige known"){
                Character.Act(dialoguePartner, "scratches her scalp");
                Character.Talk(dialoguePartner, "Wh.. what do you mean? Y... you have a name, right?");
                Character.Talk(dialoguePartner, "Surely, your friends call you something, right??");
                Character.Talk(dialoguePartner, "If I were to get into danger, and I'd call you, what would I say???");
                Text.ColourTextline("1. Superman", ConsoleColor.Yellow);
                Text.ColourTextline("2. Superguy", ConsoleColor.Yellow);
                Text.ColourTextline("3. Supergirl", ConsoleColor.Yellow);
                Text.ColourTextline("4. Glageroth, the Emanator of the Corruption, the 4th Descendant.", ConsoleColor.Yellow);
                Text.ColourTextline("5. Charlie", ConsoleColor.Yellow);
                response = Console.ReadLine();
                response = "blanked out";
            }
            if (response == "blanked out"){
                Character.Act(MC, "couldn't think of anything. You simply stood there and shrugged.");
                Character.Act(dialoguePartner, "simply sighs at your response.");
                Character.Talk(dialoguePartner, "Well, that's a first.");
                Character.Talk(dialoguePartner, "Why are you out here, then? Trying to figure out who you are?");

            }

        }
    }
}