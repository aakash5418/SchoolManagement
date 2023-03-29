CREATE PROCEDURE sp_AddAcademicStudent
@StudentId BIGINT,
@AcademicId BIGINT,
@ClassId BIGINT,
@GroupId BIGINT,
@IsPassed INT
AS
BEGIN
INSERT INTO AcademicStudent
	(StudentId,
	AcademicId,
	ClassId,
	GroupId,
	IsPassed,
	CreatedDate)
VALUES
	(@StudentId,
	@AcademicId,
	@ClassId,
	@GroupId,
	@IsPassed,
	GETDATE())
END