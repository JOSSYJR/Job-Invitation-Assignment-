using DepartmentAPI_CQRS.Domain.DTO.Response;
using DepartmentAPI_CQRS.Domain.Entities;

namespace DepartmentAPI_CQRS.Application.Departments.Query.GetDepartments
{
    public static class GetDepartmentsQueryExtensions
    {
        public static GetDepartmentsDto MapTo(this Department department)
        {
            return new GetDepartmentsDto
            {
                id= department.id,
                description = department.description,
                parentDepartmentId = department.parentDepartmentId,
                departmentName= department.departmentName,
                parentDepartmentName = department.parentDepartment?.departmentName
            };
        }
    }
}
