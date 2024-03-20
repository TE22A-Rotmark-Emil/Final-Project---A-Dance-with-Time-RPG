using System.Runtime.CompilerServices;

class Shop{
    public static (string, int) purchaseItem(List<Character> Party, Character Shopkeeper, string SpecialCase){
        (string, int) item = ("placeholder", 0);
        List<(string, int)> acceptedItems = new();
        if (Shopkeeper.Name == "Gragerfourth"){
            if (SpecialCase == "PaigeInitialised"){
                
            }
            else{
                Character.Talk(Shopkeeper, "What'cha want, eh?");
            }
        }
        foreach ((string, int) shopItem in Shopkeeper.items){
            Text.ColourText(shopItem.Item1, ConsoleColor.Green);
            Text.ColourText(" costs ", ConsoleColor.Gray);
            Text.ColourText(shopItem.Item2.ToString(), ConsoleColor.Yellow);
            Text.ColourTextline(" coins.", ConsoleColor.Gray);
            (string, int) theItem = (shopItem.Item1.ToLower(), shopItem.Item2);
            acceptedItems.Append(theItem);
        }
        Console.ReadLine();
        return item;
    }
}