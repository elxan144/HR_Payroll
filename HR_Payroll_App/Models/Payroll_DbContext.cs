using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models
{
    public class Payroll_DbContext : IdentityDbContext<AppUser>
    {
        public Payroll_DbContext(DbContextOptions<Payroll_DbContext> options) : base(options) { }

        public DbSet<Holding> Holdings { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<CompanyDepartment> CompanyDepartments { get; set; }
        public DbSet<HoldingDepartment> HoldingDepartments { get; set; }

        public DbSet<Position> Positions { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<OldWorkPlace> OldWorkPlaces { get; set; }
        public DbSet<WorkPlace> WorkPlaces { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Penalty> Penalties { get; set; }
        public DbSet<Bonus> Bonus { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                        .Property(e => e.Gender)
                        .HasConversion(e => e.ToString(), e => (Gender)Enum.Parse(typeof(Gender), e));

            modelBuilder.Entity<Employee>()
                        .Property(x => x.MaritalStatus)
                        .HasConversion(e => e.ToString() , e => (MaritalStatus)Enum.Parse(typeof(MaritalStatus), e));

            //Many-to-Many Holding and Department
            modelBuilder.Entity<HoldingDepartment>()
                        .HasKey(x => new { x.HoldingId, x.DepatmentId });

            modelBuilder.Entity<HoldingDepartment>()
                        .HasOne(x => x.Department)
                        .WithMany(x => x.HoldingDepartments)
                        .HasForeignKey(x => x.DepatmentId);

            modelBuilder.Entity<HoldingDepartment>()
                        .HasOne(x => x.Holding)
                        .WithMany(x => x.HoldingDepartments)
                        .HasForeignKey(x => x.HoldingId);

            //Many-to-Many Company and Department
            modelBuilder.Entity<CompanyDepartment>()
                        .HasKey(x => new { x.CompanyId, x.DepartmentId });

            modelBuilder.Entity<CompanyDepartment>()
                        .HasOne(x => x.Company)
                        .WithMany(x => x.CompanyDepartments)
                        .HasForeignKey(x => x.CompanyId);

            modelBuilder.Entity<CompanyDepartment>()
                        .HasOne(x => x.Department)
                        .WithMany(x => x.CompanyDepartments)
                        .HasForeignKey(x => x.DepartmentId);
        }

        public  async Task Seed(IServiceScope service)
        {

          var roles = service.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if(roles.Roles.Count() == 0)
            {
                IdentityRole admin = new IdentityRole()
                {
                    Name = "Admin"
                };
                IdentityRole HR = new IdentityRole()
                {
                    Name = "HR"
                };
                IdentityRole departmentHead = new IdentityRole()
                {
                    Name = "DepartmentHead"
                };
                IdentityRole payrollSpecialist = new IdentityRole()
                {
                    Name = "PayrollSpecialist"
                };

                await roles.CreateAsync(admin);
                await roles.CreateAsync(HR);
                await roles.CreateAsync(departmentHead);
                await roles.CreateAsync(payrollSpecialist);

            }

            var users = service.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            if(users.Users.Count() == 0)
            {
                AppUser appUser = new AppUser
                {
                    Email = "admin@admin.com",
                    UserName = "adminstrator"
                };

               var result = await users.CreateAsync(appUser, "Admin@1234");

                if (result.Succeeded)
                {
                    await users.AddToRoleAsync(appUser,"Admin");
                }

            }
            
            
        }




    }
}
