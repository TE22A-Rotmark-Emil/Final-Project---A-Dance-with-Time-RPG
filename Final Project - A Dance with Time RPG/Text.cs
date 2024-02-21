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
}