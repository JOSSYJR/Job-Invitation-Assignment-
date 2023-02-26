using DepartmentAPI_CQRS.Domain.DTO.Response;
using DepartmentAPI_CQRS.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DepartmentAPI_CQRS.Application.Departments.Query.GetDepartment
{
    public class GetDepartmentQueryHandler: IRequestHandler<GetDepartmentQuery, GetDepartmentDto>
    {
        
            private readonly ApplicationDbContext _dbContext;

            public GetDepartmentQueryHandler(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }


            public async Task<GetDepartmentDto> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
            {
                var department = await _dbContext.Departments.Include(i => i.parentDepartment).FirstOrDefaultAsync(i => i.id == request.Id);
                
                if (department != null)
                {
                    await _dbContext.Entry(department).Collection(i => i.ChildDepartments).LoadAsync();
                    var departmentItem = department.MapTo();
                    return departmentItem;
                }
                return null;
            }
        
    }
}
