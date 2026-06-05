namespace Garden.Tests;

using Garden;
using Xunit;
using Microsoft.Data.Sqlite;
using System;

public class UnitTest1 : IDisposable
{
  
    private readonly DbTest _db = new();
    
    [Fact]
    public void Gard_inserttest()
    {
       
        _db.MasterConn.CreateCommand(); 
        
        var result = helperDB.createGarderner(true, false, 0, 0, "test");
        
        Assert.Equal(1, result);
    }

    [Fact]
    public void sudo_inserttest()
    {
       
        _db.MasterConn.CreateCommand(); 
        
        bool res = helperDB.createSudo("test", "test");
        
        Assert.True(res = true);
    }

    [Fact]
    public void vol_inserttest()
    {
       
        _db.MasterConn.CreateCommand(); 
        
        bool res = helperDB.createVolunteer( 1, "test");
        
        Assert.True(res = true);
    }

    [Fact]
    public void plot_inserttest()
    {
       
        _db.MasterConn.CreateCommand(); 
        
        long res = helperDB.createPlot( 1, false, 0, "test");
        
        Assert.Equal(1, res);
    }

    [Fact]
    public void tool_inserttest()
    {
       
        _db.MasterConn.CreateCommand(); 
        
        long res = helperDB.createTool( false, 0, "test");
        
        Assert.Equal(1, res);
    }

    [Fact]
    public void task_inserttest()
    {
       
        _db.MasterConn.CreateCommand(); 
        
        bool res = helperDB.createTask( false, 0, "test");
        
        Assert.True(res = true);
    }

    // to do, other crud


    [Fact]
    public void show_open_plotstest()
    {
        _db.MasterConn.CreateCommand(); 

        helperDB.createPlot( 1, false, 0, "test");

        bool res = gardenPlotManagerDB.getOpenPlots();

        Assert.True(res = true);

    }

    [Fact]
    public void show_close_plotstest()
    {
        _db.MasterConn.CreateCommand(); 

        helperDB.createPlot( 1, false, 0, "test");

        bool res = gardenPlotManagerDB.getOpenPlots();

        Assert.True(res = true);

    }

    [Fact]
    public void getPlotGardTest()
    {
        _db.MasterConn.CreateCommand(); 

        helperDB.createPlot( 1, true, 1, "test");
        helperDB.createGarderner(true, false, 0, 0, "test");

        bool res = gardenPlotManagerDB.getPlotViaGarderner(1);

        Assert.True(res = true);

    }

    [Fact]
    public void getPlotloctest()
    {
        _db.MasterConn.CreateCommand(); 

        helperDB.createPlot( 1, true, 1, "test");
        helperDB.createGarderner(true, false, 0, 0, "test");

        bool res = gardenPlotManagerDB.getPlotViaLoc(1);

        Assert.True(res = true);

    }



    public void Dispose() => _db.Dispose();
}