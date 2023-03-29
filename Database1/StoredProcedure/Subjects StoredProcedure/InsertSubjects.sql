CREATE PROCEDURE sp_AddSubjects
@SubjectName VARCHAR(20),
@SubjectCode VARCHAR(10),
@GroupId BIGINT
AS
BEGIN
INSERT INTO Subjects
	(SubjectName,
	SubjectCode,
	GroupId,
	CreatedDate)
VALUES
	(@SubjectName,
	@SubjectCode,
	@GroupId,
	GETDATE())
END
