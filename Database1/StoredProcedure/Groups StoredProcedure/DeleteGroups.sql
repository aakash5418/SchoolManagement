CREATE PROCEDURE sp_DeleteGroups
@GroupId BIGINT
AS
BEGIN
DELETE
FROM	
	groups 
WHERE
	GroupId = @GroupId
END
