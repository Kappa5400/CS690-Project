namespace Garden;

using Microsoft.Data.Sqlite;
using System;


public class taskManagerDB
{

    public static bool viewTasks()
    {
        using var connection = new SqliteConnection(InitDB.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM task;"; 
        using var reader = command.ExecuteReader(); 

        while (reader.Read())
        {
            long id = reader.GetInt64(0);
            bool todo = reader.GetBoolean(1); 
            int volIndex = reader.GetInt32(2);
            string taskDesc = reader.GetString(3);

            Console.WriteLine($@"ID: {id}
            Task status (true means to do, false means done): {todo}
            Assigned Volunteer Index: {volIndex}
            Description: {taskDesc}
            ");
        }
        return true;
    }


    public static bool updateTask(int taskID, bool newStatus)
    {

        long dummyId;
        bool oldtoDoStatus;
        int assignedVolunteerIndex = 0;
        string taskDescription = string.Empty;

        (dummyId, oldtoDoStatus,assignedVolunteerIndex, taskDescription) = selectDB.getTaskViaIndex(taskID);

        helperDB.updateTask(newStatus,assignedVolunteerIndex,taskDescription, taskID);


        return true;

        }

        
        
}
