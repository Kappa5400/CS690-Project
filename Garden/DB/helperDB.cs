namespace Garden;

using Microsoft.Data.Sqlite;
using System;

class helperDB
{
    
    //Create, delete, and update methods
    
    static void createGarderner(bool toolUsing, bool plotOwn, int toolUsingIndex, int plotOwnIndex, string name)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO garderner VALUES ('$toolUsing, $plotOwn, $toolUsingIndex, $plotOwnIndex, $name')";
        command.Parameters.AddWithValue("$toolUsing", toolUsing, "$plotOwn", plotOwn, 
        "$toolUsingIndex", toolUsingIndex, "$plotOwnIndex", plotOwnIndex, "$name", Name);
    }

    static void createVolunteer(int task, string name)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO volunteer VALUES ('$task, $name')";
        command.Parameters.AddWithValue("$task", task, "$name", Name);
    }

    static void createSudo(string password, string name)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO sudo VALUES ('$password, $name')";
        command.Parameters.AddWithValue("$password", password, "$name", Name);
    }

    static void creatPlot(int location, bool inUse, int ownerGardernerIndex, string plotDescription)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO plot VALUES ('$location, $inUse, $ownerGardernerIndex, $plotDescription')";
        command.Parameters.AddWithValue("$location", location, "$inUse", inUse, 
        "$ownerGardernerIndex", ownerGardernerIndex, "$plotDescription", plotDescription);
    }

    static void creatTool(bool inUse, int usingGardernerIndex, string toolDescription)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO tool VALUES ('$inUse, $usingGardernerIndex, $toolDescription')";
        command.Parameters.AddWithValue("$inUse", inUse, 
        "$usingGardernerIndex", usingGardernerIndex, "$toolDescription", toolDescription);
    }

    static void creatTask(bool toDoStatus, int assignedVolunteerIndex, string taskDescription)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO tool VALUES ('$toDoStatus, $assignedVolunteerIndex, $taskDescription')";
        command.Parameters.AddWithValue("$toDoStatus", toDoStatus, 
        "$assignedVolunteerIndex", assignedVolunteerIndex, "$taskDescription", taskDescription);
    }
    
    // delete


    static void deleteGarderner(int index)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM garderner WHERE id = $index)";
        command.Parameters.AddWithValue("$index", index);
    }

    static void deleteSudo(int index)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM sudo WHERE id = $index)";
        command.Parameters.AddWithValue("$index", index);
    }

    static void deleteVolunteer(int index)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM volunteer WHERE id = $index)";
        command.Parameters.AddWithValue("$index", index);
    }

    static void deletePlot(int index)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM plot WHERE id = $index)";
        command.Parameters.AddWithValue("$index", index);
    }

    static void deleteTask(int index)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM task WHERE id = $index)";
        command.Parameters.AddWithValue("$index", index);
    }

    static void deleteTool(int index)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM tool WHERE id = $index)";
        command.Parameters.AddWithValue("$index", index);
    }

    //update


    static void updateGarderner(int index, bool toolUsing, bool plotOwn, int toolUsingIndex, int plotOwnIndex, string name)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();

        command.CommandText = @"
        UPDTATE garderner 
        SET toolUsing = $toolUsing, 
            plotOwn = $plotOwn, 
            toolUsingIndex = $toolUsingIndex, 
            plotOwnIndex = $plotOwnIndex, 
            name = $name,
        WHERE id = $index;";

        command.Parameters.AddWithValue("$toolUsing", toolUsing, "$plotOwn", plotOwn, 
        "$toolUsingIndex", toolUsingIndex, "$plotOwnIndex", plotOwnIndex, "$name", Name, "#index", index);
    }

     static void updateVolunteer(int index, int task, string name)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
        UPDATE volunteer 
        SET task = $task, 
        name = $name,
        WHERE id = $index;";

        command.Parameters.AddWithValue("$task", task, "$name", Name, "#index", index);
    }

    static void updateSudo(string password, string name)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
        UPDATE sudo
        SET password = $password,
        name = $name,
        WHERE id = $index;"; 
        
        command.Parameters.AddWithValue("$password", password, "$name", Name, "$index", index);
    }

    static void updatePlot(int location, bool inUse, int ownerGardernerIndex, string plotDescription, int index)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
        UPDATE plot 
        SET location = $location,
        inUse = $inUse, 
        ownerGardenIndex = $ownerGardernerIndex,
        plotDescription = $plotDescription'
        )";

        command.Parameters.AddWithValue("$location", location, "$inUse", inUse, 
        "$ownerGardernerIndex", ownerGardernerIndex, "$plotDescription", plotDescription, "$index", index);
    }

    static void updateTool(bool inUse, int usingGardernerIndex, string toolDescription, int index)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();

        command.CommandText = @"
        UPDATE tool 
        SET inUse = $inUse,
        usingGardernerIndex = $usingGardernerIndex, 
        toolDescription = $toolDescription,
        WHERE id = $index;)";

    
        command.Parameters.AddWithValue("$inUse", inUse, 
        "$usingGardernerIndex", usingGardernerIndex, "$toolDescription", toolDescription, "$index", index);
    }

    static void updateTask(bool toDoStatus, int assignedVolunteerIndex, string taskDescription, int index)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
        UPDATE task
        SET toDoStatus = $toDoStatus,
        assignedVolunteerIndex = $assignedVolunteerIndex,
        taskDescription = $taskDescription,
        WHERE id = $index;
        )";
        command.Parameters.AddWithValue("$toDoStatus", toDoStatus, 
        "$assignedVolunteerIndex", assignedVolunteerIndex, "$taskDescription", taskDescription, "$index", index);
    }


}