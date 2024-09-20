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
