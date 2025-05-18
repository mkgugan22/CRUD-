using Microsoft.EntityFrameworkCore;
using CRUD_Employee_Admin_Portal.Models.Enitities;

namespace CRUD_Employee_Admin_Portal.Data

{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Salary property
            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasColumnType("decimal(18,2)"); // Adjust precision and scale as needed
        }


    }
}
