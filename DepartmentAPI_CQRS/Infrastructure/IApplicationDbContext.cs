using DepartmentAPI_CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DepartmentAPI_CQRS.Infrastructure
{
    public interface IApplicationDbContext
    {
        DbSet<Department> Departments { get; set; }

        Task<int> SaveChanges();
    }
}