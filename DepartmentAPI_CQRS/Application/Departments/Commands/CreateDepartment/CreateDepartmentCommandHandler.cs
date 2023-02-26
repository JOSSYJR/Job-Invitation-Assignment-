using DepartmentAPI_CQRS.Domain.DTO.Response;
using DepartmentAPI_CQRS.Infrastructure;
using MediatR;

namespace DepartmentAPI_CQRS.Application.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand,CreateDepartmentDto>
    {
        private readonly ApplicationDbContext _dbcontext;
        public CreateDepartmentCommandHandler(ApplicationDbContext dbContext)=>_dbcontext=dbContext;

        public async Task<CreateDepartmentDto> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = request.CreateDepartment();
            await _dbcontext.Departments.AddAsync(department);
            await _dbcontext.SaveChangesAsync();

            return new CreateDepartmentDto(department.id);
        }
    }
}
