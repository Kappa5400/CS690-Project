namespace Garden.Tests;

using Garden;
using Xunit;
using Microsoft.Data.Sqlite;
using System;

public class UnitTest1 : IDisposable
{
    // 1. Declare and instantiate the fixture setup
    private readonly DbTest _db = new();
    
    [Fact]
    public void Gard_insert()
    {
        // 2. Fix the reference from _db.Conn to _db.MasterConn
        _db.MasterConn.CreateCommand(); 
        
        var result = helperDB.createGarderner(true, false, 0, 0, "test");
        
        Assert.Equal(1, result);
    }

    public void Dispose() => _db.Dispose();
}