class Persistence{
    public static int ReadPersistenceInt(string identifier){
        foreach (string state in File.ReadAllLines("PersistentChoice.txt")){
            string[] states = state.Split(": ");
            if (identifier == states[0]){
                int value = Convert.ToInt32(states[1]);
                return value;
            }
        }
        return 1;
    }
    public static string ReadPersistenceTxt(string identifier){
        foreach (string state in File.ReadAllLines("PersistentChoice.txt")){
            string[] states = state.Split(": ");
            if (identifier == states[0]){
                string value = states[1];
                return value;
            }
        }
        return "invalid";
    }
    public static Character ReadPersistenceChr(){
        Character c = new();

        foreach (string state in File.ReadAllLines("PersistenceChoice.txt")){
            string[] states = state.Split(": ");
            if (states[0] == "name"){
                // Character value = states[1];
                // return value;
                c.Name = states[0];
            }
        }
        return c;
    }
}