namespace DepartmentAPI_CQRS.Domain.DTO.Response
{
    public class CreateDepartmentDto
    {
        public CreateDepartmentDto(int id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
