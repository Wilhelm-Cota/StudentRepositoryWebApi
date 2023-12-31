﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentRestApi.Model;

#nullable disable

namespace StudentRestApi.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StudentRestApi.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"), 1L, 1);

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            Department = "Back-end Developer",
                            Email = "pauluswilhelm85@gmail.com",
                            FirstName = " Paulus",
                            Gender = 0,
                            LastName = "Wilhelm"
                        },
                        new
                        {
                            StudentId = 2,
                            Department = "Front-end Developer",
                            Email = "TK@MAIL.COM",
                            FirstName = "Tangi",
                            Gender = 0,
                            LastName = "Kandjimwena"
                        },
                        new
                        {
                            StudentId = 3,
                            Department = "Graphics Designer",
                            Email = "I@gmail.com",
                            FirstName = "Imms",
                            Gender = 0,
                            LastName = "Immunel"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
