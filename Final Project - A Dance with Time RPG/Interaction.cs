using System.IO.Pipes;
using System.Text.Json.Serialization;

/* Interactions is a class which is meant to simplify the visual structure of the "Program.cs" so that it is not cluttered with the interactions in story. */

public class Interaction(){
    /* Dialogue returns the location data, as the end of each encounter intuitively moves you onto the next - and the structure of Program.cs necessitates */
    public static string Dialogue(string dialogueType, List<Character> dialoguePartners){
        Character Unknown = new(){
            Name = "???",
            colour = ConsoleColor.DarkGray
        };
        Character Insanity = new(){
            Name = "Insanity",
        };
        // Needed for some interactions, such as 'act'.
        Character MC = new(){
            Name = "You",
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

        if (dialogueType == "rancherRefugeInsanityEncounter"){
            Character.Act(MC, "see a stranger in the distance, staring at you. Their gaze is unchanging, static. Their hooded figure solem leaves anything to the imagination, they seem decrepit, but not weak");
            Character.Act(MC, "notice them blink. How long have you been looking at them? They begin to approach you");
            if (dialoguePartners.Count > 1){
                Character.Talk(dialoguePartners[0], "(...) ey! What are you doing? What are you looking at?");
                Character.Act(MC, "turn around to face " + dialoguePartners[0].Name + ". She seems alive and well. Blinking, breathing. What are you looking at? What are you looking at? You turn around again, and the hooded figure is right in front of you");
                Character.Act(MC, "stare into their unchanging gaze. An eternal void that never falters.");
                Character.Talk(Insanity, "What are you looking at?");
                Character.Act(Insanity, "W h a t  a r e  y o u  l o o k i n g  a t ?");
                Console.ReadLine();
            }
            else{
                Character.Talk(Unknown, "What's wrong, sheep? Are you lost?");
                Character.Act(MC, "stare into their blank face. Sheep? You're not a sheep. Who does this guy think they are?");
                Character.Act(MC, "take a step forward, and are immediately impaled by a spear. Blood? Blood. You're bleeding. This guy thinks they're an angel.");
                Character.Talk(Insanity, "An angel, in a place like this? Who does this guy think they are? An angel. An angel. Sheep. Sheep. You aren't sheep.");
                Character.Act(Insanity, "Sheep. Sheep. Sheep. Sheep. S h e e p .");
            }
            return "rancherRefuge";
        }

        if (dialogueType == "rancherRefuge"){
            if (dialoguePartners.Count > 1){
                Character.Talk(Unknown, "Ey, 'lil bud?");
                Character.Talk(dialoguePartners[1], "What happened? You just blanked out!");
                Text.ColourTextline("1. I don't know.", ConsoleColor.Gray);
                Text.ColourTextline("2. They weren't blinking.", ConsoleColor.Gray);
                Text.ColourTextline("3. I couldn't see anything.", ConsoleColor.Gray);
                Text.ColourTextline("4. Where am I?", ConsoleColor.Gray);
                validResponse = new(){"1", "2", "3", "4"};
                response = Console.ReadLine();
                response = Input.CheckValid(response, validResponse);
                Character.Talk(Unknown, "Poor thing, totally out of their mind.");
                Character.Talk(dialoguePartners[0], "I'm Gragerfourth, I'm a merchant, eh? Heard you're from the Mainland - Sergtum?");
                Character.Act(MC, "don't know what he's talking about.");
                Character.Talk(dialoguePartners[1], "Say, Gragerfourth, was it? You said you're a merchant. What do you sell?");
                Character.Talk(dialoguePartners[0], "Eh? Want to see my wares? Sure thing, sure thing! Take a look!");
            }
            return "unknown";
        }

        else{
            return "unknown";
        }
    }

    public static Party NewMember(Character partyMember, Party party){
        Text.ColourTextline(partyMember.Name + " has joined the party!", ConsoleColor.Cyan);
        party.party.Add(partyMember);
        return party;
    }
}