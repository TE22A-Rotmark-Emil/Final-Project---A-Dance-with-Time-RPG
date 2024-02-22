class Persistence{
    public static int ReadPersistence(string identifier){
        foreach (string state in File.ReadAllLines("PersistentChoice.txt")){
            string[] states = state.Split(": ");
            int value = Convert.ToInt32(states[1]);
            if (identifier == states[0]){
                return value;
            }
        }
        return 1;
    }
}