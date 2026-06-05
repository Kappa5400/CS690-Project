
using Garden;
using Microsoft.Data.Sqlite;

    public class DbTest : IDisposable
    {
        public SqliteConnection Conn { get; }

        public DbTest()
        {
            Conn = new SqliteConnection("Data Source=:memory:");
            Conn.Open();
            // paste your real schema here
            InitDB.init(Conn);
        }

        public void Dispose() => Conn.Dispose();
    }