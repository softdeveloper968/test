﻿// <auto-generated />
using System;
using Employee_Amit_Chawla.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Employee_Amit_Chawla.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20221215082011_employee")]
    partial class employee
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Employee_Amit_Chawla.Models.Department", b =>
                {
                    b.Property<int>("Dept_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Dept_Id"), 1L, 1);

                    b.Property<string>("Dept_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("bit");

                    b.HasKey("Dept_Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Employee_Amit_Chawla.Models.Employee", b =>
                {
                    b.Property<int>("Emp_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Emp_Id"), 1L, 1);

                    b.Property<DateTime>("Date_Of_Birth")
                        .HasColumnType("datetime2");

                    b.Property<int>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<string>("Emp_First_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emp_Last_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("bit");

                    b.Property<string>("Profile_Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Emp_Id");

                    b.ToTable("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
