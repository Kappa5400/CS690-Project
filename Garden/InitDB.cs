namespace Garden;

using Microsoft.Data.Sqlite;
using System;

class InitDB{
    private const string ConnectionString = "Data Source=garden.db";

    static void Main(stirng[] args)
    {
        init();
    }

    static void init()
    {
        InitializeDatabase();
        initGardernerTable();
        initVolunteerTable();
        initSudoTable();
        initTaskTable();
        initToolTable();
        initPlotTable();
    }

    static void InitializeDatabase()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
    }


    static void initGardernerTable()
    {
        var createUserTable = connectionCreateCommand();
        createGardernerTable.CommandText =
        @"
        CREATE TABLE IF NOT EXISTS garderner (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            toolUsing BOOL DEFAULT 0,
            plotOwn BOOL DEFAULT 0,
            toolUsingIndex INTEGER,
            plotOwnIndex INTEGER,
            name STRING
        );
        ";
        createGardernerTable.ExcecuteNonQuery();
    }

    static void initVolunteerTable()
    {
        var createVolunteerTable = connectionCreateCommand();
        createVolunteerTable.CommandText =
        @"
        CREATE TABLE IF NOT EXISTS volunteer (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            task INTEGER,
            name STRING
        );
        ";
        createVolunteerTable.ExcecuteNonQuery();
    }

    static void initSudoTable()
    {
        var createSudoTable = connectionCreateCommand();
        createSudoTable.CommandText =
        @"
        CREATE TABLE IF NOT EXISTS sudo (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            password STRING,
            name STRING
        );
        ";
        createSudoTable.ExcecuteNonQuery();
    }

    static void initPlotTable()
    {
        var createPlotTable = connectionCreateCommand();
        createPlotTable.CommandText =
        @"
        CREATE TABLE IF NOT EXISTS plot (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            location INTEGER NOT NULL,
            inUse BOOL DEFAULT 0,
            ownerGardernerIndex INTEGER,
            plotDescription STRING
        );
        ";
        createSudoTable.ExcecuteNonQuery();
    }

    static void initToolTable()
    {
        var createToolTable = connectionCreateCommand();
        createToolTable.CommandText =
        @"
        CREATE TABLE IF NOT EXISTS tool (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            inUse BOOL DEFAULT 0,
            usingGardernerIndex INTEGER,
            toolDescription STRING
        );
        ";
        createToolTable.ExcecuteNonQuery();
    }

    static void initTaskTable()
    {
        var createTaskTable = connectionCreateCommand();
        createTaskTable.CommandText =
        @"
        CREATE TABLE IF NOT EXISTS task (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            toDoStatus BOOL DEFAULT 1,
            assignedVolunteerIndex INTEGER,
            taskDescription String
        );
        ";
        createTaskTable.ExcecuteNonQuery();
    }

    //below are helper functions

    //View functions

    static void getGardernerViaIndex(int index)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM garderner WHERE id = $index";
        command.Parameters.AddWithValue("$index", index);

        using var reader = command.ExcecuteReader();

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            int task = reader.GetInt64(1);
            string name = reader.GetString(2);
        }

        /*
        CREATE TABLE IF NOT EXISTS volunteer (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            task INTEGER,
            name STRING
        */

        Console.WriteLine($@"ID: {id}
            Name: {name}
            Assigned task: {task}
            ");

    }

    static void getAllGarderner()
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM garderner";

        using var reader = command.ExcecuteReader();

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            bool toolUsing = reader.GetBool(1);
            bool plotOwn = reader.GetBool(2);
            int toolUsingIndex = reader.GetInt64(3);
            int plotOwnIndex = reader.GetInt64(4);
            string name = reader.GetString(5);
            Console.WriteLine($@"ID: {id}
            Name: {name}
            Using a tool currently: {toolUsing}
            Owns a plot: {plotOwn}
            Index of tool if using: {toolUsingIndex}
            Index of plot if own: {plotOwnIndex}
            \n
            ");
        }

    }

     static void getAllVolunteer()
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM volunteer";

        using var reader = command.ExcecuteReader();

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            int task = reader.GetInt64(1);
            string Name = reader.GetString(2);
            Console.WriteLine($@"ID: {id}
            Name: {name}
            Assigned task number: {task}
            \n
            ");

            /*
            CREATE TABLE IF NOT EXISTS volunteer (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            task INTEGER,
            name STRING
        
        */


        }
    }

    static void getVolunteerViaIndex(int index)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM volunteere WHERE id = $index";
        command.Parameters.AddWithValue("$index", index);

        using var reader = command.ExcecuteReader();

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            bool toolUsing = reader.GetBool(1);
            bool plotOwn = reader.GetBool(2);
            int toolUsingIndex = reader.GetInt64(3);
            int plotOwnIndex = reader.GetInt64(4);
            string name = reader.GetString(5);
        }

        /*
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
            toolUsing BOOL DEFAULT 0,
            plotOwn BOOL DEFAULT 0,
            toolUsingIndex INTEGER,
            plotOwnIndex INTEGER,
            name STRING
        */

        Console.WriteLine($@"ID: {id}
            Name: {name}
            Using a tool currently: {toolUsing}
            Owns a plot: {plotOwn}
            Index of tool if using: {toolUsingIndex}
            Index of plot if own: {plotOwnIndex}
            ");

    }

    static void getSudoViaIndex(int index)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM sudo WHERE id = $index";
        command.Parameters.AddWithValue("$index", index);

        using var reader = command.ExcecuteReader();

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            string password = reader.GetString(1);
            string name = reader.GetString(2);
        }

        /*
        CREATE TABLE IF NOT EXISTS sudo (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            password STRING,
            name STRING
        */

        Console.WriteLine($@"ID: {id}
            Name: {name}
            Password: {password}
            ");

    }

    static void getAllTasks()
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM task";
        command.Parameters.AddWithValue("$index", index);

        using var reader = command.ExcecuteReader();

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            bool toDoStatus = reader.GetBool(1);
            int assignedVolunteerIndex = reader.GetInt64(2);
            String taskDescription = reader.GetString(3);
            Console.WriteLine($@"ID: {id}
            To do status: {toDoStatus}
            Assigned volunteer's index: {assignedVolunteerIndex}
            Description: {taskDescription}
            \n
            ");
        }

    }

    static void getTaskViaIndex(int index)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM task where id = $index";
        command.Parameters.AddWithValue("$index", index);

        using var reader = command.ExcecuteReader();

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            bool toDoStatus = reader.GetBool(1);
            int assignedVolunteerIndex = reader.GetInt64(2);
            String taskDescription = reader.GetString(3);
            
        }

        Console.WriteLine($@"ID: {id}
            To do status: {toDoStatus}
            Assigned volunteer's index: {assignedVolunteerIndex}
            Description: {taskDescription}");
    }


    static void getAllPlots()
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM plot";
        

        using var reader = command.ExcecuteReader();

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            int location = reader.GetInt64(1);
            bool inUse = reader.GetBool(2);
            int ownerGardenerIndex = reader.GetInt64(3);
            string plotDescription = reader.GetString(4);
            Console.WriteLine($@"ID: {id}
            Location: {location}
            In use: {inUse}
            Owner's garderner index: {ownerGardenerIndex}
            Description: {plotDescription}
            \n
            ");
        }

    }


     static void getPlotViaIndex(int index)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM plot where id = $index";
        command.Parameters.AddWithValue("$index", index);

        using var reader = command.ExcecuteReader();

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            int location = reader.GetInt64(1);
            bool inUse = reader.GetBool(2);
            int ownerGardenerIndex = reader.GetInt64(3);
            string plotDescription = reader.GetString(4); 
        }

        Console.WriteLine($@"ID: {id}
            Location: {location}
            In use: {inUse}
            Owner's garderner index: {ownerGardenerIndex}
            Description: {plotDescription}
            \n
            ");
    }

    static void getAllTools()
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM tool";
        

        using var reader = command.ExcecuteReader();

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            bool inUse = reader.GetBool(1);
            int usingGardernerIndex = reader.GetInt64(2);
            string toolDescription = reader.GetString(3);
            Console.WriteLine($@"ID: {id}
            In use: {inUse}
            Using garderner's index: {ownerGardenerIndex}
            Description: {toolDescription}
            \n
            ");
        }

        /*
        CREATE TABLE IF NOT EXISTS tool (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            inUse BOOL DEFAULT 0,
            usingGardernerIndex INTEGER,
            toolDescription STRING
            */

    }

    static void getAllTools(int index)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM tool where id = $index";
        command.Parameters.AddWithValue("$index", index);
        

        using var reader = command.ExcecuteReader();

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            bool inUse = reader.GetBool(1);
            int usingGardernerIndex = reader.GetInt64(2);
            string toolDescription = reader.GetString(3);
            
        }

        Console.WriteLine($@"ID: {id}
            In use: {inUse}
            Using garderner's index: {ownerGardenerIndex}
            Description: {toolDescription}
            \n
            ");

        /*
        CREATE TABLE IF NOT EXISTS tool (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            inUse BOOL DEFAULT 0,
            usingGardernerIndex INTEGER,
            toolDescription STRING
            */

    }


    //Create methods

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

    static void createSudo(string password, string name)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO sudo VALUES ('$password, $name')";
        command.Parameters.AddWithValue("$password", password, "$name", Name);
    }

    // to do: create tool, plot, task
    // updates
    // deletes
    // special select for only plot/tool/task info for app views
    
}

