namespace Garden.Tests;

using Garden;
using Xunit;
using Microsoft.Data.Sqlite;

public class UnitTest1 : IDisposable
{
    private readonly DbTest _db = new();
    
    [Fact]
    public void Gard_insert1()
    {
        var cmd = _db.Conn.CreateCommand();
        cmd.CommandText = "INSERT INTO garderner (name) VALUES ('Alice')";
        cmd.ExecuteNonQuery();

        var query = _db.Conn.CreateCommand();
        query.CommandText = "SELECT name FROM garderner WHERE name = 'Alice'";
        var result = (string?)query.ExecuteScalar();

        Assert.Equal("Alice", result);
    }

    [Fact]
    public void Gard_insert()
    {
        _db.Conn.CreateCommand();
        var result = helperDB.createGarderner(true, false, 0, 0, "test");
        

        Assert.Equal(0, result);
    }

    [Fact]
    public void Sudo_insert()
    {
        var cmd = _db.Conn.CreateCommand();
        cmd.CommandText = "SELECT COUNT(*) FROM sudo WHERE name = 'sudo'";
        var count = (long?)cmd.ExecuteScalar();

        Assert.Equal(1, count);
    }

    public void Dispose() => _db.Dispose();
}