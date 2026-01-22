using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RESTAPI_Employee_Management_System.Models;

namespace RESTAPI_Employee_Management_System.Models;

public partial class EmsdbContext : DbContext
{
    public EmsdbContext()
    {
    }

    public EmsdbContext(DbContextOptions<EmsdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.Property(e => e.AttendanceId).ValueGeneratedNever();

            entity.HasOne(d => d.Employee).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Attendances_Employees");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.DepartmentName).HasMaxLength(100);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasIndex(e => e.DepartmentId, "IX_Employees_DepartmentId");

            entity.Property(e => e.ContactAddress).HasMaxLength(300);
            entity.Property(e => e.EmailAddress).HasMaxLength(300);
            entity.Property(e => e.FirstName).HasMaxLength(70);
            entity.Property(e => e.Gender).HasMaxLength(6);
            entity.Property(e => e.LastName).HasMaxLength(70);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
