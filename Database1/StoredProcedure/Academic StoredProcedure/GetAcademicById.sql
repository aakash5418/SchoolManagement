CREATE  PROCEDURE sp_GetAcademicId
@AcademicId BIGINT
AS
BEGIN
SELECT
	* 
FROM
	Academic
WHERE
	AcademicId = @AcademicId
END