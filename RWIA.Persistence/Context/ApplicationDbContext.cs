using Microsoft.EntityFrameworkCore;
using RWIA.Entities;

namespace RWIA.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the DbContext to use an in-memory database.
            optionsBuilder.UseInMemoryDatabase("db_rwia");
        }

        public DbSet<ShortLink> ShortLinks { get; set; }

    }
}
