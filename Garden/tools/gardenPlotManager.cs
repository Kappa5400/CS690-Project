namespace Garden;
using Spectre.Console;
using System;

public class gardenPlotManager
{


    public static void start()
    {
        string command;

        do{
                 command = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                    .Title("Select option")
                                    .AddChoices(new[]
                                    {
                                        "view open plots", "view in use plots", "view plot of garderner by index","back","end"
                                    }));

                if (command == "view open plots")
                {
                    gardenPlotManagerDB.getOpenPlots();
                }
                else if (command == "view in use plots")
                {
                    gardenPlotManagerDB.getUsePlots();
                }
                else if (command == "view plot of garderner by index")
                {
                    int res = int.Parse(AskForInput("Enter index of garderner to look up: ") ?? "0");
                    
                    gardenPlotManagerDB.getPlotViaGarderner(res);
                }
                else if (command == "back")
                {
                    return;
                } 
        } while(command!="end");
    }
    public static string AskForInput(string message) {
        Console.Write(message);
        return Console.ReadLine() ?? string.Empty;
    }

}

