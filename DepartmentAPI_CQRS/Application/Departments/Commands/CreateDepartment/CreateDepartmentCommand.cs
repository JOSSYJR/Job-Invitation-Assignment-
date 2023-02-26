using DepartmentAPI_CQRS.Domain.DTO.Response;
using MediatR;

namespace DepartmentAPI_CQRS.Application.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest<CreateDepartmentDto>
    {
        public CreateDepartmentCommand(
            string departmentName,
            string? description,
            int? parentDepartmentId)
        {
            
            Description = description;
            ParentDepartmentId = parentDepartmentId;
            DepartmentName= departmentName;
            
        }

        public string DepartmentName { get; set; } = null!;
        public string? Description { get; set; }
        public int? ParentDepartmentId { get; set; }
    }
}
