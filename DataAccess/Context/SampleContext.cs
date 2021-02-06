using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class SampleContext : DbContext
    {

        public SampleContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new BookMap(modelBuilder.Entity<Book>());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //default identity choice
            modelBuilder.UseIdentityAlwaysColumns();
        }

        public DbSet<Book> Books { get; set; }

    }
}