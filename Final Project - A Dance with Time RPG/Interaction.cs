using System.IO.Pipes;
using System.Text.Json.Serialization;

public class Interaction(){
    public static string Dialogue(string dialogueType, List<Character> dialoguePartners){
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
                Text.ColourTextline("2. I don't know my name, sorry", ConsoleColor.DarkCyan);
                Text.ColourTextline("3. It'd be better if you avoided asking questions", ConsoleColor.DarkRed);
                Text.ColourTextline("4. That's none of your business", ConsoleColor.DarkRed);
                validResponse = new(){"1", "2", "3", "4"};
                response = Console.ReadLine();
                response = Input.CheckValid(response, validResponse);
                // looks slightly ugly but takes up less space, will be used extensively
                if (response == "1") {response = "who are you?";}
                else if (response == "2") {response = "no name, paige unknown";}
                else if (response == "3" || response == "4") {response = "no new party member, paige unknown";}
            }
            if (response == "who are you?"){
                Character.Talk(dialoguePartners[0], "I'm Paige, I'm an adventurer. Again, though, what is your name?");
                Text.ColourTextline("1. I don't know my name, sorry", ConsoleColor.DarkCyan);
                Text.ColourTextline("2. That's none of your business", ConsoleColor.DarkRed);
                validResponse = new(){"1", "2"};
                response = Console.ReadLine();
                response = Input.CheckValid(response, validResponse);
                if (response == "1") {response = "no name, paige known";}
                else if (response == "2"){response = "no new party member, paige known";}
            }
            else if (response == "no name, paige unknown"){
                Character.Talk(Unknown, "Er? You sure?");
                Character.Act(Unknown, "tilt their head, then place their scalp into the palm of their hand");
                Character.Talk(Unknown, "How about this, I tell you my name, and you tell me yours, m'kay?");
                Character.Talk(dialoguePartners[0], "I'm Paige, I'm an adventurer. So, with that out of the way, what is your name?");
                Text.ColourTextline("1. I really don't know my name", ConsoleColor.DarkCyan);
                Text.ColourTextline("2. That's none of your business", ConsoleColor.DarkRed);
                validResponse = new(){"1", "2"};
                response = Console.ReadLine();
                response = Input.CheckValid(response, validResponse);
                if (response == "1"){response = "no name, paige known";}
                else if (response == "2"){response = "no new party member, paige known";}
            }
            if (response == "no name, paige known"){
                Character.Act(dialoguePartners[0], "scratches her scalp");
                Character.Talk(dialoguePartners[0], "Wh.. what do you mean? Y... you have a name, right?");
                Character.Talk(dialoguePartners[0], "Surely, your friends call you something, right??");
                Character.Talk(dialoguePartners[0], "If I were to get into danger, and I'd call you, what would I say???");
                Text.ColourTextline("1. Superguy", ConsoleColor.Yellow);
                Text.ColourTextline("2. Superboy", ConsoleColor.Yellow);
                Text.ColourTextline("3. Supergirl", ConsoleColor.Yellow);
                Text.ColourTextline("4. Glageroth, the Emanator of the Corruption, the 4th Descendant", ConsoleColor.Yellow);
                Text.ColourTextline("5. Charlie", ConsoleColor.Yellow);
                response = Console.ReadLine();
                response = "blanked out";
            }
            if (response == "blanked out"){
                Character.Act(MC, "couldn't think of anything. You simply stood there and shrugged");
                Character.Act(dialoguePartners[0], "simply sighs at your response");
                Character.Talk(dialoguePartners[0], "Well, that's a first.");
                Character.Talk(dialoguePartners[0], "Why are you out here, then? Trying to figure out who you are?");
                Text.ColourTextline("1. Yea", ConsoleColor.DarkCyan);
                Text.ColourText("2. Nod ", ConsoleColor.DarkCyan);
                Text.ColourTextline("(action)", ConsoleColor.Yellow);
                Text.ColourTextline("3. No", ConsoleColor.DarkGray);
                validResponse = new(){"1", "2", "3"};
                response = Console.ReadLine();
                response = Input.CheckValid(response, validResponse);
                if (response == "1" || response == "2"){response = "figuring myself out";}
                else{response = "not figuring myself out";}
            }
            if (response == "not figuring myself out"){
                Character.Act(dialoguePartners[0], "raises her eyebrow and looks intently at you");
                Character.Talk(dialoguePartners[0], "What? Why are you here then?");
                bool hasPickedJokeAnswer = false;
                while (response == "not figuring myself out"){
                    Text.ColourTextline("1. I was just joking, I plan on figuring out who I am", ConsoleColor.DarkCyan);
                    if (hasPickedJokeAnswer == false){
                        Text.ColourTextline("2. I'm seeking the Sorceror's Stone, and I intend on finding it. Intel seems to suggest that it is located between 38.897957N, 77.036560W and 51.503368N, 0.127721W", ConsoleColor.Yellow);
                    }
                    if (hasPickedJokeAnswer == false){
                        Text.ColourTextline("3. That's none of your business", ConsoleColor.DarkRed);
                    }
                    else{
                        Text.ColourTextline("2. That's none of your business", ConsoleColor.DarkRed);
                    }
                    if (hasPickedJokeAnswer == false){
                        validResponse = new(){"1", "2", "3"};
                    }
                    else{
                        validResponse = new(){"1", "2"};
                    }
                    response = Console.ReadLine();
                    response = Input.CheckValid(response, validResponse);
                    if (response == "2"){
                        if (hasPickedJokeAnswer == false){    
                            hasPickedJokeAnswer = true;
                            response = "not figuring myself out";
                        }
                        else{
                            response = "no new party member, paige known";
                        }
                    }
                }
                if (response == "1"){
                    Character.Talk(dialoguePartners[0], "What a... 'fine' sense of humour?");
                    response = "figuring myself out";
                }
                else if (response == "3"){
                    response = "no new party member, paige known";
                }
            }
            if (response == "figuring myself out"){
                Character.Act(dialoguePartners[0], "straightens her posture and smiles");
                Character.Talk(dialoguePartners[0], "Well, beats whatever I was doing, that's for sure.");
                Character.Talk(dialoguePartners[0], "Mind if I join?");
                Text.ColourTextline("1. I'd be happy to have you join", ConsoleColor.DarkCyan);
                Text.ColourTextline("2. No, I wouldn't mind", ConsoleColor.DarkCyan);
                Text.ColourTextline("3. Please do", ConsoleColor.DarkCyan);
                Text.ColourTextline("4. Yeah, I would", ConsoleColor.DarkRed);
                validResponse = new(){"1", "2", "3", "4"};
                response = Console.ReadLine();
                response = Input.CheckValid(response, validResponse);
                if (response == "1" || response == "2" || response == "3") {response = "new party member";}
                if (response == "4") {response = "no new party member, paige known";}
            }
            if (response == "new party member"){
                Character.Talk(dialoguePartners[0], "Sweet. Where are we heading?");
                return "Paige joins";
            }
            else if (response == "no new party member, paige known"){
                Character.Act(dialoguePartners[0], "tilts her head");
                Character.Talk(dialoguePartners[0], "Erm, okay? Suit yourself, then.");
                Character.Act(dialoguePartners[0], "walks out into the distance, carrying some sort of elixir");
                return "Paige doesn't join";
            }
            else if (response == "no new party member, paige unknown"){
                Character.Act(Unknown, "tilt their head");
                Character.Talk(Unknown, "Right, mind my own business and all that. Take care, I guess.");
                Character.Act(Unknown, "walk out into the distance, carrying some sort of elixir");
                return "Paige doesn't join";
            }
            else{
                return "Paige doesn't join";
            }
        }
        else{
            return "Paige doesn't join";
        }
    }

    public static Party NewMember(Character partyMember, Party party){
        Text.ColourTextline(partyMember.name + " has joined the party!", ConsoleColor.Cyan);
        party.party.Add(partyMember);
        return party;
    }
}