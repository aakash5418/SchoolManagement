CREATE PROCEDURE sp_DeleteClass
@ClassId BIGINT
AS
BEGIN
DELETE
FROM	
	Class
WHERE
	ClassId = @ClassId
END