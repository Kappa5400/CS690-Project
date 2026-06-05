namespace Garden;
using Spectre.Console;
using System;

public class taskManager
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
                                        "View tasks","Update task","back","end"
                                    }));

                if (command == "View tasks")
                {
                    taskManagerDB.viewTasks();
                }
                else if(command =="Update task")
                {
                    int taskID = int.Parse(AskForInput("Input task index: "));
                    bool taskStatus = bool.Parse(AskForInput("What is the status of the task? Type true if it hasn't been done. Type false if the task is complete: "));
                    taskManagerDB.updateTask(taskID, taskStatus);
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


