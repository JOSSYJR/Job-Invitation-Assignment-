using DepartmentAPI_CQRS.Domain.DTO.Response;
using MediatR;

namespace DepartmentAPI_CQRS.Application.Departments.Query.GetDepartment
{
    public class GetDepartmentQuery : IRequest<GetDepartmentDto>
    {
        public GetDepartmentQuery(int id) => Id = id;

        public int Id { get; set; }

    }
}
