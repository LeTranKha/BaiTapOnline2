using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Online2.Models;

namespace Online2.Data
{
    public partial class StudentManagerDbContext : DbContext
    {
        public StudentManagerDbContext()
        {
        }

        public StudentManagerDbContext(DbContextOptions<StudentManagerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; } = null!;
        public virtual DbSet<Device> Devices { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<View1ServiceStat> View1ServiceStats { get; set; } = null!;
        public virtual DbSet<View2AssignmentStatusStat> View2AssignmentStatusStats { get; set; } = null!;
        public virtual DbSet<View3DeviceAssignmentStat> View3DeviceAssignmentStats { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(e => new { e.Code, e.AssignmentDate })
                    .HasName("Assignments_pkey");

                entity.ToTable("Assignments", "Online2");

                entity.HasOne(d => d.DeviceCodeNavigation)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.DeviceCode)
                    .HasConstraintName("Assignments_DeviceCode_fkey");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("Assignments_ServiceCode_fkey");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.DeviceCode)
                    .HasName("Devices_pkey");

                entity.ToTable("Devices", "Online2");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.ServiceCode)
                    .HasName("Services_pkey");

                entity.ToTable("Services", "Online2");
            });

            modelBuilder.Entity<View1ServiceStat>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View1_ServiceStats", "Online2");
            });

            modelBuilder.Entity<View2AssignmentStatusStat>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View2_AssignmentStatusStats", "Online2");
            });

            modelBuilder.Entity<View3DeviceAssignmentStat>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View3_DeviceAssignmentStats", "Online2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
