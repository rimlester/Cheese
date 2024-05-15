using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Cheese.Server
{
    public class CheeseDbContext : DbContext
    {
        public DbSet<Cheese> Cheeses { get; set; }

        string SqliteDBPath { get; }

        public CheeseDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            SqliteDBPath = Path.Join(path, "cheese.db");
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"DataSource={SqliteDBPath}");


    }
}
