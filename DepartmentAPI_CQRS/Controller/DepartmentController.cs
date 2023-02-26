using Azure.Core;
using DepartmentAPI_CQRS.Application.Departments.Commands.CreateDepartment;
using DepartmentAPI_CQRS.Application.Departments.Commands.UpdateDepartment;
using DepartmentAPI_CQRS.Application.Departments.Query.GetDepartment;
using DepartmentAPI_CQRS.Application.Departments.Query.GetDepartments;
using DepartmentAPI_CQRS.Domain.DTO.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DepartmentAPI_CQRS.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DepartmentController(IMediator mediator) =>_mediator=mediator;


        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _mediator.Send(new GetDepartmentsQuery());
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var getDepartment = await _mediator.Send(new GetDepartmentQuery(id));

            if (getDepartment != null)
            {
                return Ok(getDepartment);
            }

            return NotFound($"No department in database with ID: {id}.");

        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentRequest request)
        {
            var department = await _mediator.Send(new CreateDepartmentCommand(request.departmentName,request.description, request.parentDepartmentId));
            return Ok(department);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreateDepartmentRequest request)
        {
            var department = await _mediator.Send(new UpdateDepartmentCommand(id,request.departmentName, request.description, request.parentDepartmentId));
            return Ok(department);
        }

    }
}
