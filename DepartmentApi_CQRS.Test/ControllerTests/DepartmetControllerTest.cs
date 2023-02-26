using DepartmentAPI_CQRS.Application.Departments.Commands.CreateDepartment;
using DepartmentAPI_CQRS.Application.Departments.Commands.UpdateDepartment;
using DepartmentAPI_CQRS.Application.Departments.Query.GetDepartment;
using DepartmentAPI_CQRS.Application.Departments.Query.GetDepartments;
using DepartmentAPI_CQRS.Controller;
using DepartmentAPI_CQRS.Domain.DTO.Request;
using DepartmentAPI_CQRS.Domain.DTO.Response;
using DepartmentAPI_CQRS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using Xunit.Sdk;


namespace DepartmentApi_CQRS.Test.ControllerTests
{
    public class DepartmetControllerTest
    {
            private static readonly Mock<IMediator> _mediatorMock;
            private static readonly DepartmentController _departmentController;

            static DepartmetControllerTest()
            {
                _mediatorMock = new Mock<IMediator>();
                _departmentController = new DepartmentController(_mediatorMock.Object);
            }

        [Fact]
        public async Task GetDepartments_ReturnsDepartments_WhenDepartmentsExist()
            {
                // Arrange
                var expectedDepartments = new List<GetDepartmentsDto>
            {
                new GetDepartmentsDto { id = 1, departmentName = "CEO" },
                new GetDepartmentsDto { id = 2, departmentName = "CFO",parentDepartmentId = 1},
                new GetDepartmentsDto { id = 5, departmentName = "FA",description = "Financial Analyst" ,parentDepartmentId = 2},
                new GetDepartmentsDto { id = 6, departmentName = "Auditors",description = "Auditors" ,parentDepartmentId = 2},
                new GetDepartmentsDto { id = 3, departmentName = "CTO",parentDepartmentId = 1},
                new GetDepartmentsDto { id = 4, departmentName = "CMO",parentDepartmentId = 1},
                new GetDepartmentsDto { id = 7, departmentName = "X",parentDepartmentId = 4},
                new GetDepartmentsDto { id = 8, departmentName = "Y",parentDepartmentId = 4},
            };

                _mediatorMock.Setup(m => m.Send(It.IsAny<GetDepartmentsQuery>(), CancellationToken.None))
                    .ReturnsAsync(expectedDepartments);

                // Act
                var result = await _departmentController.GetDepartments();

                // Assert
                var okObjectResult = Assert.IsType<OkObjectResult>(result);
                var actualDepartments = Assert.IsAssignableFrom<IEnumerable<GetDepartmentsDto>>(okObjectResult.Value);
                var getDepartmentsDtos = actualDepartments.ToList();
                
                Assert.Equal(expectedDepartments.Count, getDepartmentsDtos.Count());
                Assert.Equal(expectedDepartments.First().id, getDepartmentsDtos.First().id);
                Assert.Equal(expectedDepartments.First().departmentName, getDepartmentsDtos.First().departmentName);
                Assert.Equal(expectedDepartments.Last().id, getDepartmentsDtos.Last().id);
                Assert.Equal(expectedDepartments.Last().departmentName, getDepartmentsDtos.Last().departmentName);
            }
        
        
        [Fact]
        public async Task GetDepartments_ReturnsEmptyList_WhenNoDepartmentsExist()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetDepartmentsQuery>(), CancellationToken.None))
                .ReturnsAsync(new List<GetDepartmentsDto>());

            // Act
            var result = await _departmentController.GetDepartments();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var actualDepartments = Assert.IsAssignableFrom<IEnumerable<GetDepartmentsDto>>(okObjectResult.Value);
            Assert.Empty(actualDepartments);
        }

        [Fact]
        public async Task Get_ReturnsDepartment_WhenDepartmentExists()
        {
            // Arrange
            var expectedDepartment = new GetDepartmentDto { id = 1, departmentName = "Department 1" };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetDepartmentQuery>(), CancellationToken.None))
                .ReturnsAsync(expectedDepartment);

            // Act
            var result = await _departmentController.Get(expectedDepartment.id);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var actualDepartment = Assert.IsAssignableFrom<GetDepartmentDto>(okObjectResult.Value);
            Assert.Equal(expectedDepartment.id, actualDepartment.id);
            Assert.Equal(expectedDepartment.departmentName, actualDepartment.departmentName);
        }
        
        
        [Fact]
        public async Task Get_ReturnsOk_WhenDepartmentExists()
        {
            // Arrange
            var department = new GetDepartmentDto() { id = 1, departmentName = "Department 1", description = "Department 1 description" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetDepartmentQuery>(), default)).ReturnsAsync(department);

            // Act
            var result = await _departmentController.Get(1);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(department, okResult.Value);
        }

        [Fact]
        public async Task Get_ReturnsNotFound_WhenDepartmentDoesNotExist()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetDepartmentQuery>(), default)).ReturnsAsync((GetDepartmentDto)null);

            // Act
            var result = await _departmentController.Get(1);
            ConsoleOutput.Instance.WriteLine(result.ToString(),OutputLevel.Warning);
            // Assert
            var notFoundResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundResult);
            Assert.Equal("No department in database with ID: 1.", notFoundResult?.Value);
        }
        
        
        
        [Fact]
        public async Task CreateDepartment_ReturnsOkObjectResult()
        {
            // Arrange
            var request = new CreateDepartmentRequest
            {
                departmentName = "New Department",
                description = "A new department",
                parentDepartmentId = 1
            };
            var department = new CreateDepartmentDto(1);
            _mediatorMock.Setup(x => x.Send(It.IsAny<CreateDepartmentCommand>(), default)).ReturnsAsync(department);

            // Act
            var result = await _departmentController.CreateDepartment(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<CreateDepartmentDto>(okResult.Value);
            Assert.Equal(department, okResult.Value);
        }

        
        [Fact]
        public async Task Put_WithValidData_ReturnsOk()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var departmentController = new DepartmentController(mediatorMock.Object);
            var departmentId = 1;
            var departmentName = "Test Department";
            var description = "Test Description";
            var parentDepartmentId = 2;
            var request = new CreateDepartmentRequest
            {
                departmentName = departmentName,
                description = description,
                parentDepartmentId = parentDepartmentId
            };
            var updateDepartmentCommand = new UpdateDepartmentCommand(departmentId, departmentName, description, parentDepartmentId);

            mediatorMock.Setup(m => m.Send(updateDepartmentCommand, default)).ReturnsAsync(new CreateDepartmentDto(departmentId));

            // Act
            var result = await departmentController.Put(departmentId, request) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }
        
    }
}
