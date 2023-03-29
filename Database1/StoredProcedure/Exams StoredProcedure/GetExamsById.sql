CREATE PROCEDURE sp_ExamsId
@ExamId BIGINT
AS
BEGIN
SELECT
	*
FROM
	Exams
WHERE
	ExamId = @ExamId
END