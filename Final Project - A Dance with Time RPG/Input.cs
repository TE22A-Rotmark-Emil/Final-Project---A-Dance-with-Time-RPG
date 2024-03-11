public class Input(){
    public static string CheckValid(string input, List<string> validInputs){
        input = Text.RemoveJunkInt(input);
        bool validInput = false;
        foreach (string a in validInputs){
            if (a == input){
                validInput = true;
                break;
            }
        }
        while (validInput == false){
            if (validInputs.Count == 2){
                Text.ColourText("Invalid input, please input 1 or 2.", ConsoleColor.Gray);
            }
            else if (validInputs.Count == 1){
                Text.ColourText("Invalid input, please input 1.", ConsoleColor.Gray);
            }
            else{
                Text.ColourText("Invalid input, please input ", ConsoleColor.Gray);
                int i = 0;
                int totalLength = validInputs.Count;
                foreach (string a in validInputs){
                    i++;
                    if (i == totalLength){
                        Text.ColourTextline("or " + a + ".", ConsoleColor.Gray);
                    }
                    else{
                        Text.ColourText(a + ", ", ConsoleColor.Gray);
                    }
                }
            }
            input = Console.ReadLine();
            input = Text.RemoveJunkInt(input);
            foreach (string a in validInputs){
                if (a == input){
                    validInput = true;
                    break;
                }
            }
        }
        return input;
    }
}