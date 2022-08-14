using Microsoft.EntityFrameworkCore;
using TodoList.Data.Configurations;
using TodoList.Data.Entities;

namespace TodoList.Data.Context
{
    public class ContextApp : DbContext
    {
        public DbSet<Affair> Affairs { get; set; }

        public ContextApp(DbContextOptions<ContextApp> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AffairsConfiguration());
        }
    }
}
