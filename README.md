# Job-Invitation-Assignment

This Project is an Answer for an Interview Assignment.

# Department Manager API

This is a sample ASP.NET Core API for managing departments. It includes endpoints for creating, retrieving, updating, and deleting departments.

# Prerequisites

.NET 5 SDK

Microsoft SQL Server

# Running the API

Clone this repository: git clone https://github.com/JOSSYJR/Job-Invitation-Assignment-.git

Navigate to the project directory: cd DepartmentManager

Restore packages: dotnet restore

Update the database: dotnet ef database update

Run the application: dotnet run

The API will be available at https://localhost:3001.

# Endpoints
GET /api/departments: Retrieves all departments.

GET /api/departments/{id}: Retrieves a specific department by ID.

POST /api/departments: Creates a new department.

PUT /api/departments/{id}: Updates an existing department by ID.

DELETE /api/departments/{id}: Deletes a department by ID.

# Technologies Used

ASP.NET Core 6

Entity Framework Core 6

Microsoft SQL Server

Swagger/OpenAPI

Newtonsoft.Json

# Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

# License

This project is licensed under the MIT License - see the LICENSE file for details.
