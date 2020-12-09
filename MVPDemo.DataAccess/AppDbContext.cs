using Microsoft.EntityFrameworkCore;
using MVPDemo.Model;

namespace MVPDemo.DataAccess
{
    public class AppDbContext:DbContext
    {
     
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TodoDemo;Trusted_Connection=True;MultipleActiveResultSets=true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().UsePropertyAccessMode(PropertyAccessMode.PreferField);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}