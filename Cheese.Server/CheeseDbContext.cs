using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Cheese.Server
{
    public class CheeseDbContext : DbContext
    {
        public DbSet<Cheese> Cheeses { get; set; }

        string SqliteDBPath { get; }

        public CheeseDbContext(string dbName = "cheese.db")
        {
            // just use the execution path, not like we'll need LFS for 5 items
            SqliteDBPath = Path.Join(Environment.CurrentDirectory, dbName);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"DataSource={SqliteDBPath}");


    }
}
