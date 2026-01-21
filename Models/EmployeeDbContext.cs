using Microsoft.EntityFrameworkCore;

namespace RESTAPI_Employee_Management_System.Models
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
      
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Employee>()
                .HasOne(e=>e.Department)
                .WithMany(d=>d.Employees)
                .HasForeignKey(fk=>fk.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
            
          

        }
    }
}
