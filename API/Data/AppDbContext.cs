using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<API> APIs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");

    }
}