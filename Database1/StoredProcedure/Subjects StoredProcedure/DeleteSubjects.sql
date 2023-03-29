CREATE  PROCEDURE sp_DeleteSubjects
@SubjectId BIGINT 
AS
BEGIN
DELETE
FROM
Subjects
WHERE 
	SubjectId = @SubjectId
END