using System.Runtime.CompilerServices;
/* Intended purpose was for this to be a Shop class which would be called on when the player would purchase / sell an item to a shopkeeper. It works, but it has no actual
functionality as it is never called on*/
class Shop{
    public static (string, int) purchaseItem(List<Character> Party, Character Shopkeeper, string SpecialCase){
        (string, int) item = ("placeholder", 0);
        List<(string, int)> acceptedItems = new();
        if (Shopkeeper.Name == "Gragerfourth"){
            if (SpecialCase == "PaigeInitialised"){
                
            }
            else if (SpecialCase == "No"){
                Character.Talk(Shopkeeper, "What'cha want, eh?");
            }
        }
        foreach ((string, int, string) shopItem in Shopkeeper.items){
            Text.ColourText(shopItem.Item1, ConsoleColor.Green);
            Text.ColourText(" costs ", ConsoleColor.Gray);
            Text.ColourText(shopItem.Item2.ToString(), ConsoleColor.Yellow);
            Text.ColourTextline(" coins.", ConsoleColor.Gray);
            /* Due to the way the Text Class functions, accepted inputs cannot allow for text such as "chicken pie" as it includes characters removed by Text.RemoveJunkTxt.
            Thus, the accepted name of the item cannot be its actual name - it must be ran through the RemoveJunkTxt function */
            (string, int) theItem = (Text.RemoveJunkTxt(shopItem.Item1), shopItem.Item2);
            acceptedItems.Append(theItem);
        }
        string requestedItem = Console.ReadLine();
        requestedItem = Text.RemoveJunkTxt(requestedItem);
        /* Todo: get a sugar kick, remove copilot, and finish this */
        return item;
    }
}