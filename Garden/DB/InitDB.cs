namespace Garden;

using Microsoft.Data.Sqlite;
using System;



public class InitDB{
    public static string ConnectionString { get; set; } = "Data Source=garden.db";

    static void migrate(string[] args)
    {
        init();
    }

    public static void init()
    {
      
        initGardernerTable();
        initVolunteerTable();
        initSudoTable();
        initTaskTable();
        initToolTable();
        initPlotTable();
    }



    static void initGardernerTable()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        var createGardernerTable = connection.CreateCommand();
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
        createGardernerTable.ExecuteNonQuery();
    }

    static void initVolunteerTable()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var createVolunteerTable = connection.CreateCommand();
        createVolunteerTable.CommandText =
        @"
        CREATE TABLE IF NOT EXISTS volunteer (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            task INTEGER,
            name STRING
        );
        ";
        createVolunteerTable.ExecuteNonQuery();
    }

    static void initSudoTable()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var createSudoTable = connection.CreateCommand();
        createSudoTable.CommandText =
        @"
        CREATE TABLE IF NOT EXISTS sudo (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            password STRING,
            name STRING
        );
        ";
        createSudoTable.ExecuteNonQuery();

        var enterSudo = connection.CreateCommand();
        enterSudo.CommandText = "INSERT INTO sudo (password, name) SELECT 'sudo', 'sudo' WHERE NOT EXISTS (SELECT 1 FROM sudo WHERE name = 'sudo');";

        enterSudo.ExecuteNonQuery();
    }

    static void initPlotTable()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var createPlotTable = connection.CreateCommand();
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
        createPlotTable.ExecuteNonQuery();
    }

    static void initToolTable()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var createToolTable = connection.CreateCommand();
        createToolTable.CommandText =
        @"
        CREATE TABLE IF NOT EXISTS tool (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            inUse BOOL DEFAULT 0,
            usingGardernerIndex INTEGER,
            toolDescription STRING
        );
        ";
        createToolTable.ExecuteNonQuery();

        
    }

    static void initTaskTable()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var createTaskTable = connection.CreateCommand();
        createTaskTable.CommandText =
        @"
        CREATE TABLE IF NOT EXISTS task (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            toDoStatus BOOL DEFAULT 1,
            assignedVolunteerIndex INTEGER,
            taskDescription String
        );
        ";
        createTaskTable.ExecuteNonQuery();
    }



    // for testing    
    public static void init(SqliteConnection connection)
{
    foreach (var sql in new[]
    {
        @"CREATE TABLE IF NOT EXISTS garderner (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            toolUsing BOOL DEFAULT 0,
            plotOwn BOOL DEFAULT 0,
            toolUsingIndex INTEGER,
            plotOwnIndex INTEGER,
            name STRING
        );",
        @"CREATE TABLE IF NOT EXISTS volunteer (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            task INTEGER,
            name STRING
        );",
        @"CREATE TABLE IF NOT EXISTS sudo (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            password STRING,
            name STRING
        );",
        "INSERT INTO sudo (password, name) SELECT 'sudo', 'sudo' WHERE NOT EXISTS (SELECT 1 FROM sudo WHERE name = 'sudo');",
        @"CREATE TABLE IF NOT EXISTS plot (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            location INTEGER NOT NULL,
            inUse BOOL DEFAULT 0,
            ownerGardernerIndex INTEGER,
            plotDescription STRING
        );",
        @"CREATE TABLE IF NOT EXISTS tool (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            inUse BOOL DEFAULT 0,
            usingGardernerIndex INTEGER,
            toolDescription STRING
        );",
        @"CREATE TABLE IF NOT EXISTS task (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            toDoStatus BOOL DEFAULT 1,
            assignedVolunteerIndex INTEGER,
            taskDescription STRING
        );"
    })
    {
        var cmd = connection.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
}

}

