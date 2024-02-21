class Shopkeeper(){
    public string name;
    public bool isConArtist;
    public ConsoleColor colour;
    public List<(string, int)> items;

    public void ShopkeeperDialogue(string Dialogue, int textSpeed){
        foreach (char a in Dialogue){
            Console.Write(a);
            if (a is ','){
                Thread.Sleep(textSpeed*3);
            }
            else if (a is '.' or '?' or '!'){
                Thread.Sleep(textSpeed*6);
            }
            else if (a is ' '){
                Thread.Sleep(textSpeed*2);
            }
            else{
                Thread.Sleep(textSpeed);
            }
        }
        Console.WriteLine();
        Thread.Sleep(textSpeed*18);
    }
}