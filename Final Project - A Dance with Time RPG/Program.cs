int textSpeed = 1;

Shopkeeper Gragerfourth = new(){
    name = "Gragerfourth",
    isConArtist = false,
    colour = ConsoleColor.Red,
    items = new(){
        ("Cinnamon Bun", 5), ("Yorkshire Pudding", 10), ("Apple Pie", 7), ("Crêpe", 5), ("Waffle", 5)
    }
};

while (textSpeed == 1 || textSpeed == 2){
    textSpeed = DecideTextSpeed(textSpeed);
}

Gragerfourth.ShopkeeperDialogue("What are you doing here? These brats, they're always trying to take my stuff!", textSpeed);
Console.ReadLine();

static int DecideTextSpeed(int textSpeed){
    Shopkeeper TestDummy = new(){
        name = "testDummy"
    };
    if (textSpeed == 1){
        Console.WriteLine("Would you like a fast, balanced, or slow dialogue speed?");
        Thread.Sleep(750);
        Console.WriteLine("Example:");
        TestDummy.ShopkeeperDialogue("This dialogue is written quickly, and can be difficult to keep up with.", 3);
        TestDummy.ShopkeeperDialogue("This dialogue is written at a balanced pace, mildly faster than the average person reads.", 25);
        TestDummy.ShopkeeperDialogue("This dialogue is written slowly, at around the pace the average person reads.", 35);
    }
    string desiredSpeed = Console.ReadLine().ToLower();
    desiredSpeed = Text.RemoveJunk(desiredSpeed);
    if (desiredSpeed is "fast" or "quick" or "quickly" or "speedy"){
        textSpeed = 3;
    }
    else if (desiredSpeed is "balanced" or "medium" or "decent"){
        textSpeed = 25;
    }
    else if (desiredSpeed is "slow" or "slower" or "slowly"){
        textSpeed = 35;
    }
    else if (desiredSpeed is "instant" or "super fast" or "superfast"){
        textSpeed = 0;
    }
    else if (desiredSpeed is "snail" or "very slow" or "uninstant"){
        textSpeed = 150;
    }
    else{
        textSpeed = 2;
        Text.ColourText(desiredSpeed, ConsoleColor.Yellow);
        Console.Write(" is ");
        Text.ColourText("invalid", ConsoleColor.Red);
        Console.Write(". Please write ");
        Text.ColourText("'quick', ", ConsoleColor.Cyan);
        Text.ColourText("'balanced', ", ConsoleColor.Green);
        Console.Write("or ");
        Text.ColourText("'slow'", ConsoleColor.DarkGray);
        Console.Write(" instead.");
        Console.WriteLine();
    }
    return textSpeed;
}