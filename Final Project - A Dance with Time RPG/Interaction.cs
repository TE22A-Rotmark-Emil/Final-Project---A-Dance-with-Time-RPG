using System.IO.Pipes;

public class Interaction(){
    public static void Dialogue(string DialogueType){
        int responseCount = 0;
        string response = "";
        List<string> validResponse = new();
        if (DialogueType == "paigeEncounter"){
            while (responseCount == 0 && response == ""){
                Text.ColourText("How do you respond?", ConsoleColor.Cyan);
                Text.ColourText("1. Who are you?", ConsoleColor.DarkCyan);
                Text.ColourText("2. I don't know my name, sorry.", ConsoleColor.DarkCyan);
                Text.ColourText("3. It'd be better if you avoided asking questions.", ConsoleColor.Red);
                Text.ColourText("4. That's none of your business.", ConsoleColor.Red);
                validResponse = new(){
                    "1", "2", "3", "4"
                };
                response = Input.CheckValid(response, validResponse);
            }
        }
    }
}