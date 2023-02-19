using Microsoft.EntityFrameworkCore;
using Server.models;

namespace Server.DataContxt
{
   
    public class ContextApp : DbContext
    {
        public ContextApp(DbContextOptions<ContextApp> options) : base(options) { }

        public DbSet<Template> templates => Set<Template>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Template>().ToTable("templates");
        }
    }
}
