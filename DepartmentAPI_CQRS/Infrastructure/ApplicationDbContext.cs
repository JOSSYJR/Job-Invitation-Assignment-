using DepartmentAPI_CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DepartmentAPI_CQRS.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasOne(e => e.parentDepartment).WithMany(x => x.ChildDepartments).HasForeignKey(m => m.parentDepartmentId);
        }

    }
}



   
