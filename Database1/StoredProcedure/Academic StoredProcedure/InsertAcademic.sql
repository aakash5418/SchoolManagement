CREATE PROCEDURE sp_AddAcademic
@AcademicStartYear INT,
@AcademicEndYear INT
AS
BEGIN
INSERT INTO Academic 
	(AcademicStartYear,
	AcademicEndYear,
	CreatedDate) 
VALUES
	(@AcademicStartYear,
	@AcademicEndYear,
	GETDATE())
END