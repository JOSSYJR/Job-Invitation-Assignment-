using DepartmentAPI_CQRS.Domain.Entities;

namespace DepartmentAPI_CQRS.Domain.DTO.Response
{
    public class GetDepartmentsDto
    {
            public int id { get; set; }
            public string departmentName { get; set; } = null!;
            public string? description { get; set; }
            public int? parentDepartmentId { get; set; }
            public string? parentDepartmentName { get; set; }
    }
}
