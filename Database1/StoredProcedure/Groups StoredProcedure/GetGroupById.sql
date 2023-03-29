CREATE PROCEDURE sp_GroupsId
@GroupId BIGINT
AS
BEGIN
SELECT
	* 
FROM
	Groups 
WHERE
	GroupId = @GroupId
END
