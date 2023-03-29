CREATE PROCEDURE sp_AddGroups
@GroupName VARCHAR(20)
AS
BEGIN
INSERT INTO Groups
	(GroupName,
	CreatedDate) 
VALUES
	(@GroupName,
	GETDATE())
END