CREATE PROCEDURE sp_UpsertAcademic
@AcademicId BIGINT,
@AcademicStartYear INT,
@AcademicEndYear INT
AS
BEGIN
IF EXISTS
(SELECT
	*
FROM 
	Academic 
WHERE
	AcademicId = @AcademicId)
UPDATE
	Academic 
SET 
	AcademicStartYear = @AcademicStartYear,
	AcademicEndYear =@AcademicEndYear,
	ModifiedDate = GETDATE()
WHERE
	AcademicId = @AcademicId
ELSE
insert into Academic 
	(AcademicStartYear,
	AcademicEndYear,
	CreatedDate)
VALUES
	(@AcademicStartYear,
	@AcademicEndYear,
	GETDATE())
END