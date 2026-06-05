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

        else if(command == "Tools")
        {
            toolCrud();
        }

        else if(command == "Tasks")
        {
            taskCrud();
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
                if (toolUsing)
                {
                    (long toolid, bool oldInUse, int oldOwnerGardenerIndex, string toolDesc) = selectDB.getToolsViaIndex(toolUsingIndex ?? 0);
                    helperDB.updateTool((int)toolid, true, newGardernerIndex , toolDesc);
                }


                return;
            }
            // volunteer
            if (userType == 2)
            {
                int taskNum = int.Parse(AskForInput("Enter assigned task number (if none type 0): ") ?? "0");
                string name = AskForInput("Enter volunteer name: ");
                long volID = helperDB.createVolunteer(taskNum, name); 
                helperDB.updateTask(false, (int)volID, "To do", taskNum);
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
                // index 0 is sudo user sudo
                if (index == 0){
                    Console.WriteLine("Can't delete sudo user sudo");
                    return;
                }
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
    public static void toolCrud()
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
            
                selectDB.getAllTools();
                return;
        }
        
        else if (crudCommand == "View one")
        {
            int index = int.Parse(AskForInput("Select index: ") ?? "0");
            
            
            {
                selectDB.getToolsViaIndex(index);
                return;
            }
            
        }
        else if (crudCommand == "Create")
        {

            {
              
               
                bool inUse = false;
                int usingGardernerIndex = 0;
                string toolDescription = ""; 

                string plotlUsingStr = AskForInput("Enter 1 if garderner is using the tool or 0 if they are not: ");
                if(plotlUsingStr == "1")
                {
                    inUse = true;
                }
                else
                {
                    inUse = false;
                }

               
                
                if (inUse)
                {
                    usingGardernerIndex = int.Parse(AskForInput("Enter index of garderner that is using tool: "));
                    
                }
               
                toolDescription = AskForInput("Enter description of plot: ");

                long newId = helperDB.createTool(inUse, usingGardernerIndex, toolDescription);

                //update garderner
                if (inUse)
                {
                    var (id, oldInUse, oldPlotOwn, oldToolIndex, oldPlotIndex, name) = selectDB.getGardernerViaIndex(usingGardernerIndex);
                    helperDB.updateGarderner((int)id, true, oldPlotOwn, (int)newId, oldPlotIndex, name);
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

        public static void taskCrud()
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
            
                selectDB.getAllTasks();
                return;
        }
        
        else if (crudCommand == "View one")
        {
            int index = int.Parse(AskForInput("Select index: ") ?? "0");
            
            
            {
                selectDB.getTaskViaIndex(index);
                return;
            }
            
        }
        else if (crudCommand == "Create")
        {

            {
              
               
                bool toDo = false;
                int assignedVolunteer = 0;
                string taskDesc = ""; 

               toDo = bool.Parse(AskForInput("Does this task still need to be done? Type false if no, type true if yes: "));
                
                assignedVolunteer = int.Parse(AskForInput("Enter index of volunteer assigned to this task: "));
               
                taskDesc = AskForInput("Enter description of task: ");

                long newId = helperDB.createTask(toDo, assignedVolunteer, taskDesc);

                //update vol
                
                var (id, fetchTask, fetchName) = selectDB.getVolunteerViaIndex(assignedVolunteer);
                helperDB.updateVolunteer((int)id, (int)newId, fetchName);
                
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