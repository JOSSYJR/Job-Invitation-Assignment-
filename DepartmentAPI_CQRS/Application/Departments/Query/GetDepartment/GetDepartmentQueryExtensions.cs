using DepartmentAPI_CQRS.Domain.DTO.Response;
using DepartmentAPI_CQRS.Domain.Entities;

namespace DepartmentAPI_CQRS.Application.Departments.Query.GetDepartment
{
    public static class GetDepartmentQueryExtensions
    {
        public static GetDepartmentDto MapTo(this Department department)
        {
            List<string> childDepartments = new List<string>();
            if (department.ChildDepartments != null)
            {
                foreach (var d in department.ChildDepartments)
                {
                    childDepartments.Add(d.departmentName);
                }
            }
            
            return new GetDepartmentDto
            {
                id = department.id,
                description = department.description,
                parentDepartmentId = department.parentDepartmentId,
                departmentName = department.departmentName,
                ChildDepartments = childDepartments,
                parentDepartmentName = department.parentDepartment?.departmentName
            };
        }
    }
}
