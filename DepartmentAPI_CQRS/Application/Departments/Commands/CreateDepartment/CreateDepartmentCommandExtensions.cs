using DepartmentAPI_CQRS.Domain.Entities;

namespace DepartmentAPI_CQRS.Application.Departments.Commands.CreateDepartment
{
    public static class CreateDepartmentCommandExtensions
    {
        public static Department CreateDepartment(this CreateDepartmentCommand command)
        {
            var department = new Department
                (
                    command.DepartmentName,
                    command.Description,
                    command.ParentDepartmentId
                );

            return department;
        }
    }
}
