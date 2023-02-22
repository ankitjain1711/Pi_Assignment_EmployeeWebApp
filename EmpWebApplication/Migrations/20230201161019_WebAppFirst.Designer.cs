﻿// <auto-generated />
using System;
using EmpWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmpWebApplication.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20230201161019_WebAppFirst")]
    partial class WebAppFirst
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmpWebApplication.Models.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeptId"), 1L, 1);

                    b.Property<string>("DeptName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DeptId");

                    b.HasIndex("DeptName")
                        .IsUnique()
                        .HasFilter("[DeptName] IS NOT NULL");

                    b.ToTable("department");
                });

            modelBuilder.Entity("EmpWebApplication.Models.Designation", b =>
                {
                    b.Property<int>("DesignationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DesignationId"), 1L, 1);

                    b.Property<string>("DesgName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DesignationId");

                    b.HasIndex("DesgName")
                        .IsUnique();

                    b.ToTable("designation");
                });

            modelBuilder.Entity("EmpWebApplication.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<int>("DesignationId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DeptId");

                    b.HasIndex("DesignationId");

                    b.ToTable("emps");
                });

            modelBuilder.Entity("EmpWebApplication.Models.EmployeeSkill", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("employeeSkills");
                });

            modelBuilder.Entity("EmpWebApplication.Models.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillId"), 1L, 1);

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillId");

                    b.ToTable("skill");
                });

            modelBuilder.Entity("EmpWebApplication.Models.Employee", b =>
                {
                    b.HasOne("EmpWebApplication.Models.Department", "dept")
                        .WithMany("Employees")
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmpWebApplication.Models.Designation", "designation")
                        .WithMany("Employees")
                        .HasForeignKey("DesignationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("dept");

                    b.Navigation("designation");
                });

            modelBuilder.Entity("EmpWebApplication.Models.EmployeeSkill", b =>
                {
                    b.HasOne("EmpWebApplication.Models.Employee", "Employee")
                        .WithMany("employeeSkills")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmpWebApplication.Models.Skill", "skill")
                        .WithMany("employeeSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("skill");
                });

            modelBuilder.Entity("EmpWebApplication.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("EmpWebApplication.Models.Designation", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("EmpWebApplication.Models.Employee", b =>
                {
                    b.Navigation("employeeSkills");
                });

            modelBuilder.Entity("EmpWebApplication.Models.Skill", b =>
                {
                    b.Navigation("employeeSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
