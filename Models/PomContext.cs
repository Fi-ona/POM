using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace POM.Models;

public partial class PomContext : DbContext
{
    public PomContext()
    {
    }

    public PomContext(DbContextOptions<PomContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Reference> References { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserTransaction> UserTransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=POM;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bank>(entity =>
        {
            entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Upiid).HasColumnName("UPIId");

            entity.HasOne(d => d.User).WithMany(p => p.Banks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Banks_Users");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.Logs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Logs_Users");
        });

        modelBuilder.Entity<Reference>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.References)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_References_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CurrentLoginOtp).HasColumnName("CurrentLoginOTP");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.Gender).HasMaxLength(1);
            entity.Property(e => e.PancardNumber).HasColumnName("PANCardNumber");
        });

        modelBuilder.Entity<UserTransaction>(entity =>
        {
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.UserIdFromNavigation).WithMany(p => p.UserTransactionUserIdFromNavigations)
                .HasForeignKey(d => d.UserIdFrom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserTransactions_Users");

            entity.HasOne(d => d.UserIdToNavigation).WithMany(p => p.UserTransactionUserIdToNavigations)
                .HasForeignKey(d => d.UserIdTo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserTransactions_Users1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
