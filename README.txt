Task Management System


Overview:

The Task Management System is a web-based application designed to manage and track tasks, projects, and workflows. The system provides a user-friendly interface for creating, assigning, and tracking tasks to help teams stay organized and productive.

Features:

Task creation
Task Listing
Task Update
Task Deletion
Task Completion Functionality



Technical Requirements:

.NET Core 3.1 or later
Microsoft Entity Framework Core 3.1 or later
Microsoft ASP.NET Core 3.1 or later
Microsoft SQL Server or other compatible database system


Getting Started:

Clone the repository to your local machine.
Open the solution in Visual Studio 2019 or later.
Restore NuGet packages and build the solution.
Run the application using IIS Express or a local development server.


Directory Structure:

TaskManagementSystem.Data: Entity Framework Core data access layer
TaskManagementSystem.Models: Business logic and data models
TaskManagementSystem.Controllers: ASP.NET Core controllers for handling requests
TaskManagementSystem.Views: Razor views for rendering user interfaces
TaskManagementSystem.App: Startup and configuration files for the application





Database & Table Creation:



->Open your Sql Server & write following query for create database & table:

CREATE DATABASE TaskManagementDB;
GO

USE TaskManagementDB;
GO

CREATE TABLE Tasks (
    Id INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500) NOT NULL,
    DueDate DATE NOT NULL,
    Status NVARCHAR(50) NOT NULL
);
 


Stored Procedure:


->For stored procedure write following query:

-- Create the Create Task Stored Procedure
CREATE PROCEDURE sp_CreateTask
    @Title NVARCHAR(100),
    @Description NVARCHAR(500),
    @DueDate DATE,
    @Status NVARCHAR(50)
AS
BEGIN
    INSERT INTO Tasks (Title, Description, DueDate, Status)
    VALUES (@Title, @Description, @DueDate, @Status);
END
GO

-- Create the Get All Tasks Stored Procedure
CREATE PROCEDURE sp_GetAllTasks
AS
BEGIN
    SELECT * FROM Tasks;
END
GO

-- Create the Update Task Stored Procedure
CREATE PROCEDURE sp_UpdateTask
    @Id INT,
    @Title NVARCHAR(100),
    @Description NVARCHAR(500),
    @DueDate DATE,
    @Status NVARCHAR(50)
AS
BEGIN
    UPDATE Tasks
    SET Title = @Title, Description = @Description, DueDate = @DueDate, Status = @Status
    WHERE Id = @Id;
END
GO

-- Create the Delete Task Stored Procedure
CREATE PROCEDURE sp_DeleteTask
    @Id INT
AS
BEGIN
    DELETE FROM Tasks WHERE Id = @Id;
END
GO


Attachments:

-> Tables & Stored Procedure files in Database Folder.
-> Demo Video of Application.





















