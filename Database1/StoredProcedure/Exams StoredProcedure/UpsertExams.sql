CREATE PROCEDURE sp_UpsertExams
@ExamId BIGINT,
@ExamType VARCHAR(20),
@AcademicId BIGINT
AS
BEGIN
IF EXISTS
(SELECT
	* 
FROM
	Exams
WHERE
	ExamId =@ExamId)
UPDATE
	Exams
SET
	ExamType = @ExamType,
	AcademicId= @AcademicId,
	ModifiedDate=GETDATE() 
WHERE
	ExamId = @ExamId
ELSE
INSERT INTO Exams
	(ExamType,
	AcademicId,
	CreatedDate)
VALUES
	(@ExamType,
	@AcademicId,
	GETDATE())
END