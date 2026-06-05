using Garden;
using Microsoft.Data.Sqlite;
using System;

public class DbTest : IDisposable
{
   
    private const string SharedMemoryConnectionString = "Data Source=GardenVolatileDb;Mode=Memory;Cache=Shared";
    
  
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