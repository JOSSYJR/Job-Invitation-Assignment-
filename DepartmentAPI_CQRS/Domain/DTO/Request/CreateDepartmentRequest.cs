using DepartmentAPI_CQRS.Domain.Entities;

namespace DepartmentAPI_CQRS.Domain.DTO.Request
{
    public class CreateDepartmentRequest
    {
        public string departmentName { get; set; } = null!;
        public string? description { get; set; }
        public int? parentDepartmentId { get; set; }
    }
}
