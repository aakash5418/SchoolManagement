CREATE PROCEDURE sp_DeleteAcademic
@AcademicId BIGINT
AS
BEGIN
DELETE 
FROM
	Academic 
WHERE
	AcademicId = @AcademicId
END