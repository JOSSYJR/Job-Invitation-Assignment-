using DepartmentAPI_CQRS.Domain.DTO.Response;
using DepartmentAPI_CQRS.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DepartmentAPI_CQRS.Application.Departments.Query.GetDepartments
{
    public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentsQuery, IList<GetDepartmentsDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetDepartmentsQueryHandler(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public async Task<IList<GetDepartmentsDto>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = await _dbContext.Departments.ToListAsync();
            var departmentList = new List<GetDepartmentsDto>();
            GetDepartmentsDto c;
            foreach (var departmentItem in departments)
            {
                c = departmentItem.MapTo();
                departmentList.Add(c);
            }

            return departmentList;
        }
    }
}
