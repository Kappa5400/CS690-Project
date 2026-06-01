namespace Garden;

using Spectre.Console;


public class ConsoleUI {

    // init object here

    public ConsoleUI() {
        // init object on consoleui init here
    }

    public static void Show() {
        
        var user = AnsiConsole.Prompt(
				            new SelectionPrompt<string>()
				                .Title("Please select user type")
				                .AddChoices(new[] {
				                    "Garderner/Volunteer", "Manager"
				                }));

        // to implement: seperate user role here
        if(user=="Garderner/Volunteer") {

           string command;
        

            do{
                 command = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                    .Title("Select a menu")
                                    .AddChoices(new[]
                                    {
                                        "test","garden plot manager","end"
                                    }));
                if (command == "test")
                {
                    Console.WriteLine("Hi");
                }
                else if(command=="garden plot manager")
                {
                    gardenPlotManager.start();
                }

                } while(command!="end");

            } else if(user=="Manager") {

            //to implement: password login method
            string command;

            do {
                
                command = AnsiConsole.Prompt(
				                    new SelectionPrompt<string>()
				                        .Title("What do you want to do?")
				                        .AddChoices(new[] {
				                            "CRUD","end"
				                        }));

                if(command=="CRUD") {
                    Console.WriteLine("Entering CRUD tool");
                    // check if below correct syntax
                    crud.crudManager();
                } 


            } while(command!="end");

        }
    }

    public static string AskForInput(string message) {
        Console.Write(message);
        return Console.ReadLine();
    }
}