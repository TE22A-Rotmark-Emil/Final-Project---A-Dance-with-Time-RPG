class Text(){
    public static (string, ConsoleColor) ColourText(string text, ConsoleColor colourOption){
        Console.ForegroundColor = colourOption;
        Console.Write(text);
        Console.ResetColor();
        return(text, colourOption);
    }

    public static string RemoveJunk(string text){
        text = text.Replace(" ", "");
        text = text.Replace(",", "");
        text = text.Replace(".", "");
        text = text.Replace("'", "");
        text = text.Replace("´", "");
        text = text.Replace("`", "");
        text = text.Replace("¨", "");
        text = text.Replace("^", "");
        text = text.Replace("~", "");
        text = text.Replace("*", "");
        text = text.Replace("<", "");
        text = text.Replace(">", "");
        text = text.Replace("|", "");
        text = text.Replace(";", "");
        text = text.Replace(":", "");
        text = text.Replace("\"", "");
        text = text.Replace("!", "");
        text = text.Replace("#", "");
        text = text.Replace("¤", "");
        text = text.Replace("%", "");
        text = text.Replace("+", "");
        text = text.Replace("@", "");
        text = text.Replace("£", "");
        text = text.Replace("$", "");
        text = text.Replace("€", "");
        text = text.Replace("&", "");
        text = text.Replace("/", "");
        text = text.Replace("{", "");
        text = text.Replace("(", "");
        text = text.Replace("[", "");
        text = text.Replace(")", "");
        text = text.Replace("]", "");
        text = text.Replace("=", "");
        text = text.Replace("}", "");
        text = text.Replace("\\", "");
        text = text.Replace("§", "");
        text = text.Replace("½", "");
        text = text.Replace("0", "");
        text = text.Replace("1", "");
        text = text.Replace("2", "");
        text = text.Replace("3", "");
        text = text.Replace("4", "");
        text = text.Replace("5", "");
        text = text.Replace("6", "");
        text = text.Replace("7", "");
        text = text.Replace("8", "");
        text = text.Replace("9", "");
        return text;
    }

    public static void NoSpeedPreference(){
        Shopkeeper TestDummy = new();
        Console.WriteLine("Would you like a fast, balanced, or slow dialogue speed?");
        Thread.Sleep(750);
        Console.WriteLine("Example:");
        TestDummy.ShopkeeperDialogue("This dialogue is written quickly, and can be difficult to keep up with.", 3);
        TestDummy.ShopkeeperDialogue("This dialogue is written at a balanced pace, mildly faster than the average person reads.", 25);
        TestDummy.ShopkeeperDialogue("This dialogue is written slowly, at around the pace the average person reads.", 35);
    }

    public static int DecideTextSpeed(){
        int textSpeed = 0;
        bool choice = false;
        while (choice == false){            
            string desiredSpeed = Console.ReadLine().ToLower();
            desiredSpeed = RemoveJunk(desiredSpeed);
            choice = true;
            if (desiredSpeed is "fast" or "quick" or "quickly" or "speedy"){
                textSpeed = 3;
            }
            else if (desiredSpeed is "balanced" or "medium" or "decent"){
                textSpeed = 25;
            }
            else if (desiredSpeed is "slow" or "slower" or "slowly"){
                textSpeed = 35;
            }
            else if (desiredSpeed is "instant" or "superfast"){
                textSpeed = 0;
            }
            else if (desiredSpeed is "snail" or "veryslow" or "uninstant"){
                textSpeed = 150;
            }
            else{
                ColourText(desiredSpeed, ConsoleColor.Yellow);
                Console.Write(" is ");
                ColourText("invalid", ConsoleColor.Red);
                Console.Write(". Please write ");
                ColourText("'quick', ", ConsoleColor.Cyan);
                ColourText("'balanced', ", ConsoleColor.Green);
                Console.Write("or ");
                ColourText("'slow'", ConsoleColor.DarkGray);
                Console.Write(" instead.");
                Console.WriteLine();
                choice = false;
            }
        }
        return textSpeed;
    }
}