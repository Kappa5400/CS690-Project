namespace Garden;

using Microsoft.Data.Sqlite;
using System;


public class toolManagerDB
{

    public static bool getUseTools()
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM tool WHERE inUse = true;"; 
        using var reader = command.ExecuteReader(); 

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            bool inUse = reader.GetBoolean(1); 
            int usingGardernerIndex = reader.GetInt32(2);
            string toolDescription = reader.GetString(3);

            Console.WriteLine($@"ID: {id}
            Is tool in Use: {inUse}
            Owner Gardener Index: {usingGardernerIndex}
            Description: {toolDescription}
            ");
        }
        return true;
    }


    public static bool getOpenTools()
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
       
        command.CommandText = "SELECT * FROM tool WHERE inUse = false;";

        
        using var reader = command.ExecuteReader(); 

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            bool inUse = reader.GetBoolean(1); 
            int usingGardernerIndex = reader.GetInt32(2);
            string toolDescription = reader.GetString(3);

            Console.WriteLine($@"ID: {id}
            Is tool in Use: {inUse}
            Owner Gardener Index: {usingGardernerIndex}
            Description: {toolDescription}
            ");
        }

        return true;
        
    }
}