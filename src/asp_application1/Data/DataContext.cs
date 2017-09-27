using asp_application1.Models;
using Microsoft.EntityFrameworkCore;

namespace asp_application1.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Bag> Bags { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bag>().ToTable("Bag");
           // modelBuilder.Entity<Category>().ToTable("Category");
           // modelBuilder.Entity<Supplier>().ToTable("Supplier");
        }
    }
}
