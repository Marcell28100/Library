using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Library.Models;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mark> Marks { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=library;user=root;password=;sslmode=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mark>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("mark");

            entity.HasIndex(e => e.StudentId, "StudentId");

            entity.Property(e => e.Id).HasMaxLength(40);
            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("date");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.MarkNumber)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.MarkText)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.StudentId)
                .HasMaxLength(40)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.UpdatedTime)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("date");

            entity.HasOne(d => d.Student).WithMany(p => p.Marks)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("mark_ibfk_1");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("student");

            entity.Property(e => e.Id).HasMaxLength(40);
            entity.Property(e => e.Age)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
