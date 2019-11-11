﻿// <auto-generated />
using System;
using HR_Payroll_App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HR_Payroll_App.Migrations
{
    [DbContext(typeof(Payroll_DbContext))]
    [Migration("20190823165542_WorkPlaceUdate")]
    partial class WorkPlaceUdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HR_Payroll_App.Models.Bonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("Reason");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Bonus");
                });

            modelBuilder.Entity("HR_Payroll_App.Models.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<bool>("IsHead");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("HR_Payroll_App.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HoldingId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("HoldingId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("HR_Payroll_App.Models.CompanyDepartment", b =>
                {
                    b.Property<int>("CompanyId");

                    b.Property<int>("DepartmentId");

                    b.HasKey("CompanyId", "DepartmentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("CompanyDepartments");
                });

            modelBuilder.Entity("HR_Payroll_App.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HR_Payroll_App.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Education");

                    b.Property<string>("FatherName");

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<string>("MaritalStatus")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<DateTime>("PassportExpireDate");

                    b.Property<int>("PassportId");

                    b.Property<string>("Photo");

                    b.Property<string>("RegistrationAddress");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HR_Payroll_App.Models.Holding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Holdings");
                });

            modelBuilder.Entity("HR_Payroll_App.Models.HoldingDepartment", b =>
                {
                    b.Property<int>("HoldingId");

                    b.Property<int>("DepatmentId");

                    b.HasKey("HoldingId", "DepatmentId");

                    b.HasIndex("DepatmentId");

                    b.ToTable("HoldingDepartments");
                });

            modelBuilder.Entity("HR_Payroll_App.Models.OldWorkPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("FireDate");

                    b.Property<string>("FireReason")
                        .IsRequired();

                    b.Property<DateTime>("HireDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("OldWorkPlaces");
                });

            modelBuilder.Entity("HR_Payroll_App.Models.Penalty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("Reason");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Penalties");
                });

            modelBuilder.Entity("HR_Payroll_App.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Namme");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("HR_Payroll_App.Models.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<int>("CompanyId");

                    b.Property<int>("PositionId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PositionId");

                    b.ToTable("Salaries");
                });

            modelBuilder.Entity("HR_Payroll_App.Models.Vacation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId");

                    b.Property<int>("Employeeİd");

                    b.Property<DateTime>("End");

                    b.Property<DateTime>("Start");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Vacations");
                });

            modelBuilder.Entity("HR_Payroll_App.Models.WorkPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("Entry");

                    b.Property<DateTime?>("Exit");

                    b.Property<int>("PositionId");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.HasIndex("PositionId");

                    b.ToTable("WorkPlaces");
                });

            modelBuilder.Entity("HR_Payroll_App.Models.Bonus", b =>
                {
                    b.HasOne("HR_Payroll_App.Models.Employee", "Employee")
                        .WithMany("Bonuses")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_Payroll_App.Models.Branch", b =>
                {
                    b.HasOne("HR_Payroll_App.Models.Company", "Company")
                        .WithMany("Branches")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_Payroll_App.Models.Company", b =>
                {
                    b.HasOne("HR_Payroll_App.Models.Holding", "Holding")
                        .WithMany("Companies")
                        .HasForeignKey("HoldingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_Payroll_App.Models.CompanyDepartment", b =>
                {
                    b.HasOne("HR_Payroll_App.Models.Company", "Company")
                        .WithMany("CompanyDepartments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HR_Payroll_App.Models.Department", "Department")
                        .WithMany("CompanyDepartments")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_Payroll_App.Models.HoldingDepartment", b =>
                {
                    b.HasOne("HR_Payroll_App.Models.Department", "Department")
                        .WithMany("HoldingDepartments")
                        .HasForeignKey("DepatmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HR_Payroll_App.Models.Holding", "Holding")
                        .WithMany("HoldingDepartments")
                        .HasForeignKey("HoldingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_Payroll_App.Models.OldWorkPlace", b =>
                {
                    b.HasOne("HR_Payroll_App.Models.Employee", "Employee")
                        .WithMany("OldWorkPlaces")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_Payroll_App.Models.Penalty", b =>
                {
                    b.HasOne("HR_Payroll_App.Models.Employee", "Employee")
                        .WithMany("Penalties")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_Payroll_App.Models.Position", b =>
                {
                    b.HasOne("HR_Payroll_App.Models.Department", "Department")
                        .WithMany("Positions")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_Payroll_App.Models.Salary", b =>
                {
                    b.HasOne("HR_Payroll_App.Models.Company", "Company")
                        .WithMany("Salaries")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HR_Payroll_App.Models.Position", "Position")
                        .WithMany("Salaries")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HR_Payroll_App.Models.Vacation", b =>
                {
                    b.HasOne("HR_Payroll_App.Models.Employee", "Employee")
                        .WithMany("Vacations")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("HR_Payroll_App.Models.WorkPlace", b =>
                {
                    b.HasOne("HR_Payroll_App.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HR_Payroll_App.Models.Employee", "Employee")
                        .WithOne("WorkPlaces")
                        .HasForeignKey("HR_Payroll_App.Models.WorkPlace", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HR_Payroll_App.Models.Position", "Position")
                        .WithMany("WorkPlaces")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
