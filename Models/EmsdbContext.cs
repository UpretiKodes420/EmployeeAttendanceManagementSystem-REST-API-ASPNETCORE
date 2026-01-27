using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

    public virtual DbSet<Leave> Leaves { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=EMSDB;Trusted_Connection=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasIndex(e => e.EmployeeId, "IX_Attendances_EmployeeId");

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

        modelBuilder.Entity<Leave>(entity =>
        {
            entity.HasKey(e => e.LeaveId);

            entity.Property(e => e.LeaveId).ValueGeneratedNever();
            entity.Property(e => e.FromDate)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ToDate)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Employee).WithMany(p => p.Leaves)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Leaves_Employees");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
