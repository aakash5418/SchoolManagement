CREATE PROCEDURE sp_UpsertAcademicStudent
@AcademicStudentId BIGINT,
@StudentId BIGINT,
@AcademicId BIGINT,
@ClassId BIGINT,
@GroupId BIGINT,
@IsPassed INT
AS
BEGIN
IF EXISTS
(SELECT
	*
FROM
	AcademicStudent 
WHERE
	AcademicStudentId = @AcademicStudentId)
UPDATE
	AcademicStudent 
SET
	StudentId=@StudentId,
	AcademicId=@AcademicId,
	ClassId=@ClassId,
	GroupId=@GroupId,
	IsPassed=@IsPassed,
	ModifiedDate=GETDATE() 
WHERE
	AcademicStudentId =@AcademicStudentId
ELSE
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