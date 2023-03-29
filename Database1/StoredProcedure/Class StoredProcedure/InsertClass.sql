CREATE PROCEDURE sp_AddClass
@ClassName VARCHAR(20),
@Section VARCHAR(2),
@AcademicId BIGINT
AS
BEGIN
INSERT INTO Class
	(ClassName,
	Section,
	AcademicId,
	CreatedDate)
VALUES
	(@ClassName,
	@Section,
	@AcademicId,
	GETDATE())
END