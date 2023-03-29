CREATE PROCEDURE sp_UpsertClass
@ClassId BIGINT,
@ClassName VARCHAR(20),
@Section VARCHAR(2),
@AcademicId BIGINT
AS
BEGIN
IF EXISTS
(SELECT
	*
FROM
	Class
WHERE
	ClassId = @ClassId)
UPDATE 
	class 
SET
	ClassName = @ClassName,
	Section =@Section,
	AcademicId = @AcademicId,
	ModifiedDate = GETDATE()
WHERE 
	ClassId = @ClassId
ELSE
INSERT INTO  Class
	(ClassName,
	Section,
	AcademicId,
	CreatedDate) 
VALUES
	(@ClassName,
	@Section,
	@AcademicId,
	GETDATE())
END