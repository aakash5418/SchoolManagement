CREATE PROCEDURE sp_AddMarks
@MarksObtained INT,
@TotalMarksObtained INT,
@AcademicStudentId BIGINT,
@ExamId BIGINT,
@SubjectId BIGINT
AS
BEGIN
INSERT INTO Marks
	(MarksObtained,
	TotalMarksObtained,
	AcademicStudentId
	,ExamId,
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