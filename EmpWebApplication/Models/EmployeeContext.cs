using Microsoft.EntityFrameworkCore;

namespace EmpWebApplication.Models
{
    public class EmployeeContext :DbContext

    {
        public EmployeeContext() : base()
        {

        }
               
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        public DbSet<Employee> emps { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<Designation> designation { get; set; }
        public DbSet<Skill> skill { get; set; }
        public DbSet<EmployeeSkill> employeeSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasOne<Department>(g => g.dept)
            .WithMany(s => s.Employees);

            modelBuilder.Entity<Department>()
                .HasIndex(u => u.DeptName)
                    .IsUnique();

            modelBuilder.Entity<Employee>().HasOne<Designation>(g => g.designation)
            .WithMany(s => s.Employees);

            modelBuilder.Entity<Designation>()
                .HasIndex(u => u.DesgName)
                    .IsUnique();

            modelBuilder.Entity<EmployeeSkill>().HasKey(sc => new { sc.EmployeeId, sc.SkillId });

            modelBuilder.Entity<EmployeeSkill>()
            .HasOne<Employee>(sc => sc.Employee)
            .WithMany(s => s.employeeSkills)
            .HasForeignKey(sc => sc.EmployeeId);

            modelBuilder.Entity<EmployeeSkill>()
                .HasOne<Skill>(sc => sc.skill)
                .WithMany(s => s.employeeSkills)
                .HasForeignKey(sc => sc.SkillId);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Put Your Connection String Here !!!");
        }
    }
}
