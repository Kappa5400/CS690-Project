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
                            // to implement
                        }
                    else if(crudCommand == "Update")
                        {
                            // to implement
                        }
                    else if(crudCommand == "Delete")
                        {
                            int index = AskForInput("Select index: ");
                            
                               if(userType == 1)
                            {
                                selectDB.deleteGarderner(index);
                                crudManager();
                            }
                            if(userType == 2)
                            {
                                selectDB.deleteVolunteer(index);
                                crudManager();
                            }
                            if(userType == 3)
                            {
                                selectDB.deleteSudo(index);
                                crudManager();
                            }
                        }

                    else if(crudCommand == "Back")
                        {
                            crudManager();
                        }


                }
    
    public static string AskForInput(string message) {
        Console.Write(message);
        return Console.ReadLine();

    }
    
}

