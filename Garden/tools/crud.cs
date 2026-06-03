namespace Garden;
using Spectre.Console;
using System;
using System.Data.Common;

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
            plotCrud();
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
                return;
            }
            if (userType == 2)
            {
                selectDB.getAllVolunteer();
                return;
            }
            if (userType == 3)
            {
                selectDB.getAllSudo();
                return;
            }
        }
        else if (crudCommand == "View one")
        {
            int index = int.Parse(AskForInput("Select index: ") ?? "0");
            
            if (userType == 1)
            {
                selectDB.getGardernerViaIndex(index);
                return;
            }
            if (userType == 2)
            {
                selectDB.getVolunteerViaIndex(index);
                return;
            }
            if (userType == 3)
            {
                selectDB.getSudoViaIndex(index);
                return;
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
                
                
                int newGardernerIndex = helperDB.createGarderner(toolUsing, plotOwn, toolUsingIndex ?? 0, plotOwnIndex ?? 0, name);

                if (plotOwn)
                {
                    (long id, int oldLocation, bool oldInUse, int oldOwnerGardenerIndex, string oldPlotDescription) = selectDB.getPlotViaIndex(plotOwnIndex ?? 0);
                    helperDB.updatePlot((int)id, oldLocation, true, (int)newGardernerIndex, oldPlotDescription);
                }


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
                return;
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
                return;
            }
            if (userType == 2)
            {
                helperDB.deleteVolunteer(index);
                return;
            }
            if (userType == 3)
            {
                helperDB.deleteSudo(index);
                return;
            }
        }
        else if (crudCommand == "Back")
        {
            return;
        }
    }
    public static void plotCrud()
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
            
                selectDB.getAllPlots();
                return;
        }
        
        else if (crudCommand == "View one")
        {
            int index = int.Parse(AskForInput("Select index: ") ?? "0");
            
            
            {
                selectDB.getPlotViaIndex(index);
                return;
            }
            
        }
        else if (crudCommand == "Create")
        {

            {
              
                int location = 0;
                bool inUse = false;
                int ownerGardernerIndex = 0;
                string plotDescription = ""; 

                string plotlUsingStr = AskForInput("Enter 1 if garderner is using the plot or 0 if they are not: ");
                if(plotlUsingStr == "1")
                {
                    inUse = true;
                }
                else
                {
                    inUse = false;
                }

               
                location = int.Parse(AskForInput("Enter plot location (integer): ") ?? "0");
                
                if (inUse)
                {
                    ownerGardernerIndex = int.Parse(AskForInput("Enter index of garderner that owns plot: ") ?? "0");
                    
                }
                
                plotDescription = AskForInput("Enter description of plot: ");

                long newId = helperDB.createPlot(location, inUse, ownerGardernerIndex, plotDescription);

                //update garderner
                if (inUse)
                {
                    var (id, oldToolUsing, oldPlotOwn, oldToolUsingIndex, oldPlotID, oldName) = selectDB.getGardernerViaIndex(ownerGardernerIndex);
                    helperDB.updateGarderner((int)id, oldToolUsing, oldPlotOwn, oldToolUsingIndex, (int)newId, oldName);
                }
                return;
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
            
            helperDB.deletePlot(index);
            return;
            
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