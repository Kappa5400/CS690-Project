namespace Garden;

public class Auth
{
    public static bool start()
    {
        string inputName = AskForInput("Input name: ");
        string inputPassword = AskForInput("Input password: ");
        bool res = CheckPassword(inputName, inputPassword);
        return res;
    }
    public static bool CheckPassword(string inputName, string inputPassword)
    {
        if(inputName == "" || inputPassword== "")
        {
            return false;
        }

        var (fetchID, matchPassword, matchName) = selectDB.getSudoViaName(inputName);

        if(inputPassword == matchPassword){
            return true;
        }
        else{
        return false;
        }
        
    }

    public static string AskForInput(string message) {
        Console.Write(message);
        return Console.ReadLine();
    }

}