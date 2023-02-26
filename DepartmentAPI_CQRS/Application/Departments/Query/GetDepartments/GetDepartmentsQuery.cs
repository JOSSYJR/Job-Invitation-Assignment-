using DepartmentAPI_CQRS.Domain.DTO.Response;
using DepartmentAPI_CQRS.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DepartmentAPI_CQRS.Application.Departments.Query.GetDepartments
{
    public class GetDepartmentsQuery : IRequest<IList<GetDepartmentsDto>>
    {
       
    }
}
