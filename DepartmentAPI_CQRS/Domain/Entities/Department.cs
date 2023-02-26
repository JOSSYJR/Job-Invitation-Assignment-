using System.ComponentModel.DataAnnotations;

namespace DepartmentAPI_CQRS.Domain.Entities
{
    public class Department
    {
        public Department(string departmentName, string? description, int? parentDepartmentId)
        {
            this.departmentName = departmentName;
            this.description = description;
            this.parentDepartmentId = parentDepartmentId;
        }
        [Key]
        public int id { get; set; }

        public string departmentName { get; set; } = null!;
        public string? description { get; set; }
        public int? parentDepartmentId { get; set; }

        public Department? parentDepartment { get; set; }
        public virtual ICollection<Department>? ChildDepartments { get; set; }


    }
}
