namespace Garden;
using Spectre.Console;
using System;

public class crud
{
    public crud()
    {
    }

    
    public static void crudManager()
    {
        int userType = 0;
        var command = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select a submenu")
            .AddChoices(new[]
            {
                "Users", "Tools", "Tasks", "Plot", "Back"
            })
        );

        if (command == "Back")
        {
            return;
        }

        else if(command == "Plot")
        {
            //to impliment
            return;
        }

        else if (command == "Users")
        {
            string userCommandUserTypeSelect;

            do
            {
                userCommandUserTypeSelect = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("Select an option")
                    .AddChoices(new[]
                    {
                        "Garderners", "Volunteers", "Sudo", "end"
                    }));

                if (userCommandUserTypeSelect == "Garderners")
                {
                    userType = 1;
                    userCRUD(userType);
                }
                else if (userCommandUserTypeSelect == "Volunteers")
                {
                    userType = 2;
                    userCRUD(userType);
                }
                else if (userCommandUserTypeSelect != "end")
                {
                    userType = 3;
                    userCRUD(userType);
                }
            } while(userCommandUserTypeSelect != "end");
        }
    }

    public static void userCRUD(int userType)
    {
        var crudPrompt = new SelectionPrompt<string>()
        .Title("Select an option")
        .AddChoices(new[]
        {
            "View all", "View one", "Create", "Update", "Delete", "Back"
        });
    
        var crudCommand = AnsiConsole.Prompt(crudPrompt);

        if (crudCommand == "View all")
        {
            if (userType == 1)
            {
                selectDB.getAllGarderner();
                crudManager();
            }
            if (userType == 2)
            {
                selectDB.getAllVolunteer();
                crudManager();
            }
            if (userType == 3)
            {
                selectDB.getAllSudo();
                crudManager();
            }
        }
        else if (crudCommand == "View one")
        {
            int index = int.Parse(AskForInput("Select index: ") ?? "0");
            
            if (userType == 1)
            {
                selectDB.getGardernerViaIndex(index);
                crudManager();
            }
            if (userType == 2)
            {
                selectDB.getVolunteerViaIndex(index);
                crudManager();
            }
            if (userType == 3)
            {
                selectDB.getSudoViaIndex(index);
                crudManager();
            }
        }
        else if (crudCommand == "Create")
        {
            // gardener
            if (userType == 1)
            {
              
                int? toolUsingIndex = null;
                int? plotOwnIndex = null;

                string toolUsingStr = AskForInput("Enter 1 if garderner is using a tool or 0 if they are not: ");
                bool toolUsing = toolUsingStr == "1";

                if (toolUsing)
                {
                    toolUsingIndex = int.Parse(AskForInput("Enter index of tool that is being used: ") ?? "0");
                }

                string plotOwnStr = AskForInput("Enter 1 if garderner has a plot or 0 if they do not: ");
                bool plotOwn = plotOwnStr == "1";

                if (plotOwn)
                {
                    plotOwnIndex = int.Parse(AskForInput("Enter plot index of owned plot: ") ?? "0");
                }

                string name = AskForInput("Enter garderner name: ");
                
                // Pass value or fallback fallback values if missing
                helperDB.createGarderner(toolUsing, plotOwn, toolUsingIndex ?? 0, plotOwnIndex ?? 0, name);
                return;
            }
            // volunteer
            if (userType == 2)
            {
                int taskNum = int.Parse(AskForInput("Enter volunteer task number: ") ?? "0");
                string name = AskForInput("Enter volunteer name: ");
                helperDB.createVolunteer(taskNum, name); 
                return;
            }
            // sudo
            if (userType == 3)
            {
                string password = AskForInput("Enter sudo password: ");
                string name = AskForInput("Enter sudo name: ");
                helperDB.createSudo(password, name); 
                crudManager();
            }
        }
        else if (crudCommand == "Update")
        {
            int index = int.Parse(AskForInput("Select index: ") ?? "0");
            // To implement update logic
        }
        else if (crudCommand == "Delete")
        {
            int index = int.Parse(AskForInput("Select index to delete: ") ?? "0");
            
            if (userType == 1)
            {
                helperDB.deleteGarderner(index);
                crudManager();
            }
            if (userType == 2)
            {
                helperDB.deleteVolunteer(index);
                crudManager();
            }
            if (userType == 3)
            {
                helperDB.deleteSudo(index);
                crudManager();
            }
        }
        else if (crudCommand == "Back")
        {
            return;
        }
    }
    
    public static string AskForInput(string message) 
    {
        Console.Write(message);
        return Console.ReadLine() ?? string.Empty;
    }
}