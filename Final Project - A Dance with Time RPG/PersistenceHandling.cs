class Persistence{
    public static int ReadPersistenceInt(string identifier){
        foreach (string state in File.ReadAllLines("speedPreference.txt")){
            string[] states = state.Split(": ");
            if (identifier == states[0]){
                int value = Convert.ToInt32(states[1]);
                return value;
            }
        }
        return 1;
    }
    public static string ReadPersistenceTxt(string identifier){
        foreach (string state in File.ReadAllLines("speedPreference.txt")){
            string[] states = state.Split(": ");
            if (identifier == states[0]){
                string value = states[1];
                return value;
            }
        }
        return "invalid";
    }
}