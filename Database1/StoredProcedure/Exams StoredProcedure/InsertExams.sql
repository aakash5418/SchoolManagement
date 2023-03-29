CREATE PROCEDURE sp_AddExams
@ExamType VARCHAR(20),
@AcademicId BIGINT
AS
BEGIN
INSERT INTO Exams 
	(ExamType,
	AcademicId,
	CreatedDate)
VALUES
	(@ExamType,
	@AcademicId,
	GETDATE())
END