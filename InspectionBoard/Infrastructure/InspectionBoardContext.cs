using System;
using System.Collections.Generic;
using InspectionBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace InspectionBoard.Infrastructure;

public partial class InspectionBoardContext : DbContext
{
    public InspectionBoardContext()
    {
    }

    public InspectionBoardContext(DbContextOptions<InspectionBoardContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DANIIL;Database=InspectionBoard;Trusted_Connection=True;TrustServerCertificate=Yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.IdStudent);

            entity.ToTable("Student");

            entity.Property(e => e.IdStudent).HasColumnName("id_student");
            entity.Property(e => e.Admission).HasColumnName("admission");
            entity.Property(e => e.Age)
                .HasMaxLength(50)
                .HasColumnName("age");
            entity.Property(e => e.Attestat)
                .HasMaxLength(50)
                .HasColumnName("attestat");
            entity.Property(e => e.DateOfBirth)
                .HasMaxLength(50)
                .HasColumnName("date_of_birth");
            entity.Property(e => e.Education)
                .HasMaxLength(50)
                .HasColumnName("education");
            entity.Property(e => e.EducationalMethod)
                .HasMaxLength(50)
                .HasColumnName("educational_method");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .HasColumnName("gender");
            entity.Property(e => e.GradePointAverage)
                .HasMaxLength(50)
                .HasColumnName("grade_point_average");
            entity.Property(e => e.AdmissionImg).HasColumnName("admission_img");
            entity.Property(e => e.SirotaImg).HasColumnName("sirota_img");
            entity.Property(e => e.InvalidImg).HasColumnName("invalid_img");
            entity.Property(e => e.PlaceOfResidence).HasColumnName("place_of_residence");
            entity.Property(e => e.Speciality).HasColumnName("speciality");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Nationality)
                .HasMaxLength(50)
                .HasColumnName("nationality");
            entity.Property(e => e.Patronymic).HasMaxLength(50).HasColumnName("patronymic");
            entity.Property(e => e.Snils) .HasMaxLength(50).HasColumnName("snils");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
