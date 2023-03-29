CREATE PROCEDURE sp_DeleteMarks
@MarksId BIGINT
AS
BEGIN
DELETE
FROM
	Marks
WHERE
	MarksId=@MarksId
END