namespace Garden;

using Microsoft.Data.Sqlite;
using System;

public class helperDB
{
  
    public static int createGarderner(bool toolUsing, bool plotOwn, int toolUsingIndex, int plotOwnIndex, string name)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        
        command.CommandText = "INSERT INTO garderner (toolUsing, plotOwn, toolUsingIndex, plotOwnIndex, name) VALUES ($toolUsing, $plotOwn, $toolUsingIndex, $plotOwnIndex, $name); SELECT last_insert_rowid();";
        
    
        command.Parameters.AddWithValue("$toolUsing", toolUsing);
        command.Parameters.AddWithValue("$plotOwn", plotOwn);
        command.Parameters.AddWithValue("$toolUsingIndex", toolUsingIndex);
        command.Parameters.AddWithValue("$plotOwnIndex", plotOwnIndex);
        command.Parameters.AddWithValue("$name", name); 

        long newId = (long)command.ExecuteScalar();

        return (int)newId;
        
    }

    public static bool createVolunteer(int task, string name)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO volunteer (task, name) VALUES ($task, $name)";
        command.Parameters.AddWithValue("$task", task);
        command.Parameters.AddWithValue("$name", name);

        command.ExecuteNonQuery();

        return true;

    }

    public static bool createSudo(string password, string name)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO sudo (password, name) VALUES ($password, $name)";
        command.Parameters.AddWithValue("$password", password);
        command.Parameters.AddWithValue("$name", name);

        command.ExecuteNonQuery();
        return true;
    }

    public static long createPlot(int location, bool inUse, int ownerGardernerIndex, string plotDescription)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO plot (location, inUse, ownerGardernerIndex, plotDescription) VALUES ($location, $inUse, $ownerGardernerIndex, $plotDescription); SELECT last_insert_rowid();";
    
        command.Parameters.AddWithValue("$location", location);
        command.Parameters.AddWithValue("$inUse", inUse);
        command.Parameters.AddWithValue("$ownerGardernerIndex", ownerGardernerIndex);
        command.Parameters.AddWithValue("$plotDescription", plotDescription);

        long newId = (long)command.ExecuteScalar();

        return newId;
    }

    public static long createTool(bool inUse, int usingGardernerIndex, string toolDescription)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO tool (inUse, usingGardernerIndex, toolDescription) VALUES ($inUse, $usingGardernerIndex, $toolDescription); SELECT last_insert_rowid();";
        command.Parameters.AddWithValue("$inUse", inUse);
        command.Parameters.AddWithValue("$usingGardernerIndex", usingGardernerIndex);
        command.Parameters.AddWithValue("$toolDescription", toolDescription);

        long id = (long)command.ExecuteScalar();
        return id;
    }

    public static bool createTask(bool toDoStatus, int assignedVolunteerIndex, string taskDescription)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO task (toDoStatus, assignedVolunteerIndex, taskDescription) VALUES ($toDoStatus, $assignedVolunteerIndex, $taskDescription)";
        command.Parameters.AddWithValue("$toDoStatus", toDoStatus);
        command.Parameters.AddWithValue("$assignedVolunteerIndex", assignedVolunteerIndex);
        command.Parameters.AddWithValue("$taskDescription", taskDescription);

        command.ExecuteNonQuery();
        return true;
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
        //index 0 is the sudo, don't want to delete
        if (index == 0){
            return;
        }

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


    public static void updatePlot(int index, int location, bool inUse, int ownerGardernerIndex, string plotDescription)
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

    public static void updateTool(int index, bool inUse, int usingGardernerIndex, string toolDescription)
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