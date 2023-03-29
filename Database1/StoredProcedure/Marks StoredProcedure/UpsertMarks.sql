CREATE PROCEDURE sp_UpsertMarks
@MarksId BIGINT,
@MarksObtained INT,
@TotalMarksObtained INT,
@AcademicStudentId BIGINT,
@ExamId BIGINT,
@SubjectId BIGINT
AS
BEGIN
IF EXISTS
(SELECT
	*
FROM
	Marks
WHERE
	MarksId=@MarksId)
UPDATE
	Marks
SET
	MarksObtained=@MarksObtained,
	TotalMarksObtained=@TotalMarksObtained,
	AcademicStudentId=@AcademicStudentId,
	ExamId=@ExamId,
	SubjectId=@SubjectId,
	ModifiedDate=GETDATE() 
WHERE
	MarksId=@MarksId
ELSE
INSERT INTO Marks
	(MarksObtained,
	TotalMarksObtained,
	AcademicStudentId,
	ExamId,
	SubjectId,
	CreatedDate)
VALUES
	(@MarksObtained,
	@TotalMarksObtained,
	@AcademicStudentId,
	@ExamId,
	@SubjectId,
	GETDATE())
END