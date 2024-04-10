using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Runtime;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

public class Battle(){
    public static bool Fight(List<Character> MCTeam, List<Character> Opposition, string SpecialCase){
        if (SpecialCase == "No"){
            bool isAlive = true;
            while (isAlive == true){
                foreach (Character teamMember in MCTeam){
                    if (teamMember.currentHP > 0){             
                        Defend(teamMember, false);
                        Text.ColourText("What will ", ConsoleColor.Gray);
                        Text.ColourText(teamMember.Name, teamMember.colour);
                        Text.ColourTextline(" do?", ConsoleColor.Gray);
                        Text.ColourTextline("1. Fight", ConsoleColor.Red);
                        Text.ColourTextline("2. Defend", ConsoleColor.Green);
                        Text.ColourTextline("3. Item", ConsoleColor.Yellow);
                        Text.ColourTextline("4. Flee", ConsoleColor.Blue);
                        List<string> validInputs = new(){"1", "2", "3", "4"};
                        string fightOption = Console.ReadLine();
                        fightOption = Input.CheckValid(fightOption, validInputs);
                        Character target = new();
                        if (Opposition.Count > 1){
                            Text.ColourTextline("Who will you attack?", ConsoleColor.Gray);
                            validInputs.Clear();
                            for (int i = 0; i < Opposition.Count; i++)
                            {
                            int j = i;
                                j++;
                                Text.ColourText(j.ToString() + ".", ConsoleColor.Gray);
                                Text.ColourText(" ", ConsoleColor.Gray);
                                j--;
                                Text.ColourTextline(Opposition[j].Name, Opposition[j].colour);
                                j++;
                                validInputs.Add(j.ToString());
                            }
                            string targetOption = Console.ReadLine();
                            targetOption = Input.CheckValid(targetOption, validInputs);
                            target = Opposition[int.Parse(targetOption)-1];
                        }
                        else{
                            target = Opposition[0];
                        }
                        if (fightOption == "1"){Damage(teamMember, target);}
                        if (fightOption == "2"){Defend(teamMember, true);}
                    }
                    else{
                        Console.WriteLine(teamMember + " has " + teamMember.currentHP + "HP");
                    }
                }
            }
        }
        else if (SpecialCase == "Angel"){
            Character.Talk(Opposition[0], "My, what a bother.");
            Character.Talk(Opposition[0], "You're a vicious one, aren't you?");
            Text.ColourTextline("What will you do?", ConsoleColor.Gray);
            Text.ColourTextline("1. Fight", ConsoleColor.DarkRed);
            Text.ColourTextline("2. Apologise", ConsoleColor.DarkRed);
            List<string> validInputs = new(){"1", "2"};
            string fightOption = Console.ReadLine();
            fightOption = Input.CheckValid(fightOption, validInputs);
            if (fightOption == "1"){
                Damage(MCTeam[0], Opposition[0]);
                Character.Talk(Opposition[0], "You sheep are all the same.");
            }
            else if (fightOption == "2"){
                Character.Talk(Opposition[0], "Oh? Interesting. You think you can back out.");
            }
            MCTeam[0].dodgeChance = 0;
            Damage(Opposition[0], MCTeam[0]);
            MCTeam[0].dodgeChance = 30;
        }

        void Damage(Character actor, Character target){
            int missRandom = Random.Shared.Next(100);
            int dodgeRandom = Random.Shared.Next(100);
            if (missRandom > actor.accuracy){
                Text.ColourText(actor.Name, actor.colour);
                Text.ColourTextline(" missed!", ConsoleColor.Gray);
            }
            else if (target.dodgeChance > dodgeRandom){
                Text.ColourText(target.Name, target.colour);
                Text.ColourText(" dodged the attack!", ConsoleColor.Gray);
            }
            else if (target.defence >= actor.attack){
                Text.ColourText(target.Name, target.colour);
                Text.ColourText(" took no damage! ", ConsoleColor.Gray);
                Text.ColourText(actor.Name, actor.colour);
                Text.ColourTextline("'s damage was too low!", ConsoleColor.Gray);
            }
            else{
                int damageTaken = actor.attack - target.defence;
                target.currentHP -= damageTaken;
                Text.ColourText(target.Name, target.colour);
                Text.ColourText(" has taken ", ConsoleColor.Gray);
                Text.ColourText(damageTaken.ToString(), ConsoleColor.DarkRed);
                Text.ColourTextline(" damage!", ConsoleColor.Gray);
                if (target.currentHP <= 0){
                    Text.ColourText(target.Name, target.colour);
                    Text.ColourTextline(" has fainted!", ConsoleColor.Gray);
                }
                else{
                    Text.ColourText(target.Name, target.colour);
                    Text.ColourText( " now has ", ConsoleColor.Gray);
                    Text.ColourText(target.currentHP.ToString(), target.colour);
                    Text.ColourTextline(" HP left!", ConsoleColor.Gray);
                }
            }
        }

        void Defend(Character defender, bool defend){
            if (defend == false){
                if (defender.equippedItem.identifier == "Shield"){
                    Text.ColourText(defender.Name, defender.colour);
                    Text.ColourText(" lowers their shield (", ConsoleColor.Gray);
                    Text.ColourText("-" + defender.equippedItem.stat, ConsoleColor.Red);
                    Text.ColourTextline(" defence)", ConsoleColor.Gray);
                    defender.defence -= defender.equippedItem.stat;
                    defender.items.Add(defender.equippedItem);
                    defender.equippedItem = ("Fist", 0, "Weapon");
                }
                else{

                }
            }
            else{    
                List<(string, int, string)> shields = new();
                foreach ((string, int, string) item in defender.items){
                    if (item.Item3 == "Shield"){
                        shields.Add(item);
                    }
                }
                if (shields.Count > 1){
                    Text.ColourText("Which shield will ", ConsoleColor.Gray);
                    Text.ColourText(defender.Name, defender.colour);
                    Text.ColourTextline(" equip?", ConsoleColor.Gray);
                    List<string> validInputs = new();
                    for (int i = 0; i < shields.Count; i++)
                    {
                        int j = i;
                        j++;
                        Text.ColourText(j.ToString() + ".", ConsoleColor.Gray);
                        Text.ColourText(" ", ConsoleColor.Gray);
                        j--;
                        Text.ColourText(shields[j].Item1, ConsoleColor.Cyan);
                        Text.ColourText(" (", ConsoleColor.Gray);
                        Text.ColourText("+" + shields[j].Item2.ToString(), ConsoleColor.Blue);
                        Text.ColourText(") ", ConsoleColor.Gray);
                        Text.ColourTextline(defender.defence.ToString() + " defence --> " + (defender.defence + shields[j].Item2).ToString() + " defence", defender.colour);
                        j++;
                        validInputs.Add(j.ToString());
                    }
                    string shieldOption = Console.ReadLine();
                    shieldOption = Input.CheckValid(shieldOption, validInputs);
                    defender.equippedItem = shields[int.Parse(shieldOption)-1];
                }
                else if (shields.Count == 0){

                }
            }
        }
        return false;
    }
}