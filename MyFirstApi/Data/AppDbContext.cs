using Microsoft.EntityFrameworkCore;
using MyFirstApi.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using MyFirstApi.Repository;
using MyFirstApi.Dtos;



namespace MyFirstApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                //.OnDelete(DeleteBehavior.SetNull);
                .OnDelete(DeleteBehavior.Restrict);
        }
    }


}
