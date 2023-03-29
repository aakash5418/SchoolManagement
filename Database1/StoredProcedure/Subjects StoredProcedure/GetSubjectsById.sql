CREATE PROCEDURE sp_GetSubjectId
@SubjectId BIGINT
AS
BEGIN
SELECT
	*
FROM
	Subjects
WHERE
	SubjectId = @SubjectId
END
