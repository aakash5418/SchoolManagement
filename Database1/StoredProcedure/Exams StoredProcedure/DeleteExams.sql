CREATE PROCEDURE sp_DeleteExams
@ExamId BIGINT
AS
BEGIN
DELETE 
FROM 
	Exams 
WHERE
	ExamId = @ExamId
END