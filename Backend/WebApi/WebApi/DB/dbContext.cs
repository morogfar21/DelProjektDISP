using Microsoft.EntityFrameworkCore;
using WebApi.Models;

// local :"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=Haandvaerker;Trusted_Connection=True;MultipleActiveResultSets=true"
// gcloud: "DefaultConnection": "Server=mssql-gke-rk;Database=Haandvaerker;uid=sa;pwd=F21swtdisp!!!!;MultipleActiveResultSets=true"

namespace WebApi.DB
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {

        }

        public DbSet<Haandvaerker> Haandvaerkers { get; set; }
        public DbSet<Vaerktoej> Vaerktoejs { get; set; }
        public DbSet<Vaerktoejskasse> Vaerktoejskasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Haandvaerker>().ToTable("Haandvaerker");
            modelBuilder.Entity<Vaerktoej>().ToTable("Vaerktoej");
            modelBuilder.Entity<Vaerktoejskasse>().ToTable("Vaerktoejskasse");
        }

    }
}
