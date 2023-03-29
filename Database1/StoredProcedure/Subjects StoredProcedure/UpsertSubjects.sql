CREATE PROCEDURE sp_UpsertSubjects
@SubjectId BIGINT,
@SubjectName VARCHAR(20),
@SubjectCode VARCHAR(10),
@GroupId BIGINT
AS
BEGIN
IF EXISTS
(SELECT
	*
FROM
	Subjects
WHERE 
	SubjectId = @SubjectId)
UPDATE
	Subjects 
SET
	SubjectName=@SubjectName,
	SubjectCode=@SubjectCode,
	GroupId=@GroupId,
	ModifiedDate=GETDATE()
WHERE 
	SubjectId=@SubjectId
ELSE
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