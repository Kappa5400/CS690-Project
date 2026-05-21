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
        command.CommandText = "SELECT * FROM garderner WHERE gardernerIndex = $index";
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

    static void getVolunteerViaIndex(int index)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM volunteere WHERE volunteerIndex = $index";
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

}

