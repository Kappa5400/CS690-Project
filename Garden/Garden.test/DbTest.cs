using Garden;
using Microsoft.Data.Sqlite;
using System;

public class DbTest : IDisposable
{
    // Give the in-memory database a specific name and enable the shared cache
    private const string SharedMemoryConnectionString = "Data Source=GardenVolatileDb;Mode=Memory;Cache=Shared";
    
    // This keeps the database alive in RAM throughout the test life cycle
    public SqliteConnection MasterConn { get; }

    public DbTest()
    {
        
        InitDB.ConnectionString = SharedMemoryConnectionString;

        
        MasterConn = new SqliteConnection(SharedMemoryConnectionString);
        MasterConn.Open();

        
        InitDB.init(MasterConn);
    }

    public void Dispose()
    {
        
        MasterConn.Dispose();
    }
}