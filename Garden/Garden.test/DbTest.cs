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
        // 1. Force InitDB and helperDB to point to the shared RAM instance
        InitDB.ConnectionString = SharedMemoryConnectionString;

        // 2. Open the master connection to lock the database into RAM
        MasterConn = new SqliteConnection(SharedMemoryConnectionString);
        MasterConn.Open();

        // 3. Build the tables inside this shared memory space
        InitDB.init(MasterConn);
    }

    public void Dispose()
    {
        // Closing this master connection completely purges the database from RAM
        MasterConn.Dispose();
    }
}