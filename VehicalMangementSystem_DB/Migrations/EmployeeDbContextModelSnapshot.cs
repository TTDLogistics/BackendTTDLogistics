﻿// <auto-generated />
using System;
using EmployeeMangementSystem_DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeMangementSystem_DB.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    partial class EmployeeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeMangementSystem_Entity.UserLogin.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_on");

                    b.Property<bool>("LockedStatus")
                        .HasColumnType("bit")
                        .HasColumnName("locked_status");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("modified_by");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_on");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.Property<string>("designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("loginName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
