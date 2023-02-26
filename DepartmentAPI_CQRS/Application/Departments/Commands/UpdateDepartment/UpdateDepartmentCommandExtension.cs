using DepartmentAPI_CQRS.Domain.Entities;

namespace DepartmentAPI_CQRS.Application.Departments.Commands.UpdateDepartment
{
    public static class UpdateDepartmentCommandExtension
    {
        public static Department UpdateDepartment(this UpdateDepartmentCommand command)
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
