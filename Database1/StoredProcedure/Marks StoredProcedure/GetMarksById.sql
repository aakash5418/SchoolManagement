CREATE PROCEDURE sp_GetMarksId
@MarksId BIGINT
AS
BEGIN
SELECT
	*
FROM
	Marks 
WHERE
	MarksId =@MarksId
END

