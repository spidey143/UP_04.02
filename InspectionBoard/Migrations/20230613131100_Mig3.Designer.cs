﻿// <auto-generated />
using System;
using InspectionBoard.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InspectionBoard.Migrations
{
    [DbContext(typeof(InspectionBoardContext))]
    [Migration("20230613131100_Mig3")]
    partial class Mig3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InspectionBoard.Models.OrphanhoodDocument", b =>
                {
                    b.Property<int>("IdOrphanhoodDocumentImg")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_orphanhood_document_img");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOrphanhoodDocumentImg"));

                    b.Property<byte[]>("OrphanhoodDocumentImg")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("orphanhood_document_img");

                    b.HasKey("IdOrphanhoodDocumentImg");

                    b.ToTable("OrphanhoodDocument", (string)null);
                });

            modelBuilder.Entity("InspectionBoard.Models.Speciality", b =>
                {
                    b.Property<int>("IdSpeciality")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_speciality");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSpeciality"));

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("IdSpeciality");

                    b.ToTable("Speciality", (string)null);
                });

            modelBuilder.Entity("InspectionBoard.Models.Student", b =>
                {
                    b.Property<int>("IdStudent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_student");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStudent"));

                    b.Property<string>("Admission")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("admission");

                    b.Property<string>("Age")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("age");

                    b.Property<string>("Attestat")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("attestat");

                    b.Property<string>("DateOfBirth")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Education")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("education");

                    b.Property<string>("EducationalMethod")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("educational_method");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("Gender")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("gender");

                    b.Property<string>("GradePointAverage")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("grade_point_average");

                    b.Property<int?>("IdAdmissionImg")
                        .HasColumnType("int")
                        .HasColumnName("id_admission_img");

                    b.Property<int?>("IdOrphanhoodDocumentImg")
                        .HasColumnType("int")
                        .HasColumnName("id_orphanhood_document_img");

                    b.Property<int?>("IdPlaceOfResidence")
                        .HasColumnType("int")
                        .HasColumnName("id_place_of_residence");

                    b.Property<int?>("IdSpeciality")
                        .HasColumnType("int")
                        .HasColumnName("id_speciality");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("Nationality")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nationality");

                    b.Property<bool?>("OrphanhoodDocument")
                        .HasColumnType("bit")
                        .HasColumnName("orphanhood_document");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("patronymic");

                    b.Property<string>("Snils")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("snils");

                    b.HasKey("IdStudent");

                    b.ToTable("Student", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
