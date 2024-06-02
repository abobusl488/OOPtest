using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Tab1> Tab1 { get; set; }
        public DbSet<Tab2> Tab2 { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tab2>()
                .HasOne(t => t.Tab1)
                .WithMany()
                .HasForeignKey(t => t.KeyTab1)
                .HasConstraintName("ftab1");
        }
    }
}
