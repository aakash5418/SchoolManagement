CREATE PROCEDURE sp_GetStudentId
@StudentId BIGINT
AS
BEGIN
SELECT
	* 
FROM 
	Student
WHERE 
	StudentId = @StudentId
END