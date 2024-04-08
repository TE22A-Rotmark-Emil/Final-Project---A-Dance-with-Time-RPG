using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Runtime;

public class Battle(){
    public static bool Fight(List<Character> MCTeam, List<Character> Opposition, string SpecialCase){
        if (SpecialCase == "No"){
            foreach (Character teamMember in MCTeam){
                if (teamMember.currentHP > 0){                
                    Text.ColourText("What will ", ConsoleColor.Gray);
                    Text.ColourText(teamMember.Name, teamMember.colour);
                    Text.ColourTextline(" do?", ConsoleColor.Gray);
                    Text.ColourTextline("1. Fight", ConsoleColor.Red);
                    Text.ColourTextline("2. Defend", ConsoleColor.Green);
                    Text.ColourTextline("3. Flee", ConsoleColor.DarkBlue);
                    List<string> validInputs = new(){"1", "2", "3"};
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
                            Text.ColourText(j.ToString(), ConsoleColor.Gray);
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
                }
                else{
                    Console.WriteLine(teamMember + " has " + teamMember.currentHP + "HP");
                }
            }
        }
        else if (SpecialCase == "Angel"){
            Character.Talk(Opposition[0], "My, what a bother.");
            Character.Talk(Opposition[0], "You're a vicious one, aren't you?");
            Text.ColourTextline("What will you do?", ConsoleColor.Gray);
            Text.ColourTextline("1. Fight", ConsoleColor.DarkRed);
            Text.ColourTextline("2. Apologise", ConsoleColor.DarkGray);
            List<string> validInputs = new(){"1", "2"};
            string fightOption = Console.ReadLine();
            fightOption = Input.CheckValid(fightOption, validInputs);
            Damage(MCTeam[0], Opposition[0]);
            Character.Talk(Opposition[0], "You sheep are all the same.");
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

        return false;
    }
}