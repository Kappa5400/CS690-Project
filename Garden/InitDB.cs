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


}

