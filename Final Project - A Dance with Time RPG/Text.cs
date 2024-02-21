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
        return text;
    }
}