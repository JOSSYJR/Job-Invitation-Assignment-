using DepartmentAPI_CQRS.Domain.Entities;

namespace DepartmentAPI_CQRS.Infrastructure.Repository
{
    public sealed class DepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public DepartmentRepository(ApplicationDbContext dbContext)=> _dbContext = dbContext;
        public void Insert(Department department)=> _dbContext.Set<Department>().Add(department);
    }
}
