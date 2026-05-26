namespace Garden;

using Microsoft.Data.Sqlite;
using System;

class gardenPlotManagerDB(){
    
    static void getOpenPlots()
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM plot WHERE inUse = false;";
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

    static void getPlotViaGarderner(int index)
    {
        using var connection = newSqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM plot WHERE id = $index;";
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


}
