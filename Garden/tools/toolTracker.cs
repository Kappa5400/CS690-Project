namespace Garden;
using Spectre.Console;
using System;

public class toolTracker
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
                                        "View in use tools","View open tools","back","end"
                                    }));

                if (command == "View in use tools")
                {
                    toolManagerDB.getUseTools();
                }
                else if(command =="View open tools")
                {
                    toolManagerDB.getOpenTools();
                }

                else if (command == "back")
                {
                    return;
                } 
                
        } while(command!="end");
    }    


}


