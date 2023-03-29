CREATE PROCEDURE sp_Upsertgroups
@GroupId BIGINT,
@GroupName VARCHAR(20)
AS
BEGIN 
IF EXISTS
(SELECT
	* 
FROM 
	Groups 
WHERE
	GroupId = @GroupId)
UPDATE
	Groups 
SET 
	GroupName=@GroupName,
	ModifiedDate=GETDATE()
WHERE
	GroupId = @GroupId
ELSE
INSERT INTO Groups
	(GroupName,
	CreatedDate)
VALUES
	(@GroupName,
	GETDATE())
END