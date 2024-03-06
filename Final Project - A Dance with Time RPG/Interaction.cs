using System.IO.Pipes;

public class Interaction(){
    public static void Dialogue(string DialogueType){
        int responseCount = 0;
        string response = "";
        List<string> validResponse = new();
        if (DialogueType == "paigeEncounter"){
            while (responseCount == 0 && response == ""){
                Text.ColourTextline("How do you respond?", ConsoleColor.Cyan);
                Text.ColourTextline("1. Who are you?", ConsoleColor.DarkCyan);
                Text.ColourTextline("2. I don't know my name, sorry.", ConsoleColor.DarkCyan);
                Text.ColourTextline("3. It'd be better if you avoided asking questions.", ConsoleColor.Red);
                Text.ColourTextline("4. That's none of your business.", ConsoleColor.Red);
                validResponse = new(){
                    "1", "2", "3", "4"
                };
                response = Console.ReadLine().ToLower();
                response = Input.CheckValid(response, validResponse);
            }
        }
    }
}