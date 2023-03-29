CREATE PROCEDURE sp_GetClassId
@ClassId BIGINT
AS
BEGIN
SELECT
	*
FROM
	Class
WHERE
	ClassId = @ClassId
END