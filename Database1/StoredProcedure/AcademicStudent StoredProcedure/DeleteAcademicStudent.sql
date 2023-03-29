CREATE PROCEDURE sp_DeleteAcademicStudent
@AcademicStudentId BIGINT
AS
BEGIN
DELETE
FROM
	AcademicStudent
WHERE
	AcademicStudentId = @AcademicStudentId
END