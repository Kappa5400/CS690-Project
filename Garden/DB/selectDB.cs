namespace Garden;

using Microsoft.Data.Sqlite;
using System;

public class selectDB{

    public static (long id, bool toolUsing, bool plotOwn, int toolUsingIndex, int plotOwnIndex, string name) getGardernerViaIndex(int index)
    
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM garderner WHERE id = $index";
        command.Parameters.AddWithValue("$index", index);

        using var reader = command.ExecuteReader();

        long id = 0;
        int task = 0;
        string name = string.Empty;
        bool plotOwn = false;
        int toolUsingIndex = 0;
        int plotOwnIndex = 0;
        bool toolUsing = false;

        while (reader.Read())
        {
            id = reader.GetInt64(0);
            toolUsing = reader.GetBoolean(1);
            plotOwn = reader.GetBoolean(2);   
            toolUsingIndex = reader.GetInt32(3);
            plotOwnIndex = reader.GetInt32(4);
            name = reader.GetString(5);
           
        }

        Console.WriteLine($@"ID: {id}
            Using a tool currently: {toolUsing}
            Owns a plot: {plotOwn}
            Index of tool if using: {toolUsingIndex}
            Index of plot if own: {plotOwnIndex}
            ");

        return  (id, toolUsing, plotOwn, toolUsingIndex, plotOwnIndex, name);
    }

    public static void getAllGarderner()
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM garderner";

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            bool toolUsing = reader.GetBoolean(1);
            bool plotOwn = reader.GetBoolean(2);   
            int toolUsingIndex = reader.GetInt32(3);
            int plotOwnIndex = reader.GetInt32(4);
            string name = reader.GetString(5);
            Console.WriteLine($@"ID: {id}
            Name: {name}
            Using a tool currently: {toolUsing}
            Owns a plot: {plotOwn}
            Index of tool if using: {toolUsingIndex}
            Index of plot if own: {plotOwnIndex}
            ");
        }
    }

    public static void getAllVolunteer()
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM volunteer";

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            long task = reader.GetInt64(1);
            string name = reader.GetString(2); 
            Console.WriteLine($@"ID: {id}
            Name: {name}
            Assigned task number: {task}
            ");
        }
    }

    public static void getAllSudo()
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM sudo";

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            string password = reader.GetString(1);
            string name = reader.GetString(2);
            Console.WriteLine($@"ID: {id}
            Name: {name}
            Password: {password}
            ");
        }
    }

    public static void getVolunteerViaIndex(int index)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM volunteer WHERE id = $index"; 
        command.Parameters.AddWithValue("$index", index);

        using var reader = command.ExecuteReader();

        long id = 0;
        bool toolUsing = false;
        bool plotOwn = false;
        int toolUsingIndex = 0;
        int plotOwnIndex = 0;
        string name = string.Empty;

        while (reader.Read())
        {
            id = reader.GetInt64(0);
            toolUsing = reader.GetBoolean(1); 
            plotOwn = reader.GetBoolean(2);   
            toolUsingIndex = reader.GetInt32(3);
            plotOwnIndex = reader.GetInt32(4);
            name = reader.GetString(5);
        }

        Console.WriteLine($@"ID: {id}
            Name: {name}
            Using a tool currently: {toolUsing}
            Owns a plot: {plotOwn}
            Index of tool if using: {toolUsingIndex}
            Index of plot if own: {plotOwnIndex}
            ");
    }

    public static (long id, string password, string name) getSudoViaIndex(int index)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM sudo WHERE id = $index";
        command.Parameters.AddWithValue("$index", index);

        using var reader = command.ExecuteReader();

      
        long id = 0;
        string password = string.Empty;
        string name = string.Empty;

        while (reader.Read())
        {
            id = reader.GetInt64(0);
            password = reader.GetString(1);
            name = reader.GetString(2);
        }

        Console.WriteLine($@"ID: {id}
            Name: {name}
            Password: {password}
            ");
        return (id, password, name);
    }

    public static (long id, string password, string name) getSudoViaName(string name)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM sudo WHERE name = $name LIMIT 1";
        command.Parameters.AddWithValue("$name", name);

        using var reader = command.ExecuteReader();

      
        long id = 0;
        string password = "";
        string dbName = "";

        while (reader.Read())
        {
            id = reader.GetInt64(0);
            password = reader.GetString(1);
            dbName = reader.GetString(2);
        }

        return (id, password, dbName);
    }

    public static void getAllTasks()
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM task"; 

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            bool toDoStatus = reader.GetBoolean(1); 
            int assignedVolunteerIndex = reader.GetInt32(2);
            string taskDescription = reader.GetString(3);
            Console.WriteLine($@"ID: {id}
            To do status: {toDoStatus}
            Assigned volunteer's index: {assignedVolunteerIndex}
            Description: {taskDescription}
            ");
        }
    }

    public static void getTaskViaIndex(int index)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);  
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM task where id = $index";
        command.Parameters.AddWithValue("$index", index);

        using var reader = command.ExecuteReader();

        long id = 0;
        bool toDoStatus = false;
        int assignedVolunteerIndex = 0;
        string taskDescription = string.Empty;

        while (reader.Read())
        {
            id = reader.GetInt64(0);
            toDoStatus = reader.GetBoolean(1); 
            assignedVolunteerIndex = reader.GetInt32(2);
            taskDescription = reader.GetString(3);
        }

        Console.WriteLine($@"ID: {id}
            To do status: {toDoStatus}
            Assigned volunteer's index: {assignedVolunteerIndex}
            Description: {taskDescription}");
    }

    public static void getAllPlots()
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM plot";

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            int location = reader.GetInt32(1);
            bool inUse = reader.GetBoolean(2); 
            int ownerGardenerIndex = reader.GetInt32(3);
            string plotDescription = reader.GetString(4);
            Console.WriteLine($@"ID: {id}
            Location: {location}
            In use: {inUse}
            Owner's garderner index: {ownerGardenerIndex}
            Description: {plotDescription}
            ");
        }
    }

    public static (long id, int location, bool inUse, int ownerGardenerIndex, string plotDescription) getPlotViaIndex(int index)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM plot where id = $index";
        command.Parameters.AddWithValue("$index", index);

        using var reader = command.ExecuteReader();

        long id = 0;
        long location = 0;
        bool inUse = false;
        long ownerGardenerIndex = 0;
        string plotDescription = string.Empty;

        while (reader.Read())
        {
            id = reader.GetInt64(0);
            location = reader.GetInt64(1);
            inUse = reader.GetBoolean(2); 
            ownerGardenerIndex = reader.GetInt64(3);
            plotDescription = reader.GetString(4); 
        }

        Console.WriteLine($@"ID: {id}
            Location: {location}
            In use: {inUse}
            Owner's garderner index: {ownerGardenerIndex}
            Description: {plotDescription}
            ");

        return (id, (int)location, inUse, (int)ownerGardenerIndex, plotDescription);
    }

    public static void getAllTools()
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM tool";

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            bool inUse = reader.GetBoolean(1); 
            int usingGardernerIndex = reader.GetInt32(2);
            string toolDescription = reader.GetString(3);
            Console.WriteLine($@"ID: {id}
            In use: {inUse}
            Using garderner's index: {usingGardernerIndex} 
            Description: {toolDescription}
            ");
        }
    }

    public static (long id, bool inUse, int usingGardernerIndex, string toolDescription) getToolsViaIndex(int index)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM tool where id = $index";
        command.Parameters.AddWithValue("$index", index);

        using var reader = command.ExecuteReader();

        long id = 0;
        bool inUse = false;
        long usingGardernerIndex = 0; 
        string toolDescription = string.Empty;

        while (reader.Read())
        {
            id = reader.GetInt64(0);
            inUse = reader.GetBoolean(1); 
            usingGardernerIndex = reader.GetInt64(2);
            toolDescription = reader.GetString(3);
        }

        Console.WriteLine($@"ID: {id}
            In use: {inUse}
            Using garderner's index: {usingGardernerIndex}
            Description: {toolDescription}
            ");
  
    return ((int)id, inUse, (int)usingGardernerIndex, toolDescription);
    }

}