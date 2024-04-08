using System.Diagnostics.CodeAnalysis;
using System.Net;

public class Battle(){
    public static bool Fight(List<Character> MCTeam, List<Character> Opposition){
        foreach (Character teamMember in MCTeam){
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
                    foreach (Character enemy in Opposition){
                        Text.ColourText((i+1).ToString(), ConsoleColor.Gray);
                        Text.ColourText(" ", ConsoleColor.Gray);
                        Text.ColourTextline(enemy.Name, enemy.colour);
                        validInputs.Append(i+1.ToString());
                    }
                }
                string targetOption = Console.ReadLine();
                targetOption = 
            }
            else{
                target = Opposition[0];
            }
            if (fightOption == "1"){Damage(teamMember, target);}
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
                if (target.currentHP <= 0){
                    Text.ColourText(target.Name, target.colour);
                    Text.ColourTextline(" has fainted!", ConsoleColor.Gray);
                }
                else{
                    Text.ColourText(target.Name, target.colour);
                    Text.ColourText(" has taken ", ConsoleColor.Gray);
                    Text.ColourText(damageTaken.ToString(), ConsoleColor.DarkRed);
                    Text.ColourText(" damage! ", ConsoleColor.Gray);
                    Text.ColourText(target.Name, target.colour);
                    Text.ColourText( "now has ", ConsoleColor.Gray);
                    Text.ColourText(target.currentHP.ToString(), target.colour);
                    Text.ColourText(" HP left!", ConsoleColor.Gray);
                }
            }
        }

        return false;
    }
}