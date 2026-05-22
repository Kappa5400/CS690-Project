namespace Garden;
using Spectre.Console;

public class crud
{
    
    public crud()
    {
        
    }

    public void crudManager()
    {
        int userType = 0;
        var command = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select a submenu")
            .AddChoices(new[]
            {
                "Users", "Tools", "Tasks"
            })
        );

        if (command == "Users")
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
                        int userType = 1;
                        userCRUD(userType);
                    }
                    else if (userCommandUserTypeSelect == "Volunteers")
                {
                    int userType = 2;
                    userCRUD(userType);
                }
                else {
                    int userType = 3;
                    userCRUD(userType);
                }
            } while(userCommandUserTypeSelect!= "end");
        }
    }

    public void userCRUD(int userType)
    {
        {
                    var crudCommand = new SelectionPrompt<string>()
                    .Title("Select an option")
                    .AddChoices(new[]
                    {
                        "View all", "View one", "Create", "Update", "Delete", "Back"
                    });
                
                    if(crudCommand == "View all")
                        {
                                if(userType == 1)
                            {
                                selectDB.getAllGarderner();
                                crudManager();
                            }
                            if(userType == 2)
                            {
                                selectDB.getAllVolunteer();
                                crudManager();
                            }
                            if(userType == 3)
                            {
                                selectDB.getAllSudo();
                                crudManager();
                            }
                        }
                    else if(crudCommand == "View one")
                        {
                            
                            int index = AskForInput("Select index: ");
                            
                               if(userType == 1)
                            {
                                selectDB.getGardernerViaIndex(index);
                                crudManager();
                            }
                            if(userType == 2)
                            {
                                selectDB.getVolunteerViaIndex(index);
                                crudManager();
                            }
                            if(userType == 3)
                            {
                                selectDB.getSudoViaIndex(index);
                                crudManager();
                            }

                        }
                    else if(crudCommand == "Create")
                        {
                            // garderner
                            if(userType == 1)
                            {
                                // make these null so empty can be used if no tool or plot exist for garderner
                                int toolUsingIndex = null;
                                int plotOwnIndex = null;

                                bool toolUsing = AskForInput("Enter 1 if garderner is using a tool or 0 if they are not:");
                                // lookup if bool can be 1 or 0
                                if(toolUsing == 1)
                                {
                                    int toolUsingIndex = AskForInput("Enter index of tool that is being used.");
                                }
                                bool plotOwn = AskForInput("Enter 1 if garderner has a plot or 0 if they do not: ");
                                if(plotOwn == 1)
                                {
                                    int plotOwnIndex = AskForInput("Enter plot index of owned plot:");
                                }
                                string name = AskForInput("Enter garderner name:");
                                helperDB.createGarderner(toolUsing, plotOwn, toolUsingIndex, plotOwnIndex, name);
                                crudManager();
                            }
                            // volunteer
                            if(userType == 2)
                            {
                                helperDB.createVolunteer(index);
                                crudManager();
                            }
                            // sudo
                            if(userType == 3)
                            {
                                helperDB.createSudo(index);
                                crudManager();
                            }
                        }
                    else if(crudCommand == "Update")
                        {
                            // to implement
                            int index = AskForInput("Select index: ");

                        }
                    else if(crudCommand == "Delete")
                        {
                            int index = AskForInput("Select index to delete: ");
                            
                               if(userType == 1)
                            {
                                helperDB.deleteGarderner(index);
                                crudManager();
                            }
                            if(userType == 2)
                            {
                                helperDB.deleteVolunteer(index);
                                crudManager();
                            }
                            if(userType == 3)
                            {
                                helperDB.deleteSudo(index);
                                crudManager();
                            }
                        }

                    else if(crudCommand == "Back")
                        {
                            crudManager();
                        }

        }
    }
    
    public static string AskForInput(string message) {
        Console.Write(message);
        return Console.ReadLine();

    }
    
}

