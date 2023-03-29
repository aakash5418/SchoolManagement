CREATE PROCEDURE sp_DeleteStudent
@StudentId BIGINT
AS
BEGIN
DELETE
FROM 
	Student 
WHERE 
	StudentId = @StudentId
END