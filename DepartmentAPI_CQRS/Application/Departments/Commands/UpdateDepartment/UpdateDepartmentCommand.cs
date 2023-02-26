using DepartmentAPI_CQRS.Domain.DTO.Response;
using MediatR;

namespace DepartmentAPI_CQRS.Application.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest<CreateDepartmentDto>
    {
        public UpdateDepartmentCommand(int id,string departmentName, string? description, int? parentDepartmentId)
        {
            Id = id;
            Description = description;
            ParentDepartmentId = parentDepartmentId;
            DepartmentName = departmentName;

        }
        public int Id { get; set; }
        public string DepartmentName { get; set; } = null!;
        public string? Description { get; set; }
        public int? ParentDepartmentId { get; set; }
    }
}
