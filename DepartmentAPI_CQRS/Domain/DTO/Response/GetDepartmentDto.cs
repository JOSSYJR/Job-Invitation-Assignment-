using DepartmentAPI_CQRS.Domain.Entities;

namespace DepartmentAPI_CQRS.Domain.DTO.Response
{
    public class GetDepartmentDto
    {
        public int id { get; set; }
        public string departmentName { get; set; } = null!;
        public string? description { get; set; }
        public int? parentDepartmentId { get; set; }
        public string? parentDepartmentName { get; set; }
        public virtual List<string>? ChildDepartments { get; set; }
    }
}
