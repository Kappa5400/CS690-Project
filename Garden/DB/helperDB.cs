namespace Garden;

using Microsoft.Data.Sqlite;
using System;

public class helperDB
{
  
    public static void createGarderner(bool toolUsing, bool plotOwn, int toolUsingIndex, int plotOwnIndex, string name)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        
        command.CommandText = "INSERT INTO garderner (toolUsing, plotOwn, toolUsingIndex, plotOwnIndex, name) VALUES ($toolUsing, $plotOwn, $toolUsingIndex, $plotOwnIndex, $name)";
        
    
        command.Parameters.AddWithValue("$toolUsing", toolUsing);
        command.Parameters.AddWithValue("$plotOwn", plotOwn);
        command.Parameters.AddWithValue("$toolUsingIndex", toolUsingIndex);
        command.Parameters.AddWithValue("$plotOwnIndex", plotOwnIndex);
        command.Parameters.AddWithValue("$name", name); 

        command.ExecuteNonQuery(); 
    }

    public static void createVolunteer(int task, string name)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO volunteer (task, name) VALUES ($task, $name)";
        command.Parameters.AddWithValue("$task", task);
        command.Parameters.AddWithValue("$name", name);

        command.ExecuteNonQuery();
    }

    public static void createSudo(string password, string name)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO sudo (password, name) VALUES ($password, $name)";
        command.Parameters.AddWithValue("$password", password);
        command.Parameters.AddWithValue("$name", name);

        command.ExecuteNonQuery();
    }

    public static void createPlot(int location, bool inUse, int ownerGardernerIndex, string plotDescription)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO plot (location, inUse, ownerGardernerIndex, plotDescription) VALUES ($location, $inUse, $ownerGardernerIndex, $plotDescription)";
        command.Parameters.AddWithValue("$location", location);
        command.Parameters.AddWithValue("$inUse", inUse);
        command.Parameters.AddWithValue("$ownerGardernerIndex", ownerGardernerIndex);
        command.Parameters.AddWithValue("$plotDescription", plotDescription);

        command.ExecuteNonQuery();
    }

    public static void creatTool(bool inUse, int usingGardernerIndex, string toolDescription)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO tool (inUse, usingGardernerIndex, toolDescription) VALUES ($inUse, $usingGardernerIndex, $toolDescription)";
        command.Parameters.AddWithValue("$inUse", inUse);
        command.Parameters.AddWithValue("$usingGardernerIndex", usingGardernerIndex);
        command.Parameters.AddWithValue("$toolDescription", toolDescription);

        command.ExecuteNonQuery();
    }

    public static void creatTask(bool toDoStatus, int assignedVolunteerIndex, string taskDescription)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO task (toDoStatus, assignedVolunteerIndex, taskDescription) VALUES ($toDoStatus, $assignedVolunteerIndex, $taskDescription)";
        command.Parameters.AddWithValue("$toDoStatus", toDoStatus);
        command.Parameters.AddWithValue("$assignedVolunteerIndex", assignedVolunteerIndex);
        command.Parameters.AddWithValue("$taskDescription", taskDescription);

        command.ExecuteNonQuery();
    }

    public static void deleteGarderner(int index)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM garderner WHERE id = $index"; 
        command.Parameters.AddWithValue("$index", index);

        command.ExecuteNonQuery();
    }

    public static void deleteSudo(int index)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM sudo WHERE id = $index";
        command.Parameters.AddWithValue("$index", index);

        command.ExecuteNonQuery();
    }

    public static void deleteVolunteer(int index)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM volunteer WHERE id = $index";
        command.Parameters.AddWithValue("$index", index);

        command.ExecuteNonQuery();
    }

    public static void deletePlot(int index)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM plot WHERE id = $index";
        command.Parameters.AddWithValue("$index", index);

        command.ExecuteNonQuery();
    }

    public static void deleteTask(int index)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM task WHERE id = $index";
        command.Parameters.AddWithValue("$index", index);

        command.ExecuteNonQuery();
    }

    public static void deleteTool(int index)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM tool WHERE id = $index";
        command.Parameters.AddWithValue("$index", index);

        command.ExecuteNonQuery();
    }

    public static void updateGarderner(int index, bool toolUsing, bool plotOwn, int toolUsingIndex, int plotOwnIndex, string name)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
        UPDATE garderner 
        SET toolUsing = $toolUsing, 
            plotOwn = $plotOwn, 
            toolUsingIndex = $toolUsingIndex, 
            plotOwnIndex = $plotOwnIndex, 
            name = $name
        WHERE id = $index;"; 

        command.Parameters.AddWithValue("$toolUsing", toolUsing);
        command.Parameters.AddWithValue("$plotOwn", plotOwn);
        command.Parameters.AddWithValue("$toolUsingIndex", toolUsingIndex);
        command.Parameters.AddWithValue("$plotOwnIndex", plotOwnIndex);
        command.Parameters.AddWithValue("$name", name);
        command.Parameters.AddWithValue("$index", index); 

        command.ExecuteNonQuery();
    }

    public static void updateVolunteer(int index, int task, string name)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
        UPDATE volunteer 
        SET task = $task, 
            name = $name
        WHERE id = $index;";

        command.Parameters.AddWithValue("$task", task);
        command.Parameters.AddWithValue("$name", name);
        command.Parameters.AddWithValue("$index", index);

        command.ExecuteNonQuery();
    }

    public static void updateSudo(string password, string name, int index) 
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
        UPDATE sudo
        SET password = $password,
            name = $name
        WHERE id = $index;"; 
        
        command.Parameters.AddWithValue("$password", password);
        command.Parameters.AddWithValue("$name", name);
        command.Parameters.AddWithValue("$index", index);

        command.ExecuteNonQuery();
    }

    public static void updatePlot(int location, bool inUse, int ownerGardernerIndex, string plotDescription, int index)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
        UPDATE plot 
        SET location = $location,
            inUse = $inUse, 
            ownerGardernerIndex = $ownerGardernerIndex,
            plotDescription = $plotDescription
        WHERE id = $index;";

        command.Parameters.AddWithValue("$location", location);
        command.Parameters.AddWithValue("$inUse", inUse);
        command.Parameters.AddWithValue("$ownerGardernerIndex", ownerGardernerIndex);
        command.Parameters.AddWithValue("$plotDescription", plotDescription);
        command.Parameters.AddWithValue("$index", index);

        command.ExecuteNonQuery();
    }

    public static void updateTool(bool inUse, int usingGardernerIndex, string toolDescription, int index)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
        UPDATE tool 
        SET inUse = $inUse,
            usingGardernerIndex = $usingGardernerIndex, 
            toolDescription = $toolDescription
        WHERE id = $index;";

        command.Parameters.AddWithValue("$inUse", inUse);
        command.Parameters.AddWithValue("$usingGardernerIndex", usingGardernerIndex);
        command.Parameters.AddWithValue("$toolDescription", toolDescription);
        command.Parameters.AddWithValue("$index", index);

        command.ExecuteNonQuery();
    }

    public static void updateTask(bool toDoStatus, int assignedVolunteerIndex, string taskDescription, int index)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
        UPDATE task
        SET toDoStatus = $toDoStatus,
            assignedVolunteerIndex = $assignedVolunteerIndex,
            taskDescription = $taskDescription
        WHERE id = $index;";
        
        command.Parameters.AddWithValue("$toDoStatus", toDoStatus);
        command.Parameters.AddWithValue("$assignedVolunteerIndex", assignedVolunteerIndex);
        command.Parameters.AddWithValue("$taskDescription", taskDescription);
        command.Parameters.AddWithValue("$index", index);

        command.ExecuteNonQuery();
    }
}