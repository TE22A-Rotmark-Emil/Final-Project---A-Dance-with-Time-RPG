using System.IO.Pipes;
using System.Text.Json.Serialization;

public class Interaction(){
    public static void Dialogue(string dialogueType, Character dialoguePartner){
        // Since "Unknown" is defined outside of this parameter, they'll have to be redefined in Interaction since it is likely that an interaction can include Unknown.
        Character Unknown = new(){
            name = "???",
            colour = ConsoleColor.DarkGray
        };
        string response = "";
        List<string> validResponse = new();
        if (dialogueType == "paigeEncounter"){
            bool unknownName = true;
            if (response == "" && unknownName == true){
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
            }
            if (response == "1"){
                Character.Talk(dialoguePartner, "I'm Paige, I'm an adventurer. Again, though, what is your name?");
                response = "who are you?";
                unknownName = false;
            }
            if (response == "who are you?" && unknownName == false){
                Text.ColourTextline("1. I don't know my name, sorry.", ConsoleColor.DarkCyan);
                Text.ColourTextline("2. That's none of your business.", ConsoleColor.DarkRed);
                response = Console.ReadLine();
                response = Input.CheckValid(response, validResponse);
            }

        }
    }
}