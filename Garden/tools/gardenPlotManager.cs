namespace Garden;
using Spectre.Console;

public class gardenPlotManager
{


    public void start()
    {
        string command;

        do{
                 command = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                    .Title("Select option")
                                    .AddChoices(new[]
                                    {
                                        "view open plots","view plot of garderner by index","back","end"
                                    }));

                if (command == "view open plots")
                {
                    DB.gardenPlotManager.getOpenPlots();
                }
                else if (command == "view plot of garderner by index")
                {
                    int res = AskForInput("Enter index of garderner to look up");
                    DB.gardenPlotManager.getPlotViaGarderner();
                }
                else if (command == "back")
                {
                    ConsoleUI.show();
                } 
        } while(command!="end");
    }
    public static string AskForInput(string message) {
        Console.Write(message);
        return Console.ReadLine();
    }

}

