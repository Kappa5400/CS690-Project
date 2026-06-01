namespace Garden;

using Microsoft.Data.Sqlite;
using System;


public class gardenPlotManagerDB
{

    public static void getOpenPlots()
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM plot WHERE inUse = 0;"; 
        using var reader = command.ExecuteReader(); 

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            int location = reader.GetInt32(1);
            bool inUse = reader.GetBoolean(2); // 4. Fixed GetBool -> GetBoolean
            int ownerGardenerIndex = reader.GetInt32(3);
            string plotDescription = reader.GetString(4);

            Console.WriteLine($@"ID: {id}
            Location: {location}
            Is Plot In Use: {inUse}
            Owner Gardener Index: {ownerGardenerIndex}
            Description: {plotDescription}
            ");
        }
    }


    public static void getPlotViaGarderner(int index)
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
       
        command.CommandText = "SELECT * FROM plot WHERE ownerGardernerIndex = $index;";
        command.Parameters.AddWithValue("$index", index);
        
        using var reader = command.ExecuteReader(); 

        while (reader.Read())
        {
            
            long id = reader.GetInt64(0);
            int location = reader.GetInt32(1);
            bool inUse = reader.GetBoolean(2);
            int ownerGardenerIndex = reader.GetInt32(3);
            string plotDescription = reader.GetString(4);

            Console.WriteLine($@"Plot ID: {id}
            Location: {location}
            Is Plot In Use: {inUse}
            Owner Gardener Index: {ownerGardenerIndex}
            Description: {plotDescription}
            ");
        }
    }
}