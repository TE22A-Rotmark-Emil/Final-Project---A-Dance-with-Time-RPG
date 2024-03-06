public class Input(){
    public static string CheckValid(string input, List<string> validInputs){
        input = input.ToLower();
        bool validInput = false;
        foreach (string a in validInputs){
            if (a == input){
                validInput = true;
                break;
            }
        }
        while (validInput == false){
            Text.ColourText("Invalid Input, please input ", ConsoleColor.Gray);
            int i = 0;
            int totalLength = validInputs.Count;
            foreach (string a in validInputs){
                i++;
                if (i == totalLength){
                    Text.ColourTextline("or " + a + ".", ConsoleColor.White);
                }
                else{
                    Text.ColourText(a + ", ", ConsoleColor.White);
                }
            }
            input = Console.ReadLine().ToLower();
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