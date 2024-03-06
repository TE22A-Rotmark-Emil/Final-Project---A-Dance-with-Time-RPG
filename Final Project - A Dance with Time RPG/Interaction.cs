using System.IO.Pipes;
using System.Text.Json.Serialization;

public class Interaction(){
    public static string Dialogue(string dialogueType, Character dialoguePartner){
        // Since "Unknown" is defined outside of this parameter, they'll have to be redefined in Interaction since it is likely that an interaction can include Unknown.
        Character Unknown = new(){
            name = "???",
            colour = ConsoleColor.DarkGray
        };
        // Needed for some interactions, such as 'act'.
        Character MC = new(){
            name = "You",
            colour = ConsoleColor.Gray
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
                validResponse = new(){"1", "2", "3", "4"};
                response = Console.ReadLine();
                response = Input.CheckValid(response, validResponse);
                // looks slightly ugly but takes up less space, will be used extensively
                if (response == "1") {response = "who are you?";}
                else if (response == "2") {response = "i don't know";}
                else if (response == "3" || response == "4") {response = "no new party member, paige unknown";}
            }
            if (response == "who are you?"){
                Character.Talk(dialoguePartner, "I'm Paige, I'm an adventurer. Again, though, what is your name?");
                Text.ColourTextline("1. I don't know my name, sorry.", ConsoleColor.DarkCyan);
                Text.ColourTextline("2. That's none of your business.", ConsoleColor.DarkRed);
                validResponse = new(){"1", "2"};
                response = Console.ReadLine();
                response = Input.CheckValid(response, validResponse);
                if (response == "1") {response = "no name, paige known";}
                else if (response == "2"){response = "no new party member, paige known";}
            }
            if (response == "no name, paige known"){
                Character.Act(dialoguePartner, "scratches her scalp");
                Character.Talk(dialoguePartner, "Wh.. what do you mean? Y... you have a name, right?");
                Character.Talk(dialoguePartner, "Surely, your friends call you something, right??");
                Character.Talk(dialoguePartner, "If I were to get into danger, and I'd call you, what would I say???");
                Text.ColourTextline("1. Superguy", ConsoleColor.Yellow);
                Text.ColourTextline("2. Superboy", ConsoleColor.Yellow);
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
                Text.ColourTextline("1. Yea", ConsoleColor.DarkCyan);
                Text.ColourText("2. Nod ", ConsoleColor.DarkCyan);
                Text.ColourTextline("(action)", ConsoleColor.Yellow);
                Text.ColourTextline("3. No", ConsoleColor.DarkGray);
                validResponse = new(){"1", "2", "3"};
                response = Console.ReadLine();
                response = Input.CheckValid(response, validResponse);
                if (response == "1" || response == "2"){
                    response = "figuring myself out";
                }
                else{
                    response = "not figuring myself out";
                }
            }
            if (response == "figuring myself out"){
                Character.Act(dialoguePartner, "straightens her posture and smiles");
                Character.Talk(dialoguePartner, "Well, beats whatever I was doing, that's for sure.");
                Character.Talk(dialoguePartner, "Mind if I join?");
                Text.ColourTextline("1. I'd be happy to have you join", ConsoleColor.DarkCyan);
                Text.ColourTextline("2. No, I wouldn't mind", ConsoleColor.DarkCyan);
                Text.ColourTextline("3. Please do", ConsoleColor.DarkGray);
                Text.ColourTextline("4. Yeah, I would", ConsoleColor.DarkRed);
                validResponse = new(){"1", "2", "3", "4"};
                response = Console.ReadLine();
                response = Input.CheckValid(response, validResponse);
                if (response == "1" || response == "2") {response = "new party member";}
                if (response == "3") {response = "pleading";}
                if (response == "4") {response = "no new party member, paige known";}
            }
            if (response == "new party member"){
                Character.Talk(dialoguePartner, "Sweet. Where are we heading?");
                return("Path of Remembrance");
            }
            else if (response == "no new party member, paige known"){
                Character.Act(dialoguePartner, "tilts her head");
                Character.Talk(dialoguePartner, "Erm, okay? Suit yourself, then.");
                Character.Act(dialoguePartner, "walks out into the distance, carrying some sort of elixir");
                return("Path of Pain");
            }
            else if (response == "no new party member, paige unknown"){
                Character.Act(Unknown, "tilt their head");
                Character.Talk(Unknown, "Right, mind my own business and all that. Take care, I guess.");
                Character.Act(Unknown, "walk out into the distance, carrying some sort of elixir");
                return("Path of Pain");
            }
            else{
                return("Path of Pain");
            }
        }
        else{
            return "void";
        }
    }

    public static Party NewMember(Character partyMember, Party party){
        Text.ColourTextline(partyMember.name + " has joined the party!", ConsoleColor.Cyan);
        party.party.Add(partyMember);
        return party;
    }
}