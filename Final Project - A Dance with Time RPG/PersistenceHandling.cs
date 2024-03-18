using System.Text.Json;

class Persistence{
    public static int ReadPersistenceInt(string identifier, string textFile){
        foreach (string state in File.ReadAllLines(textFile)){
            string[] states = state.Split(": ");
            if (identifier == states[0]){
                int value = Convert.ToInt32(states[1]);
                return value;
            }
        }
        return 1;
    }
    public static string ReadPersistenceTxt(string identifier, string textFile){
        foreach (string state in File.ReadAllLines(textFile)){
            string[] states = state.Split(": ");
            if (identifier == states[0]){
                string value = states[1];
                return value;
            }
        }
        return "invalid";
    }
}