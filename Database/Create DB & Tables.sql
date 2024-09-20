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
