CREATE PROCEDURE sp_GetAcademicStudentId
@AcademicStudentId BIGINT
AS
BEGIN
SELECT
	* 
FROM
	AcademicStudent
WHERE
	AcademicStudentId = @AcademicStudentId
END
