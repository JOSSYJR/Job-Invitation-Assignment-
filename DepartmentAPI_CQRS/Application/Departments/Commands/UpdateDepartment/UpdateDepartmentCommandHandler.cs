using DepartmentAPI_CQRS.Application.Departments.Commands.CreateDepartment;
using DepartmentAPI_CQRS.Domain.DTO.Response;
using DepartmentAPI_CQRS.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DepartmentAPI_CQRS.Application.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, CreateDepartmentDto>
    {
        private readonly ApplicationDbContext _dbcontext;
        public UpdateDepartmentCommandHandler(ApplicationDbContext dbContext) => _dbcontext = dbContext;

        public async Task<CreateDepartmentDto> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = request.UpdateDepartment();
            var c = await _dbcontext.Departments.SingleOrDefaultAsync((p => p.id == request.Id));
            if (c != null)
            {
                c.description = request.Description;
                c.departmentName = request.DepartmentName;
                c.parentDepartmentId = request.ParentDepartmentId;

                await _dbcontext.SaveChangesAsync();

            }

            return new CreateDepartmentDto(department.id);
        }
    }
}
